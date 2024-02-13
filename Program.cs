
using System;
using System.Collections.Generic;
using System.Linq;



public partial class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums1 = { 1, 2, 2, 1 };
        int[] nums2 = { 2, 2 };
        int[] result = solution.Intersect(nums1, nums2);
        Console.WriteLine("Intersection:");
        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }
}