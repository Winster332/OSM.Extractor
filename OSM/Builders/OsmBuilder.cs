using System.Linq;
using OSM.Entities;

namespace OSM.Builders
{
	public class OsmBuilder
	{
		public OsmFile Osm { get; }
		
		public OsmBuilder(OsmFile osm)
		{
			Osm = osm;
		}

		public OsmMap Build()
		{
			// var nodes = Osm.Nodes
			// 	.GroupBy(c => c.ChangeSet)
			// 	.Select(c => new OsmVersionedEntity<OsmNode>
			// 	{
			// 		ChangeSet = c.Key,
			// 		History = c.OrderBy(n => n.Version).ToList()
			// 	}.Compute())
			// 	.ToList();
			var ways = Osm.Ways;
			var map = new OsmMap
			{
				BaseOsm = Osm,
				Ways = Osm.Ways.Select(c => new OsmMapWay
				{
					Id = c.Id,
					Visible = c.Visible,
					Version = c.Version,
					ChangeSet = c.ChangeSet,
					TimeStamp = c.TimeStamp,
					User = c.User,
					Uid = c.Uid,
					
					Tags = c.Tags,
					Nodes = c.Nds
						.Select(nd => Osm.Nodes.FirstOrDefault(n => n.Id == nd.Ref))
						.OrderBy(f => f.Version)
						.ToList()
				}).OrderBy(c => c.Version).ToList()
			};

			return map;
		}
	}
}