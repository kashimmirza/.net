// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml;

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums1 = { 1, 2, 2, 2, 1 };
        int[] nums2 = { 2, 2 };
        int[] result = solution.Intersect(nums1, nums2);
        Console.WriteLine("Intersection:");
        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
        int[] nums = { 1,2 };
        int k = 2;
        Solution1 solution2 = new Solution1();
        solution2.FindKthLargest(nums, k);
        int[] arr = { 3,5,5};
        Solutionval solutionvalid = new Solutionval();
        solutionvalid.ValidMountainArray(arr);
        Solutionduplicate solutionduplicate = new Solutionduplicate();
        solutionduplicate.RemoveDuplicates(nums);



    }
}

public class Solution1
{
    public int FindKthLargest(int[] nums, int k)
    {
        if (k < 1 || k > nums.Length)
            throw new ArgumentException("Invalid value of k");

        List<int>list = new List<int>();
        foreach (int num in nums)
        {
            list.Add(num);

        }
        return quickselect(list, k);
    }
    public int quickselect(List<int>nums, int k)
    {
        
        Random random = new Random();
        int pivotindex = random.Next(nums.Count);
        int pivot = nums[pivotindex];

        List<int>Left = new List<int>();
        List<int>Right = new List<int>();
        List<int>medium = new List<int>();
        foreach(int num in nums)
        {
            if (num > pivot)
            {
                Left.Add(num);
            }
            else if (num < pivot)
            {
                Right.Add(num);
            }
            else
            {
                medium.Add(num);
            }
        }
        if (k <= Left.Count)
        {
            return quickselect(nums, k);
        }
        else if (k > Left.Count + medium.Count)
        {
            return quickselect(nums, k-Left.Count-medium.Count);
        }
        return pivot;




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

public class Solutionval
{
    public bool ValidMountainArray(int[] arr)
    {
        int cnt = 0;
        if (arr.Length < 3)
        {
            return false;
        }
        int maxelement = 0;
        int maxindex = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (maxelement < arr[i])
            {
                maxelement = arr[i];
                maxindex = i;
            }
        }
        for (int i = 0; i < arr.Length; i++)
        {
            if (maxelement == arr[i])
            {
                cnt++;
            }
        }
        if (maxindex == arr.Length - 1)
        {
            return false;
        }
        else if (maxindex == 0)
        {
            return false;
        }else if (cnt > 1)
        {
            return false;
        }
        
        int flag = 0;

        for (int i = 0; i < maxindex; i++)
        {
            if (arr[i] >= arr[i+1])
            {
                flag = -1;
            }
        }
        for (int i = maxindex+1; i < arr.Length-1; i++)
        {
            if (arr[i+1] >= arr[i])
            {
                flag = -1;
            }
        }


        if (flag == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}


public class Solutionduplicate
{
    public int RemoveDuplicates(int[] nums)
    {
        int k = findingUnique(nums)+1;
        int len = nums.Length;
        int[] expected = new int[k];
        int index = 0;
        for (int i = len - 2; i >= 0; i--)
        {
            if (i == 0 || nums[i] != nums[i + 1])
            {
                expected[index] = nums[i+1];
                index++;

            }
            else
            {
                len--;
            }
        }
        expected[k-1] = nums[0];
        Array.Sort(expected);
        for (int i = 0; i<expected.Length; i++)
        {
            nums[i] = expected[i];
        }
        for (int i = expected.Length; i < nums.Length; i++)
        {
            nums[i] = 0;
        }



        return k;

    }
    int findingUnique(int[] nums)
    {
        int unique = 0;

        int len = nums.Length;
        int index = 0;
        for (int i = len-2; i >= 0; i--)
        {
            if (i == 0 || nums[i] != nums[i + 1])
            {
                unique++;
                
                index++;

            }
            else
            {
                len--;
            }
        }
        return index;


    }
}

