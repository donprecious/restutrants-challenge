using InversePermutation;
using Xunit;

namespace Test.InversePermutation
{
    public class TestInversePermutation
    {
        [Theory]
        [InlineData( new int[] {1, 4, 3, 2}, new int[] {1, 4, 3, 2})]
        [InlineData(new int[] {2, 3, 4, 5, 1}, new int[] {5, 1, 2, 3, 4})]
        public void ShouldComputeInvese(int[] input, int[] output)
        {
            // arrange
           
            // act 
            var reverse = Permutation.InversePermutation(input, output.Length); 
            // assert 
            Assert.Equal(output, reverse);
        }

    }
}