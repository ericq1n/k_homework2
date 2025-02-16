using System.ComponentModel.DataAnnotations;

namespace Qin_Eric_HW2.Models
{
    //instatiate enum
    public enum CustomerType
    {
        Standard,
        Event
    }
    //instantiate parent class 
    public class Order
    {
        //instantiate constants
        public const decimal ADULT_PRICE = 11.00m;
        public const decimal CHILD_PRICE = 6.00m;

        //instantiate properties
        public CustomerType CustomerType { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Number of tickets cannot be negative")]
        public Int32? NumberOfAdultTickets { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Number of tickets cannot be negative")]
        public Int32? NumberOfChildTickets { get; set; }
        public Int32? TotalItems { get; private set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal? AdultSubtotal { get; private set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal? ChildSubtotal { get; private set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal? Subtotal { get; private set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal? Total { get; set; }

        //define methods
        public void CalcSubtotals()   //override method in children
        {
            //check null to ensure total values are filled
            if (NumberOfAdultTickets is null)
            {
                NumberOfAdultTickets = 0;
            }
            if (NumberOfChildTickets is null)
            {
                NumberOfChildTickets = 0;
            }
            //perform operations
            TotalItems = NumberOfAdultTickets + NumberOfChildTickets;
            AdultSubtotal = NumberOfAdultTickets * ADULT_PRICE;
            ChildSubtotal = NumberOfChildTickets * CHILD_PRICE;
            Subtotal = AdultSubtotal + ChildSubtotal;
        }
    }
}
