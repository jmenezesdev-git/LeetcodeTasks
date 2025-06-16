import sys


class Solution:
    ### would move the if total >214.... block into it's own function but thats actually inefficient
    def myAtoi(s: str) -> int:
        try:
            total = int(s)
            if total > 2147483647:
                return 2147483647
            elif total < -2147483648:
                return -2147483648
            return total
        except:
            total = 0
            leadingWhitespace = 0
            for c in s:
                if (c == '-' or c == '+') and leadingWhitespace == 0:
                    if c == '-':
                        leadingWhitespace = -1
                    else:
                        leadingWhitespace = 1
                elif c == '0' or c == '1' or c == '2' or c == '3' or c == '4' or c == '5' or c == '6' or c == '7' or c == '8' or c == '9':
                    #2^31 =  2147483648
                    if leadingWhitespace == 0:
                        leadingWhitespace = 1
                    total = (total * 10) + int(c)
                elif c == ' ' and leadingWhitespace == 0:
                    pass
                else:
                    total = total * leadingWhitespace
                    if total > 2147483647:
                        return 2147483647
                    elif total < -2147483648:
                        return -2147483648
                    return total
            total = total * leadingWhitespace
            if total > 2147483647:
                return 2147483647
            elif total < -2147483648:
                return -2147483648
            return total
                

    if __name__ == "__main__":  
        var = "-91283472332"
        print("result of " + var + " = " + str(myAtoi(var)))