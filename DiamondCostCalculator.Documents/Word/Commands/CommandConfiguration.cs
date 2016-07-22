using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DiamondCostCalculator.Documents.Word.Commands
{
    [XmlRoot("commandConfig")]
    internal class CommandConfiguration
    {
        [XmlArray("commands")]
        [XmlArrayItem("command")]
        public List<CommandData> Commands;
    }

    internal class CommandData
    {
        [XmlAttribute("Token")]
        public string Token { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("parameters")]
        public string Params { get; set; }
    }
}
