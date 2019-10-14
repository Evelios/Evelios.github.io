---
title: "Scaling Noise And Randomness Functions"
category: generative
tags: generative procedural noise randomness
----

# Intro

A lot of my generative work is based off noise and randomness. 

There a couple of ways to inject some randomness into an algorithm.

You can use purely random numbers. For example you can chose a random number of
elements like a random number of sides for some polygon, a random number of
lines to be drawn.

You can also have randomness using a variation in placement. This is equivilent
to having some random number an an area. For example if I want to draw a line
somewhere from the left side of the page to the right side of the page.

You need a certain amount of control over this randomness for a variety of
reasons. It is easier to fine tune algorithms during development when you can
see the direct actions of each of the changes in the code without having added
variations in the output of the algorithm every time you have a test run.

This might seem straight forward at first but there a couple things that make
each of these actions more dificult. For example, does this work for scaling
our generative work up to different sizes? Does this generative work still
generate similarly for different aspect ratios?

# Seeded random numbers

How to we control this process of generating randomness?

If we uses a seeded rng, then we get repetitive results.

```py
set_seed(1234)
rng(1, 10)
# 5
rng(1, 10)
# 3
rng(1, 10)
# 7

set_seed(1234)
rng(1, 10)
# 5
rng(1, 10)
# 3
rng(1, 10)
# 7

```

## Paper sizes

Using the A and B series of paper to ignore aspect ratio changes.

Okay, this is great. How do we relate this back to using output pictures?

We need to use relative keying for heights and widths.

## Aspect ratios

How does this then affect aspect ratios?

# Seeded Noise Functions

Seeded noise functions are now an issue because they are relative to the input
canvas sizes as well.

## Paper sizes

## Aspect ratios

Aspect ratios can then change how this image is preceived as well.


[Generative Art Randomness]:(http://www.damtp.cam.ac.uk/user/cbs31/Publications_files/bridges2010.pdf)
