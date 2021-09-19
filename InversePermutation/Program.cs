using System;

namespace InversePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {2, 3, 4, 5, 1};
            int size = arr.Length;
            
          var inverse = Permutation.InversePermutation(arr, size);
            for (int i = 0; i < size; i++)
                Console.Write(inverse[i]);
            
            Console.ReadKey();
        }

    
    }
}