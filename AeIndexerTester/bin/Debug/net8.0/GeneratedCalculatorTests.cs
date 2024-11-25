
using NUnit.Framework;

namespace GeneratedTests
{
    [TestFixture]
    public class CalculatorTests
    {
        
                [Test]
                public void AddTwoNumbers_Test()
                {
                    // Arrange
                    var calc = new Calculator();
        
                    // Act
                    var result = calc.Add(2, 3);
        
                    // Assert
                    Assert.AreEqual(5, result);
                }
                
                [Test]
                public void SubtractTwoNumbers_Test()
                {
                    // Arrange
                    var calc = new Calculator();
        
                    // Act
                    var result = calc.Subtract(5, 3);
        
                    // Assert
                    Assert.AreEqual(2, result);
                }
                
    }
}