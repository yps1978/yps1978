import math


# Add any extra import statements you may need here


# Add any helper functions you may need here
def findMinElem(arr, start, end):
    minimum = (-1, 1000000)

    for i in range(start, end + 1):
        if arr[i] < minimum[1]:
            minimum = (i, arr[i])

    return minimum


def findMinArray(arr, k):
    sorted_arr = sorted(arr)

    start_ix = 0
    while start_ix < len(arr) and arr[start_ix] == sorted_arr[start_ix]:
        start_ix += 1

    if start_ix >= len(arr) - 1:
        return arr

    swap_count = 0
    i = start_ix
    while swap_count <= k and i < start_ix + k:
        # find min and it's position in the array
        min_elem = findMinElem(arr, i, i + (k - swap_count))
        p = min_elem[0]  # position of minimum

        if p == i:
            i += 1
        else:
            # swap
            arr[p] = arr[p - 1]
            arr[p - 1] = min_elem[1]

            swap_count += 1

    return arr


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
    n_1 = 3
    arr_1 = [5, 3, 1]
    k_1 = 2
    expected_1 = [1, 5, 3]
    output_1 = findMinArray(arr_1, k_1)
    check(expected_1, output_1)

    n_2 = 5
    arr_2 = [8, 9, 11, 2, 1]
    k_2 = 3
    expected_2 = [2, 8, 9, 11, 1]
    output_2 = findMinArray(arr_2, k_2)
    check(expected_2, output_2)

    n_3 = 6
    arr_3 = [2, 7, 8, 1, 5, 3]
    k_3 = 2
    expected_3 = [2, 1, 7, 8, 5, 3]
    output_3 = findMinArray(arr_3, k_3)
    check(expected_3, output_3)

    n_4 = 6
    arr_4 = [2, 7, 8, 1, 5, 3]
    k_4 = 3
    expected_4 = [1, 2, 7, 8, 5, 3]
    output_4 = findMinArray(arr_4, k_4)
    check(expected_4, output_4)

    n_5 = 6
    arr_5 = [2, 7, 8, 1, 5, 3]
    k_5 = 4
    expected_5 = [1, 2, 7, 5, 8, 3]
    output_5 = findMinArray(arr_5, k_5)
    check(expected_5, output_5)
