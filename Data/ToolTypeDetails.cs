using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailsView.Data
{
    public class ToolTypeDetails : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _toolTypeID;
        private string _toolTypeName;

        public int ToolTypeID
        {
            get => _toolTypeID; 
            set
            {
                _toolTypeID = value;
                RaisePropertyChanged(nameof(ToolTypeID));
            }
        }

        public string ToolTypeName
        {
            get => _toolTypeName; 
            set
            {
                _toolTypeName = value;
                RaisePropertyChanged(nameof(ToolTypeName));
            }
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
