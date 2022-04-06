using serialize_task.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace serialize_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Chips = new Product { Id = 1, Name = "Lays", Price = 2.30 };
            Product Drink = new Product { Id = 2, Name = "Coca-Cola", Price = 1.70 };
            Product Chocolate = new Product { Id = 3, Name = "Snikers", Price = 1.70 };
            OrderItem item1 = new OrderItem { Id = 2, Product = Drink, Count = 1};
            item1.TotalPrice = Drink.Price * item1.Count;
            OrderItem item2 = new OrderItem { Id = 1, Product = Chips, Count = 2 };
            item2.TotalPrice = Chips.Price * item2.Count;
            OrderItem item3 = new OrderItem { Id = 3, Product = Chocolate, Count = 3  };
            item3.TotalPrice = Chocolate.Price * item3.Count;
            OrderItem item4 = new OrderItem { Id = 4, Product = Drink, Count = 2  };
            item4.TotalPrice = Drink.Price * item4.Count;
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(item1);
            orderItems1.Add(item2);
            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(item3);
            orderItems2.Add(item4);
            Order order1 = new Order { Id = 1, OrderItems = orderItems1 };
            Order order2 = new Order { Id = 3, OrderItems = orderItems2 };
            #region Serialize
            var jsonObj = JsonConvert.SerializeObject(order2);
            Console.WriteLine(jsonObj);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\tu7cldm19\Desktop\task\serialize_task\serialize_task\Files\sebine.json"))
            {
                sw.WriteLine(jsonObj);
            }
            #endregion
            #region Deserialize
            string result;
            using (StreamReader sr = new StreamReader(@"C:\Users\tu7cldm19\Desktop\task\serialize_task\serialize_task\Files\zulfiyya.json"))
            {
                result = sr.ReadToEnd();
            }
            Order or1 = JsonConvert.DeserializeObject<Order>(result);
            foreach (var item in or1.OrderItems)
            {
                Console.WriteLine(item.Product.Name);
            }

            #endregion
        }
    }
}
