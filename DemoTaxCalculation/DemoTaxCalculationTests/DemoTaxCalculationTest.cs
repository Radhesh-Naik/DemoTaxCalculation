using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using Xunit;
using DemoTaxCalculation;


namespace DemoTaxCalculationTests
{
    public class DemoTaxCalculationTest
    {

        [Fact]
        //[Theory]
        //[InlineData((Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).ToString() + "\\MunicipalRecord.json").ToString())]
        public void File_ShouldReadFile()
        {
            //Arrange
            string expected = "C:\\Users\\Radhesh.Naik\\Desktop\\MunicipalDetail\\MunicipalRecord.json";
            //Act
            FileOperation fO = new FileOperation();
            string Actual = fO.GetFile();
            //Assert
            Assert.Equal(expected, Actual);
        }
        //[Fact]
        //public void File_ShouldReadDataFromFile()
        //{
        //    //Arrange
        //    //Act
        //    //Assert
        //}
    }
}
