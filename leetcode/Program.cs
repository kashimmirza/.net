// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums1 = { 1, 2, 2, 2,1 };
        int[] nums2 = { 2, 2 };
        int[] result = solution.Intersect(nums1, nums2);
        Console.WriteLine("Intersection:");
        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }
}



public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        int[] resultedArray = new int[1000 * 1000];
        List<int> list = new List<int>();
        
       List<int>trackindex = new List<int>();
       for(int i = 0; i < nums1.Length; i++)
        {
            for(int j = 0; j < nums2.Length; j++)
            {   
                if (nums1[i] == nums2[j])
                {
                    if (!trackindex.Contains(j))
                    {
                        trackindex.Add(j);
                        list.Add(nums2[j]);
                    }
                }
            }
        }
        resultedArray = list.ToArray();
        return resultedArray;

    }
}
