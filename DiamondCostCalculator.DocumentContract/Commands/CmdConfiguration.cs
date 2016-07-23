using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DiamondCostCalculator.DocumentContract.Commands
{
    [XmlRoot("commandConfig")]
    public class CmdConfiguration
    {
        [XmlArray("commands")]
        [XmlArrayItem("command")]
        public List<CommandData> Commands;
    }

    public class CommandData
    {
        [XmlAttribute("Token")]
        public string Token { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}
