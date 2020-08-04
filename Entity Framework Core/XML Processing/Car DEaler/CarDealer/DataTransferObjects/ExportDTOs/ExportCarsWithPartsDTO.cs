namespace CarDealer.DataTransferObjects.ExportDTOs
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarsWithPartsDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public List<ExportPartsDTO> Parts { get; set; }
    }

    [XmlType("part")]
    public class ExportPartsDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}

//<car make = "Opel" model="Astra" travelled-distance="516628215">
//    <parts>
//      <part name = "Master cylinder" price="130.99" />
