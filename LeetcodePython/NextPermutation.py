
class Solution:
    def nextPermutation(nums: list[int]) -> None:
        if len(nums) < 2:
            return
        # temp = list(nums) #no longer needed as first while loop handles this
        # temp.sort(reverse=True)
        # if temp == nums:
        #     nums.sort()
        #     return
        i = len(nums) - 2 # at least 2 items in list
        while i >= 0 and nums[i] >= nums[i+1]: #while items are in reverse order decrement I
            i-=1
        
        if i>=0: #if something was found that wasn't in reverse order [0,3,2,1] 's 0 for example which would be i
            j = len(nums) - 1
            while nums[j] <= nums[i]: # detects 1 > 0 in above example at j = 3, i = 0 leaving us at 3
                j-=1
            temp = nums[i] #swaps
            nums[i] = nums[j]
            nums[j] = temp
        
            temp = list(nums[i+1:])
            temp.sort(reverse=False)
            j = i+1
            for val in temp:
                nums[j] = val

                j+=1
            return


        """
        Do not return anything, modify nums in-place instead.
        """
                

    if __name__ == "__main__":  
        var = [3,2,1]
        var = [1,2,3]
        var = [1,3,2]
        var = [2,1,3]
        var = [2,3,1]
        var = [3,1,2]
        var = [4,2,0,2,3,2,0]
        var = [0,3,2,1]
        nextPermutation(var)
        print("result of nextPermutation = " + str(var))