using DetailsView;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostMater.Data
{
    public class OneTimeOperationItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class OneTimeOperationsList : IDataSourceSelector
    {
        public static List<OneTimeOperationItem> GetAll()
        {
            return new List<OneTimeOperationItem>()
            {
                new OneTimeOperationItem() {ID=0, Name=string.Empty },
                new OneTimeOperationItem() {ID=1, Name="Fabrication" },
                new OneTimeOperationItem() {ID=2, Name="Surface Treatment (E.P)" },
                new OneTimeOperationItem() {ID=3, Name="Grinding" },
                new OneTimeOperationItem() {ID=4, Name="Procurement Cost" },
                new OneTimeOperationItem() {ID=5, Name="Miscellaneus" },
                new OneTimeOperationItem() {ID=6, Name="Others B.O" },
                new OneTimeOperationItem() {ID=7, Name="Hardware" }
            };
        }

        public IEnumerable GetDataSource(object record, object dataSource)
        {
            if (record == null)
                return null;

            return OneTimeOperationsList.GetAll();
        }
    }
}
