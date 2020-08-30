using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTaxCalculation
{
    public interface ICalculateTax
    {
        decimal GetSpecificMunicipalTax(IDictionary<string, string> MunicipalTaxDetails, string municipal, string date);
        TaxModel GetMunicipalTaxDetails(IDictionary<string, string> MunicipalTaxDetails, string municipal, string date);

        decimal ComputeTax(TaxModel mtd, string municipalName, string date);
    }
}
