using DetailsView.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostMater.Data
{
    public class CostMaterProject
    {
        ObservableCollection<Component> lstComponent { get; set; }
        List<MachiningParameter> lstMachiningParam { get; set; }
        public CostMaterProject(ObservableCollection<Component> lstComponent, List<MachiningParameter> lstMachiningParam) 
        { 
            this.lstComponent = lstComponent;
            this.lstMachiningParam = lstMachiningParam;
        }
    }
}
