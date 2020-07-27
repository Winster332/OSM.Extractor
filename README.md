# OSM.Extractor
Extract ways and nodes from *.osm file.
https://www.openstreetmap.org
Allows you to extract data from an exported file, with ways, nodes, tags, etc.

## How use?

```C#
var pathFile = "map-file.osm";
			
var parser = new OsmParser();
var osmFile = await parser.ParseFromFileAsync(pathFile);
			
var builder = new OsmBuilder(osmFile);
var map = builder.Build();
```

LICENCE
-------
[GNU General Public License v3.0](https://github.com/Winster332/OSM.Extractor/blob/master/LICENSE)
