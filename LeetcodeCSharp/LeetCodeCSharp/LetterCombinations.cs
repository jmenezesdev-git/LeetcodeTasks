using System.Reflection.Metadata.Ecma335;

public class LetterCombinationsTask
{

    private static LetterCombinationsTask letterCombinationsTask = null;
    private LetterCombinationsTask()
    {

    }

    public static LetterCombinationsTask GetInstance()
    {
        if (letterCombinationsTask == null)
        {
            return new LetterCombinationsTask();
        }
        return letterCombinationsTask;
    }

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length > 0)
        {
            List<string> returnValues = new List<string>();
            returnValues = RecLetterCombinationGen(digits, 0, "", returnValues);
            return returnValues;
        }
        return new List<string>();


    }

    private List<string> RecLetterCombinationGen(string digits, int index, string currLetters, List<string> returnValues)
    {
        
        if (index == digits.Length - 1)
        {
            //Last values
            foreach (char c in GenerateRelatedChars(digits[index]))
            {
                returnValues.Add(currLetters + c);    
            }
            return returnValues;
        }
        else
        {
            foreach (char c in GenerateRelatedChars(digits[index]))
            {
                RecLetterCombinationGen(digits, index+1, currLetters + c, returnValues);   
            }
            
        }
        return returnValues;

    }

    private List<char> GenerateRelatedChars(char digit) {
        List<char> returnValues = new List<char>();
        if (digit == '2')
        {
            returnValues.Add('a');
            returnValues.Add('b');
            returnValues.Add('c');
        }
        else if (digit == '3')
        {
            returnValues.Add('d');
            returnValues.Add('e');
            returnValues.Add('f');
        }
        else if (digit == '4')
        {
            returnValues.Add('g');
            returnValues.Add('h');
            returnValues.Add('i');
        }
        else if (digit == '5')
        {
            returnValues.Add('j');
            returnValues.Add('k');
            returnValues.Add('l');
        }
        else if (digit == '6')
        {
            returnValues.Add('m');
            returnValues.Add('n');
            returnValues.Add('o');
        }
        else if (digit == '7')
        {
            returnValues.Add('p');
            returnValues.Add('q');
            returnValues.Add('r');
            returnValues.Add('s');
        }
        else if (digit == '8')
        {
            returnValues.Add('t');
            returnValues.Add('u');
            returnValues.Add('v');
        }
        else if (digit == '9')
        {
            returnValues.Add('w');
            returnValues.Add('x');
            returnValues.Add('y');
            returnValues.Add('z');
        }
        return returnValues;
    }

}