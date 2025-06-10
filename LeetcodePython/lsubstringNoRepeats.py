class Solution:

    def lengthOfLongestSubstring(s: str) -> int:
        print (s)
        if len(s) <= 1:
            return len(s)
        else:
            arrayMax = 0
            currentArray = []
            for c in s:
                duplicateStatus = -1
                for charIndex, char in enumerate(currentArray):
                    if char == c:
                        duplicateStatus = charIndex
                
                if duplicateStatus == -1:
                    currentArray.append(c)
                else:
                    currentArray = currentArray[duplicateStatus+1:len(currentArray)]
                    currentArray.append(c)
                
                if arrayMax < len(currentArray):
                    arrayMax = len(currentArray)
            return arrayMax

    if __name__ == "__main__":
        print(str(lengthOfLongestSubstring("abcabcbb")))
        print(str(lengthOfLongestSubstring("")))
        print(str(lengthOfLongestSubstring("pwwkew")))
