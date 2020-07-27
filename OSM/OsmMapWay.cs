using System;
using System.Collections.Generic;
using OSM.Entities;

namespace OSM
{
	public class OsmMapWay
	{
		public string Id { get; set; }
		public bool Visible { get; set; }
		public int Version { get; set; }
		public string ChangeSet { get; set; }
		public DateTime TimeStamp { get; set; }
		public string User { get; set; }
		public string Uid { get; set; }
		
		public List<OsmTag> Tags { get; set; } = new List<OsmTag>();
		public List<OsmNode> Nodes { get; set; } = new List<OsmNode>();
	}
}