import math
# Add any extra import statements you may need here
import random

import numpy


# Add any helper functions you may need here
def addSorted(arr, elem):
    left, right = 0, len(arr) - 1
    while left <= right:
        mid = left + ((right - left) // 2)
        if not left < mid <= right:
            if arr[left] < elem < arr[right]:
                arr.insert(left + 1, elem)
            elif arr[right] < elem:
                arr.insert(right + 1, elem)
            else:
                arr.insert(mid, elem)
            return

        if arr[mid] <= elem:
            left = mid + 1
        else:
            right = mid

    # if got here, then just append element
    arr.append(elem)


def findMedian(arr):
    output = [0 for i in range(len(arr))]
    buffer = []

    for i in range(len(arr)):
        addSorted(buffer, arr[i])

        if (i + 1) % 2 == 1:
            output[i] = buffer[i // 2]
        else:
            ix = i // 2
            output[i] = (buffer[ix] + buffer[ix + 1]) // 2

    return output


# These are the tests we use to determine if the solution is correct.
# You can add your own at the bottom, but they are otherwise not editable!

def printInteger(n):
    print('[', n, ']', sep='', end='')


def printIntegerList(array):
    size = len(array)
    print('[', end='')
    for i in range(size):
        if i != 0:
            print(', ', end='')
        print(array[i], end='')
    print(']', end='')


test_case_number = 1


def check(expected, output):
    global test_case_number
    expected_size = len(expected)
    output_size = len(output)
    result = True
    if expected_size != output_size:
        result = False
    for i in range(min(expected_size, output_size)):
        result &= (output[i] == expected[i])
    rightTick = '\u2713'
    wrongTick = '\u2717'
    if result:
        print(rightTick, 'Test #', test_case_number, sep='')
    else:
        print(wrongTick, 'Test #', test_case_number, ': Expected ', sep='', end='')
        printIntegerList(expected)
        print(' Your output: ', end='')
        printIntegerList(output)
        print()
    test_case_number += 1


if __name__ == "__main__":
    arr_1 = [5, 15, 1, 3]
    expected_1 = [5, 10, 5, 4]
    output_1 = findMedian(arr_1)
    check(expected_1, output_1)

    arr_2 = [2, 4, 7, 1, 5, 3]
    expected_2 = [2, 3, 4, 3, 4, 3]
    output_2 = findMedian(arr_2)
    check(expected_2, output_2)

    a = []
    for i in range(100):
        x = random.randint(1, 10000000)
        addSorted(a, x)
    check(sorted(a), a)

# Add your own test cases here
