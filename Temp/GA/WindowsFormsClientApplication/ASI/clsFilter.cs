using System.Xml.Serialization;

namespace WindowsFormsClientApplication
{
    public class clsFilter
    {
        [XmlElement(ElementName = "UseIt")]
        public bool UseIt { get; set; } = false;

        [XmlElement(ElementName = "ColId")]
        public int ColId { get; set; }

        [XmlElement(ElementName = "Channel")]
        public string Channel { get; set; }

        [XmlElement(ElementName = "DataType")]
        public string DataType { get; set; }

        [XmlElement(ElementName = "Operator")]
        public string Operator { get; set; }

        [XmlElement(ElementName = "LimitValue")]
        public double LimitValue { get; set; }

        [XmlElement(ElementName = "Logic")]
        public string Logic { get; set; }
    }
}
