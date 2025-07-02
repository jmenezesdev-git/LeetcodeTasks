package main

 import (
 	"fmt"
 // 	//"sort"
 // 	//"strconv" 			//fmt.Println("Searched index " + strconv.Itoa(middleIndex))
 )

//Solution was incomplete - required me to implement a sorting algorigthm. I chose quicksort and put it in leetcodeTasks.go
 func threeSum(nums []int) [][]int {
    nums = quickSort(nums, 0, len(nums)-1)
    res := [][]int{}

    for i := 0; i < len(nums)-2; i++ {
        if i > 0 && nums[i] == nums[i-1] {
            continue
        }

        k, j := i+1, len(nums)-1

        for k < j {
            sum := nums[i] + nums[k] + nums[j]
            if sum == 0 {
                res = append(res, []int{nums[i], nums[k], nums[j]})
                k++
                j--

                for k < j && nums[k] == nums[k-1] {
                    k++
                }
                for k < j && nums[j] == nums[j+1] {
                    j--
                }
            } else if sum < 0 {
                k++
            } else {
                j--
            }
        }
    }

    return res
 }

 //Still too slow, I have no clue how to solve this using maps despite what the hints suggest
 //used my solution for 2s sum since 2/3 hints suggested using your 2sSum solution
 // third hint suggested using maps which I was already doing. I'm looking at the solution this "Medium" challenge is harder than most "Hard" challenges
func threeSum_SecondAttempt(nums []int) [][]int{
	numToIndexMap := make(map[int]int)
	tripletList := [][]int{}
	numToCountMap := make(map[int]int)

	for i, num := range nums {
		numToIndexMap[num] = i
		numToCountMap[num]++
	}

	for i, _ := range numToIndexMap {
		fmt.Println(fmt.Sprint(i) + " has " + fmt.Sprint(numToCountMap[i]) + " instances")
		//fmt.Println(i)
		results := twoSumMapExists(nums, i*-1, numToIndexMap, numToIndexMap[i], numToCountMap)
		//fmt.Println("i = " + fmt.Sprint(i) + " results = " + fmt.Sprint(results))
		if (len(results) > 0){
			for j := 0; j < len(results);j++{
					//fmt.Println("j0 = " + fmt.Sprint(results[j][0]) + " j1 = " + fmt.Sprint(results[j][1]))
					triplet := []int{i, nums[results[j][0]], nums[results[j][1]]}

					if (triplet[0] != triplet[1] || triplet[1] != triplet[2] || (triplet[0] == triplet[1] && triplet[1] == triplet[2] && triplet[0] == 0)) {

						duplicate := false
						
						for k := 0; k < len(tripletList);k++{
							
							//
							zeroFound := false
							oneFound := false
							twoFound := false
							skip := false
							if tripletList[k][0] == triplet[0] {
								zeroFound = true
							} else if tripletList[k][0] == triplet[1] {
								oneFound = true
							} else if tripletList[k][0] == triplet[2] {
								twoFound = true
							} else { //no match on first index
								skip = true
							}
							
							if skip == false{
								if tripletList[k][1] == triplet[0] && zeroFound == false {
									zeroFound = true
								} else if tripletList[k][1] == triplet[1] && oneFound == false{
									oneFound = true
								} else if tripletList[k][1] == triplet[2] && twoFound == false{
									twoFound = true
								} else { //no match on second index
									skip = true
								}
							}
							
							if skip == false {
								if tripletList[k][2] == triplet[0] && zeroFound == false {
									zeroFound = true
									duplicate = true
								} else if tripletList[k][2] == triplet[1] && oneFound == false{
									oneFound = true
									duplicate = true
								} else if tripletList[k][2] == triplet[2] && twoFound == false{
									twoFound = true
									duplicate = true
								}
							}
						}

						if duplicate == false {
							tripletList = append(tripletList, triplet)
						}
					}

			}
		}
	}
	return tripletList

}

func twoSumMapExists(nums []int, target int, numToIndexMap map[int]int, currentIndex int, numToCountMap map[int]int) [][]int {

	results := [][]int{}

	for i, num := range nums {
        diff := target - num

        if idx, found := numToIndexMap[diff]; found && ((i != idx && i != currentIndex && idx != currentIndex) || (numToCountMap[nums[i]] > 1 && i == idx && nums[i] != nums[currentIndex]) || (numToCountMap[nums[i]] > 1 && i == currentIndex && nums[i] != nums[idx]) || (numToCountMap[nums[idx]] > 1 && idx == currentIndex && nums[i] != nums[currentIndex]) || (numToCountMap[nums[i]] > 2 && i == idx && i == currentIndex)){

				results = append(results, []int{i, idx})

        }

        numToIndexMap[num] = i
    }

	return results
}


 //Too slow, I need to do a major rework somewhere
func threeSum_Old(nums []int) [][]int {
	//Generating a map to save us time on the third element
    numToIndexMap := make(map[int]int)
    numToCountMap := make(map[int]int)
	for i, num := range nums {
		numToIndexMap[num] = i
		numToCountMap[num]++
	}

	keys := make([]int, 0, len(numToIndexMap))
	for key := range numToIndexMap {
		keys = append(keys, key)
	}



	tripletList := [][]int{}

	for i, _ := range numToIndexMap { //iterate through unique values //valIndex
		if numToCountMap[i] > 1 { //if there is at least 2 copies
			//check existence of i*2-x == 0
			diff := (i*2) * (-1)

			if idx, found := numToIndexMap[diff]; found {
					triplet := []int{nums[numToIndexMap[i]], nums[numToIndexMap[i]], nums[idx]}

					if (triplet[0] != triplet[1] || triplet[1] != triplet[2] || (triplet[0] == triplet[1] && triplet[1] == triplet[2] && numToCountMap[triplet[1]] > 2)) {

						duplicate := false
						
						for k := 0; k < len(tripletList);k++{
							
							//
							zeroFound := false
							oneFound := false
							twoFound := false
							skip := false
							if tripletList[k][0] == triplet[0] {
								zeroFound = true
							} else if tripletList[k][0] == triplet[1] {
								oneFound = true
							} else if tripletList[k][0] == triplet[2] {
								twoFound = true
							} else { //no match on first index
								skip = true
							}
							
							if skip == false{
								if tripletList[k][1] == triplet[0] && zeroFound == false {
									zeroFound = true
								} else if tripletList[k][1] == triplet[1] && oneFound == false{
									oneFound = true
								} else if tripletList[k][1] == triplet[2] && twoFound == false{
									twoFound = true
								} else { //no match on second index
									skip = true
								}
							}
							
							if skip == false {
								if tripletList[k][2] == triplet[0] && zeroFound == false {
									zeroFound = true
									duplicate = true
								} else if tripletList[k][2] == triplet[1] && oneFound == false{
									oneFound = true
									duplicate = true
								} else if tripletList[k][2] == triplet[2] && twoFound == false{
									twoFound = true
									duplicate = true
								}
							}
						}

						if duplicate == false {
							tripletList = append(tripletList, triplet)
						}
					}
				
			}


		} 

		for _, k := range keys{
		 	diff := (i+k) * (-1)
			if i != k {
				if idx, found := numToIndexMap[diff]; found{
					if((nums[idx] != nums[numToIndexMap[i]] && nums[idx] != nums[numToIndexMap[k]])|| (nums[idx] == nums[numToIndexMap[k]] && numToCountMap[nums[idx]] > 1)){
						
						triplet := []int{nums[numToIndexMap[i]], nums[numToIndexMap[k]], nums[idx]}

					
						duplicate := false
						

						for k := 0; k < len(tripletList);k++{
							
							//
							zeroFound := false
							oneFound := false
							twoFound := false
							skip := false
							if tripletList[k][0] == triplet[0] {
								zeroFound = true
							} else if tripletList[k][0] == triplet[1] {
								oneFound = true
							} else if tripletList[k][0] == triplet[2] {
								twoFound = true
							} else { //no match on first index
								skip = true
							}
							
							if skip == false{
								if tripletList[k][1] == triplet[0] && zeroFound == false {
									zeroFound = true
								} else if tripletList[k][1] == triplet[1] && oneFound == false{
									oneFound = true
								} else if tripletList[k][1] == triplet[2] && twoFound == false{
									twoFound = true
								} else { //no match on second index
									skip = true
								}
							}
							
							if skip == false {
								if tripletList[k][2] == triplet[0] && zeroFound == false {
									zeroFound = true
									duplicate = true
								} else if tripletList[k][2] == triplet[1] && oneFound == false{
									oneFound = true
									duplicate = true
								} else if tripletList[k][2] == triplet[2] && twoFound == false{
									twoFound = true
									duplicate = true
								}
							}
						}

						if duplicate == false {
							tripletList = append(tripletList, triplet)
						}
						
					}
				}
			}
		}
		

	}
	// for i, num := range nums {
	// 	for j := i+1; j<len(nums)-1;j++{
	// 		diff := (num + nums[j]) * (-1)
	// 		if idx, found := numToIndexMap[diff]; found {
	// 			if idx != i && idx != j{
	// 				triplet := []int{nums[i], nums[j], nums[idx]}

	// 				duplicate := false
					
	// 				for k := 0; k < len(tripletList);k++{
						
	// 					//
	// 					zeroFound := false
	// 					oneFound := false
	// 					twoFound := false
	// 					skip := false
	// 					if tripletList[k][0] == triplet[0] {
	// 						zeroFound = true
	// 					} else if tripletList[k][0] == triplet[1] {
	// 						oneFound = true
	// 					} else if tripletList[k][0] == triplet[2] {
	// 						twoFound = true
	// 					} else { //no match on first index
	// 						skip = true
	// 					}
						
	// 					if skip == false{
	// 						if tripletList[k][1] == triplet[0] && zeroFound == false {
	// 							zeroFound = true
	// 						} else if tripletList[k][1] == triplet[1] && oneFound == false{
	// 							oneFound = true
	// 						} else if tripletList[k][1] == triplet[2] && twoFound == false{
	// 							twoFound = true
	// 						} else { //no match on second index
	// 							skip = true
	// 						}
	// 					}
						
	// 					if skip == false {
	// 						if tripletList[k][2] == triplet[0] && zeroFound == false {
	// 							zeroFound = true
	// 							duplicate = true
	// 						} else if tripletList[k][2] == triplet[1] && oneFound == false{
	// 							oneFound = true
	// 							duplicate = true
	// 						} else if tripletList[k][2] == triplet[2] && twoFound == false{
	// 							twoFound = true
	// 							duplicate = true
	// 						}
	// 					}
	// 				}

	// 				if duplicate == false {
	// 					tripletList = append(tripletList, triplet)
	// 				}
	// 			}
	// 		}
	// 	} 
	// }
	return tripletList
}