using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliveri
{
    abstract class Delivery
    {
        public abstract string Address { get; set; }
    }

    class HomeDelivery : Delivery
    {
        private string address;

        private List<string> products;
        public override string Address
        {
            get { return address; }
            set { address = value; }
        }
        public List<string> Products
        {
            get { return products; }
            set { products = value; }
        }
        public HomeDelivery(string address, List<string> products)
        {
            this.address = address;
            this.products = products;
        }
    }
    class PickPointDelivery : Delivery
    {
        private string address;
        private List<string> products;
        public override string Address
        {
            get { return address; }
            set { address = value; }
        }
        public List<string> Products
        {
            get { return products; }
            set { products = value; }
        }
        public PickPointDelivery(string address, List<string> products)
        {
            this.address = address;
            this.products = products;
        }
    }
    class RestaurantDelivery : Delivery
    {
        private string address;
        private List<string> products;
        public override string Address
        {
            get { return address; }
            set { address = value; }
        }
        public List<string> Products
        {
            get { return products; }
            set { products = value; }
        }
        public RestaurantDelivery(string address, List<string> products)
        {
            this.address = address;
            this.products = products;
        }
    }
    class ShopDelivery : Delivery
    {
        private string address;
        private List<string> products;
        public override string Address
        {
            get { return address; }
            set { address = value; }
        }
        public List<string> Products
        {
            get { return products; }
            set { products = value; }
        }
        public ShopDelivery(string address, List<string> products)
        {
            this.address = address;
            this.products = products;
        } 
    }
    class GetProducts
    {
        public List<string> ChooseProducts()
        {
            List<string> products = new List<string>();
            Console.WriteLine("Выберите продукты (введите 'end' для завершения):");

            while (true)
            {
                string product = Console.ReadLine();
                if (product.ToLower() == "end")
                {
                    break;
                }
                products.Add(product);
            }
            return products;
        }
    }
    class GetAddress
    {
        public Delivery GetAdd(string Deliverytype, List<string> products = null)
        {
            string address;
            
            if (Deliverytype == "Дом")
            {
                Console.WriteLine("Введите адрес доставки:");
                address = Console.ReadLine();

                return new HomeDelivery(address, products);
            }
            else if (Deliverytype == "Пункт")
            {
                Console.WriteLine("Введите адрес пункта выдачи:");
                address = Console.ReadLine();
                return new PickPointDelivery(address, products);
            }else if(Deliverytype == "Самовывоз")
            {
                Console.WriteLine("Введите адрес Ресторана :");
                address = Console.ReadLine();
                return new RestaurantDelivery(address, products);
            }
            else
            {
                throw new ArgumentException("Такого типа доставки нет");
            }
                
        }
    }
    
    class Display 
    {
        public void Show()
        {
            GetProducts getProducts = new GetProducts();
            List<string> products = getProducts.ChooseProducts();

            GetAddress getAddress = new GetAddress();

            Console.WriteLine("Введите тип доставки (Дом/Пункт/Самовывоз):");
            string deliveryType = Console.ReadLine();

            Delivery delivery = getAddress.GetAdd(deliveryType, products);
            Console.WriteLine("Адрес доставки: " + delivery.Address);

            if (delivery is HomeDelivery shopDelivery)
            {
                Console.WriteLine("Выбранные продукты:");
                foreach (var product in shopDelivery.Products)
                {
                    Console.WriteLine("- " + product);
                }
            }
            else if (delivery is PickPointDelivery shopDeliver)
            {
                Console.WriteLine("Выбранные продукты:");
                foreach (var product in shopDeliver.Products)
                {
                    Console.WriteLine("- " + product);
                }
            }
            else if (delivery is RestaurantDelivery shopDeliveri)
            {
                Console.WriteLine("Выбранные продукты:");
                foreach (var product in shopDeliveri.Products)
                {
                    Console.WriteLine("- " + product);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Display display = new Display();
            display.Show();

        }
    }
}
