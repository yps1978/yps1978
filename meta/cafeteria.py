from typing import List
'''A cafeteria table consists of a row of NN seats, numbered from 11 to NN from left to right. Social distancing guidelines require that every diner be seated such that KK seats to their left and KK seats to their right (or all the remaining seats to that side if there are fewer than KK) remain empty.
There are currently MM diners seated at the table, the iith of whom is in seat S_iS 
i
​
 . No two diners are sitting in the same seat, and the social distancing guidelines are satisfied.
Determine the maximum number of additional diners who can potentially sit at the table without social distancing guidelines being violated for any new or existing diners, assuming that the existing diners cannot move and that the additional diners will cooperate to maximize how many of them can sit down.
Please take care to write a solution which runs within the time limit.
Constraints
1 \le N \le 10^{15}1≤N≤10 
15
 
1 \le K \le N1≤K≤N
1 \le M \le 500{,}0001≤M≤500,000
M \le NM≤N
1 \le S_i \le N1≤S 
i
​
 ≤N
Sample test case #1
N = 10
K = 1
M = 2
S = [2, 6]
Expected Return Value = 3
Sample test case #2
N = 15
K = 2
M = 3
S = [11, 6, 14]
Expected Return Value = 1
Sample Explanation
In the first case, the cafeteria table has N = 10N=10 seats, with two diners currently at seats 22 and 66 respectively. The table initially looks as follows, with brackets covering the K = 1K=1 seat to the left and right of each existing diner that may not be taken.
  1 2 3 4 5 6 7 8 9 10
  [   ]   [   ]
Three additional diners may sit at seats 44, 88, and 1010 without violating the social distancing guidelines.
In the second case, only 11 additional diner is able to join the table, by sitting in any of the first 33 seats.'''


def getMaxAdditionalDinersCount(N: int, K: int, M: int, S: List[int]) -> int:
    if K == 0:
        return N - M

    s = sorted(S)
    count = int((s[0] - 1) / (K + 1))
    last = s[0]
    for v in s[1:]:
        count += int((v - last - 1 - K) / (K + 1))
        last = v

    count += int((N - last) / (K + 1))

    return count


if __name__ == '__main__':
    # print(getHitProbability(2, 2, [[1, 1], [1, 1]]))
    print(f'{("PASS" if getMaxAdditionalDinersCount(11, 1, 2, [2, 6]) == 3 else "FAILED - Expected 3")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(15, 2, 3, [11, 6, 14]) == 1 else "FAILED - Expected 1")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(15, 2, 3, [11, 5, 14]) == 2 else "FAILED - Expected 2")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(5, 2, 1, [2]) == 1 else "FAILED - Expected 1")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(5, 1, 1, [3]) == 2 else "FAILED - Expected 2")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(5, 1, 1, [4]) == 1 else "FAILED - Expected 1")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(4, 2, 1, [2]) == 0 else "FAILED - Expected 0")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(4, 1, 1, [3]) == 1 else "FAILED - Expected 1")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(4, 1, 1, [4]) == 1 else "FAILED - Expected 1")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(15, 0, 1, [11]) == 14 else "FAILED - Expected 14")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(15, 1, 2, [2, 4]) == 5 else "FAILED - Expected 5")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(16, 1, 2, [4, 2]) == 6 else "FAILED - Expected 6")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(16, 1, 4, [2, 3, 4, 5]) == 5 else "FAILED - Expected 5")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(15, 5, 1, [6]) == 1 else "FAILED - Expected 1")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(10, 2, 2, [2, 10]) == 1 else "FAILED - Expected 1")}')
    print(f'{("PASS" if getMaxAdditionalDinersCount(20, 2, 2, [2, 20]) == 5 else "FAILED - Expected 5")}')
