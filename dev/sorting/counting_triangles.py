import math


# Add any extra import statements you may need here


# Add any helper functions you may need here
def quicksort(arr):
    if len(arr) <= 1:
        return arr

    # using last element as pivot
    pivot = sorted(arr[len(arr) - 1])

    left, middle, right = [], [], []
    for i in range(len(arr)):
        shortlist = sorted(arr[i])
        if shortlist < pivot:
            left.append(shortlist)
        elif shortlist > pivot:
            right.append(shortlist)
        else:
            middle.append(shortlist)

    return quicksort(left) + middle + quicksort(right)


def countDistinctTriangles(arr):
    # Write your code here
    if len(arr) < 2:
        return len(arr)

    sorted_arr = quicksort(arr)
    result = 1
    i = 0
    while i < len(sorted_arr) - 1:
        if sorted_arr[i] != sorted_arr[i + 1]:
            result += 1
        i += 1

    return result


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
    arr_1 = [(7, 6, 5), (5, 7, 6), (8, 2, 9), (2, 3, 4), (2, 4, 3)]
    expected_1 = 3
    output_1 = countDistinctTriangles(arr_1)
    check(expected_1, output_1)

    arr_2 = [(3, 4, 5), (8, 8, 9), (7, 7, 7)]
    expected_2 = 3
    output_2 = countDistinctTriangles(arr_2)
    check(expected_2, output_2)

    # Add your own test cases here
    arr_3 = [(3, 4, 5), (4, 5, 3)]
    expected_3 = 1
    output_3 = countDistinctTriangles(arr_3)
    check(expected_3, output_3)