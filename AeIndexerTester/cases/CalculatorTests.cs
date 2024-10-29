namespace AeIndexerTester.cases;

using NUnit.Framework;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void SetUp()
    {
        // 初始化代码，每个测试方法之前调用
        _calculator = new Calculator();
    }

    [Test]
    public void Add_ShouldReturnSum_WhenGivenTwoIntegers()
    {
        // Arrange
        int a = 5;
        int b = 7;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        // Assert.AreEqual(12, result);
    }

    [Test]
    public void Subtract_ShouldReturnDifference_WhenGivenTwoIntegers()
    {
        // Arrange
        int a = 10;
        int b = 4;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        // Assert.AreEqual(6, result);
    }

    [TearDown]
    public void TearDown()
    {
        // 清理代码，每个测试方法之后调用
        _calculator = null;
    }
}