import math


# Add any extra import statements you may need here


# Add any helper functions you may need here


def findPositions(arr, x):
    # (orig, current, index)
    indexed_list = [(arr[i], arr[i], i + 1) for i in range(len(arr))]

    k = x
    result = []
    while k > 0:
        # 1.
        pop_list = []

        # (max_value, index_in_pop_list, index_in_original)
        max_poped = (-1, -1, x * x)

        for i in range(min(x, len(indexed_list))):
            aux = indexed_list.pop(0)
            if max_poped[0] < aux[1]:
                max_poped = (aux[1], i, aux[2])
            elif max_poped[0] == aux[1] and max_poped[2] > aux[2]:
                max_poped = (aux[1], i, aux[2])

            pop_list.append(aux)

        # 2.
        result.append(max_poped[2])
        pop_list.pop(max_poped[1])

        # 3.
        for i in range(len(pop_list)):
            value = pop_list[i][1] - 1 if pop_list[i][1] > 0 else 0
            indexed_list.append((pop_list[i][0], value, pop_list[i][2]))

        k -= 1

    return result


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
    n_1 = 6
    x_1 = 5
    arr_1 = [1, 2, 2, 3, 4, 5]
    expected_1 = [5, 6, 4, 1, 2]
    output_1 = findPositions(arr_1, x_1)
    check(expected_1, output_1)

    n_2 = 13
    x_2 = 4
    arr_2 = [2, 4, 2, 4, 3, 1, 2, 2, 3, 4, 3, 4, 4]
    expected_2 = [2, 5, 10, 13]
    output_2 = findPositions(arr_2, x_2)
    check(expected_2, output_2)

    # Add your own test cases here
