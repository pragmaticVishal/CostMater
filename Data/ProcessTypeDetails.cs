using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailsView.Data
{
    public class ProcessTypeDetails : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _processTypeID;
        private string _processTypeName;

        public int ProcessTypeID
        {
            get => _processTypeID; 
            set
            {
                _processTypeID = value;
                RaisePropertyChanged(nameof(ProcessTypeID));
            }
        }

        public string ProcessTypeName
        {
            get => _processTypeName; 
            set
            {
                _processTypeName = value;
                RaisePropertyChanged(nameof(ProcessTypeName));
            }
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
