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
            
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("C:\\Users\\Mellor\\source\\repos\\ConsoleApp2\\ConsoleApp2\\people.xml");
            XmlElement? xRoot = xDoc.DocumentElement;

            XmlElement raceElem = xDoc.CreateElement("race");

            // создаем атрибут type
            XmlAttribute typeAttr = xDoc.CreateAttribute("type");

            // создаем элементы Description, Evidence (1-3), Weakness
            XmlElement SpeedElem = xDoc.CreateElement("Speed");
            XmlElement AgeElem = xDoc.CreateElement("Age");
            XmlElement SizeElem = xDoc.CreateElement("Size");
            XmlElement SpecificationsElem = xDoc.CreateElement("Specification");
            

            // создаем текстовые значения для элементов и атрибута
            XmlText typeText = xDoc.CreateTextNode("Человек");
            XmlText SpeedText = xDoc.CreateTextNode("30");
            XmlText AgeText = xDoc.CreateTextNode("До 100");
            XmlText SizeText = xDoc.CreateTextNode("Средний");
            XmlText SpecificationText = xDoc.CreateTextNode("Сил +1, Лов +1, Тел +1, Инт +1, Мдр +1, Хар +1");



            //добавляем узлы
            typeAttr.AppendChild(typeText);
            SpeedElem.AppendChild(SpeedText);
            AgeElem.AppendChild(AgeText);
            SizeElem.AppendChild(SizeText);
            SpecificationsElem.AppendChild(SpecificationText);
      


            // добавляем атрибут type
            raceElem.Attributes.Append(typeAttr);

            // добавляем элементы description, evidence(1-3), weakness
            raceElem.AppendChild(SpeedElem);
            raceElem.AppendChild(AgeElem);
            raceElem.AppendChild(SizeElem);
            raceElem.AppendChild(SpecificationsElem);

            // добавляем в корневой элемент новый элемент ghost
            xRoot?.AppendChild(raceElem);


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
                xDoc.Save("C:\\Users\\Mellor\\source\\repos\\ConsoleApp2\\ConsoleApp2\\people.xml");
            }
        }
    }
}
