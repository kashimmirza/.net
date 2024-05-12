
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

        string[] words = { "bella", "label", "roller" };
        CommonCharacters bb = new CommonCharacters();
        bb.CommonChars(words);

    }
}