// See https://aka.ms/new-console-template for more information


    int[] nums =  { 0,0 };
    LongestConsecutive(nums);


    int LongestConsecutive(int[] nums)
    {
        int longconse = 1;
        Array.Sort(nums);
    int cntconse = 1;
        for (int i = 0; i < nums.Length - 1; i++)
        {
        if ((nums[i + 1] - nums[i]) == 1 )
        {
            cntconse++;
            if (cntconse > longconse)
            {
                longconse = cntconse;

            }
        }
        else if ((nums[i + 1] - nums[i])>1)
        {

            cntconse = 1;


        }

        }
    return longconse;
       
    }


