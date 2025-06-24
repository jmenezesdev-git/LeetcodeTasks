
using System.Globalization;
using System.Text.RegularExpressions;
using System.Transactions;

public class ManualRegexTask
{

    private static ManualRegexTask manualRegexTask = null;
    private ManualRegexTask()
    {

    }

    public static ManualRegexTask GetInstance()
    {
        if (manualRegexTask == null)
        {
            return new ManualRegexTask();
        }
        return manualRegexTask;
    }

    //This is faster but I'm lost as to how it can be improved
    private bool IsMatchCharRecursive(string searchString, string pattern, int stringIndex, int patternIndex)
    {
        //just noticed that we don't care if it's NOT a-z

        if (patternIndex == pattern.Length)
        {
            if (stringIndex == searchString.Length)
            {
                return true;
            }
            return false;
        }

        bool currentCharMatch = (stringIndex < searchString.Length) && (pattern[patternIndex] == '.' || (searchString[stringIndex] == pattern[patternIndex])) ; //using this match far too often
        bool nextCharWildCard = pattern.Length - 1 >= patternIndex + 1 && pattern[patternIndex + 1] == '*'; //using this match twice far too often

        if (!currentCharMatch && nextCharWildCard)
        {
            return IsMatchCharRecursive(searchString, pattern, stringIndex, patternIndex + 2); //skip wildcard set
        }
        else if (currentCharMatch && nextCharWildCard)
        {
            if (IsMatchCharRecursive(searchString, pattern, stringIndex + 1, patternIndex) || IsMatchCharRecursive(searchString, pattern, stringIndex, patternIndex + 2))
            {//increment string matching OR attempt to treat like match 0
                return true;
            }
            else
            {
                return false;
            }
            ;
        }
        else if (currentCharMatch)
        {
            return IsMatchCharRecursive(searchString, pattern, stringIndex + 1, patternIndex + 1);
        }
        else    //No character match, no wild card
        {
            return false;
        }

    }


    public bool IsMatch(string s, string p)
    {
        //Whole String approach is mega slow, this might be a case where Leetcode DOESN'T punish function calls.
        //This is faster but I'm lost as to how it can be improved
        //return IsMatchCharRecursive(s, p, 0, 0);

        //This is only a "beats 33.72%" script? I've tried 3 ways and it's been 3hours
        //There is surely some massive optimization issue I'm encountering given that it looks like 9/10 people are using a 0ms strat. Not sure I have the right idea
        return Regex.IsMatch(s, "^" + p + "$");




        // Console.WriteLine("Called IsMatch with String = " + s + " and Pattern = " + p);
        // if (p.Contains('*')) //are things complicated?
        // {
        //     int patternIndex = 0;
        //     int cursor = 0;
        //     while (patternIndex < p.Length - 1)
        //     {   //what do we do for a*a*a*a?
        //         //Letter or period with no wildcard
        //         if ((p[patternIndex] == '.' || (p[patternIndex] >= 'a' && p[patternIndex] <= 'z')) && p.Length - 1 >= patternIndex + 1 && p[patternIndex + 1] != '*')
        //         {
        //             Console.WriteLine("Inside Solo Letter Match for char");
        //             if (s.Length > cursor && (p[patternIndex] == '.' || p[patternIndex] == s[cursor]))
        //             {
        //                 patternIndex++;
        //                 cursor++;
        //             }
        //             else
        //             {
        //                 return false;
        //             }
        //         }
        //         else if ((p[patternIndex] == '.' || (p[patternIndex] >= 'a' && p[patternIndex] <= 'z')) && p.Length - 1 >= patternIndex + 1 && p[patternIndex + 1] == '*')
        //         {
        //             bool moreMatches = false;
        //             if (p.Length - 1 >= patternIndex + 2)
        //             {
        //                 moreMatches = true;
        //             }
        //             Console.WriteLine("moreMatches = " + moreMatches);


        //             int greedMatch = 0;
        //             if (p[patternIndex] == '.')
        //             {
        //                 greedMatch = s.Length - cursor;
        //             }
        //             else
        //             {
        //                 for (int i = cursor; i < s.Length; i++)
        //                 {
        //                     if (s[i] == p[patternIndex])
        //                     {
        //                         greedMatch++;
        //                     }
        //                     else if (s[i] != p[patternIndex])
        //                     {
        //                         if (moreMatches == true)
        //                         {
        //                             break;
        //                         }
        //                         else
        //                         {
        //                             return false;
        //                         }
        //                     }
        //                 }
        //             }

        //             while (greedMatch > -1)
        //             {
        //                 if (IsMatch(s.Substring(cursor + greedMatch), p.Substring(patternIndex + 2)))
        //                 {
        //                     return true;
        //                 }
        //                 else
        //                 {
        //                     greedMatch--;
        //                 }
        //             }
        //             return false;

        //         }
        //     }
        // }
        // else if (p.Contains('.'))
        // {
        //     if (p.Length != s.Length)
        //     {
        //         return false;
        //     }
        //     for (int i = 0; i < s.Length; i++)
        //         {
        //             if (s[i] != p[i] && p[i] != '.')
        //             {
        //                 return false;
        //             }
        //         }
        // }
        // else if (String.Compare(s, p) != 0) //Things are simple, do a linear comparison
        // {
        //     return false;
        // }
        // return true;
    }

}