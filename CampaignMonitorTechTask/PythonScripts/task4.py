def find_duplicates(input):
    dup_list = []
    counter = 1
    for i in input:
        num_rep = input.count(i)
        if (num_rep >= counter):
            counter = num_rep
            dup_list.append(i)
    return set(dup_list)

""" Test cases """
input = [5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4]
#input = [1, 2, 3, 4, 5, 1, 6, 7]
#input = [1, 2, 3, 4, 5, 6, 7]

most_rep = find_duplicates(input)
print('Most Occurring Values are: {0}'.format(most_rep))