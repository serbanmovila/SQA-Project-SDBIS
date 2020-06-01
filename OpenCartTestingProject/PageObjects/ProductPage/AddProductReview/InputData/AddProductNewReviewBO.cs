using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestingProject.PageObjects.ProductPage.AddProductReview.InputData
{
    class AddProductNewReviewBO
    {
        public string Name { get; set; } = "Test name";
        public string Review { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc at nulla euismod, molestie purus eget, molestie tellus. Donec lobortis interdum metus, at feugiat lacus maximus vel. ";

        public int Rating { get; set; } = 3;
    }
}
