using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAndAbstractFactory
{
    public interface ICustomer
    {
        decimal TotalBill();
        
    }

    //for factory we have to add it, to make composition of it
    public interface IDiscount
    {
        decimal Calculate();
    }
    public interface ITax
    {
        decimal Calculate();
    }
    public interface IDelivery
    {
        decimal Calculate();
    }

    // No discount
    public class NoDiscount : IDiscount
    {
        public decimal Calculate()
        {
            return 5;
        }
    }
    // Holiday Discount
    public class HoliDayDiscount : IDiscount
    {
        public decimal Calculate()
        {
            // lot of logic
            return 5;
        }
    }
    // Sat and Sunday
    public class WeeklyDiscount : IDiscount
    {
        public decimal Calculate()
        {
            // lot of logic
            return 1;
        }
    }

    // No tax
    public class NoTax : ITax
    {
        public decimal Calculate()
        {
            return 2;
        }
    }
    // Local taxes
    public class LocalTax : ITax
    {
        public decimal Calculate()
        {
            return 5;
        }
    }
    // State Taxes
    public class StateTax : ITax
    {
        public decimal Calculate()
        {
            return 5;
        }
    }

    // Hand delivery
    public class HandDelivery : IDelivery
    {
        public decimal Calculate()
        {
            return 5;
        }
    }
    // Courier
    public class Courier : IDelivery
    {
        public decimal Calculate()
        {
            return 5;
        }
    }


    public class Customer : ICustomer
    {
        private ITax _tax = null;
        private IDiscount _Discount = null;
        private IDelivery _Delivery = null;
        public Customer(ITax tax, IDiscount discount
                        , IDelivery delivery)
        {
            _tax = tax;
            _Discount = discount;
            _Delivery = delivery;
        }
        public decimal TotalPurchase { get; set; }
        public virtual decimal TotalBill()
        {
            // there is some
            // some more
            // big calculation
            return (TotalPurchase +
                _tax.Calculate() +
                _Delivery.Calculate())
                - _Discount.Calculate();

        }
    }

    public class DiscountedCustomer : ICustomer
    {
        
        public decimal TotalBill()
        {
            return 5;
        }
    }
    public class GodCustomer : ICustomer
    {
        
        public decimal TotalBill()
        {
            return 4;
        }
    }

    public class SpecialCustomer : ICustomer
    {
        
        public decimal TotalBill()
        {
            return 3;
        }
    }
}
