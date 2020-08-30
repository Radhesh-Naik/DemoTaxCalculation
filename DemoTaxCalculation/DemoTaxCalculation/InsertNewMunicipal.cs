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
    public class InsertNewMunicipal : IInsertNewMunicipalDetails
    {
        public void InsertDatatoFile()
        {
            try
            {
                //string newEntrymunicipal = "Lipskus";
                //string newEntryTaxDetails = "Yearly = 0.2, Monthly = 0.4, Daily = 0.1";
                string yearly = "Yearly=";
                string monthly = "Monthly=";
                string daily = "Daily=";
                Console.WriteLine("Enter Municipal Name to Add: ");
                string newEntrymunicipal = Console.ReadLine();

                Console.WriteLine("Enter Yearly Tax for {0}: ", newEntrymunicipal);
                decimal YearlyTax;

                if (decimal.TryParse(Console.ReadLine(), out YearlyTax))
                {
                    yearly = yearly + YearlyTax;
                }
                else
                {
                    Console.WriteLine("incorrent tax entered, Please resubmit the details");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                Console.WriteLine("Enter Monthly Tax for {0}: ", newEntrymunicipal);
                decimal MonthlyTax;

                if (decimal.TryParse(Console.ReadLine(), out MonthlyTax))
                {
                    monthly = monthly + MonthlyTax;
                }
                else
                {
                    Console.WriteLine("incorrent tax entered, Please resubmit the details");
                    Console.ReadKey();
                    Environment.Exit(1);
                }

                Console.WriteLine("Enter Daily Tax for {0}: ", newEntrymunicipal);
                decimal DailyTax;

                if (decimal.TryParse(Console.ReadLine(), out DailyTax))
                {
                    daily = daily + DailyTax;
                }
                else
                {
                    Console.WriteLine("incorrent tax entered, Please resubmit the details");
                    Console.ReadKey();
                    Environment.Exit(1);
                }

                string newEntryTaxDetails = string.Join(",", new string[] { yearly, monthly, daily });

                FileOperation fO = new FileOperation();
                string fileName = fO.GetFile();
                IDictionary<string, string> MunicipalTaxDetails = fO.ReadDataFromFile(fileName);
                MunicipalTaxDetails.Add(newEntrymunicipal, newEntryTaxDetails);
                string dateToWrite = JsonConvert.SerializeObject(MunicipalTaxDetails);
                File.WriteAllText(fileName, dateToWrite);
                //string Json = System.IO.File.ReadAllText(filePath);
                //IDictionary<string, string> fileDetails = JsonConvert.DeserializeObject<IDictionary<string, string>>(Json);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
