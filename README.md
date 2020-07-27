# OSM.Extractor
Extract ways and nodes from *.osm file.
https://www.openstreetmap.org

## How use?

```C#
var pathFile = "map-file.osm";
			
var parser = new OsmParser();
var osmFile = await parser.ParseFromFileAsync(pathFile);
			
var builder = new OsmBuilder(osmFile);
var map = builder.Build();
```
