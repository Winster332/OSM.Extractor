using OSM.Parser;

namespace OSM.Entities
{
	public class OsmNd
	{
		[OsmProperty("ref")]
		public string Ref { get; set; }
	}
}