package main

import (
	"fmt"
	//"strconv" 			//fmt.Println("Searched index " + strconv.Itoa(middleIndex))
)


func main() {
	//fmt.Println(twoSum([]int{-3,4,3,90}, 0))
	//fmt.Println(searchInsert([]int{1, 3}, 2))
	// //fmt.Println(lengthOfLastWord("Hello World"))
	// fmt.Println(lengthOfLastWord("   fly me   to   the moon  "))
	// fmt.Println(lengthOfLastWord("luffy is still joyboy"))
	//fmt.Println(lengthOfLastWord("a"))
	//fmt.Println(maxArea([]int{1,2,2}))
	//fmt.Println(maxArea([]int{1,8,6,2,5,4,8,3,7}))

	//fmt.Println(plusOne([]int{9}))
	///fmt.Println(intToRoman(0))
	//fmt.Println(threeSum([]int{-2,0,3,-1,4,0,3,4,1,1,1,-3,-5,4,0}))
	//fmt.Println(threeSum([]int{0,0,0}))
	// fmt.Println(threeSum([]int{-2,0,0,2,2}))

	//fmt.Println(threeSum([]int{-10,0,10,20,-10,-40}))
	// fmt.Println(threeSumClosest([]int{-1,2,1,-4}, 1))
	//fmt.Println(threeSumClosest([]int{0,1,2}, 1))
	// fmt.Println(threeSumClosest([]int{10,20,30,40,50,60,70,80,90}, 1))
	//fmt.Println(fourSum([]int{1,0,-1,0,-2,2}, 0))
	// fmt.Println(fourSum([]int{-2,-1,-1,1,1,2,2}, 0))
	fmt.Println(fourSum([]int{-3,-1,0,2,4,5}, 2))
	// fmt.Println(fourSum([]int{10,20,30,40,50,60,70,80,90}, 1))


	

	
	

}

func partition(arr []int, low, high int) ([]int, int) {
	pivot := arr[high]
	i := low
	for j := low; j < high; j++ {
		if arr[j] < pivot {
			arr[i], arr[j] = arr[j], arr[i]
			i++
		}
	}
	arr[i], arr[high] = arr[high], arr[i]
	return arr, i
}

func quickSort(nums []int, low int, high int) []int{
	if low < high{
		var p int
		nums, p = partition(nums, low, high)
		nums = quickSort(nums, low, p-1)
		nums = quickSort(nums, p+1, high)
	}
	return nums
}

func twoSum(nums []int, target int) []int {

	//I don't know how to use hashmaps(or is this a dict?) in Go so this is definitely not my work. I built a slower optimized double for
	numToIndexMap := make(map[int]int) //Map syntax is something like map[key]val. Need to use make to create data structures. myMap = map[int]int doesn't work.
	//thinking of make() like new

	for i, num := range nums {
        diff := target - num //:= is how we assign new variables

        // Oh boy my first GO task and they're doing some really weird stuff right off the bat
		// I think this is setting the definitions of idx, found before checking if found != null?
		// This is somewhat difficult to grok at first glance but I think this is a beginner issue.
        if idx, found := numToIndexMap[diff]; found {
            return []int{i, idx}
			//this return provides {lateIndex, earlierIndex}. This only works because the question specified that it was okay to return in any order.
        }

        numToIndexMap[num] = i
    }

	return nil
}

func searchInsert(nums []int, target int) int {
	lowerBound := 0
	upperBound := len(nums) - 1
	expectedIndex := 0

	//Googled how to do a while loop in Go
	//Can't search iteratively due to constraint of O(log n) time complexity. Basically mandates binary search.
	for lowerBound <= upperBound {
		middleIndex :=  (lowerBound + upperBound)/2
		if nums[middleIndex] == target {
			return middleIndex
		}
		if nums[middleIndex] <= target {
			lowerBound = middleIndex + 1
			if lowerBound > len(nums) -1 || nums[lowerBound] >= target {
				expectedIndex = lowerBound
			}
		} else {
			upperBound = middleIndex - 1
				expectedIndex = lowerBound
		}

	}
	if expectedIndex < 0 {
		return 0
	}
	return expectedIndex
	//What do ya know? Beats 100% and no solution mining
}

func lengthOfLastWord(s string) int {
	if len(s) == 0 {
		return 0
	}
	wordStarted := false
	counter := 0
	for i := len(s)-1; i>=0; i-- {
		if s[i] != ' ' {
			counter++
			if !wordStarted {
				wordStarted =  true
			}
		} else if s[i] == ' ' && wordStarted{
			return counter;
		}
	}
	return counter
}

func maxArea(height []int) int {
	localMax := 0
	// This is too slow, should probably aim to take into account how this is actually working IRL
	// for i := 0;i<len(height)-1;i++{
	// 	if height[i] * (len(height)-i) > localMax{
	// 		for j := len(height)-1;j>i;j--{
	// 			if(height[i] > height[j]){
	// 				tempMax := height[j] * (j-i)
	// 				if localMax <  tempMax{
	// 					localMax = tempMax
	// 				}
	// 			} else {
	// 				tempMax := height[i] * (j-i)
	// 				if localMax <  tempMax{
	// 					localMax = tempMax
	// 				}
	// 				j = -1
	// 			}
				
	// 		}
	// 	}
	// }

	//Updated Algorithm
	left := 0
	right := len(height) -1
	maxWidth := right
	for currentWidth := maxWidth; currentWidth > 0; currentWidth-- {
		if height[left] < height[right]{ //if we have a state where the right is higher we have achieved ths maximum possible result for that left index
										 //this works because right starts at the highest possible value and only goes down.
			tempMax := height[left] * currentWidth
			if localMax <  tempMax{
				localMax = tempMax
			}
			left++
		} else { //if we achieve a state where the left is higher than the right or they are equal
				//this should be the highest possible number for any use of that RIGHT index

			tempMax := height[right] * currentWidth
			if localMax <  tempMax{
				localMax = tempMax
			}
			right--
		}
	}

	return localMax
}