public class RemoveElementTask {

    private static RemoveElementTask removeElementTask = null;
    private RemoveElementTask() {

    }

    public static RemoveElementTask GetInstance() {
        if (removeElementTask == null)
        {
            return new RemoveElementTask();
        }
        return removeElementTask;    
     }

    public int RemoveElement(int[] nums, int val) {
        int cursor = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
            {

            }
            else
            {
                nums[cursor] = nums[i];
                cursor++;
            }

        }
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write(nums[i] + ", ");
         }
        Console.Write("\n");
        return cursor;
    }
}