def VerifyString(input):
    if not input:
        print(True)
    else:
        print(False)


""" Test cases """
#input = None # True (None is the equivalent of null in Python)
input = "a" # False
#input = "" # True
#input = "null" # False
#input = "None" # False

VerifyString(input)