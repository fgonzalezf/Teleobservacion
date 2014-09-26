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
                DataColumn column;
                IFields pFields = table.Fields;
                for (int i = 0; i < pCursor.Fields.FieldCount; i++)
                {
                    column = new DataColumn();
                    column.ColumnName = pFields.get_Field(i).Name;
                    if (pFields.get_Field(i).Type == esriFieldType.esriFieldTypeString)
                    {
                        column.DataType = System.Type.GetType("System.String");
                    }
                    else if (pFields.get_Field(i).Type == esriFieldType.esriFieldTypeInteger)
                    {
                        column.DataType = System.Type.GetType("System.Int32");
                    }
                    else if (pFields.get_Field(i).Type == esriFieldType.esriFieldTypeDouble)
                    {
                        column.DataType = System.Type.GetType("System.Double");
                    }
                    else if (pFields.get_Field(i).Type == esriFieldType.esriFieldTypeDate)
                    {
                        column.DataType = System.Type.GetType("System.DateTime");
                    }
                    else if (pFields.get_Field(i).Type == esriFieldType.esriFieldTypeSingle)
                    {
                        column.DataType = System.Type.GetType("System.Single");
                    }
                    else if (pFields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                    {
                        column.DataType = System.Type.GetType("System.Byte");
                    }
                    column.ReadOnly = false;
                    ExpertInfo.Columns.Add(column);
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
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ExpertInfo;



        }
    }
}
