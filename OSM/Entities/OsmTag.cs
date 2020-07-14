using OSM.Parser;

namespace OSM.Entities
{
	public class OsmTag
	{
		[OsmProperty("k")]
		public string K { get; set; }
		[OsmProperty("v")]
		public string V { get; set; }
	}
}