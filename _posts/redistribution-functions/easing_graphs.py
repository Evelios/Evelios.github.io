#!/usr/bin/env python3
'''
Plotting easing functions for a blog post
'''
import matplotlib.pyplot as plt
import numpy as np
from redist import exponential, power, step

BACKGROUND = '#f9f6f2'
LINE_COLOR = '#8d75a0'

def main():
    ''' Run the main module '''
    # Power Law
    fn = lambda x: power(x, skew_down=False)
    plot_function('Power Law Skew Up Increase', fn)

    fn = lambda x: power(x, skew_down=True)
    plot_function('Power Law Skew Down Increase', fn)

    fn = lambda x: power(x, skew_down=False, inc=False)
    plot_function('Power Law Skew Up Decrease', fn)

    fn = lambda x: power(x, skew_down=True, inc=False)
    plot_function('Power Law Skew Down Decrease', fn)

    fns = [lambda x, e=e: power(x, exp=e, skew_down=False)
           for e in range(1, 12, 2)]
    plot_function('Power Law Skew Up Increase Ranges', *fns)

    # Exponential
    fn = lambda x: exponential(x, increase=True)
    plot_function('Exponential Increase', fn)

    fn = lambda x: exponential(x, increase=False)
    plot_function('Exponential Decrease', fn)

    fns = [lambda x, e=e: exponential(x, exp=e) for e in range(1, 12, 2)]
    plot_function('Exponential Increase Ranges', *fns)

    # Step
    steps = 10
    fn = lambda x: step(x, bins=steps)
    plot_function('%d Steps' % steps, fn)

    plt.show()

def plot_function(name, *functions):
    ''' Plot a list of functions '''
    # Plot Configuration
    width_in = 4
    height_in = 3
    fig = plt.figure(figsize=(width_in, height_in))
    axis = plt.gca()
    axis.set_facecolor(BACKGROUND)
    fig.set_facecolor(BACKGROUND)
    plt.title(name)

    # Plot the input functions
    for fn in functions:
        npoints = 1000
        x = np.arange(0, 1, 1.0/npoints)
        y = list(map(fn, x))

        plt.plot(x, y, color=LINE_COLOR)

    # Write out the plot to a file
    file_name = name.lower().replace(' ', '-') + '.png'
    plt.savefig('img/' + file_name)

if __name__ == "__main__":
    main()
