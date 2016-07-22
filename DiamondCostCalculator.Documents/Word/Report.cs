using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.Documents.Word.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace DiamondCostCalculator.Documents.Word
{
    internal abstract class Report
    {
        private const string ReportTemplateFolder = "ReportTemplates";

        private char[] separator = new[] { ';' };
        protected Dictionary<string, ICommand> Commands;

        public Report()
        {
            ReadCommands();
        }

        private void ReadCommands()
        {
            CommandConfiguration configuration;
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ReportTemplateFolder, GetReportName());
            path = string.Format("{0}.xml", path);
            using (var file = new FileStream(path, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(CommandConfiguration));
                configuration = (CommandConfiguration)serializer.Deserialize(file);
            }
            Commands = configuration.Commands.ToDictionary(c => c.Token, c => GetCommand(c.Name, c.Params));
        }

        private IEnumerable<string> GetParams(string str)
        {
            return str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        private ICommand GetCommand(string name, string prms)
        {
            var type = Type.GetType(name);
            var context = new CommandContext(GetParams(prms));

            var command = (ICommand)Activator.CreateInstance(type);
            command.Context = context;
            return command;
        }

        protected abstract string GetReportName();
        public abstract void BuildReport(IWordProcessor processor);
    }
}
