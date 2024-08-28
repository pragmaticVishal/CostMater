using Syncfusion.WinForms.DataGrid;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DetailsView.Data
{
    public class MaterialDataSourceSelector : IDataSourceSelector
    {
        public IEnumerable GetDataSource(object record, object dataSourcee)
        {
            // Assuming you have a method to get the list of materials
            return GetMaterials();
        }


        private ObservableCollection<Material> GetMaterials()
        {
            // Replace this with your actual data retrieval logic
            return new ObservableCollection<Material>
            {
                new Material { MaterialID = 0, MaterialName = "" },
                new Material { MaterialID = 1, MaterialName = "SS-304" },
                new Material { MaterialID = 2, MaterialName = "SS-305" },
                new Material { MaterialID = 3, MaterialName = "SS-306" },
                new Material { MaterialID = 4, MaterialName = "MS" },
                new Material { MaterialID = 5, MaterialName = "AL" }
            };
        }
    }

    public class Material
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
    }
}