using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AOE.WebUI
{
    [XmlRoot("Config")]
    public class EmployeeListConfig
    {
        [XmlAttribute("type")]
        public EmployeeListDataSource DataSource { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }

        [XmlElement("PageSize")]
        public int PageSize { get; set; }

        [XmlElement("IsEditable")]
        public bool IsEditable { get; set; }

        public static EmployeeListConfig GetConfig(string xmlConfigFile) 
        {
            string absolutePath = HttpContext.Current.Server.MapPath(xmlConfigFile);
            return DeserializeFromXml(absolutePath);
        }

        private static EmployeeListConfig DeserializeFromXml(string xmlConfigFile)
        {
            using (TextReader textReader = new StreamReader(xmlConfigFile))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(EmployeeListConfig));
                return (EmployeeListConfig)deserializer.Deserialize(textReader);
            }
        }
    }
}