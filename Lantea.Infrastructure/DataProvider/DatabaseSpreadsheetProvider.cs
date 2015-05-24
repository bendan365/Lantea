using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Toxy;

namespace Lantea.Infrastructure
{
    public class DatabaseSpreadsheetProvider:ISpreadsheetProvider
    {

        public ToxySpreadsheet LoadData(DataContext context)
        {
            Database db = DatabaseFactory.CreateDatabase(context.ConnectionStringName);
            
            DbCommand cmd=db.GetSqlStringCommand(context.QueryString);
            ToxySpreadsheet ss = new ToxySpreadsheet();
            ss.Name = context.ConnectionStringName;
            int i=0;
            using(IDataReader reader=db.ExecuteReader(cmd))
            {
                ToxyTable table = new ToxyTable();
                table.Name = "Sheet1";
                ToxyRow row=new ToxyRow(i);
                if (i == 0)
                {
                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        row.Cells.Add(new ToxyCell(j, reader.GetName(i)));
                    }
                }
                else
                {
                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        string value=reader.GetString(j);
                        if(!string.IsNullOrEmpty(value))
                            row.Cells.Add(new ToxyCell(j, value));
                    }                    
                }
                table.Rows.Add(row);
                i++;
                ss.Tables.Add(table);
            }            
            return ss;
        }
    }
}
