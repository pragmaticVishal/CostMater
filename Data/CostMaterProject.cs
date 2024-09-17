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
        public ObservableCollection<Component> lstComponent { get; set; }
        public ObservableCollection<MachiningParameter> lstMachiningParam { get; set; }
        public CostMaterProject(ObservableCollection<Component> lstComponent, ObservableCollection<MachiningParameter> lstMachiningParam) 
        { 
            this.lstComponent = lstComponent;
            this.lstMachiningParam = lstMachiningParam;
        }
    }
}
