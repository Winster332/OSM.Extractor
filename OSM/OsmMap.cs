using System.Collections.Generic;
using OSM.Entities;

namespace OSM
{
	public class OsmMap
	{
		public OsmFile BaseOsm { get; set; }
		public List<OsmMapWay> Ways { get; set; } = new List<OsmMapWay>();
	}
}