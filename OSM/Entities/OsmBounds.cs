using OSM.Parser;

namespace OSM.Entities
{
	public class OsmBounds
	{
		[OsmProperty("minlat")]
		public double MinLat { get; set; }
		[OsmProperty("minlon")]
		public double MinLon { get; set; }
		[OsmProperty("maxlat")]
		public double MaxLat { get; set; }
		[OsmProperty("maxlon")]
		public double MaxLon { get; set; }
	}
}