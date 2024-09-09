using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostMater.Data
{
    public class LaserAndBendingItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class LaserAndBendingList : IDataSourceSelector
    {
        public static List<LaserAndBendingItem> GetAll()
        {
            return new List<LaserAndBendingItem>()
            {
                new LaserAndBendingItem(){ ID = 0, Name = ""},
                new LaserAndBendingItem(){ ID = 1, Name = "Laser Cutting"},
                new LaserAndBendingItem(){ ID = 2, Name = "Material Bending (Counts)"},
                new LaserAndBendingItem(){ ID = 3, Name = "Material Bending (Dimension)"}
            };
        }
        public IEnumerable GetDataSource(object record, object dataSource)
        {
            if (record == null)
                return null;

            return LaserAndBendingList.GetAll();
        }
    }
}
