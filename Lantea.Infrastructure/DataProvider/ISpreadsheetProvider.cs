using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toxy;

namespace Lantea.Infrastructure
{
    public interface ISpreadsheetProvider
    {
        ToxySpreadsheet LoadData(DataContext context);
    }
}
