using System.Collections.Generic;
using OSM.Parser;

namespace OSM.Entities
{
	public class OsmFile
	{
		[OsmProperty("version")]
		public string Version { get; set; }
		[OsmProperty("generator")]
		public string Generator { get; set; }
		[OsmProperty("copyright")]
		public string Copyright { get; set; }
		[OsmProperty("attribution")]
		public string Attribution { get; set; }
		[OsmProperty("license")]
		public string License { get; set; }
		
		public OsmBounds Bounds { get; set; }
		public List<OsmNode> Nodes { get; set; } = new List<OsmNode>();
		public List<OsmWay> Ways { get; set; } = new List<OsmWay>();
	}
}