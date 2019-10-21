using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Asv.GeometryConverter
{
    class Program
    {
        static void Main(string[] args)
        {



            var xDoc = new XmlDocument();
            xDoc.Load(args.First());
            foreach (var element in xDoc.FirstChild.Cast<XmlElement>().Where(_ => _.Name != "Geometry").ToArray())
            {
                xDoc.FirstChild.RemoveChild(element);
            }

            foreach (var element in xDoc.FirstChild.Cast<XmlElement>().Where(_ => _.Name == "Geometry"))
            {
                var key = element.GetAttribute("x:Key");
                element.SetAttribute("x:Key", key.Replace("Geometry", ""));

            }

            xDoc.Save(args.Skip(1).First());
        }
    }
}
