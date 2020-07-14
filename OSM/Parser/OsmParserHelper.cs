using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OSM.Parser
{
	internal class OsmParserHelper
	{
		public static Dictionary<string, PropertyInfo> GetOsmProperties(Type type)
		{
			var fields = type.GetProperties()
				.Select(c => new
				{
					Property = c,
					Attribute = (c.GetCustomAttributes().FirstOrDefault() as OsmPropertyAttribute)?.Name
				})
				.Where(c => c.Attribute != null)
				.ToDictionary(c => c.Attribute, f => f.Property);
			return fields;
		}

		public static void SetValue(object instance, PropertyInfo property, string value)
		{
			if (property.PropertyType == typeof(double))
			{
				property.SetValue(instance, double.Parse(value));
			}
			else if (property.PropertyType == typeof(string))
			{
				property.SetValue(instance, value);
			}
			else if (property.PropertyType == typeof(int))
			{
				property.SetValue(instance, int.Parse(value));
			}
			else if (property.PropertyType == typeof(bool))
			{
				property.SetValue(instance, bool.Parse(value));
			}
			else if (property.PropertyType == typeof(DateTime))
			{
				var dt = DateTime.Parse(value);
				property.SetValue(instance, dt);
			}
		}
	}
}