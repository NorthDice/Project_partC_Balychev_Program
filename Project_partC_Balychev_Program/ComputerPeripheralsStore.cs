using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partC_Balychev_Program
{
    public class ComputerPeripheralsStore : StoreItem
    {
        private string _companyName;
        private PeripheriItems _type;

        public ComputerPeripheralsStore()
            : this("JBL", 1, 0.99, PeripheriItems.Headphones) { }

        public ComputerPeripheralsStore(string companyName, int quantityInStock, double price, PeripheriItems type)
            : base(quantityInStock, price)
        {
            _companyName = companyName;
            _type = type;
        }

        public string CompanyName
        {
            get
            {
                return _companyName;
            }
            set
            {
                if (value.Length > 12)
                {
                    throw new ArgumentException("Company name length must be less then 12 letters");
                }
                if (string.IsNullOrEmpty(value))
                {
                    _companyName = "No name";
                }
                else
                {
                    _companyName = value;
                }

            }
        }

        public PeripheriItems Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (!Enum.IsDefined(typeof(PeripheriItems), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Unknown type of PeripherItems.");
                }

                _type = value;

            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ComputerPeripheralsStore other = (ComputerPeripheralsStore)obj;

            return CompanyName == other.CompanyName &&
                   QuantityInStock == other.QuantityInStock &&
                   Price == other.Price &&
                   Type == other.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CompanyName, QuantityInStock, Price, Type);
        }

        public override int QuantityInStock
        {
            get
            {
                return quantityInStock;
            }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentException("Quantity in stock cannot be less then zero and more than 20.");
                }

                quantityInStock = value;
            }
        }

        public override double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0.99 || value > 1000)
                {
                    throw new ArgumentException("Price cannot be higher than $1,000 and lower than 0.99");
                }

                price = value;
            }
        }



        public override string ToString()
        {
            return $"Company name: {CompanyName} | Quantity in Stock {QuantityInStock} | Price {Price} | Type of product {Type}";
        }

    }
}
