import math

def area_of_triangle(a, b, c):
    result = 0
    if ((a>0) and (b>0) and (c>0)):
        if (((a+b) > c) and ((b+c) > a) and ((a+c) > b)):
            half_perimeter = (a + b + c)/2
            temp_val = half_perimeter * (half_perimeter - a) * (half_perimeter - b) * (half_perimeter - c)
            result = math.sqrt(temp_val)
        else:
            print('Err: Inputs that cannot form a triangle')
    else:
        print('Err: Inputs are negative values')
    return result


""" Test cases """
#(a,b,c) = (3,4,5)
#a = b = c = 5
#(a,b,c) = (-3,5,4)
(a,b,c) = (3,4,5)

result = area_of_triangle(a,b,c)
if result != 0:
    print('Area of traingle with {0}, {1} and {2} is {3}'.format(a,b,c,result))
else:
    print('Invalid Traingle Exception!!')