using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AttackDragon.Extensions;

namespace AttackDragon.Testing
{
    public class AttackDragon
    {

        public TestResult TestMethod(MethodInfo method, object[] args, object instance = null)
        {
            try
            {
                var result = method.Invoke(instance, args);
                return new TestResult
                {
                    IsSuccess = true,
                    Message = "Method successfully invoked.",
                    Result = result
                };
            }
            catch(Exception ex)
            {
                return new TestResult
                {
                    IsSuccess = false,
                    Message = $"Method invocation failed due to {ex.Message}"
                };
            }
        }

        [Pure]
        public List<object[]> GetPossibleCalls(Type[] types)
        {
            if (types == null || types.Length == 0) return new List<object[]>();

            var testCases = new List<object[]>();

            var len = types.Length;

            foreach (var type in types)
            {
                testCases.Add(GetTestCases(type));
            }

            return FillList(testCases, len);
        }

        public List<object[]> FillList(List<object[]> testCases, int len)
        {
            var result = new List<object[]>();
            var maxes = testCases.Select(item => item.Length).ToArray();
            var currentIndexes = new int[testCases.Count];
            var halaat = testCases.Multiply(item => item.Length);
            for (int i = 0; i < halaat; i++)
            {
                var answer = new object[len];
                for (int j = 0; j < len; j++)
                {
                    answer[j] = testCases[j].ElementAt(currentIndexes[j]);
                }

                result.Add(answer);

                currentIndexes = IncrementSelectIndexes(currentIndexes, maxes, 0);
            }

            return result;
        }

        public void LetsGetResult()
        {
            var inc = IncrementSelectIndexes(
                    new int[] {1, 0, 1},
                    new int[] {2, 1, 5},
                    0
                );
        }

        [Pure]
        public int[] IncrementSelectIndexes(in int[] current, in int[] maxes, in int indexAt)
        {
            try
            {
                int[] newCurrent = new int[current.Length];
                current.CopyTo(newCurrent, 0);
                if (current[indexAt] < maxes[indexAt] - 1)
                {
                    newCurrent[indexAt]++;
                    return newCurrent;
                }
                else
                {
                    newCurrent[indexAt] = 0;
                    return IncrementSelectIndexes(newCurrent, maxes, indexAt + 1);
                }
            }
            catch
            {
                return new int[current.Length];
            }
        }

        public object[] GetTestCases(Type type)
        {
            if (type == typeof(int)) return IntTestCases.Cast<object>().ToArray();
            if (type == typeof(uint)) return UIntTestCases.Cast<object>().ToArray();
            if (type == typeof(long)) return LongTestCases.Cast<object>().ToArray();
            if (type == typeof(ulong)) return ULongTestCases.Cast<object>().ToArray();
            if (type == typeof(short)) return ShortTestCases.Cast<object>().ToArray();
            if (type == typeof(ushort)) return UShortTestCases.Cast<object>().ToArray();
            if (type == typeof(byte)) return ByteTestCases.Cast<object>().ToArray();
            if (type == typeof(sbyte)) return SByteTestCases.Cast<object>().ToArray();
            if (type == typeof(bool)) return BoolTestCases.Cast<object>().ToArray();
            if (type == typeof(float)) return FloatTestCases.Cast<object>().ToArray();
            if (type == typeof(double)) return DoubleTestCases.Cast<object>().ToArray();
            if (type == typeof(decimal)) return DecimalTestCases.Cast<object>().ToArray();
            if (type == typeof(char)) return CharTestCases.Cast<object>().ToArray();
            if (type == typeof(string)) return StringTestCases.ToArray();
            return ObjectTestCases.ToArray();
        }

        public IEnumerable<int> IntTestCases => new int[] { 0, int.MaxValue, int.MinValue };
        public IEnumerable<uint> UIntTestCases => new uint[] { 0, uint.MaxValue };
        public IEnumerable<long> LongTestCases => new long[] { 0, long.MaxValue, long.MinValue };
        public IEnumerable<ulong> ULongTestCases => new ulong[] { 0, ulong.MaxValue };
        public IEnumerable<short> ShortTestCases => new short[] { 0, short.MaxValue, short.MinValue };
        public IEnumerable<ushort> UShortTestCases => new ushort[] { 0, ushort.MaxValue, ushort.MinValue };
        public IEnumerable<byte> ByteTestCases => new byte[] { 0, byte.MaxValue };
        public IEnumerable<sbyte> SByteTestCases => new sbyte[] { 0, sbyte.MaxValue, sbyte.MinValue };
        public IEnumerable<bool> BoolTestCases => new bool[] { true, false };
        public IEnumerable<float> FloatTestCases => new float[] { 0f, float.MaxValue, float.MinValue, float.Epsilon, float.Epsilon * -1, float.NaN, float.NegativeInfinity, float.PositiveInfinity };
        public IEnumerable<double> DoubleTestCases => new double[] { 0d, double.MaxValue, double.MinValue, double.Epsilon, double.Epsilon * -1, double.NegativeInfinity, double.PositiveInfinity };
        public IEnumerable<decimal> DecimalTestCases => new decimal[] { decimal.Zero, decimal.One, decimal.MinusOne, decimal.MaxValue, decimal.MinValue };
        public IEnumerable<char> CharTestCases => new char[] { char.MinValue, char.MaxValue, ' ', '‌', '@' };
        public IEnumerable<string> StringTestCases => new string[] { string.Empty, default, "Abc", "متن فارسی", "\0" };
        public IEnumerable<object> ObjectTestCases => new object[] { default };

    }
}
