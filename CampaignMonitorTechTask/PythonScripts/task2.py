def collect_divisors(input):
    max_val = input + 1
    divisors_list = []
    for i in range(1, max_val):
        if (input % i) == 0:
            divisors_list.append(i)
    return divisors_list


""" Test cases """
input = 60
#input = 42

div_list = collect_divisors(input)
print('Divisors of {0} => {1}'.format(input, div_list))