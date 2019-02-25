using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace hw2402
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));

            Car c1 = new Car("Honda", "Civic HatchBack", 2012, "Mouse Grey", 4215, 5);
            using (Stream file = new FileStream(@"C:\temp\xmlfile.xml", FileMode.Create))
            {
                myXmlSerializer.Serialize(file, c1);
            }//serializer - creates the file
            using (Stream file = new FileStream(@"C:\temp\xmlfile.xml", FileMode.Open))
            {
                c1 = myXmlSerializer.Deserialize(file) as Car;
            }//deserialize - can console.write
            Console.WriteLine(c1);
            Console.WriteLine();


            Car c2 = new Car("Daihatsu", "Sirion", 2007, "Green/Grey", 1511, 5);
            using (Stream file = new FileStream(@"C:\temp\xmlfile2.xml", FileMode.Create))
            {
                myXmlSerializer.Serialize(file, c2);
            }//serialize - creates the file
            using (Stream file = new FileStream(@"C:\temp\xmlfile2.xml", FileMode.Open))
            {
                c2 = myXmlSerializer.Deserialize(file) as Car;
            }//deserialize - can console.write
            Console.WriteLine(c2);
            Console.WriteLine();


            XmlSerializer myXmlSerializerArray = new XmlSerializer(typeof(Car[]));

            Car[] cars = { c1, c2 };
            using (Stream file = new FileStream(@"C:\temp\xmlfilearray.xml", FileMode.Create))
            {
                myXmlSerializerArray.Serialize(file, cars);
            }//serialize aray - creates the file
            using (Stream file = new FileStream(@"C:\temp\xmlfilearray.xml", FileMode.Open))
            {
                cars = myXmlSerializerArray.Deserialize(file) as Car[];
            }//deserialize array - can console.write
            foreach (var car in cars)
            Console.WriteLine(car);
            Console.WriteLine();


            new Car("xmlfile");
            new Car("xmlfile2");


            Car.SerializeACar("xmlfile3", c1);
            Car.SerializeCarArray("xmlfilearray2", cars);
            Console.WriteLine();


            Console.WriteLine(Car.DeserializeACar("xmlfile"));
            Console.WriteLine(Car.DeserializeACar("xmlfile2"));


            Console.WriteLine("Deserialize car array");
            foreach (var car in cars)
            Console.WriteLine(Car.DeserializeCarArray("xmlfilearray"));
            
            


        }
    }
}
