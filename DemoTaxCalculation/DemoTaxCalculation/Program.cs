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
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static void Main(string[] args)
        {
            //InsertDatatoFile();

            //Console.ReadLine();


            FileOperation fO = new FileOperation();
            TaxCalculation tC = new TaxCalculation();
            string fileName = fO.GetFile();
            IDictionary<string, string> MunicipalTaxDetails = fO.ReadDataFromFile(fileName);
            //GetSpecificMunicipalTax(MunicipalTaxDetails);
            //Console.WriteLine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            Console.WriteLine("Choose Your Options : 1 - Get Tax, 2 - Add Municipal \n");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter Municipal Name: ");
                    string municipal = Console.ReadLine();
                    Console.WriteLine("Enter a date eg. 2016.12.31: ");
                    DateTime userDateTime;
                    string taxdate = null;
                    if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
                    {
                        taxdate = userDateTime.ToString("yyyyMMdd");
                    }
                    else
                    {
                        Console.WriteLine("You have entered an incorrect value.");
                    }

                    decimal tax = tC.GetSpecificMunicipalTax(MunicipalTaxDetails, municipal, taxdate);
                    Console.WriteLine("The tax for the {0} is {1}", municipal, tax);
                    break;
                case "2":
                    InsertNewMunicipal iNM = new InsertNewMunicipal();
                    iNM.InsertDatatoFile();
                    break;
                default:
                    Main(null);
                    break;
            }
            Console.ReadLine();



            Console.ReadLine();
        }

        //public static string GetFile()
        //{
        //    try
        //    {
        //        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //        IConfigurationRoot configuration = builder.Build();
        //        string fileUNCPath = configuration.GetSection("appsettings:MunicipalTaxFile").Value;
        //        return fileUNCPath;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static IDictionary<string,string> ReadDataFromFile(string filePath)
        //{
        //    try
        //    {
        //        //IDictionary<string,string[]> fileDetails = new IDictionary<string,string[]>();
        //        //deserialize JSON from file  
        //        string Json = System.IO.File.ReadAllText(filePath);
        //        IDictionary<string, string> fileDetails = JsonConvert.DeserializeObject<IDictionary<string, string>>(Json);

        //        return fileDetails;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static TaxModel GetMunicipalTaxDetails(IDictionary<string,string> MunicipalTaxDetails, string municipal, string date)
        //{
        //    TaxModel municipalTaxDetails = new TaxModel();
        //    try
        //    {
        //        //Console.WriteLine("Enter Municipal Name: ");
        //        //string municipal = Console.ReadLine();
        //        municipalTaxDetails.Municipal = municipal;

        //        foreach (KeyValuePair<string, string> entry in MunicipalTaxDetails)
        //        {
        //            if ((entry.Key).ToLower() == municipal.ToLower())
        //            {
        //                string[] TaxValues = (entry.Value).Split(",");

        //                if (TaxValues.Count() != 0)
        //                {
        //                    foreach (string val in TaxValues)
        //                    {
        //                        if (val.Contains("Yearly="))
        //                        {
        //                            decimal yearly = Convert.ToDecimal(val.Split('=')[1]);
        //                            municipalTaxDetails.yearlyTax = yearly;
        //                        }

        //                        if (val.Contains("Monthly="))
        //                        {
        //                            decimal monthly = Convert.ToDecimal(val.Split('=')[1]);
        //                            municipalTaxDetails.monthlyTax = monthly;
        //                        }

        //                        if (val.Contains("Daily="))
        //                        {
        //                            decimal daily = Convert.ToDecimal(val.Split('=')[1]);
        //                            municipalTaxDetails.dailyTax = daily;
        //                        }

        //                    }

        //                }
        //                else
        //                {
        //                    Console.WriteLine("No tax declared for the municipal");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("No Municipal found");
        //            }
        //        }
        //        return municipalTaxDetails;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
                
        //    }
        //}

        public static void ApplicationDatabase()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        //public static void InsertDatatoFile()
        //{
        //    try
        //    {
        //        //string newEntrymunicipal = "Lipskus";
        //        //string newEntryTaxDetails = "Yearly = 0.2, Monthly = 0.4, Daily = 0.1";
        //        string yearly = "Yearly=";
        //        string monthly = "Monthly=";
        //        string daily = "Daily=";
        //        Console.WriteLine("Enter Municipal Name to Add: ");
        //        string newEntrymunicipal = Console.ReadLine();

        //        Console.WriteLine("Enter Yearly Tax for {0}: ",newEntrymunicipal);
        //        decimal YearlyTax;

        //        if(decimal.TryParse(Console.ReadLine(), out YearlyTax))
        //        {
        //            yearly = yearly + YearlyTax;
        //        }
        //        else
        //        {
        //            Console.WriteLine("incorrent tax entered, Please resubmit the details");
        //            Console.ReadKey();
        //            Environment.Exit(1);
        //        }
        //        Console.WriteLine("Enter Monthly Tax for {0}: ", newEntrymunicipal);
        //        decimal MonthlyTax;

        //        if (decimal.TryParse(Console.ReadLine(), out MonthlyTax))
        //        {
        //            monthly = monthly + MonthlyTax;
        //        }
        //        else
        //        {
        //            Console.WriteLine("incorrent tax entered, Please resubmit the details");
        //            Console.ReadKey();
        //            Environment.Exit(1);
        //        }

        //        Console.WriteLine("Enter Daily Tax for {0}: ", newEntrymunicipal);
        //        decimal DailyTax;

        //        if (decimal.TryParse(Console.ReadLine(), out DailyTax))
        //        {
        //            daily = daily + DailyTax;
        //        }
        //        else
        //        {
        //            Console.WriteLine("incorrent tax entered, Please resubmit the details");
        //            Console.ReadKey();
        //            Environment.Exit(1);
        //        }

        //        string newEntryTaxDetails = string.Join(",", new string[] { yearly,monthly,daily});


        //        string fileName = GetFile();
        //        IDictionary<string, string> MunicipalTaxDetails = ReadDataFromFile(fileName);
        //        MunicipalTaxDetails.Add(newEntrymunicipal, newEntryTaxDetails);
        //        string dateToWrite = JsonConvert.SerializeObject(MunicipalTaxDetails);
        //        File.WriteAllText(fileName, dateToWrite);
        //        //string Json = System.IO.File.ReadAllText(filePath);
        //        //IDictionary<string, string> fileDetails = JsonConvert.DeserializeObject<IDictionary<string, string>>(Json);

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static void GetSpecificMunicipalTax(IDictionary<string,string> MunicipalTaxDetails, string municipal, string date)
        //{
        //    try
        //    {
        //        TaxModel mtd = GetMunicipalTaxDetails(MunicipalTaxDetails, municipal, date);
        //        //Console.WriteLine("Enter Date to compute Tax: ");
        //        //string date = Console.ReadLine();
                
        //        decimal tax = ComputeTax(mtd, municipal, date); ;

        //        //if (date.Substring(4,2) == "05")//monthly
        //        //{
        //        //    tax = mtd.monthlyTax;
        //        //}
        //        //else if(date.Substring(date.Length-4) == "0101" || date.Substring(date.Length - 4) == "2512")//daily
        //        //{
        //        //    tax = mtd.dailyTax;
        //        //}
        //        //else
        //        //{
        //        //    tax = mtd.yearlyTax;
        //        //}

        //        Console.WriteLine("The tax for the {0} is {1}",mtd.Municipal, tax);


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static decimal ComputeTax(TaxModel mtd,string municipalName, string date)
        //{
        //    try
        //    {
        //        decimal tax;

        //        if (date.Substring(4, 2) == "05")//monthly
        //        {
        //            tax = mtd.monthlyTax;
        //        }
        //        else if (date.Substring(date.Length - 4) == "0101" || date.Substring(date.Length - 4) == "2512")//daily
        //        {
        //            tax = mtd.dailyTax;
        //        }
        //        else
        //        {
        //            tax = mtd.yearlyTax;
        //        }
        //        return tax;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


    }
}
