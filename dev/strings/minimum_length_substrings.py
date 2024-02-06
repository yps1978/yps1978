import math


# Add any extra import statements you may need here


# Add any helper functions you may need here
def substr_in_string(sub_str, str_val):
    lookup_str = str_val
    for i in range(len(sub_str)):
        index = lookup_str.find(sub_str[i])
        if index < 0:
            return False
        else:
            lookup_str = lookup_str[:index] + lookup_str[index+1:]

    return True


def min_length_substring(s, t):
    str_arr = list(t)

    left = 0
    right = len(s) - 1

    min_found = -1

    while left < right:
        if s[left] not in str_arr:
            left += 1
        elif s[right] not in str_arr:
            right -= 1
        else:
            if substr_in_string(t, s[left:right+1]):
                min_found = right - left + 1
            left += 1
            right -= 1

    return min_found


# These are the tests we use to determine if the solution is correct.
# You can add your own at the bottom, but they are otherwise not editable!

def printInteger(n):
    print('[', n, ']', '', '')


test_case_number = 1


def check(expected, output):
    global test_case_number
    result = False
    if expected == output:
        result = True
    rightTick = '\u2713'
    wrongTick = '\u2717'
    if result:
        print(rightTick, 'Test #', test_case_number, '')
    else:
        print(wrongTick, 'Test #', test_case_number, ': Expected ', '', '')
        printInteger(expected)
        print(' Your output: ', '')
        printInteger(output)
        print()
    test_case_number += 1


if __name__ == "__main__":
    s1 = "dcbefebce"
    t1 = "fd"
    expected_1 = 5
    output_1 = min_length_substring(s1, t1)
    check(expected_1, output_1)

    s2 = "bfbeadbcbcbfeaaeefcddcccbbbfaaafdbebedddf"
    t2 = "cbccfafebccdccebdd"
    expected_2 = -1
    output_2 = min_length_substring(s2, t2)
    check(expected_2, output_2)

    # Add your own test cases here
