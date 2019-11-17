---
category: procedural
tags: procedural
---

So I have been following [Amit Patel's tutorial on procedural
generation](http://www-cs-students.stanford.edu/~amitp/game-programming/polygon-map-generation/)
on procedural island generation. Amit's tutorial seems to be the best
described process for procedural generation I have come across so far. He
also has an incredible wealth of knowledge linked within his posts about
helpful procedural generation techniques in many different areas. For his
island generation, Amit uses a completely ontogenetic (top down) approach
to island generation, so this approach does not work for many of the
'infinite' terrain generators some people are currently trying to make.
A top down approach means that he starts with his goal in mind and works
towards his goal. His goal was to create an island that has good coasts,
rivers, and a constant slope. Therefore, his procedure for map generation
does not follow natural geological terrain evolution. This process of
generation by simulation is called teleological generation (bottom up),
where you start with processes that simulate Earth's processes, and tweak
parameters and higher level effects to come out with your end goal.

Copying Amit's process has taught me a lot about the basics and many tools
of procedural generation that I can use to create my own terrain
generation process. For my next project I want to create a map that covers
a larger area than the one Amit created. I want it to contains several
continents or large islands but not generate terrain on a global scale.
I want the map to be large but still a manageable size. I am not looking
to make the next Civilization or Spore or No Man's Sky. Given the new tool
I have learned. I think I at least have a good jumping off point to begin
this project.

There are many things which I wish to improve upon for from the old
project. For starters, the whole map is represented as a polygonal graph
in the form of a [PAN
graph](http://www.voronoi.com/wiki/index.php?title=PAN_graphs), and I want
to smooth out the moisture and elevation map to have continuous
transition. Currently it just has large steps displayed by the average
elevation at each polygon. I know this can be done using [barycentric
coordinates](https://en.wikipedia.org/wiki/Barycentric_coordinate_system)
to come up interpolated elevation within each polygon.

I also wish to implement biomes. Amit does this in his tutorial, however
in his game he does not implement a temperature system because his game
does not need it. Biome generation is based off of the [Whittaker
diagrams](http://w3.marietta.edu/~biol/biomes/biome_main.html) which show
the relationship of biomes based off of temperature and moisture. Amit
overcame this by substituted elevation for temperature and made a couple
of other modifications to fit his needs. A temperature system should not
be difficult to implement to help with creating biomes. Temperature could
also help to give context to the world, such as how close to the equator
is this map portion and could possibly help in creating a culture in that
area.

Amit's implementation of elevation on his island was very simple. It was
calculated based on the distance from ocean, scaled after the fact to
create a smooth gradient to the middle of the mountain. This works well
for his islands and the game he was designing. For his game, the elevation
of the region indicated the difficulty of monsters. I wish to take a more
teleological approach and simulate [plate
tectonics](http://pubs.usgs.gov/gip/dynamic/understanding.html) to
generate the elevations . This will help to create a better distribution
of elevations in more reasonable locations. Miguel Cepero of Voxel Farm
made a good [simulation of plate
tectonics](http://procworld.blogspot.com.au/2016/04/geometry-is-destiny.html)
using mesh triangulations and the midpoint displacement algorithm to
simulate this effect for his continent. I have a slightly different
approach in mind, but his example is a good starting point for tackling
this problem.

Another thing, More Noise! Amit only uses noise in his project for his
random point generation, island shape, and in his renderings of his map.
However I really like his approach to adding noise to his map to try to
get away from the rigid polygon structure in his map. I just have many
more places where I feel that noise can be added to create a more
interesting terrain patterns. There is a lifetime that could be explored
understanding the possibilities of using noise for procedural generation.
I hope to explain some of the possibilities for noise in terrain
generation here later.

I want to better model the way water and erosion help to create our
landscape. This could be done using
[hydrology](http://arches.liris.cnrs.fr/publications/SIG2013.html) or the
[rain drop
algorithm](http://pcg.wikidot.com/pcg-algorithm:rain-drop-algorithm) to
create that effect. Using
[watersheds](http://www.voronoi.com/wiki/index.php?title=Rivers_and_watersheds)
and [drainage basins](https://en.wikipedia.org/wiki/Drainage_basin) are
extremely important to creating a believable landscape. This helps to
carve out habitable areas and is an important part of city generation. All
of the early civilizations were created by lakes and rivers, and thus most
of our largest cities are in these locations.

A long way down the road I want to work on making the maps that look like
they were more hand crafted. For example there are a lot of wonderful hand
made maps at the [Cartographer's
Guild](http://www.cartographersguild.com/) and there are [a lot of
techniques](https://en.wikipedia.org/wiki/Terrain_cartography) like
[relief shading](http://www.reliefshading.com/) which have been used by
cartographer's to make a interesting map that can trick us into seeing the
terrain better on a flat surface. Relief shading puts a lot of emphasis on
water runoff regions and provides simple lighting which go a long way to
creating the illusion of mountains to a map.

Even further down the road I hope to put in some sort of name / culture
/ history generation for the map as well. Miguel Cepero did a simple
[example of
this](http://procworld.blogspot.com.au/2011/07/political-landscape.html)
using voronoi diagrams and a heightmap.

Cory Lee has also created a [political map
generator](https://github.com/coryleeio/political-map-generator). This
culture and and history generation can also be seen in roguelikes such as
[Dwarf Fortress](http://www.bay12games.com/dwarves/) and [Ultima Ratio
Regum](http://www.ultimaratioregum.co.uk/game/) to name the two most
influential for me.

With procedural generation, anything is possible. I look forward to
exploring these possibilities and sharing the things that I have learned.

The current results from following Amit's Island generation Tutorial:

![Island Color](/assets/procedural-island/2016-09-16/island-color.png)

Figure 1: Colored Island showing Sea, Lakes, Rivers, Beaches and Elevation
information

![Island Moisture](/assets/procedural-island/2016-09-16/island-moisture.png)

Figure 2: Moisture Map with Green being high moisture

![Island Elevation](/assets/procedural-island/2016-09-16/island-elevation.png)

Figure 3: Elevation map with white as high elevation
