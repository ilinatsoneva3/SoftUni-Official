namespace BookShop.DataProcessor.ExportDto
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Book")]
    public class ExportBookDTO
    {
        [XmlAttribute("Pages")]
        public int Pages { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }
    }
}

//<Book Pages="4881">
  //  <Name>Sierra Marsh Fern</Name>
  //  <Date>03/18/2016</Date>
  //</Book>
