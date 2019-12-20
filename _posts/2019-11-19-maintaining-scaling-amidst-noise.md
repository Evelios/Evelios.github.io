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

**Possibly insert a reference image here**

For me, this issue stems from trying to change my design window. I'm
looking to have my output work generated at multiple scales and
potentially different paper shapes. I want as much of the origional piece
as possible to stay the same. As I have stated, the only real reason this
is an issue is bacause of the use of this controlled noise. Since I base
my work off of noise, I need to be able to also control it as it changes
to larger or smaller prints. This problem comes in two forms, increasing
or decreasing the size of the paper that I'm printing to, and changing the
aspect ration. The problem of the aspect ratio is a troublesome one,
especially for someone like me who gets to live with strange conventions
of paper sizes. These issues are also amplified that there are two main
types of noise that I deal with. First there is the random discrete noise,
aka pick a number from 1 to 100 a certain number of times. That one
generally straight forward to control. The main problems come with the
second type of noise, [continuous
noise](https://en.wikipedia.org/wiki/Perlin_noise). This type of noise is
fairly particular in how you deal with it, so I'll have to cover the
intercies of that type of noise as well. At the end of this we will be
sure that what we are tying to produce will be able to be shipped
physically or digitally in whichever form we desire.

## Scaling Size

So let's ease into this whole thing. The easiest section to correct is
basic scaling. First we need to cover a couple of basics about randomness
and noise though. Most importantly, there is no such thing of true
randomness within many frameworks like programming. There are ways of
making them seem random by injecting external noise sources or making
cryptographically secure random numbers but luckily we don't need to wory
about those. We are looking at just good old procedurally random number
generators (PRNGs). This means that we are able to maintain our randomness
between program executions by setting the *seed* of the random number
generator. Every time you run the program with a set seed you should get
the same results, and if you want to vary them you are able to. As an
artist, this gives me the ability to curate a selection of pieces that
turned out the best from a particular algorithm.

In some languages like python this is as easy as

```cpp
random.seed(1)
```

Now that we have repeatability between program executions lets try to get
repeatability between different outptut scales. The most important thing
here is that we don't use any absolute [magic
numbers](https://medium.com/@jaredstromberg/magic-numbers-developments-bane-ce1c4f057ab9).
Magic numbers in generative art and procedural content in genneral are
fairly unavoidable since it is all about tweaking something within
a particular context. The problem arises when they are left on their own.
Instead of saying "give me a flower that is 15x15 pixels" say "give me
a flower that is 0.1 x 0.1 the height of the page". This lets the program
be a little more robust to this scaling problem. Within the context of the
random number generators we can do the same thing. When I'm using random
numbers I have them generate a number within some range. Just make sure
that this range is referenced within some relative context instead of
being an absolute context.
