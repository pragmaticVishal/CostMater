using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailsView.Data
{
    public class ToolSurfaceDetails : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _toolSurfaceID;
        private string _toolSurfaceName;

        public int ToolSurfaceID
        {
            get => _toolSurfaceID;
            set
            {
                _toolSurfaceID = value;
                RaisePropertyChanged(nameof(ToolSurfaceID));
            }
        }

        public string ToolSurfaceName
        {
            get => _toolSurfaceName;
            set
            {
                _toolSurfaceName = value;
                RaisePropertyChanged(nameof(ToolSurfaceName));
            }
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
