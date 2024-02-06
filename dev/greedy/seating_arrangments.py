import math


# Add any extra import statements you may need here


# Add any helper functions you may need here


def minOverallAwkwardness(arr):
    sorted_arr = sorted(arr)

    min_awk = 0
    last_left = last_right = sorted_arr[0]

    for i in range(1, len(arr)):
        if i % 2 == 0:
            right_diff = abs(sorted_arr[i] - last_right)
            min_awk = max(right_diff, min_awk)
            last_right = sorted_arr[i]
        else:
            left_diff = abs(sorted_arr[i] - last_left)
            min_awk = max(left_diff, min_awk)
            last_left = sorted_arr[i]

    return min_awk


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
    arr_1 = [5, 10, 6, 8]
    expected_1 = 4
    output_1 = minOverallAwkwardness(arr_1)
    check(expected_1, output_1)

    arr_2 = [1, 2, 5, 3, 7]
    expected_2 = 4
    output_2 = minOverallAwkwardness(arr_2)
    check(expected_2, output_2)

    # Add your own test cases here
