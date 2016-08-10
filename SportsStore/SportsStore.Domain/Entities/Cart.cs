using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();



        public void AddItem(Product product, int quantity)
        {
            CartLine line = lines.FirstOrDefault(p => p.Product.ProductID == product.ProductID);

            if (line == null)
                lines.Add(new CartLine { Product = product, Quantity = quantity});
            else
            {
                line.Quantity += quantity;
            }
        }



        public void RemoveLine(Product product)
        {
            lines.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }



        public decimal ComputeTotalValue()
        {
            return lines.Sum(p => p.Product.Price * p.Quantity);
        }



        public void Clear()
        {
            lines.Clear();
        }



        public IEnumerable<CartLine> Lines
        {
            get { return lines; }
        }
    }
}
