---
category: procedural
tags: procedural
---

This post is going to be a short one, but it is also exciting. I have
finished the bulk of the initial map generating and have gotten my map to
render in 3D! Thank you Three js and WebGL. I can use the optimized
triangle rendering of WebGL to also create smoother terrain maps through
vertex shading. So I now have a rendered 3D model of my map. This let me
see many things that I could not see in the 2D view. It makes terrain
veriations immediately visible which is great for mountains, but it is not
so great for lakes. Seeing this allowed me to fix that problem.

![3D Rendered map](/assets/procedural-island/2016-07-03/3d-render.png)

3D Rendered Map

I also have the start of town generation finished. To do this I considered
what favorable living conditions would be for starting civilizations.
Firstly, you want to live near water. This is the obvious one. Secondly
you want to be on a relatively even terrain so you have space for farms.
This would mean low elevation. Thirdly I thought that it would be more
beneficial to be at a moderate temperature. Now I currently give all three
parameters equal weight when considering where to place the towns. So
I pick random locations for towns (many of them land in the ocean so this
number needs to be larger than you think) and if they are land tiles, roll
against the living conditions to see if a town springs up. Giving this
randomness helps to clump cities in more favorable conditions but this
still allows towns to pop to the top of mountains trying to live off of
tree bark and rocks. This makes for a more interesting map and for me
I immediately try to put a story to those towns trying to live in the
harsher conditions. That's free back story right there.

So we start with the elevation, moisture and temperature maps and average
them together as mentioned above to give up how favorable the living
conditions are.

![Moisture](/assets/procedural-island/2016-07-03/moisture.png)

Moisture

![Elevation](/assets/procedural-island/2016-07-03/elevation.png)

Elevation

![Temperature](/assets/procedural-island/2016-07-03/temperature.png)

Temperature

![Living Conditions](/assets/procedural-island/2016-07-03/living-conditions.png)

Living Conditions

Then going a step further, we do our roll for generating towns (this was
of 200 points to generate 11 towns just to give an idea of how many towns
didn't make it, especially because of the many that drowned).

![Living Conditions](/assets/procedural-island/2016-07-03/towns.png)

Living Conditions with Towns

This is an exciting first step, because now I cam move on to create
a history for the towns through the process of expanding borders, which
could be a history of conquests and battles, ect. This project is giving
much better and quicker results than I anticipated.
