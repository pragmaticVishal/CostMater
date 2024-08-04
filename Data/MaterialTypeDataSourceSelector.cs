using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailsView.Data
{
    public class MaterialTypeDataSourceSelector : IDataSourceSelector
    {
        public IEnumerable GetDataSource(object record, object dataSource)
        {
            if (record == null)
                return null;

            return new MaterialTypeDetailsRepository().GetAll();
        }
    }
}
