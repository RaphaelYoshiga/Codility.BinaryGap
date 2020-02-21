using System;
using Shouldly;
using Xunit;

namespace Codility.BinaryGap.UnitTests
{
    public class BinaryGapShould
    {
        private readonly BinaryGapFinder _binaryGapFinder;

        public BinaryGapShould()
        {
            _binaryGapFinder = new BinaryGapFinder();
        }

        [Theory]
        [InlineData("1", 0)]
        [InlineData("10", 0)]
        [InlineData("100000", 0)]
        public void FindNoGaps(string binary, int largestGap)
        {
            var findBinaryGap = _binaryGapFinder.FindBinaryGap(binary);

            findBinaryGap.ShouldBe(largestGap);
        }


        [Theory]
        [InlineData("101", 1)]
        [InlineData("1001", 2)]
        [InlineData("100001", 4)]
        public void CalculateBinaryGaps(string binary, int largestGap)
        {
            var findBinaryGap = _binaryGapFinder.FindBinaryGap(binary);

            findBinaryGap.ShouldBe(largestGap);
        }


        [Theory]
        [InlineData("1010001", 3)]
        [InlineData("10010001", 3)]
        [InlineData("10101000", 1)]
        public void CalculateWithManyGaps(string binary, int largestGap)
        {
            var findBinaryGap = _binaryGapFinder.FindBinaryGap(binary);

            findBinaryGap.ShouldBe(largestGap);
        }
    }
}
