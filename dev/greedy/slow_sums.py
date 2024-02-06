import math


# Add any extra import statements you may need here


# Add any helper functions you may need here


def getTotalTime(arr):
    sorted_arr = sorted(arr)

    penalties = 0
    i = len(arr) - 1
    last_penalty = 0

    while i > 0:
        if penalties == 0:
            last_penalty = sorted_arr[i] + sorted_arr[i - 1]
        else:
            last_penalty += sorted_arr[i - 1]

        penalties += last_penalty

        i -= 1

    return penalties


# These are the tests we use to determine if the solution is correct.
# You can add your own at the bottom, but they are otherwise not editable!

def printInteger(n):
    print('[', n, ']', sep='', end='')


test_case_number = 1


def check(expected, output):
    global test_case_number
    result = False
    if expected == output:
        result = True
    rightTick = '\u2713'
    wrongTick = '\u2717'
    if result:
        print(rightTick, 'Test #', test_case_number, sep='')
    else:
        print(wrongTick, 'Test #', test_case_number, ': Expected ', sep='', end='')
        printInteger(expected)
        print(' Your output: ', end='')
        printInteger(output)
        print()
    test_case_number += 1


if __name__ == "__main__":
    arr_1 = [4, 2, 1, 3]
    expected_1 = 26
    output_1 = getTotalTime(arr_1)
    check(expected_1, output_1)

    arr_2 = [2, 3, 9, 8, 4]
    expected_2 = 88
    output_2 = getTotalTime(arr_2)
    check(expected_2, output_2)

    arr_3 = [1, 2, 3, 4, 5, 6, 7, 8, 9]
    expected_3 = 276
    output_3 = getTotalTime(arr_3)
    check(expected_3, output_3)
