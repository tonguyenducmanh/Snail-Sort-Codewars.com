using System.Linq;
using System;
using System.Collections.Generic;
public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        List<List<int>> listInput = new List<List<int>>();
        List<int> listOutput = new List<int>();
        int[] zero = new int[0];
        List<int> temp = new List<int>();
        int rowCount = array.Count();

        if (array.Length == 1 && array[0].Length != 0) { listOutput.Add(array[0][0]); }
        if (array.Length == 1 && array[0].Length == 0) { return zero; }
        if (array.Length >= 2)
        {
            Console.WriteLine("co tong cong " + rowCount + " hang");
            foreach (int[] row in array)
            {
                listInput.Add(row.ToList());
                Console.WriteLine(String.Join(" , ", row));
            }
            if (array.Length > 1)
            {
                while ( listInput.Count()> 0)
                {
                    //thêm toàn bộ từ hàng 1, xóa hàng 1 ở mảng cũ đầu tiên

                    for (int j = 0; j < listInput[0].Count(); j++)
                    {
                        listOutput.Add(listInput[0][j]);
                    }
                    listInput.Remove(listInput[0]);

                    //thêm các ô cuối từ hàng 2 tới hàng dưới cùng, xóa các ô cuối ở mảng cũ đầu tiên
                    for (int j = 0; j < listInput.Count(); j++)
                    {
                        listOutput.Add(listInput[j].LastOrDefault());
                    }
                    for (int j = 0; j < listInput.Count(); j++)
                    {
                        listInput[j].RemoveAt(listInput.Count());
                    }

                    //thêm toàn bộ từ hàng cuối, xóa hàng cuối
                    for (int j = 0; j < listInput.Count(); j++)
                    {
                        listOutput.Add(listInput.LastOrDefault()[listInput.Count() - 1 - j]);
                    }
                    listInput.Remove(listInput.LastOrDefault());

                    //thêm các ô đầu từ hàng 2 ở dưới lên hàng đầu.
                    for (int j = 0; j < listInput.Count(); j++)
                    {
                        temp.Add(listInput[j].FirstOrDefault());
                        Console.WriteLine(listInput[j].FirstOrDefault());
                    }
                    for (int j = 0; j < listInput.Count(); j++)
                    {
                        listInput[j].RemoveAt(0);
                    }
                    for (int j = 0; j < temp.Count(); j++)
                    {
                        listOutput.Add(temp[temp.Count() - 1 - j]);
                    }
                    temp.Clear();

                }

            }
        }
        
        return listOutput.ToArray();
    }
}
public class Program
    {
    static void Main(string[] args)
    {
        int[][] array =
        {
/*            new []{1,2,3,4,5,6},
           new []{20,21,22,23,24,7},
           new []{19,32,33,34,25,8},
           new []{18,31,36,35,26,9},
           new []{17,30,29,28,27,10},
           new []{16,15,14,13,12,11}*/
/*           new []{1,2,3,4,5},
           new []{16,17,18,19,6},
           new []{15,24,25,20,7},
           new []{14,23,22,21,8},
           new []{13,12,11,10,9}*/
           new []{1,2,3},
           new []{4,5,6},
           new []{7,8,9},
        };
        var result = SnailSolution.Snail(array);
            Console.WriteLine(String.Join(',',result));
        }
    }



