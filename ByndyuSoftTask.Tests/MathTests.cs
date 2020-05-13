using System;
using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ByndyuSoftTask.Tests
{
    public class MathTests
    {
        private Math _math;
        private int[] _largeArray;

        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [TestCase(new int[] { 1, 12, 10 }, 11)]
        [TestCase(new int[] { -1, -21, -10 }, -31)]
        [TestCase(new int[] { 0, 12 }, 12)]
        [TestCase(new int[] { 1, 2, 2, 2, 2, }, 3)]
        [TestCase(new int[] { 1, 7, 3, 5, 6, }, 4)]
        [TestCase(new int[] { 4, 0, 3, 19, 492, -10, 1 }, -10)]
        [TestCase(new int[] { 10, -122, 9 }, -113)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 }, 0)]
        [TestCase(new int[] { 1, 12, -12, -14 }, -26)]
        public void NormalInputArray(int[] array, int outputExpected)
        {
            var output = _math.SumTwoMinIntInArray(array);
            Assert.AreEqual(outputExpected, output);
        }

        [TestCase(new int[] { })]
        [TestCase(null)]
        [TestCase(new int[] { 0 })]
        public void InvalidInputArray(int[] array)
        {
            Assert.Catch(() => _math.SumTwoMinIntInArray(array));
        }

        [Test]
        public void LargeDataArrayTime()
        {
            var random = new Random();
            _largeArray = new int[2000000000];
            var timer = new Stopwatch();

            for (var i = 0; i < _largeArray.Length; i++)
                _largeArray[i] = random.Next();

            timer.Start();
            _math.SumTwoMinIntInArray(_largeArray);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 100000, $"Время поиска на 2х миллиардах не удовлетворяет условию: {timer.ElapsedMilliseconds} < 100000");
        }
    }
}