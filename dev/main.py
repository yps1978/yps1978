# class Node:
#     def __init__(self, info):
#         self.info = info
#         self.left = None
#         self.right = None
#         self.level = None
#
#     def __str__(self):
#         return str(self.info)
#
#
# class BinarySearchTree:
#     def __init__(self):
#         self.root = None
#
#     def create(self, val):
#         if self.root == None:
#             self.root = Node(val)
#         else:
#             current = self.root
#
#             while True:
#                 if val < current.info:
#                     if current.left:
#                         current = current.left
#                     else:
#                         current.left = Node(val)
#                         break
#                 elif val > current.info:
#                     if current.right:
#                         current = current.right
#                     else:
#                         current.right = Node(val)
#                         break
#                 else:
#                     break
#

# Enter your code here. Read input from STDIN. Print output to STDOUT
'''
class Node:
      def __init__(self,info): 
          self.info = info  
          self.left = None  
          self.right = None 


       // this is a node of the tree , which contains info as data, left , right
'''


#
# def lca(root, v1, v2):
#     (info, b1, b2) = lca_search(root, v1, v2)
#     return info
#
# def lca_search(root, v1, v2):
#     if root is None:
#         return None, False, False
#
#     node, al, bl = lca_search(root.left, v1, v2)
#     if al and bl and node is not None:
#         return node, al, bl
#
#     node, ar, br = lca_search(root.right, v1, v2)
#     if ar and br and node is not None:
#         return node, ar, br
#
#     return root, al or ar or root.info == v1, bl or br or root.info == v2
#
#
# tree = BinarySearchTree()
# t = int(input())
#
# arr = list(map(int, input().split()))
#
# for i in range(t):
#     tree.create(arr[i])
#
# v = list(map(int, input().split()))
#
# ans = lca(tree.root, v[0], v[1])
# print(ans.info)

def get_hash(num):
    digits = []

    while num > 0:
        remainder = num % 62
        digits.append(remainder)
        num = int(num / 62)

    digits.reverse()

    return digits


print(get_hash(1))
