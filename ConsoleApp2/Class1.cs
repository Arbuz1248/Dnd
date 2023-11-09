using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2
{
    internal class Class1
    {
    public static void Main(string[] args)
        {
            var people = new List<person>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\Mellor\\source\\repos\\ConsoleApp2\\ConsoleApp2\\people.xml");
            XmlElement? xRoot = xmlDoc.DocumentElement;
            if (xRoot != null )
            {
                foreach (XmlElement xnode in xRoot)
                {
                    person Person = new person();
                    XmlNode? attr = xnode.Attributes.GetNamedItem("race");
                    Person.Race = attr?.Value;
                    foreach (XmlNode childNode in xnode.ChildNodes)
                    {
                        if(childNode.Name == "specifications")
                        {
                            Person.Specifications = childNode.InnerText;
                        }
                        if (childNode.Name == "speed")
                        {
                            Person.Speed = int.Parse(childNode.InnerText);
                        }
                        if (childNode.Name == "size")
                        {
                            Person.Size = childNode.InnerText;
                        }
                        if (childNode.Name == "age")
                        {
                            Person.Age = childNode.InnerText;
                        }
                        
                    }
                    people.Add(Person);
                
                }
                foreach (var Person in people)
                {
                    Console.WriteLine("Раса: " + Person.Race + ", скорость: " + Person.Speed + ", размер:" + Person.Size + ", возраст: " + Person.Age + ", характеристики:" + Person.Specifications + ".");
                }
            }
        }
    }
}
