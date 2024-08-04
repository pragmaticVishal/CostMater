using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailsView.Data
{
    public class MaterialTypeDetails : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _materialTypeID;
        private string _materialTypeName;

        public int MaterialTypeID
        {
            get => _materialTypeID; set
            {
                _materialTypeID = value;
                RaisePropertyChanged(nameof(MaterialTypeID));
            }
        }

        public string MaterialTypeName
        {
            get => _materialTypeName; set
            {
                _materialTypeName = value;
                RaisePropertyChanged(nameof(MaterialTypeName));
            }
        }

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
