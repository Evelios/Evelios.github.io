---
title: "Mantaining Scaling Amidst Noise"
category: generative
tags: generative noise
---

**Outline**
* Problem Statement
  + Scaling size
  + Changing aspect ratio
  + Continious noise functions
* Maintaining scaling
* Handling aspect ratio
* Adapting for continious noise functions

# Maintaining Scaling Amidst Noise

Generative art often implements a controlled use of randomness and noise as one
of the central tenets of the work. This contolled use of chaos is what gives the
art the near infinite variety of output as well as each of the individual quirks
within a single generated piece. This level of control is a skill that needs to
be developed and honed over time. Here I would like to help to guide you along
the journey to help to refine this noise in your own work. I'm not here to
provide the context of how to use randomness in your art to evoke particular
feelings. There are other articles for that. This article is going to focus on
one of the basics of introducing randomness and noise into your work at all.
What happens when I change the page, world, or screen, dimensions on the work
I'm developing? Will my work scale the way I'm expecting? In my context, I'm
trying to generate works of art, so my expectation is that when I print my work
on a larger canvas, the work is the same as when printed on a smaller context.
This isn't true for all contexts though. Say for example you are working on a
game world, and as you make a larger world, you are looking for more game area
to play on. This is a reasonable case, and some of what I'm saying may also
apply if you want to program with some scale independents and unit agnostic
(feet, meters, or some abstract game unit). I will cover many of the use cases
of trying to control the scalability of noise and randomness so that you can
implement these practices when you go to create your generative systems.
