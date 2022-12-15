using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Utils
{
    public static List<List<int>> MatrixToList(List<List<List<List<int>>>> matrix)
    {
        int count = 0;
        int offset = 0;
        var dict = new Dictionary<int, List<int>>();
        var h_size = matrix.Count;
        var w_size = matrix[0].Count;
        for (int index = 0; index < h_size; index++)
        {
            for (int subIndex = 0; subIndex < w_size; subIndex++)
            {
                List<List<int>> entry = matrix[index][subIndex];
                int h_es = entry.Count;
                int w_es = entry[0].Count;
                offset = h_es;
                for (int ei = 0; ei < h_es; ei++)
                {
                    int key = count + ei;
                    if (!dict.ContainsKey(key)) dict.Add(key, new List<int>());
                    for (int esi = 0; esi < w_es; esi++)
                    {
                        dict[key].Add(entry[ei][esi]);
                    }
                }
            }
            count += offset;
        }

        var ans = new List<List<int>>();
        foreach(var key in dict.Keys)
        {
            ans.Add(dict[key]);
        }
        return ans;
    }
}
