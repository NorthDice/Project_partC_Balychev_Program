using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partC_Balychev_Program
{
    public abstract class StoreItem
    {
        protected double price;
        protected int quantityInStock;

        protected StoreItem(int quantityInStock, double price)
        {
            this.quantityInStock = quantityInStock;
            this.price = price;

            runProgram.itemAdded += isEmptyStock;
        }

        public static event EventHandler<string> EmptyStock;

        public abstract double Price { get; set; }

        public virtual int QuantityInStock
        {
            get
            {
                return quantityInStock;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity in stock cannot be less then zero.");
                }
                quantityInStock = value;
            }
        }

        public abstract override string ToString();

        private void isEmptyStock(object sender, EventArgs e)
        {
            if (quantityInStock == 0)
            {
                EmptyStock?.Invoke(this, ToString());
            }
        }
        
    }
}
