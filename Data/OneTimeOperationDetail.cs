using DetailsView.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component = DetailsView.Data.Component;

namespace CostMater.Data
{
    public class OneTimeOperationDetail : INotifyPropertyChanged, IDataErrorInfo
    {
        public string this[string columnName] { get { return string.Empty; } }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private int _onetimeOpDetailID;
        private int _componentID;
        private int _oneTimeOpItemSelectedID;
        private decimal _qty;
        private decimal _rate;
        private decimal _amount;
        private Component _component;

        [Display(Name = "Component")]
        public Component Component
        {
            get => _component;
            set
            {
                _component = value;
            }
        }

        [Display(Name = "Component ID")]
        public int ComponentID
        {
            get => _componentID;
            set
            {
                _componentID = value;
                RaisePropertyChanged(nameof(ComponentID));
            }
        }

        [Display(Name = "One time Op Detail ID")]
        public int OnetimeOpDetailID
        {
            get => _onetimeOpDetailID;
            set
            {
                _onetimeOpDetailID = value;
                RaisePropertyChanged(nameof(OnetimeOpDetailID));
            }
        }

        [Display(Name = "Operation")]
        public int OneTimeOpItemSelectedID
        {
            get => _oneTimeOpItemSelectedID;
            set
            {
                _oneTimeOpItemSelectedID = value;
                RaisePropertyChanged(nameof(OneTimeOpItemSelectedID));
            }
        }

        [Display(Name = "Drawing / Part No.")]
        public string DrawingNo
        {
            get => Component.DrawingNo;
        }

        [Display(Name = "Quantity")]
        public decimal Qty
        {
            get => _qty;
            set
            {
                _qty = value;
                RaisePropertyChanged(nameof(Qty));
            }
        }

        [Display(Name = "Rate")]
        public decimal Rate
        {
            get => _rate;
            set
            {
                _rate = value;
                RaisePropertyChanged(nameof(Rate));
            }
        }

        [Display(Name = "Amount")]
        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                RaisePropertyChanged(nameof(Amount));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
