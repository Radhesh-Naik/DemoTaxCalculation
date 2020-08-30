using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTaxCalculation
{
    public class TaxModel
    {
        public string Municipal { get; set; }

        public decimal yearlyTax { get; set; }

        public decimal monthlyTax { get; set; }

        public decimal dailyTax { get; set; }
    }


}
