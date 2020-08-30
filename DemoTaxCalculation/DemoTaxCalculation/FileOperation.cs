using System;
using System.Reflection;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading;

namespace DemoTaxCalculation
{
    public class FileOperation : IFileOperation
    {
        public string GetFile()
        {
            try
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                string fileUNCPath = configuration.GetSection("appsettings:MunicipalTaxFile").Value;
                return fileUNCPath;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDictionary<string, string> ReadDataFromFile(string filePath)
        {
            try
            {
                //IDictionary<string,string[]> fileDetails = new IDictionary<string,string[]>();
                //deserialize JSON from file  
                string Json = System.IO.File.ReadAllText(filePath);
                IDictionary<string, string> fileDetails = JsonConvert.DeserializeObject<IDictionary<string, string>>(Json);

                return fileDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
