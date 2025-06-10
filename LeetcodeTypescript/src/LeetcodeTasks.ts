

    export function RemoveDuplicatesSortedTask() {

    //Leetcode checks the contents of nums but only the first n places for some reason - rendering this solution inefficient
    //array.filter doesn't work here.
    console.log("Remove Duplicates 1, 1, 2 = " + RemoveDuplicates([1, 1, 2]));
    console.log("Remove Duplicates 0,0,1,1,1,2,2,3,3,4 = " + RemoveDuplicates([0,0,1,1,1,2,2,3,3,4]));
    console.log("Remove Duplicates 1, 1, 2 = " + RemoveDuplicates([1, 1, 2]));

}

export function RemoveDuplicates(nums: number[]): number {

    if (nums.length <= 1){
        return nums.length;
    }
    var i = 1;
    var j = 0;
    while (i<nums.length){
        if(nums[i] == nums[j]){
            nums.splice(i, 1);
        }
        else{
            i++;
            j++;
        }

    }

    return nums.length;
};

export function LongestPalindromeTask() {

    //Leetcode checks the contents of nums but only the first n places for some reason - rendering this solution inefficient
    //array.filter doesn't work here.
    console.log("Longest Palindrome Substring of babad = " + LongestPalindrome("babad"));
    console.log("Longest Palindrome Substring of cbbd = " + LongestPalindrome("cbbd"));
    console.log("Longest Palindrome Substring of ac = " + LongestPalindrome("ac"));
    //console.log("Longest Palindrome Substring of gjesiosskk = " + removeDuplicates([1, 1, 2]));

}

function LongestPalindrome(s: string): string {
    if (s.length <= 1){
        return s;
    }
    var longestPalindrome = s.substring(0, 1);
    
    for (let i = 0;i<s.length;i++){


        //This approach is too slow, sub 50%. Reworking.
        // var index = HasDuplicateAtIndex(i, s, s[i]);
        // if (index != -1){
        //     while (index != -1){
        //             if ((index-i) + 1 > longestPalindrome.length && IsPalindrome(s, i, index)){
        //                 longestPalindrome = s.substring(i, index+1);
        //             }
        //         var index = HasDuplicateAtIndex(index, s, s[i]);
        //     }
        // }

        longestPalindrome = ExpansionMethodPalindrome(s, i, longestPalindrome);
    }
    return longestPalindrome;
};

function ExpansionMethodPalindrome(s: string, i:number, longestPalindrome: string): string{
    var noMiddlePalindrome =  Expand(s, i, i+1);
    var middlePalindrome =  Expand(s, i, i);
    if (noMiddlePalindrome.length > middlePalindrome.length){
        if (noMiddlePalindrome.length > longestPalindrome.length){
            return noMiddlePalindrome;
        }
    }
    else {
        if (middlePalindrome.length > longestPalindrome.length){
            return middlePalindrome;
        }
    }
        
    return longestPalindrome;
}

function Expand(s: string, startIndex: number, endIndex: number): string {
        while (startIndex >= 0 && endIndex < s.length && s[startIndex] == s[endIndex]) {
            endIndex++;
            startIndex--;
        }

        return s.substring(startIndex + 1, endIndex);
    }

function IsPalindrome(s: string, startIndex: number, endIndex: number): boolean{
    while (startIndex<endIndex){
        if (s[startIndex] != s[endIndex]){
            return false;
        }
        else{
            startIndex++;
            endIndex--;
        }
    }
    return true;
}

function HasDuplicateAtIndex(startIndex: number, s: string, ch: string): number{
    for(let i = startIndex+1; i<s.length;i++){
        if(ch == s[i]){
            return i;
        }
    }
    return -1;
}

export function ZigZagConvertTask(){
    console.log("ZigZagConversion of PAYPALISHIRING 3 = " + ZigConvert("PAYPALISHIRING", 3));
    console.log("ZigZagConversion of PAYPALISHIRING 4 = " + ZigConvert("PAYPALISHIRING", 4));
    console.log("ZigZagConversion of ABCDE 4 = " + ZigConvert("ABCDE", 4));
}

function ZigConvert(s: string, numRows: number): string {
    if (numRows == 1 || numRows >= s.length){
        return s;
    }

//This solution is 30%/30% there are major optimization faults in this. Likely need to execute in O(n) time.
/*var modulator = 2 * (numRows - 1);
    let array: string[] = [];
    for (var i=0;i<s.length;i++){
        var modulo = (i+1)%modulator;
        if (array.length<modulator){
            array.push(s[i]);
        }
        else{
            if (modulo == 0){
                array[modulator-1] = array[modulator-1].concat(s[i]);
            }
            else{
                array[modulo-1] = array[modulo-1].concat(s[i]);
            }
        }
    }

    var returnString = "";
    
    for(var i=0;i<numRows;i++){
        if(i == 0 || i == numRows-1){
            returnString = returnString.concat(array[i]);
        }
        else{
            for(var j=0; j<array[i].length;j++){
                
                if (array.length < modulator){
                    if (array.length <= (modulator-(i-1))-1 ){
                        returnString = returnString.concat(array[i][j]);
                    }
                    else{
                        returnString = returnString + array[i][j] + array[(modulator-(i-1))-1][j];
                    }
                }
                else if (array[(array.length-(i-1))-1].length > j){
                    returnString = returnString + array[i][j] + array[(array.length-(i-1))-1][j];
                }
                else{
                    returnString = returnString.concat(array[i][j]);
                }
            }
        }
    }*/






    let array: string[] = new Array(numRows).fill('');
    var rowSelector = -1;
    var climbingUp = false;
    for (var i=0;i<s.length;i++){
        if (climbingUp){
            rowSelector--;
        } else{
            rowSelector++;
        }
        array[rowSelector] +=s[i]

        if (rowSelector == numRows - 1){
            climbingUp = true;
        } else if (rowSelector == 0){
            climbingUp = false;
        }
    }
    //Apparently this is super inefficient
    // var returnString = "";
    // for(var i=0;i<numRows;i++){
        
    //     returnString += array[i];
            
    // }
    // return returnString;
    return array.join('');

};
