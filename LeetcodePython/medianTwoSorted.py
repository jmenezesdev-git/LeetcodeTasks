class Solution:
    def findMedianSortedArrays(nums1: list[int], nums2: list[int]) -> float:
        ##Leetcode suggests the runtime of this is longer than iteratively doing the whole list regardless of size. Not sure I agree
        ## there appears to be variance of 0-4ms when resubmitting and the runtime for these is all <5ms.
        len1 = len(nums1)
        len2 = len(nums2)


        if len1 + len2 == 1:
            if len1 == 0:
                return nums2[0]
            else:
                return nums1[0]
            
        pointer1 = 0
        pointer2 = 0
        currSearch = 0
        limSearch = int((len1 + len2)/2)+1
        latest=-1
        secondLatest=-1

        while (pointer1 < len1 or pointer2 < len2) and currSearch < limSearch:
            if pointer1 < len1 and pointer2 < len2:
                if nums1[pointer1] <= nums2[pointer2]:
                    secondLatest = latest
                    latest = nums1[pointer1]
                    pointer1+=1
                elif nums2[pointer2] < nums1[pointer1]:
                    secondLatest = latest
                    latest = nums2[pointer2]
                    pointer2+=1
            elif pointer1 < len1:
                secondLatest = latest
                latest = nums1[pointer1]
                pointer1+=1
            else:
                secondLatest = latest
                latest = nums2[pointer2]
                pointer2+=1
            currSearch+=1
            if currSearch == limSearch:
               if (len1 + len2) % 2 == 0:
                    return (latest + secondLatest)/2
               else:
                   return latest
            

        return 0.0

    if __name__ == "__main__":  
        nums1 = [1,3] #1,3
        nums2 = [2] #,4,5
        print("result of " + str(nums1) + " and " + str(nums2) + " = " + str(findMedianSortedArrays(nums1, nums2)))