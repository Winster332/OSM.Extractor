using System;

namespace OSM.Parser
{
	[AttributeUsage(AttributeTargets.Property)]
	internal class OsmPropertyAttribute : Attribute
	{
		public string Name { get; set; }

		public OsmPropertyAttribute(string name)
		{
			Name = name;
		}
	}
}