import math

# Add any extra import statements you may need here


# Add any helper functions you may need here

# def minOperations(arr):
#     count = 0
#     permutations = []
#     reversed_arr = True
#     orig = [x for x in arr]
#     while reversed_arr:
#         start = 0
#         while start < len(arr) and arr[start] == start + 1:
#             start += 1
#
#         end = len(arr) - 1
#         while end > 0 and arr[end] == end + 1:
#             end -= 1
#
#         reversed_arr = False
#         for i in range(start, end):
#             if arr[i] > arr[i + 1]:
#                 arr[i], arr[i + 1] = arr[i + 1], arr[i]
#                 count += 1
#                 permutations.append(i)
#                 print(arr)
#                 reversed_arr = True
#
#     return count


min_permutations = 100


def reverseSort(arr, start, length, permutations):
    while start < len(arr) and arr[start] == start + 1:
        start += 1

    global min_permutations

    if start == len(arr):
        min_permutations = min(min_permutations, permutations)
        return permutations
    elif permutations > min_permutations:
        return permutations

    for i in range(start, len(arr)):
        for j in range(length, -1, -1):
            if i + j <= len(arr):
                aux = arr[i: i + j]
                aux.reverse()
                aux = arr[0:i] + aux + arr[i + j:]
                reverseSort(aux, 0, j-1, permutations + 1)


def minOperations(arr):
    global min_permutations

    min_permutations = 100
    reverseSort(arr, 0, len(arr), 0)

    return min_permutations


# def variability(arr):
#     hops = 0
#     for i in range(len(arr) - 1):
#         hops += abs(arr[i] - arr[i + 1])
#
#     return hops
#
#
# def minOperations(arr):
#     permutations = 0
#     loop = True
#     last_segment = (0,0)
#     while loop:
#         i = 0
#
#         while i < len(arr) and arr[i] == i + 1:
#             i += 1
#
#         k = len(arr) - 1
#         while k > 0 and arr[k] == k + 1:
#             k -= 1
#
#         search_ix = i
#         min_variability = 1000
#         max_interval_length = 0
#         (start, end, direction) = (i, i, 0)
#         while i < k:
#             start_ix = i
#             direction = 1 if arr[i] < arr[i + 1] else -1
#             i += 2
#             while i <= k:
#                 if (arr[i] < arr[i - 1] and direction == 1) or (arr[i] > arr[i - 1] and direction == -1):
#                     break
#                 i += 1
#             aux = variability(arr[start_ix: i])
#             if aux < min_variability and last_segment != (start_ix, i):
#                 min_variability = aux
#                 (start, end, direction) = (start_ix, i, direction)
#             elif aux == min_variability and i - start_ix > max_interval_length and last_segment != (start_ix, i):
#                 max_interval_length = i - start_ix
#                 (start, end, direction) = (start_ix, i, direction)
#
#             i -= 1
#
#         if end - start + search_ix == k+1:
#             if direction == -1:
#                 permutations += 1
#             break
#
#         permutations += 1
#         aux = []
#         for j in range(0, start):
#             aux.append(arr[j])
#         sublist = arr[start: end]
#         sublist.reverse()
#         aux += sublist
#         for j in range(end, k+1):
#             aux.append(arr[j])
#         arr = aux
#         last_segment = (start, end)
#
#     return permutations


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
    n_1 = 5
    arr_1 = [1, 2, 5, 4, 3]
    expected_1 = 1
    output_1 = minOperations(arr_1)
    check(expected_1, output_1)

    n_2 = 3
    arr_2 = [3, 1, 2]
    expected_2 = 2
    output_2 = minOperations(arr_2)
    check(expected_2, output_2)

    # Add your own test cases here
    n_3 = 5
    arr_3 = [4, 5, 3, 1, 2]
    expected_3 = 3
    output_3 = minOperations(arr_3)
    check(expected_3, output_3)

    n_4 = 9
    arr_4 = [5, 1, 2, 3, 6, 7, 8, 9, 4]
    expected_4 = 4
    output_4 = minOperations(arr_4)
    check(expected_4, output_4)
