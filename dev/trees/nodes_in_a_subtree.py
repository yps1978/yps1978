import math


# Add any extra import statements you may need here


class Node:
    def __init__(self, data):
        self.val = data
        self.children = []


# Add any helper functions you may need here

def count_below_node(root, query, s):
    def count_children_nodes(node):
        if node == None:
            return 0

        node_count = 1 if s[node.val - 1] == query[1] else 0

        for child in node.children:
            node_count += count_children_nodes(child)

        return node_count

    max_count = 0
    if root.val == query[0]:
        max_count = count_children_nodes(root)
    else:
        for child in root.children:
            child_count = count_below_node(child, query, s)
            if child_count > max_count:
                max_count = child_count

    return max_count


def count_of_nodes(root, queries, s):
    result = []

    for query in queries:
        result.append(count_below_node(root, query, s))

    return result


# These are the tests we use to determine if the solution is correct.
# You can add your own at the bottom, but they are otherwise not editable!

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
    # Testcase 1
    n_1, q_1 = 3, 1
    s_1 = "aba"
    root_1 = Node(1)
    root_1.children.append(Node(2))
    root_1.children.append(Node(3))
    queries_1 = [(1, 'a')]

    output_1 = count_of_nodes(root_1, queries_1, s_1)
    expected_1 = [2]
    check(expected_1, output_1)

    # Testcase 2
    n_2, q_2 = 7, 3
    s_2 = "abaacab"
    root_2 = Node(1)
    root_2.children.append(Node(2))
    root_2.children.append(Node(3))
    root_2.children.append(Node(7))
    root_2.children[0].children.append(Node(4))
    root_2.children[0].children.append(Node(5))
    root_2.children[1].children.append(Node(6))
    queries_2 = [(1, 'a'), (2, 'b'), (3, 'a')]
    output_2 = count_of_nodes(root_2, queries_2, s_2)
    expected_2 = [4, 1, 2]
    check(expected_2, output_2)

# Add your own test cases here
