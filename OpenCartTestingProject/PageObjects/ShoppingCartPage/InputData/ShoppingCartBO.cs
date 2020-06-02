using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestingProject.PageObjects.ShoppingCartPage.InputData
{
    public class ShoppingCartBO
    {
        public string ProductName { get; set; } = "Samsung Galaxy Tab 10.1";
        public string Quantity { get; set; } = "5";
        public string WrongQuantity { get; set; } = "-5";
        public string Country { get; set; } = "Romania";
        public string Region { get; set; } = "Iasi";
        public string Postcode { get; set; } = "700028";
        public string WrongCountry { get; set; } = " --- Please Select --- ";
        public string WrongRegion { get; set; } = " --- Please Select --- ";

    }
}
