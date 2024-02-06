import math


# Add any extra import statements you may need here


# Add any helper functions you may need here


def findEncryptedWord(s):
    str_len = len(s)

    if str_len == 0:
        return ''

    if str_len == 1:
        return s

    mid_ix = (str_len // 2) - 1 if str_len % 2 == 0 else str_len // 2

    return s[mid_ix] + findEncryptedWord(s[:mid_ix]) + findEncryptedWord(s[mid_ix + 1:])


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
    s1 = "abc"
    expected_1 = "bac"
    output_1 = findEncryptedWord(s1)
    check(expected_1, output_1)

    s2 = "abcd"
    expected_2 = "bacd"
    output_2 = findEncryptedWord(s2)
    check(expected_2, output_2)

    # Add your own test cases here
    s3 = "facebook"
    expected_3 = "eafcobok"
    output_3 = findEncryptedWord(s3)
    check(expected_3, output_3)