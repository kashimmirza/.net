public class Solution
{
    public IList<int> Intersection(int[][] nums)
    {
        List<int> list = new List<int>();
        List<int> resultedlist = new List<int>();
        int counti = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums[i].Length; j++)
            {
                list.Add(nums[i][j]);
                counti = list.Count(num => num == nums[i][j]);
                if (counti == nums.Length)
                {
                    resultedlist.Add(nums[i][j]);
                }
            }
        }
        resultedlist.Sort();
        return resultedlist;

    }
}