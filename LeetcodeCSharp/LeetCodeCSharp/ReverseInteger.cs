using System.IO.Pipelines;

public class ReverseIntegerTask
{

    private static ReverseIntegerTask reverseIntegerTask = null;
    private ReverseIntegerTask()
    {

    }

    public static ReverseIntegerTask GetInstance()
    {
        if (reverseIntegerTask == null)
        {
            return new ReverseIntegerTask();
        }
        return reverseIntegerTask;
    }

    public int Reverse(int x) {

        //this is slow. String reversal is also slow.
        //trying to minimize checks. We really care about how close we are to int.Min and int.Max
        //48%..not great.. but I gotta go so it's all I'm getting today
        int result = 0;
        while (x != 0)
        {
        if (result < int.MinValue/10 )
        {
            return 0;
        }
        else if (result > int.MaxValue/10)
        {
            return 0;
        }

            result = (result * 10) + (x % 10);
            x = x / 10;
        }
            

        return result;
    }
}