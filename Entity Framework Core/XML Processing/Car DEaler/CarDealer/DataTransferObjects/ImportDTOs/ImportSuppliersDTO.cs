﻿namespace CarDealer.DataTransferObjects.ImportDTOs
{
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class ImportSuppliersDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
