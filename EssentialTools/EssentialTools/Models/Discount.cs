using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{

    public interface IDiscountHelper
    {

        decimal ApplyDiscount(decimal total);

    }

    public class DefaultDiscountHelper : IDiscountHelper
    {

        public decimal DiscountSize { get; set; }



        public DefaultDiscountHelper(decimal discountSize)
        {
            DiscountSize = discountSize;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return (total - (DiscountSize / 100m * total));
        }

    }
}