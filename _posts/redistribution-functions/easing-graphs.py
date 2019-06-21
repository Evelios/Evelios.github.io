#!/usr/bin/env python3
import matplotlib.pyplot as plt
import numpy as np
from easing_functions import *
from redist import *

background = '#f9f6f2'
line_color = '#8d75a0'

def main():
    # Power Law
    #  fn = lambda x: power(x, skewDown=False)
    #  plotFunction('Power Law Skew Up Increase', fn)

    #  fn = lambda x: power(x, skewDown=True)
    #  plotFunction('Power Law Skew Down Increase', fn)

    #  fn = lambda x: power(x, skewDown=False, inc=False)
    #  plotFunction('Power Law Skew Up Decrease', fn)

    #  fn = lambda x: power(x, skewDown=True, inc=False)
    #  plotFunction('Power Law Skew Down Decrease', fn)

    #  fns = [ lambda x, e=e: power(x, exp=e, skewDown=False)
            #  for e in range(1, 12, 2) ]
    #  plotFunction('Power Law Skew Up Increase Ranges', *fns)

    # Exponential
    #  fn = lambda x: exponential(x, increase=True)
    #  plotFunction('Exponential Increase', fn)

    #  fn = lambda x: exponential(x, increase=False)
    #  plotFunction('Exponential Decrease', fn)

    #  fns = [ lambda x, e=e: exponential(x, exp=e) for e in range(1, 12, 2) ]
    #  plotFunction('Exponential Increase Ranges', *fns)

    # asdf

    # Step
    steps = 10
    fn = lambda x: step(x, bins=steps)
    plotFunction('%d Steps' % steps, fn)

    plt.show()

def plotFunction(name, *functions):
    # Plot Configuration
    width_in  = 4
    height_in = 3
    fig       = plt.figure(figsize = (width_in, height_in))
    ax        = plt.gca()
    ax.set_facecolor(background)
    fig.set_facecolor(background)
    plt.title(name)

    # Plot the input functions
    for fn in functions:
        npoints = 1000
        x = np.arange(0, 1, 1.0/npoints)
        y = list(map(fn, x))

        plt.plot(x, y, color=line_color)

    # Write out the plot to a file
    file_name = name.lower().replace(' ', '-') + '.png'
    plt.savefig('img/' + file_name)

if __name__ == "__main__":
    main()




