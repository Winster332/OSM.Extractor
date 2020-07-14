using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using OSM.Entities;

namespace OSM.Parser
{
	public class OsmParser
	{
		private Dictionary<Type, Dictionary<string, PropertyInfo>> _metaOsmElements;
		public OsmParser()
		{
			_metaOsmElements = new Dictionary<Type, Dictionary<string, PropertyInfo>>();
			
			AddMetaOsmElement<OsmFile>();
			AddMetaOsmElement<OsmBounds>();
			AddMetaOsmElement<OsmNd>();
			AddMetaOsmElement<OsmNode>();
			AddMetaOsmElement<OsmTag>();
			AddMetaOsmElement<OsmWay>();
		}

		private void AddMetaOsmElement<T>()
		{
			var elementType = typeof(T);
			var properties = OsmParserHelper.GetOsmProperties(elementType);
			_metaOsmElements.Add(elementType, properties);
		}
		
		private void ApplyAttributes(XmlAttributeCollection attributes, object obj)
		{
			var osmProperties = _metaOsmElements[obj.GetType()];
			
			foreach (XmlAttribute rootAttribute in attributes)
			{
				var attrName = rootAttribute.Name;
				var attrValue = rootAttribute.Value;

				if (osmProperties.ContainsKey(attrName))
				{
					var property = osmProperties[attrName];
					OsmParserHelper.SetValue(obj, property, attrValue);
				}
			}
		}

		private object ParseChild(XmlElement xmlNode, OsmFile osm)
		{
			var name = xmlNode.Name;
			var attrs = xmlNode.Attributes;
			var result = default(object);

			if (name == "bounds")
			{
				var bounds = new OsmBounds();
				ApplyAttributes(attrs, bounds);
				osm.Bounds = bounds;
				
				result = bounds;
			}
			else if (name == "node")
			{
				var node = new OsmNode();
				ApplyAttributes(attrs, node);
				osm.Nodes.Add(node);;
				
				foreach (XmlElement xmlNodeChildNode in xmlNode.ChildNodes)
				{
					var childElement = ParseChild(xmlNodeChildNode, osm);

					if (childElement.GetType() == typeof(OsmTag))
					{
						node.Tags.Add((OsmTag) childElement);
					}
				}

				result = node;
			}
			else if (name == "tag")
			{
				var tag = new OsmTag();
				ApplyAttributes(attrs, tag);

				result = tag;
			}
			else if (name == "way")
			{
				var way = new OsmWay();
				ApplyAttributes(attrs, way);
				osm.Ways.Add(way);
				
				foreach (XmlElement xmlNodeChildNode in xmlNode.ChildNodes)
				{
					var childElement = ParseChild(xmlNodeChildNode, osm);

					if (childElement.GetType() == typeof(OsmTag))
					{
						way.Tags.Add((OsmTag) childElement);
					}
					else if (childElement.GetType() == typeof(OsmNd))
					{
						way.Nds.Add((OsmNd) childElement);
					}
				}

				result = way;
			}
			else if (name == "nd")
			{
				var nd = new OsmNd();
				ApplyAttributes(attrs, nd);

				result = nd;
			}

			return result;
		}
		
		public OsmFile ParseFromFile(string filePath)
		{
			var result = default(OsmFile);
			
			using (var stream = new FileInfo(filePath).OpenRead())
			{
				result = ParseFromStream(stream);
			}

			return result;
		}
		
		public async Task<OsmFile> ParseFromFileAsync(string filePath)
		{
			var result = default(OsmFile);
			
			using (var stream = new FileInfo(filePath).OpenRead())
			{
				result = await ParseFromStreamAsync(stream);
			}

			return result;
		}
		
		public async Task<OsmFile> ParseFromStreamAsync(Stream stream)
		{
			var fileSource = string.Empty;
			
			using (var reader = new StreamReader(stream))
			{
				fileSource = await reader.ReadToEndAsync();
			}

			return Parse(fileSource);
		}

		public OsmFile ParseFromStream(Stream stream)
		{
			var fileSource = string.Empty;
			
			using (var reader = new StreamReader(stream))
			{
				fileSource = reader.ReadToEnd();
			}

			return Parse(fileSource);
		}

		public OsmFile Parse(string xmlFileSource)
		{
			var osm = new OsmFile
			{
				Nodes = new List<OsmNode>(),
				Ways = new List<OsmWay>(),
				Bounds = new OsmBounds()
			};
			var doc = new XmlDocument();
			doc.LoadXml(xmlFileSource);
			var root = doc.DocumentElement;

			ApplyAttributes(root.Attributes, osm);

			foreach (XmlElement xmlNode in root)
			{
				ParseChild(xmlNode, osm);
			}

			return osm;
		}
	}
}