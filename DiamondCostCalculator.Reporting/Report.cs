using DiamondCostCalculator.DependencyResolver;
using DiamondCostCalculator.DocumentContract;
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
    public abstract class Report
    {
        private const string ReportsFolder = "Reports";

        private char[] separator = new[] { ';' };
        protected Dictionary<string, ICommand> Commands;

        public Report()
        {
            ReadCommands();
            SetupCommands();
        }

        private void ReadCommands()
        {
            var path = GetFilePath(GetReportName(), "xml");

            CmdConfiguration configuration;
            using (var file = new FileStream(path, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(CmdConfiguration));
                configuration = (CmdConfiguration)serializer.Deserialize(file);
            }
            Commands = configuration.Commands.ToDictionary(c => c.Token, c => MakeCommand(c.Type));
        }

        private string GetFilePath(string file, string ext)
        {
            return Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
                ReportsFolder, 
                string.Format("{0}.{1}", file, ext));
        }

        public string GetTemplateFilePath()
        {
            return GetFilePath(GetReportName(), "docx");
        }

        private ICommand MakeCommand(string type)
        {
            return Container.Resolve<ICommand>(type);
        }

        protected ICommand GetCommand(Type cmdType)
        {
            return Commands.First(c => c.Value.GetType().GetInterface(cmdType.Name) != null).Value;
        }

        public void BuildReport(IWordProcessor creator)
        {
            creator.ApplyCommands(Commands);
        }

        protected abstract string GetReportName();
        protected abstract void SetupCommands();
    }
}
