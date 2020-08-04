﻿using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.ExportDTOs
{
    [XmlType("sale")]
    public class ExportSalesDTO
    {
        [XmlElement("car")]
        public ExportCarDTO Car { get; set; }

        [XmlElement("discount")]
                public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CusomerName { get; set; }

        [XmlElement("price")]
                public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
                public decimal PriceWithDiscount { get; set; }
    }

    [XmlType("car")]
    public class ExportCarDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
