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

        if root is None:
            return 0

        return (root.val * 10) + self.sumNumbers(root.left) + self.sumNumbers(root.right)

    def get_tree(self, arr):
        root = TreeNode(arr[0])
        list = [root]
        miter = iter(range(0, len(arr)))
        for i in miter:
            node = list.pop()
            node.val = arr[i]
            if i + 1 < len(arr):
                node.left = TreeNode(arr[i + 1])
                list.append(node.left)
                next(miter, None)
            if i + 1 < len(arr):
                node.right = TreeNode(arr[i + 1])
                list.append(node.right)
                next(miter, None)

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

