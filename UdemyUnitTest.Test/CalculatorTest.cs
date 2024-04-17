using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyUnitTest.APP;

namespace UdemyUnitTest.Test
{
    public class CalculatorTest
    {
        public Calculator Calculator { get; set; }
        public Mock<ICalculatorService> mymock { get; set; }


        public CalculatorTest()
        {
            mymock = new Mock<ICalculatorService>();
            Calculator = new Calculator(mymock.Object);
        }

        [Theory]
        [InlineData(2,5,7)]
        [InlineData(10,2,12)]
        public void Add_SimpleValues_ReturnValue(int a , int b , int expectedTotal)
        {
            mymock.Setup(x=>x.add(a,b)).Returns(expectedTotal);

            //Act
            var actualTotal = Calculator.add(a, b);
           

            Assert.Equal(expectedTotal,actualTotal);

            mymock.Verify(x=>x.add(a,b), Times.Never);

        }

        [Theory]
        [InlineData(2,5,10)]
        [InlineData(2,3,15)]
        public void Multip_SimpleValues_ReturnsMultipValue(int a, int b, int expectedTotal)
        {
            mymock.Setup(x=>x.multip(a,b)).Returns(expectedTotal);  

            var actualTotal = Calculator.multip(a, b);

            Assert.Equal(expectedTotal,actualTotal);    
        }



    }
}
