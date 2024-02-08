# Definition for a binary tree node.
class TreeNode(object):
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution(object):

    def sumNumbers(self, root):
        """
        :type root: TreeNode
        :rtype: int
        """

        def reverse_sum(node, h, sum):
            if node is None:
                return 0

            current = node.val * pow(10, h)
            if node.left is None and node.right is None:
                return int(str(sum + current)[::-1])

            return reverse_sum(node.left, h + 1, sum + current) + reverse_sum(node.right, h + 1, sum + current)

        return reverse_sum(root, 0, 0)

    def get_tree(self, arr):
        root = TreeNode(arr[0])
        list = [root]
        i = 0
        while i < len(arr):
            node = list.pop(0)
            if i + 1 < len(arr):
                node.left = TreeNode(arr[i + 1])
                list.append(node.left)
                i += 1
            if i + 1 < len(arr):
                node.right = TreeNode(arr[i + 1])
                list.append(node.right)
                i += 1
            else:
                i += 1

        return root


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
        print(expected)
        print(' Your output: ', end='')
        print(output)
        print()
    test_case_number += 1


if __name__ == "__main__":
    s = Solution()
    test_1 = [1, 2, 3]
    expected_1 = 25
    output_1 = s.sumNumbers(s.get_tree(test_1))
    check(expected_1, output_1)

    test_2 = [4, 9, 0, 5, 1]
    expected_2 = 1026
    output_2 = s.sumNumbers(s.get_tree(test_2))
    check(expected_2, output_2)
