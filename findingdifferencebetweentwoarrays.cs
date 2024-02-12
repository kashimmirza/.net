// See https://aka.ms/new-console-template for more information

int[] Array1 = new int[] { 1, 2, 3 };

int[] Array2 = new int[] { 2, 3 };
FindDifference(Array1, Array2);









IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
{



    int length = 0;
    List<int> finalResult = new List<int>();
    List<int> resulteddup1 = new List<int>();
    List<int> resulteddup2 = new List<int>();
    HashSet<int> resulteddup = new HashSet<int>();


    for (int i = 0; i < nums1.Length; i++)
    {
        for (int j = 0; j < nums2.Length; j++)
        {
            if (nums1[i] == nums2[j])
            {
                resulteddup.Add(nums1[i]);


            }
        }
    }
    for (int i = 0; i < nums1.Length; i++)
    {
        if (!resulteddup.Contains(nums1[i]))
        {
            if (!resulteddup1.Contains(nums1[i]))
            {
                resulteddup1.Add(nums1[i]);
            }
        }
    }

    for (int i = 0; i < nums2.Length; i++)
    {
        if (!resulteddup.Contains(nums2[i]))
        {
            if (!resulteddup2.Contains(nums2[i]))
            {
                resulteddup2.Add(nums2[i]);


            }
        }
    }

    IList<IList<int>> resultList = new List<IList<int>>();
    resultList.Add(resulteddup1);
    resultList.Add(resulteddup2);



    return resultList;
}



