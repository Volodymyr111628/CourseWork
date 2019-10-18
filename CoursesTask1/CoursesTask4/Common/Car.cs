using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoursesTask4.Common
{
    [Serializable]
    public class Car
    {
        public int carId;
        public decimal price;
        public int quantity;
        public decimal total;

        public Car() { }

        public Car(int CarId,decimal Price,int Quantity,decimal Total)
        {
            carId = CarId;
            price = Price;
            quantity = Quantity;
            total = Total;
        }

        public string ReturnString()
        {
            return string.Format($"CarId: {carId}, Car price: {price}, Quantity: {quantity}, Total: {total} \n");
        }
    }
}
