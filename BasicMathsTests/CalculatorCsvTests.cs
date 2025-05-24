using CsvHelper;
using Ex2;
using System.Globalization;

namespace BasicMathsTests
{
    public class CalculatorCsvTests
    {
        public static IEnumerable<object[]> GetTestData(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    foreach(var record in csv.GetRecords<TestData>())
                    {
                        yield return new object[] { record.A, record.B, record.Expected };
                    }
                }
            }
        }

    

        [Theory]
        [MemberData(nameof(GetTestData), parameters: "C:\\Users\\Wai Yan Moe Myint\\source\\SELab9Ex2\\BasicMathsTests\\add_testdata.csv")]
        public void Add_CsvData_ReturnsCorrectSum(int a,int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Add(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData), parameters: "C:\\Users\\Wai Yan Moe Myint\\source\\SELab9Ex2\\BasicMathsTests\\subtract_testdata.csv")]
        public void Subtract_CsvData_ReturnsCorrectSum(int a, int b, double expected)
        {
            var calculator = new Calculator();
            double result = Convert.ToDouble(calculator.Subtract(a, b));
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData), parameters: "C:\\Users\\Wai Yan Moe Myint\\source\\SELab9Ex2\\BasicMathsTests\\multiply_testdata.csv")]
        public void Multiply_CsvData_ReturnsCorrectSum(int a, int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Multiply(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData), parameters: "C:\\Users\\Wai Yan Moe Myint\\source\\SELab9Ex2\\BasicMathsTests\\Divide_testdata.csv")]
        public void Divide_CsvData_ReturnsCorrectSum(int a, int b, double expected)
        {
            var calculator = new Calculator();
            int result = calculator.Divide(a, b);
            Assert.Equal(expected, result);
        }
    }

    public class TestData
    {
        public int A { get; set; }
        public int B { get; set; }
        public double Expected { get; set; }
    }
}