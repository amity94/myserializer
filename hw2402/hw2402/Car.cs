using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace hw2402
{
    public class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        private int codan;
        protected int numberOfSeats;

        public Car()
        {

        }

        public Car(string fileName)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));

            Car c;
            using (Stream file = new FileStream($@"C:\temp\{fileName}.xml", FileMode.Open))
            {
                c = myXmlSerializer.Deserialize(file) as Car;
            }//deserialize - can consle.writeline
            Console.WriteLine(c);
        }

        public Car(string brand, string model, int year, string color, int codan, int numberOfSeats)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Color = color;
            this.codan = codan;
            this.numberOfSeats = numberOfSeats;
        }

        public int GetCodan()
        {
            return codan;
        }

        public int GetNumberOfSeats()
        {
            return numberOfSeats;
        }

        protected void ChangeNumberOfSeats(int number)
        {
            numberOfSeats = numberOfSeats + number;
        }

        public static void SerializeACar(string fileName, Car anycar)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));

            using (Stream file = new FileStream($@"C:\temp\{fileName}.xml", FileMode.Create))
            {
                myXmlSerializer.Serialize(file, anycar);
            }//serialize - creates the file
        }

        public static void SerializeCarArray(string fileName, Car[] cars)
        {
            XmlSerializer myXmlSerializerArray = new XmlSerializer(typeof(Car[]));

            using (Stream file = new FileStream($@"C:\temp\{fileName}.xml", FileMode.Create))
            {
                myXmlSerializerArray.Serialize(file, cars);
            }//serialize - creates the file
        }

        public static Car DeserializeACar(string fileName)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));

            Car c;
            using (Stream file = new FileStream($@"C:\temp\{fileName}.xml", FileMode.Open))
            {
                c = myXmlSerializer.Deserialize(file) as Car;
            }//deserialize - can consle.writeline
            return c;
        }

        public static Car[] DeserializeCarArray(string fileName)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car[]));

            Car[] cars;
            using (Stream file = new FileStream($@"C:\temp\{fileName}.xml", FileMode.Open))
            {
                cars = myXmlSerializer.Deserialize(file) as Car[];
            }//deserialize - can consle.writeline
            return cars as Car[];
        }

        //public static bool CarCompare(string fileName)
        //{

        //}

        public override string ToString()
        {
            return $"Brand: {Brand, 10} Model: {Model, 15} Year: {Year, 4} Color: {Color, 15} Codan: {codan, 5} Number Of Seats: {numberOfSeats, 2}";
        }

    }
}
