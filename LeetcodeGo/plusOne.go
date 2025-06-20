package main

func plusOne(digits []int) []int {
	lastIndex := len(digits)-1
	if digits[lastIndex] < 9{
		digits[lastIndex]++
		return digits
	} else{
		for lastIndex >= 0 && digits[lastIndex] == 9{
			digits[lastIndex] = 0
			lastIndex--
		}
		if lastIndex == -1{
			return append([]int{1}, digits...)
		} else {
			digits[lastIndex]++
			return digits
		}
	}
	return digits
}