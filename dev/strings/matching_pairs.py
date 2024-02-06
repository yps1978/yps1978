import math


# Add any extra import statements you may need here


# Add any helper functions you may need here


def matching_pairs(s, t):
    if len(s) < 2 or len(s) > 1000000 or len(s) != len(t):
        return 0

    # This is the initial count, that can be altered by any of the following: [-2, -1, 1, 2]
    base_count = 0
    for i in range(len(s)):
        if s[i] == t[i]:
            base_count += 1

    max_swap_count = -3
    for i in range(len(s) - 1):
        for j in range(i + 1, len(t)):
            swap_count = 0
            if s[i] == t[j]:
                swap_count += 1
            else:
                swap_count -= 1

            if s[j] == t[i]:
                swap_count += 1
            else:
                swap_count -= 1

            if swap_count == 2:
                return base_count + swap_count

            if max_swap_count < swap_count:
                max_swap_count = swap_count

    return base_count + max_swap_count


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
    s_1, t_1 = "abcde", "adcbe"
    expected_1 = 5
    output_1 = matching_pairs(s_1, t_1)
    check(expected_1, output_1)

    s_2, t_2 = "abcd", "abcd"
    expected_2 = 2
    output_2 = matching_pairs(s_2, t_2)
    check(expected_2, output_2)

    # Add your own test cases here
    s_3, t_3 = "yasel prado", "yaesl prado"
    expected_3 = 11
    output_3 = matching_pairs(s_3, t_3)
    check(expected_3, output_3)