namespace InversePermutation
{
    public class Permutation
    {
     public  static int[] InversePermutation(int[] arr, int size)
        {
            int[] arr2 = new int[size];
            for (int i = 0; i < size; i++)
                arr2[arr[i] - 1] = i + 1;

            return arr2;

        }
    }
}