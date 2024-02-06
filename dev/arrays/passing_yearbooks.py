import math


def findSignatureCounts(arr):
    signatures = [1 for i in range(len(arr))]

    for i in range(len(arr)):
        signatures[i] = 1
        j = i
        while arr[j] - 1 != i:
            signatures[i] += 1
            j = arr[j] - 1

    return signatures


# These are the tests we use to determine if the solution is correct.
# You can add your own at the bottom, but they are otherwise not editable!

def printInteger(n):
    print('[', n, ']', '', '')


def printIntegerList(array):
    size = len(array)
    print('[', '')
    for i in range(size):
        if i != 0:
            print(', ', '')
        print(array[i], '')
    print(']', '')


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
        print(rightTick, 'Test #', test_case_number, '')
    else:
        print(wrongTick, 'Test #', test_case_number, ': Expected ', '', '')
        printIntegerList(expected)
        print(' Your output: ', '')
        printIntegerList(output)
        print()
    test_case_number += 1


if __name__ == "__main__":
    arr_1 = [2, 1]
    expected_1 = [2, 2]
    output_1 = findSignatureCounts(arr_1)
    check(expected_1, output_1)

    arr_2 = [1, 2]
    expected_2 = [1, 1]
    output_2 = findSignatureCounts(arr_2)
    check(expected_2, output_2)

    arr_3 = [3, 2, 4, 1]
    expected_3 = [3, 1, 3, 3]
    output_3 = findSignatureCounts(arr_3)
    check(expected_3, output_3)

    arr_4 = [4, 3, 2, 5, 1]
    expected_4 = [3, 2, 2, 3, 3]
    output_4 = findSignatureCounts(arr_4)
    check(expected_4, output_4)

# Add your own test cases here
