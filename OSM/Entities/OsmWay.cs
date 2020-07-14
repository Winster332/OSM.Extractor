using System;
using System.Collections.Generic;
using OSM.Parser;

namespace OSM.Entities
{
	public class OsmWay
	{
		[OsmProperty("id")]
		public string Id { get; set; }
		[OsmProperty("visible")]
		public bool Visible { get; set; }
		[OsmProperty("version")]
		public int Version { get; set; }
		[OsmProperty("changeset")]
		public string ChangeSet { get; set; }
		[OsmProperty("timestamp")]
		public DateTime TimeStamp { get; set; }
		[OsmProperty("user")]
		public string User { get; set; }
		[OsmProperty("uid")]
		public string Uid { get; set; }
		
		public List<OsmNd> Nds { get; set; } = new List<OsmNd>();
		public List<OsmTag> Tags { get; set; } = new List<OsmTag>();
	}
}