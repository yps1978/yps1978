def brute_force(mat):
    for i in range(len(mat)):
        for j in range(len(mat[0]) - 1, -1, -1):
            if mat[i][j] < k:
                return i, j


def binary_search(mat):
    x0, x, x1 = 0, 0, len(mat) - 1
    y0, y, y1 = 0, 0, len(mat[0]) - 1

    while mat[x0][y1] == k:
        # search row
        if mat[x1][y1] == 0:
            x = x0 + int((x1 - x0) / 2)
            if x == x0:
                # abort inner loop
                break
            else:
                if mat[x][y1] == k:
                    x0, x1 = x + 1, x1
                else:
                    x0, x1 = x0, x
        else:
            x = x1
            break

    while True:
        # search column
        if mat[x][y1] == k:
            y = y0 + int((y1 - y0) / 2)
            if y == y0:
                # abort inner loop
                if y == 0:
                    x, y = x + 1, len(mat[0]) - 1
                break
            else:
                if mat[x][y] == k:
                    y0, y1 = y0, y - 1
                else:
                    y0, y1 = y, y1
        else:
            y = y1
            break

    return x, y


def test_brute_force():
    mat = [[0 for _ in range(n)] for _ in range(m)]
    for s in range(m * n * k - 1):
        a, b = brute_force(mat)
        mat[a][b] += 1

    x, y = brute_force(mat)
    assert (x, y) == (2, 0)


def test_binary_search():
    mat = [[0 for _ in range(n)] for _ in range(m)]
    for s in range(m * n * k - 1):
        a, b = binary_search(mat)
        mat[a][b] += 1

    x, y = binary_search(mat)
    assert (x, y) == (2, 0)


if __name__ == '__main__':
    m, n, k = 3, 3, 3
    test_brute_force()
    test_binary_search()
