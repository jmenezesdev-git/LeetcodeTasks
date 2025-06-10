n = int(input())
arr = []
for i in range(n):
    arr.append(input())
a, b = 0, 0
start = False
for i in range(n):
    if arr[i] == "white":
        if not start:
            start = True
    else:
        if start:
            a += 1
            start = False
if start:
    a += 1
start = False
for i in range(n):
    if arr[i] == "red":
        if not start:
            start = True
    else:
        if start:
            b += 1
            start = False
if start:
    b += 1


print(min(a + 1, b + 1))