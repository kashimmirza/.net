



int[] Array1 = new int[] { 1, 2, 3 };

int[] Array2 = new int[] { 2, 3 };
    Intersection(Array1, Array2);
    

    int[] Intersection(int[] nums1, int[] nums2)
    {

        int length = 0;
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
        int k = 0;
        int[] result = new int[resulteddup.Count];
        foreach (var a in resulteddup)
        {
            result[k] = a;
            k++;
        }


        return result;
    }


