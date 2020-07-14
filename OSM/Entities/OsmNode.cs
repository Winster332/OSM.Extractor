using System;
using System.Collections.Generic;
using OSM.Parser;

namespace OSM.Entities
{
	public class OsmNode
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
		[OsmProperty("lat")]
		public double Lat { get; set; }
		[OsmProperty("lon")]
		public double Lon { get; set; }
		public List<OsmTag> Tags { get; set; } = new List<OsmTag>();
	}
}