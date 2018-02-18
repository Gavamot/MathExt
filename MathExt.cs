using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Gause
{
    public static class MyMath
    {
        public static int NOD(IEnumerable<int> n)
        {
            return NOD(n.ToArray());
        }

        public static int NOD(params int[] n)
        {
            int min = n.Min(), i;
            for (i = min; i > 0; i--)
            {
                bool reminderIsZero = true;
                for (int j = 0; j < n.Length; j++)
                    reminderIsZero &= n[j] % i == 0;
                if (reminderIsZero) break;
            }
            return i;
        }

        [TestFixture]
        private class MyMathTest
        {
            [TestCase(1, 44, 43)]
            [TestCase(10, 20, 50)]
            [TestCase(10, 20, 50)]
            [TestCase(0, 0, 10)]
            [TestCase(100, 100, 100)]
            [TestCase(3, 3, 3, 3, 3, 3)]
            [TestCase(3, 12, 6, 12, 3)]
            public void NODCorrect(int actual, params int[] n)
            {
                Assert.AreEqual(actual, NOD(n));
            }

            [TestCase(2, 44, 43)]
            [TestCase(16, 20, 50)]
            [TestCase(5, 20, 50)]
            public void NODUnCorrect(int actual, params int[] n)
            {
                Assert.AreNotEqual(actual, NOD(n));
            }
        }
    }
}
