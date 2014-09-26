using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geodatabase;

namespace Teleobservacion
{
    class LlenarCombobox
    {

        public List<string> listaElementos(string Ruta, string Campo, string Query)
        {
            List<string> Lista = new List<string>();
            Lista.Add("");//Elemento vacio primer elemento
            IGPUtilities pGputilities = new GPUtilitiesClass();
            IFeatureClass pFeatureClass = pGputilities.OpenFeatureClassFromString(Ruta);
            ITable pTable = (ITable)pFeatureClass;
            IQueryFilter pQuery = new QueryFilterClass();
            pQuery.WhereClause = Query;
            ICursor pCursor = pTable.Search(pQuery, true);
            IRow pRow = pCursor.NextRow();
            while (pRow != null)
            {
                int idx = pRow.Fields.FindField(Campo);
                Lista.Add(pRow.get_Value(idx).ToString());
                pRow = pCursor.NextRow();
            }

            return Lista;
        }
    }
}
