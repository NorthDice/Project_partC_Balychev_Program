using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partC_Balychev_Program
{
    public class AlcoholStore : StoreItem
    {
        private string _alcoCompanyName;
        private AlcoholItems _type;

        public AlcoholStore()
           : this("Bermudez", 1, 1.99, AlcoholItems.Rum) { }

        public AlcoholStore(string companyName, int quantityInStock, double price, AlcoholItems type)
            : base(quantityInStock, price)
        {
            _alcoCompanyName = companyName;
            _type = type;
        }

        public string AlcoCompanyName
        {
            get
            {
                return _alcoCompanyName;
            }
            set
            {
                if (value.Length > 12)
                {
                    throw new ArgumentException("Company name length must be less then 12 letters");
                }
                if (string.IsNullOrEmpty(value))
                {
                    _alcoCompanyName = "No name";
                }
                else
                {
                    _alcoCompanyName = value;
                }

            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            AlcoholStore other = (AlcoholStore)obj;
            return AlcoCompanyName == other.AlcoCompanyName
                && QuantityInStock == other.QuantityInStock
                && Price == other.Price
                && Type == other.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AlcoCompanyName, QuantityInStock, Price, Type);
        }

        public AlcoholItems Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (!Enum.IsDefined(typeof(AlcoholItems), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Unknown type of AlcoholItems.");
                }

                _type = value;

            }
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
                if (value < 1.99 || value > 5000)
                {
                    throw new ArgumentException("Price cannot be higher than $5,000 and lower than 1.99");
                }

                price = value;
            }

        }

        public override string ToString()
        {
            return $"Company name: {AlcoCompanyName} | Quantity in Stock {QuantityInStock} | Price {Price} | Type of alcohol {Type}";
        }
    }
}
