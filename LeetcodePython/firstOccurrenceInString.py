####Pretty sure this is a waste of time in Python, why would...yup optimal solution
class Solution:
    def strStr(haystack: str, needle: str) -> int:
        return haystack.find(needle)

    if __name__ == "__main__":  

        haystack = "sadbutsad"
        needle = "sad"
        print("haystack = " + haystack + " needle = " + needle + " output = " + str(strStr(haystack, needle)))
        haystack = "leetcode"
        needle = "leeto"
        print("haystack = " + haystack + " needle = " + needle + " output = " + str(strStr(haystack, needle)))
