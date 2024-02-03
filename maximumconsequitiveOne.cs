// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int[] nums = {1,1,0,1,1,1};
int maximumn = 0;
int cnt = 0;
for (int i = 0; i < nums.Length; i++)
{
    int j = 0;

    if (nums[i] == 1)
    {
        cnt++;
    }
    if (i == nums.Length - 1)
    {
        if (cnt > maximumn)
        {
            maximumn = cnt;

        }
    }
    else if (nums[i] == 0)
    {
        if (cnt > maximumn)
        {
            maximumn = cnt;
            cnt = 0;
        }
    }
}

