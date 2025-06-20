package main

//Known constraint of the problem was that 1 <= int <= 3999. Would need code changes to handle 4000+ or negatives, 0 returns ""
func intToRoman(num int) string {
    
	digit := 0
	outputString := ""
	ones := ""
	fives := ""
	nextOnes := ""
	for num > 0{
		onesDigit := num % 10
		num = num/10
		if digit == 0 {
			ones = "I"
			fives = "V"
			nextOnes = "X"
		} else if digit == 1 {
			ones = "X"
			fives = "L"
			nextOnes = "C"
		} else if digit == 2 {
			ones = "C"
			fives = "D"
			nextOnes = "M"
		} else if digit == 3 {
			ones = "M"
			fives = ""
			nextOnes = ""
		}
		if onesDigit == 9 {
			outputString = ones + nextOnes + outputString
		} else if onesDigit > 5 {
			if onesDigit == 8 {
				outputString = fives + ones + ones + ones + outputString
			} else if onesDigit == 7 {
				outputString = fives + ones + ones + outputString
			} else {
				outputString = fives + ones + outputString
			}
		} else if onesDigit == 5 {
			outputString = fives + outputString
		} else if onesDigit == 4 {
			outputString = ones + fives + outputString
		} else if onesDigit > 0 {
			if onesDigit == 3 {
				outputString = ones + ones + ones + outputString
			} else if onesDigit == 2 {
				outputString = ones + ones + outputString
			} else {
				outputString = ones + outputString
			}
		}

		digit++
	}
	return outputString
}