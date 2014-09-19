using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;

namespace Teleobservacion
{
    class Table_To_DataTable
    {
        public DataTable ConvertITable(ITable table, string whereClause)
        {

            DataTable ExpertInfo;
            ExpertInfo = new DataTable("ExpertInfo");
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = whereClause; // create the where clause statement
            try
            {
               
                ICursor pCursor = table.Search(queryFilter, true);
                IRow pRow = pCursor.NextRow();

                if (pRow != null)
                {
                    for (int i = 0; i < pRow.Fields.FieldCount; i++)
                    {
                        ExpertInfo.Columns.Add(pRow.Fields.get_Field(i).Name);
                    }
                    while (pRow != null)
                    {
                        DataRow pDataRow = ExpertInfo.NewRow();
                        for (int j = 0; j < pCursor.Fields.FieldCount; j++)
                            pDataRow[j] = pRow.get_Value(j);
                        ExpertInfo.Rows.Add(pDataRow);
                        pRow = pCursor.NextRow();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ExpertInfo;



        }
    }
}
