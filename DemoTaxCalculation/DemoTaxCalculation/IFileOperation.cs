using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTaxCalculation
{
    public interface IFileOperation
    {
        string GetFile();
        IDictionary<string, string> ReadDataFromFile(string filePath);
    }
}
