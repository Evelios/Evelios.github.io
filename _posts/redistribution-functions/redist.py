import math

def exponential(x, exp=1, increase=True):
    '''
    Exponential redistribution function. e^exp
    This function skews the values either up or down by a particular ammount
    according to the input parameters. The output distribution will be
    exponential shaped.
    '''
    if increase:
        nom   = 1 - math.exp(-x * exp)
        denom = 1 - math.exp(-exp)
    else:
        nom   = 1 - math.exp(-x * exp)
        denom = 1 - math.exp(-exp)

    return nom/denom

def power(x, exp=2, inc=True, skewDown=True):
    '''
    Power redistrubution function. x^exp
    This either increases or decreases the input values by a particular
    ammount. This can either skew the distribution towards one or zero as well.
    '''
    if inc:
        if skewDown:
            return math.pow(x, 1 / exp)
        else:
            return 1 - math.pow(1 - x, exp)
    else:
        if skewDown:
            return math.pow(x, exp)
        else:
            return 1 - math.pow(1 - x, 1 / exp)

def step(x, bins):
    ''' Return the values of x in descritized bins '''
    return math.floor(bins * x) / bins
