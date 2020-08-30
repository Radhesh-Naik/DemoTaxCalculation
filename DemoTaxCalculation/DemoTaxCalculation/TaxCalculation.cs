using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoTaxCalculation
{
    public class TaxCalculation : ICalculateTax
    {
        public decimal ComputeTax(TaxModel mtd, string municipalName, string date)
        {
            try
            {
                decimal tax;

                if (date.Substring(4, 2) == "05")//monthly
                {
                    tax = mtd.monthlyTax;
                }
                else if (date.Substring(date.Length - 4) == "0101" || date.Substring(date.Length - 4) == "2512")//daily
                {
                    tax = mtd.dailyTax;
                }
                else
                {
                    tax = mtd.yearlyTax;
                }
                return tax;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TaxModel GetMunicipalTaxDetails(IDictionary<string, string> MunicipalTaxDetails, string municipal, string date)
        {
            TaxModel municipalTaxDetails = new TaxModel();
            try
            {
                //Console.WriteLine("Enter Municipal Name: ");
                //string municipal = Console.ReadLine();
                municipalTaxDetails.Municipal = municipal;

                foreach (KeyValuePair<string, string> entry in MunicipalTaxDetails)
                {
                    if ((entry.Key).ToLower() == municipal.ToLower())
                    {
                        string[] TaxValues = (entry.Value).Split(",");

                        if (TaxValues.Count() != 0)
                        {
                            foreach (string val in TaxValues)
                            {
                                if (val.Contains("Yearly="))
                                {
                                    decimal yearly = Convert.ToDecimal(val.Split('=')[1]);
                                    municipalTaxDetails.yearlyTax = yearly;
                                }

                                if (val.Contains("Monthly="))
                                {
                                    decimal monthly = Convert.ToDecimal(val.Split('=')[1]);
                                    municipalTaxDetails.monthlyTax = monthly;
                                }

                                if (val.Contains("Daily="))
                                {
                                    decimal daily = Convert.ToDecimal(val.Split('=')[1]);
                                    municipalTaxDetails.dailyTax = daily;
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("No tax declared for the municipal");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Municipal found");
                    }
                }
                return municipalTaxDetails;
            }
            catch (Exception)
            {

                throw;

            }
        }

        public decimal GetSpecificMunicipalTax(IDictionary<string, string> MunicipalTaxDetails, string municipal, string date)
        {
            try
            {
                TaxModel mtd = GetMunicipalTaxDetails(MunicipalTaxDetails, municipal, date);
                //Console.WriteLine("Enter Date to compute Tax: ");
                //string date = Console.ReadLine();

                decimal tax = ComputeTax(mtd, municipal, date); ;

                //if (date.Substring(4,2) == "05")//monthly
                //{
                //    tax = mtd.monthlyTax;
                //}
                //else if(date.Substring(date.Length-4) == "0101" || date.Substring(date.Length - 4) == "2512")//daily
                //{
                //    tax = mtd.dailyTax;
                //}
                //else
                //{
                //    tax = mtd.yearlyTax;
                //}

                //Console.WriteLine("The tax for the {0} is {1}", mtd.Municipal, tax);

                return tax;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
