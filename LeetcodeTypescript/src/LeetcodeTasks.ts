

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

export function GenerateParenthesisTask(){
    generateParenthesis(3);
}

//Initial Solution works but is slow (10%, 13%)
//Optimization of joins lead to faster but still slow (19%, 13%) results
//Moved countLeft and countRight to function signature (49%, 39%)
//Moved n > 0 check outside recursion (73%, 17%)
//Tried nesting functions to reduce number of passed parameters but it returned worse results (48%, 25%)
function generateParenthesis(n: number): string[] {
    if(n > 0){
        return parenthesisGenerator(n, "(", 1, 0);
    }
    return [];
};

function parenthesisGenerator(n: number, currentString: string, countLeft: number, countRight: number):string[]{
    if (countLeft == n && countRight == n){
        var returnArray: string[] = [currentString];
        return returnArray;
    }

    if (countLeft < n){
        var returnArray: string[] = parenthesisGenerator(n, currentString + "(", countLeft+1, countRight);

        if (countLeft > countRight){
            returnArray = [...returnArray, ...parenthesisGenerator(n, currentString + ")", countLeft, countRight+1)];

        }
        return returnArray;
    } else if (countLeft == n){
        return parenthesisGenerator(n, currentString + ")", countLeft, countRight+1);
    }
    return [];
}



class ListNode {
    val: number
    next: ListNode | null
    constructor(val?: number, next?: ListNode | null) {
        this.val = (val===undefined ? 0 : val)
        this.next = (next===undefined ? null : next)
    }
}

///Real PITA - tried 3-pointer solution for ages before giving up and going with 4 bit of cleanup got us to 100%/55%
export function SwapPairsTask(){
    console.log(swapPairs(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, null))))));
}
 

function swapPairs(head: ListNode | null): ListNode | null {    
    if (head == null){
        return null
    } else if (head.next == null){
        return head
    }

    var newHead: ListNode | null = null; // Not sure why but we can't use head without something breaking in the pointer system. (ie head = ptr2)
    var prevPtr: ListNode | null = null; //Tried a three-pointer method but I couldn't get it working so now we have 4
    var ptr1: ListNode | null = head;
    
    while (ptr1 != null && ptr1.next != null) {
        var ptr2: ListNode | null = ptr1.next;
        var ptr3: ListNode | null = ptr1.next.next;
        
        ptr1.next = ptr3;
        if (ptr2 != null) {
            ptr2.next = ptr1;
        }
        if (prevPtr != null) {
            prevPtr.next = ptr2;
        } else {
            newHead = ptr2;
        }
        prevPtr = ptr1;
        ptr1 = ptr3; 
    }
    
    return newHead;



};

export function MergeKListsTask(){
    
    var list: ListNode | null = new ListNode(1, new ListNode(4, new ListNode(5, null)));
    var lists: Array<ListNode | null> = [];
    lists.push(list); 
    list = new ListNode(1, new ListNode(3, new ListNode(4, null)));
    lists.push(list); 
    list = new ListNode(2, new ListNode(6, null));
    lists.push(list); 
    console.log(mergeKLists(lists));


}

//first attempt beats 30% - not bad! Main issue is probably how many times it loops through the array
//second attempt tracks previousLowest value to save on array iteration (beats 38%,63%)
//thought up a couple ways to optimize iterations but unlikely to massively increase performance. looking at solutions for an idea

//Ah, offical solution loads all values into a 1d array, sorts by val, then adjusts their nexts to point at whatever's next in the array - a cunning rework, but not for today!
function mergeKLists(lists: Array<ListNode | null>): ListNode | null {

    if (lists.length == 0){
        return null;
    }
    var newHead: ListNode | null = null;
    var prevPtr: ListNode | null = null;

    var lowestVal = Number.MAX_SAFE_INTEGER;
    var previousLowest = Number.MAX_SAFE_INTEGER;
    var index = -1;
    var firstRun = true;
    var secondRun = true;
    var indexPtr = null;
    var tIndex = -1
    if (lists.length > 0){
        while (lowestVal != Number.MAX_SAFE_INTEGER || index != -1 || firstRun || secondRun){
            lowestVal = Number.MAX_SAFE_INTEGER;
            index = -1;
            for (var i = 0; i<lists.length;i++){
                var list = lists[i];
                if (list != null){
                    if (!firstRun && previousLowest == list.val){
                        lowestVal = list.val;
                        index = i;
                        indexPtr = list;
                        break;
                    }
                    if (list.val < lowestVal){
                        lowestVal = list.val;
                        index = i;
                        indexPtr = list;
                        previousLowest = lowestVal;
                    }
                }
                
            }
            if (firstRun){
                firstRun = false;
            } else if (secondRun){
                secondRun = false;
            }
            if (index != -1){
                if (newHead == null || prevPtr == null){
                    if (indexPtr != null){
                        prevPtr = new ListNode(indexPtr.val, null);
                        
                        newHead = prevPtr;
                        lists[index] = indexPtr.next;
                    }
                } else {
                    if (indexPtr != null){
                        prevPtr.next = new ListNode(indexPtr.val, null);
                        prevPtr = prevPtr.next;
                        lists[index] = indexPtr.next;
                    }
                }
            }
        }
    }

    return newHead;
};
