import math


# Add any extra import statements you may need here

# Add any helper functions you may need here


def numberOfWays(arr, k):
    pairs = [[0 for i in range(len(arr))] for j in range(len(arr))]
    pairsFound = 0

    for i in range(len(arr) - 1):
        for j in range(i, len(arr)):
            if arr[i] + arr[j] == k:
                mn = min(arr[i], arr[j])
                mx = max(arr[i], arr[j])
                if pairs[mn][mx]:
                    continue
                pairsFound += 1
                pairs[mn][mx] = 1

    return pairsFound


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
    k_1 = 6
    arr_1 = [1, 2, 3, 4, 3]
    expected_1 = 2
    output_1 = numberOfWays(arr_1, k_1)
    check(expected_1, output_1)

    k_2 = 6
    arr_2 = [1, 5, 3, 3, 3]
    expected_2 = 4
    output_2 = numberOfWays(arr_2, k_2)
    check(expected_2, output_2)

    # Add your own test cases here
