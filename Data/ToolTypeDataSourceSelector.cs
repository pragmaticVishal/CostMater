using Syncfusion.WinForms.DataGrid;
using System.Collections;

namespace DetailsView.Data
{
    public class ToolTypeDataSourceSelector : IDataSourceSelector
    {
        public IEnumerable GetDataSource(object record, object dataSource)
        {
            if (record == null)
                return null;

            return new ToolTypeDetailsRepository().GetAll();
        }
    }
}
