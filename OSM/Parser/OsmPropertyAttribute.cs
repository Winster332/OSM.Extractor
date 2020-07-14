using System;

namespace OSM.Parser
{
	[AttributeUsage(AttributeTargets.Property)]
	public class OsmPropertyAttribute : Attribute
	{
		public string Name { get; set; }

		public OsmPropertyAttribute(string name)
		{
			Name = name;
		}
	}
}