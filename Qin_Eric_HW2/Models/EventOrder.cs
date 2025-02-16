using System.ComponentModel.DataAnnotations;

namespace Qin_Eric_HW2.Models
{
    public class EventOrder: Order
    {
        //instantiate properties
        //required customer code 3-5 letters
        [Required(ErrorMessage = "Customer Code is required")]
        [RegularExpression("^[A-Za-z]{3,5}$", ErrorMessage = "Customer Code must be 3 to 5 letters only")]
        public String CustomerCode { get; set; }

        //required service fee 0-175
        [Required(ErrorMessage = "Service Fee is required")]
        [Range(0, 175, ErrorMessage = "Service Fee must be between 0 and 175")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal ServiceFee { get; set; }

        public Boolean PreferredCustomer { get; set; }

        // define methods
        public void CalcTotals()
        {
            //call parent method
            CalcSubtotals();
            // Check preferred customer value
            if (PreferredCustomer == true)
            {
                ServiceFee = 0;
            }
            // default add service fee
            Total = Subtotal + ServiceFee;
        }
    }
}
