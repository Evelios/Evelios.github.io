---
category: procedural
tags: procedural
---

I have made progress on my project. I used the same basic scaffolding that
I had from my last post to get my project started. The first thing
I tackled was the plate tectonics. My map shape is made by a simple
thresholded perlin noise. The map shape is bland, but that is a problem
for a later date. I am interested on how to place the large scale
geographic features, such as mountains, basins, and to some extent, lakes.
The biggest feature I was trying to come up with was the placement of the
mountains. On earth mountains ranges are generally placed near the coast,
and sometimes are more inland. This is due to plate tectonics, and
I wanted to simulate this process to get the same effect. To help explain
how I did this, first I am going to go over the basic concepts of plate
tectonics that I used to get there.

![Generic Map](/assets/procedural-island/2016-06-20/map.png)

First off there are two types of plates. There are oceanic plates and
continental plates. The oceanic plates are more dense that the continental
plates and sink bellow the continental plates. All the plates on earth are
moving at some velocity with relation to each other, causing them to move
to and away from other plates. This creates three different types of
boundaries, convergent  (colliding), divergent (spreading apart), and
transform (sliding plates) boundaries.

![Tectonic Plate Boundaries](/assets/procedural-island/2016-06-20/tectonic-plate-boundaries.png)

Divergent boundaries happen in the ocean (except for through Iceland) and
are responsible for the oceanic ridges. Transform boundaries usually
accompany divergent boundaries and often result in fractures cretingmany
smaller divergent boundaries in a zig-zag pattern. Convergent boundaries
are the most interesting and come in three flavors. Ocean-ocean
boundaries, ocean-continental, and continental-continental boundaries.
Each of these boundaries creates a buckling in the crust and is the main
component of orogeny, which is the process of creating mountain regions.
Most of the convergent boundaries are ocean-continental which is why most
mountains are on the coast. The ocean-ocean boundaries create  pockets of
volcanic activity resulting in island chains. Then there are
continental-continental boundaries which is responsible for creating the
larges mountain ranges, such as the Himalayas because neither continental
plate wants to sink bellow the other. I am taking a naive approach to
plate tectonics in this generator and many of the topics are greatly
simplified and fudged. If you are interested there are links on how it
actually works [here](http://pubs.usgs.gov/gip/dynamic/understanding.html)
and on [wikipedia](https://en.wikipedia.org/wiki/Plate_tectonics]).

![Global Plate Boundaries](/assets/procedural-island/2016-06-20/plates-tect2.png)
![Pacific Plate Boundaries](/assets/procedural-island/2016-06-20/tectonic-plate-boundaries-detailed.png)

So first, I started with the basic map generated with the noise function
and then added the plates to the map. The plates were created with
a relaxed voronoi diagram. The each plate is checked if it is an oceanic
or continental plate depending on what kind of tile makes up the majority
of the plate. The plate is then given a direction. From looking at maps of
the movements of the plates, I saw that plates tend to move away from
oceanic plates and try to move towards continental plates. This helps to
orient oceanic plates to create convergent boundaries near the continents
borders. Then you just need to calculate the boundary type based on the
direction of the neighboring plates. This is shown bellow. The plate types
are slightly colored green and blue respectively. The border types are
calculated on the ratio from convergent to divergent. So the red lines are
convergent boundaries and the divergent boundaries are the blue lines.
Transform boundaries are green, and any boundary that is somewhat green is
also partly a transform boundary.

![Plate Movement Direction](/assets/procedural-island/2016-06-20/plate-boundaries.png)

Plate Boundaries - Convergent: Red, Divergent: Blue, Transform: Green

Excellent, now that we have the plate boundaries we can figure out how to
use them. The location of these plate boundaries is responsible for where
the [geologic provences](https://en.wikipedia.org/wiki/Geologic_province)
are. There are several types of geological provence. The craton (which is
a combination of the shield and platform provence) is a stable protions of
the continent. The orogen is the location where orogenensis, or mountain
building happens. Basins are flattened and depressed areas which are
formed by erosion. Then there are the two oceanic provence, the oceanic
crust and the extended crust (continental shelf).

I currently only use the convergent boundaries for calculating provence
and I have not yet implemented the continental shelf, because I did not
think it was important yet. All tiles that are ocean tiles are assigned to
be oceanic crust and all land tiles are part of the craton unless
otherwise specified. I wanted the mountains to be at the fault lines so
I just said that a tile was a part of the orogen if it was a certain
distance from a convergent fault. If you look at a map of the different
provence like this one, you can see that basins are generally inland and
on the opposite side of the orogens. So that's what I did. A tile was
a basin if it was a certain distance (slightly larger than the orogens)
away from a convergent boundary and is not a coastal tile.

![Plate Movement Direction](/assets/procedural-island/2016-06-20/world-geologic-provences.jpg)
![Map Boundaires and provence](/assets/procedural-island/2016-06-20/boundaries-and-provences.png)

Blue: Ocean Crust, Pink: Craton, Green: Orogen, Merky Green-Blue: Basin

And when we take away the plate borders we are left with the image at the
bottom. I was happy with how it turned out so far. I think there is still
some number tweaking that needs to be done. but the mountains are making
long chains at the borders, and basins are where they should be. The next
step is to add elevations to the land.

![Geological provence](/assets/procedural-island/2016-06-20/geo-provences.png)
