using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FactoryAndAbstractFactory
{
    public class Program
    {
        static ICustomer x = null;

        static void Main(string[] args)
        {

            string strType = "NT";//Can come from parameter table or from config file etc.
            x = SimpleFactory.CreateCustomer(strType);
            x.TotalBill();
            Console.WriteLine(x.TotalBill());
            Console.ReadLine();
        }
    }

    public class Order
    {
        ICustomer x = null;
        public Order()
        {
            x.TotalBill();
        }
    }

    public class Inventory
    {
        ICustomer x = null;
        public Inventory()
        {
            x.TotalBill();
        }
    }

    public class Invoice
    {
        ICustomer x = null;
        public Invoice()
        {
            x.TotalBill();
        }
    }

    public static class SimpleFactory
    {
        //static Dictionary<string, ICustomer> container = new Dictionary<string, ICustomer>();
        //After adding Unity
        static UnityContainer container = new UnityContainer();// after this we can remove our clone method.
        //Centralizing new keyword
        static SimpleFactory()
        {

            container.RegisterType<IFactoryCustomer, FactoryCustomer>("N");
            container.RegisterType<IFactoryCustomer, FactoryCustomerNoTax>("NT");
            container.RegisterType<IFactoryCustomer, FactoryCustomerHoliday>("H");


        }
        public static ICustomer CreateCustomer(string strType = "N")
        {
            //Nature of poly beauty of oop, punching out product
            //return containers[strType];
            //To get clone
            //We need to add method in our interface, to make a fresh object, not by ref
            //return container[strType].Clone();
            return container.Resolve<IFactoryCustomer>(strType).Create();



        }
    }

    //Now we need IFactory
    //Define an interface for creating an object
    public interface IFactoryCustomer
    {
        IDelivery CreateDeliver();
        IDiscount CreateDiscount();
        ITax CreateTax();
        ICustomer Create();
    }

    //Identify the most used cobination and implement the base class arrount it, with implemenation
    public class FactoryCustomer : IFactoryCustomer
    {
        // this is the factory method
        //lets a class defer instantiation it uses to subclasses
        //very important step 
        public virtual ICustomer Create()
        {
            //very important step 
            return new Customer(CreateTax(),
                                CreateDiscount(),
                                CreateDeliver());
        }

        public virtual IDelivery CreateDeliver()
        {
            // query the recent courier fees
            // query courier  delivery
            return new Courier();
        }

        public virtual IDiscount CreateDiscount()
        {
            return new NoDiscount();
        }

        public virtual ITax CreateTax()
        {
            // what is tax query db
            // query online service
            return new LocalTax();
        }
    }
    //but let subclasses decide which class to instantiate
    public class FactoryCustomerNoTax : FactoryCustomer
    {
        public override ITax CreateTax()
        {
            return new NoTax();
        }
    }
    public class FactoryCustomerHoliday : FactoryCustomer
    {
        public override IDiscount CreateDiscount()
        {
            return new HoliDayDiscount();
        }
    }
}
