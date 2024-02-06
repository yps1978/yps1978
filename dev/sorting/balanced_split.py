import math


# Add any extra import statements you may need here


# Add any helper functions you may need here


def balancedSplitExists(arr):
    if arr == None or len(arr) < 2:
        return False

    sorted_arr = sorted(arr)

    left_ix, right_ix = 0, len(arr) - 1
    left_sum, right_sum = 0, sorted_arr[len(arr) - 1]

    while left_ix + 1 < right_ix:

        while left_sum + sorted_arr[left_ix] <= right_sum and left_ix < right_ix:
            left_sum += sorted_arr[left_ix]
            left_ix += 1

        if left_ix == right_ix:
            left_ix -= 1

        if left_ix + 1 < right_ix:
            right_ix -= 1
            right_sum += sorted_arr[right_ix]

    if left_ix + 1 == right_ix and left_sum == right_sum and sorted_arr[left_ix] != sorted_arr[right_ix]:
        return True

    return False


# These are the tests we use to determine if the solution is correct.
# You can add your own at the bottom, but they are otherwise not editable!

def printString(string):
    print('[\"', string, '\"]', sep='', end='')


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
        printString(expected)
        print(' Your output: ', end='')
        printString(output)
        print()
    test_case_number += 1


if __name__ == "__main__":
    arr_1 = [2, 1, 2, 5]
    expected_1 = True
    output_1 = balancedSplitExists(arr_1)
    check(expected_1, output_1)

    arr_2 = [3, 6, 3, 4, 4]
    expected_2 = False
    output_2 = balancedSplitExists(arr_2)
    check(expected_2, output_2)

    # Add your own test cases here
    arr_3 = [8, 8, 4, 4, 4, 3, 1]
    expected_3 = True
    output_3 = balancedSplitExists(arr_3)
    check(expected_3, output_3)