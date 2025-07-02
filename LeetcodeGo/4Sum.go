package main

 import (
 	"fmt"
 )

//Based on the ThreeSum solution  implements a surrounding loop. Adjusts continue parameters to account for i no longer being the base loop. Adds fourth value to check
//Also checks against target instead of 0
func fourSum(nums []int, target int) [][]int {
    nums = quickSort(nums, 0, len(nums)-1)
    res := [][]int{}
	for l := 0; l < len(nums)-3; l++{
		if l > 0 && nums[l] == nums[l-1]{
			continue
		}
		
		for i := l+1; i < len(nums)-2; i++ {
			if i > l+1 && nums[i] == nums[i-1] {
				continue
			}

			k, j := i+1, len(nums)-1

			for k < j {
				sum := nums[l] + nums[i] + nums[k] + nums[j]
				if sum == target {
					res = append(res, []int{nums[l], nums[i], nums[k], nums[j]})
					fmt.Println("Appended " + fmt.Sprint(nums[l]) + ", "+ fmt.Sprint(nums[i]) + ", " + fmt.Sprint(nums[k]) + ", " + fmt.Sprint(nums[j]) + ". ")
					fmt.Println("At " + fmt.Sprint(l) + ", "+ fmt.Sprint(i) + ", " + fmt.Sprint(k) + ", " + fmt.Sprint(j) + ". ")
					k++
					j--

					for k < j && nums[k] == nums[k-1] {
						k++
					}
					for k < j && nums[j] == nums[j+1] {
						j--
					}
					fmt.Println("New indices " + fmt.Sprint(l) + ", "+ fmt.Sprint(i) + ", " + fmt.Sprint(k) + ", " + fmt.Sprint(j) + ". ")
				} else if sum < target {
					k++
				} else {
					j--
				}
				
			}
		}
	
	}

    return res
 }