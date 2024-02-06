def are_they_equal(array_a, array_b):
    sorted_a = sorted(array_a)
    sorted_b = sorted(array_b)

    if sorted_a != sorted_b:
        return False

    return True


# These are the tests we use to determine if the solution is correct.
# You can add your own at the bottom, but they are otherwise not editable!
def printString(string):
    print('[\"', string, '\"]', '', '')


test_case_number = 1


def check(expected, output):
    global test_case_number
    result = False
    if expected == output:
        result = True
    rightTick = '\u2713'
    wrongTick = '\u2717'
    if result:
        print(rightTick, 'Test #', test_case_number, '')
    else:
        print(wrongTick, 'Test #', test_case_number, ': Expected ', '', '')
        printString(expected)
        print(' Your output: ', '')
        printString(output)
        print()
    test_case_number += 1


if __name__ == "__main__":
    n_1 = 4
    a_1 = [1, 2, 3, 4]
    b_1 = [1, 4, 3, 2]
    expected_1 = True
    output_1 = are_they_equal(a_1, b_1)
    check(expected_1, output_1)

    n_2 = 4
    a_2 = [1, 2, 3, 4]
    b_2 = [1, 2, 3, 5]
    expected_2 = False
    output_2 = are_they_equal(a_2, b_2)
    check(expected_2, output_2)

    # Add your own test cases here
    n_3 = 4
    a_3 = [7, 2, 9, 1]
    b_3 = [1, 2, 9, 7]
    expected_3 = True
    output_3 = are_they_equal(a_3, b_3)
    check(expected_3, output_3)
