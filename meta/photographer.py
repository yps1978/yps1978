'''
Director of Photography (Chapter 1)
Level 1
Time limit: 5s
Not started
Note: Chapter 2 is a harder version of this puzzle. The only difference is a larger constraint on NN.
A photography set consists of NN cells in a row, numbered from 11 to NN in order, and can be represented by a string CC of length NN. Each cell ii is one of the following types (indicated by C_iC
i
​
 , the iith character of CC):
If C_iC
i
​
  = “P”, it is allowed to contain a photographer
If C_iC
i
​
  = “A”, it is allowed to contain an actor
If C_iC
i
​
  = “B”, it is allowed to contain a backdrop
If C_iC
i
​
  = “.”, it must be left empty
A photograph consists of a photographer, an actor, and a backdrop, such that each of them is placed in a valid cell, and such that the actor is between the photographer and the backdrop. Such a photograph is considered artistic if the distance between the photographer and the actor is between XX and YY cells (inclusive), and the distance between the actor and the backdrop is also between XX and YY cells (inclusive). The distance between cells ii and jj is |i - j|∣i−j∣ (the absolute value of the difference between their indices).
Determine the number of different artistic photographs which could potentially be taken at the set. Two photographs are considered different if they involve a different photographer cell, actor cell, and/or backdrop cell.
Constraints
1 \le N \le 2001≤N≤200
1 \le X \le Y \le N1≤X≤Y≤N
Sample test case #1
N = 5
C = APABA
X = 1
Y = 2
Expected Return Value = 1
Sample test case #2
N = 5
C = APABA
X = 2
Y = 3
Expected Return Value = 0
Sample test case #3
N = 8
C = .PBAAP.B
X = 1
Y = 3
Expected Return Value = 3
Sample Explanation
In the first case, the absolute distances between photographer/actor and actor/backdrop must be between 11 and 22. The only possible photograph that can be taken is with the 33 middle cells, and it happens to be artistic.
In the second case, the only possible photograph is again taken with the 33 middle cells. However, as the distance requirement is between 22 and 33, it is not possible to take an artistic photograph.
In the third case, there are 44 possible photographs, illustrated as follows:
.P.A...B
.P..A..B
..BA.P..
..B.AP..
All are artistic except the first, where the artist and backdrop exceed the maximum distance of 33.'''
from typing import List


def getRangeCount(opened: List[int], active_a: List[int], curr_pos, X: int, Y: int):
    count = 0
    for p in [i for i in opened]:
        for a in [j for j in active_a]:
            if a > p:
                if p < a < curr_pos and X <= a - p <= Y and X <= curr_pos - a <= Y:
                    count += 1
                    print(f'{p}-{a}-{curr_pos}')
                elif a - p > Y and len(active_a) == 1:
                    if p in opened:
                        opened.remove(p)

    return count


def getArtisticPhotographCount(N: int, C: str, X: int, Y: int) -> int:
    count = 0
    open_pab = []
    open_bap = []
    active_a = []
    for i, c in enumerate(C):
        if c == 'P':
            open_pab.append(i)
            # check the closing bap
            count += getRangeCount(open_bap, active_a, i, X, Y)
        elif c == 'B':
            open_bap.append(i)
            # check the closing pab
            count += getRangeCount(open_pab, active_a, i, X, Y)
        elif c == 'A':
            active_a.append(i)
        elif c == '.':
            # do nothing
            pass
        else:
            # error, report
            return 0

    return count


if __name__ == '__main__':
    ret = getArtisticPhotographCount(5, "APABA", 1, 2)
    print(f'{("PASS" if ret == 1 else f"FAILED - Expected 1, Got {ret}")}')

    ret = getArtisticPhotographCount(5, "APABA", 2, 3)
    print(f'{("PASS" if ret == 0 else f"FAILED - Expected 0, Got {ret}")}')

    ret = getArtisticPhotographCount(5, ".PBAAP.B", 1, 3)
    print(f'{("PASS" if ret == 3 else f"FAILED - Expected 4, Got {ret}")}')

    ret = getArtisticPhotographCount(5, "PPPAABB", 1, 3)
    print(f'{("PASS" if ret == 10 else f"FAILED - Expected 10, Got {ret}")}')
'''
P..A.B.
P..A..B
.P.A.B.
.P.A..B
.P..AB.
.P..A.B
..PA.B.
..PA..B
..P.AB.
..P.A.B


'''