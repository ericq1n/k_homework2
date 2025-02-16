using System.ComponentModel.DataAnnotations;

namespace Qin_Eric_HW2.Models
{
    public class StandardOrder: Order
    {
        //instantiate constants
        //Standardized tax rate of 8.75%
        public const decimal SALES_TAX_RATE = 0.0875m;

        //instantiate properties
        public String? CustomerName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal? SalesTax { get; private set; }

        //define methods
        public void CalcTotals()
        {
            //call parent method
            CalcSubtotals();
            //calculate tax
            SalesTax = Subtotal * SALES_TAX_RATE;
            Total = Subtotal + SalesTax;
        }
    }
}
