package main

//  import (
//  	"fmt"
//  // 	//"sort"
//  // 	//"strconv" 			//fmt.Println("Searched index " + strconv.Itoa(middleIndex))
//  )

//Starting off by copying my 3Sum solution. The sort is definitely needed.
func threeSumClosest(nums []int, target int) int {
	numsLen := len(nums)
    nums = quickSort(nums, 0, numsLen-1)
	result := (nums[numsLen-3] + nums[numsLen-2] + nums[numsLen-1])

    for i := 0; i < numsLen-2; i++ {
        if i > 2 && nums[i] == nums[i-3] {
            continue
        }

        k, j := i+1, numsLen-1

        for k < j {
            sum := (nums[i] + nums[k] + nums[j])
			if (target - sum == 0){
				return sum 
			} else if sum < target{
				k++
				for k < j && nums[k] == nums[k-1] {
                    k++
                }
			} else if sum > target{
				j--
				for k < j && nums[j] == nums[j+1] {
                    j--
                }
			}
			if max(target - sum, (target-sum)*-1) < max(target - result, (target-result) *-1){
				result = sum
			}
			
        }
    }

    return result
}