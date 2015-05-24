using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toxy;

namespace Lantea.Infrastructure
{
    public class FileSpreadsheetProvider:ISpreadsheetProvider
    {
        public ToxySpreadsheet LoadData(DataContext context)
        {
            ParserContext pc = new ParserContext(context.Path);
            ISpreadsheetParser parser=ParserFactory.CreateSpreadsheet(pc);
            var ss=parser.Parse();
            return ss;
        }
    }
}
