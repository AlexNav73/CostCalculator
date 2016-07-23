using DiamondCostCalculator.DependencyResolver;
using DiamondCostCalculator.DocumentContract.Commands;
using DiamondCostCalculator.DocumentContract.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace DiamondCostCalculator.Reporting
{
    internal abstract class Report
    {
        private const string ReportTemplateFolder = "ReportTemplates";

        private char[] separator = new[] { ';' };
        protected Dictionary<string, ICommand> Commands;

        public Report()
        {
            ReadCommands();
            SetupCommands();
        }

        private void ReadCommands()
        {
            CmdConfiguration configuration;
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ReportTemplateFolder, GetReportName());
            path = string.Format("{0}.xml", path);
            using (var file = new FileStream(path, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(CmdConfiguration));
                configuration = (CmdConfiguration)serializer.Deserialize(file);
            }
            Commands = configuration.Commands.ToDictionary(c => c.Token, c => GetCommand(c.Type));
        }

        private ICommand GetCommand(string type)
        {
            return Resolver.Resolve<ICommand>(Type.GetType(type));
        }

        protected ICommand GetCommand(Type cmdType)
        {
            return Commands.First(c => c.Value.GetType() == cmdType).Value;
        }

        public void BuildReport(IWordProcessor creator)
        {
            creator.ApplyCommands(Commands);
        }

        protected abstract string GetReportName();
        protected abstract void SetupCommands();
    }
}
