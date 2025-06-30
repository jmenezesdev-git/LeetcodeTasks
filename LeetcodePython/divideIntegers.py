class Solution:
    #Linear solution by subtracting absolute value of divisor from absolute dividend (getting absolute value without multiplying or dividing) is too slow due to while loop
    #likely wants some bit shift related or some other method I am not aware of that takes less than dividend/divisor iterations
    #yup. bit shifting did it.
    def divide(dividend: int, divisor: int) -> int:

        #no multiplication, division or modulo
        
    # Pos/Pos = >=0
    #Pos/Neg = <=0
    #Neg/Neg = >=0
        newDividend = 0
        newDivisor = 0

        if dividend == 0:
            return 0
        positive = True
        if dividend > 0:
            newDividend = dividend
            if divisor < 0:
                newDivisor = 0 - divisor
                positive = False
            else:
                newDivisor = divisor
        elif dividend < 0:
            newDividend = 0 - dividend
            if divisor > 0:
                newDivisor = divisor 
                positive = False 
            else:
                newDivisor = 0 - divisor

        if newDividend < newDivisor:
            return 0
        



        if newDivisor == 1:
            if positive:
                if newDividend > 2147483647:
                    return 2147483647
                else:
                    return newDividend
            else:
                if newDividend > 2147483648:
                      return -2147483648
                else:
                    return 0-newDividend
        
        
        returnValue = 0
        while (newDivisor <= newDividend):
            subVal = newDivisor
            multi2 = 1 #bit shifting value of 0 does nothing.
            while (subVal<< 1) <= newDividend: #If a left bitshift of 1 is less than the new dividend left bitshift multi and subval
                subVal = subVal << 1
                multi2 = multi2 << 1
            returnValue+= multi2 # add the largest double to our divisor that we can divide by to undershoot the return value
            newDividend -= subVal #subtract the largest power of 2 we can remove from the dividend

        if positive:
            if returnValue > 2147483647:
                return 2147483647
            else:
                return returnValue
        else:
            if returnValue > 2147483648:
                return -2147483648
            else:
                return 0-returnValue


    if __name__ == "__main__":
        print(str(divide(-12, -3)))
