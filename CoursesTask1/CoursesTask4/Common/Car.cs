using System;
using System.Runtime.Serialization;

namespace CoursesTask4.Common
{
    [Serializable]
    [DataContract]
    public class Car
    {
        [DataMember]
        public int carId { get; set; }
        [DataMember]
        public decimal price { get; set; }
        [DataMember]
        public int quantity { get; set; }
        [DataMember]
        public decimal total { get; set; }

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
