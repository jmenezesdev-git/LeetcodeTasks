class Solution:
    def isValid(s: str) -> bool:
        stack = []
        for c in s:
            if c == "(" or c == "{" or c == "[":
                stack.append(c)
            if c == ")" or c == "}" or c == "]":
                
                if len(stack) < 1:
                    return False
                else:
                    latestItem = stack[-1]
                if c == ")" and latestItem == "(":
                    stack.pop()
                elif c == "}" and latestItem == "{":
                    stack.pop()
                elif c == "]" and latestItem == "[":
                    stack.pop()
                else:
                    return False
        if len(stack) > 0:
            return False
        return True
    
    if __name__ == "__main__":
        print(isValid(""))
