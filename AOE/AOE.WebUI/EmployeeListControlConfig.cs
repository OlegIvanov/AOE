using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AOE.WebUI
{
    [XmlRoot("Config")]
    public class EmployeeListControlConfig
    {
        [XmlElement("DataSource")]
        public DataSource DataSource { get; set; }

        [XmlElement("PageSize")]
        public int PageSize { get; set; }

        [XmlElement("IsEditable")]
        public bool IsEditable { get; set; }

        public static EmployeeListControlConfig GetConfig(string xmlConfigFile) 
        {
            string absolutePath = HttpContext.Current.Server.MapPath(xmlConfigFile);
            return DeserializeFromXml(absolutePath);
        }

        private static EmployeeListControlConfig DeserializeFromXml(string xmlConfigFile)
        {
            using (TextReader textReader = new StreamReader(xmlConfigFile))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(EmployeeListControlConfig));
                return (EmployeeListControlConfig)deserializer.Deserialize(textReader);
            }
        }
    }

    public class DataSource
    {
        [XmlAttribute("type")]
        public SourceType Type { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }
    }

    public enum SourceType
    {
        Database = 0,
        Webservice = 1
    }
}