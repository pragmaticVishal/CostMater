using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostMater.Data
{
    public class MachiningParameter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Fields
        private int _machiningParameterId;
        private int _materialID;
        private string _materialName;
        private int _processTypeID;
        private string _processTypeName;
        private int _toolTypeID;
        private string _toolTypeName;
        private int _toolSurfaceID;
        private string _toolSurfaceName;
        private decimal _cuttingSpeed;
        private decimal _feedRate;
        private decimal _depthOfCutEachPass;
        private decimal _drillSize;
        private decimal _threadPitch;
        #endregion

        #region Properties
        public int MachiningParameterId
        {
            get => _machiningParameterId;
            set
            {
                _machiningParameterId = value;
                RaisePropertyChanged(nameof(MachiningParameterId));
            }
        }

        [Display(Name = "Material")]
        public int MaterialID
        {
            get => _materialID;
            set
            {
                _materialID = value;
                RaisePropertyChanged(nameof(MaterialID));
            }
        }

        [Display(Name = "Material Name")]
        public string MaterialName
        {
            get => _materialName;
            set
            {
                _materialName = value;
                RaisePropertyChanged(nameof(MaterialName));
            }
        }

        [Display(Name = "Process Type ID")]
        public int ProcessTypeID
        {
            get => _processTypeID;
            set
            {
                _processTypeID = value;
                RaisePropertyChanged(nameof(ProcessTypeID));
            }
        }

        [Display(Name = "Process Name")]
        public string ProcessTypeName
        {
            get => _processTypeName;
            set
            {
                _processTypeName = value;
                RaisePropertyChanged(nameof(ProcessTypeName));
            }
        }

        [Display(Name = "Tool Type ID")]
        public int ToolTypeID
        {
            get => _toolTypeID;
            set
            {
                _toolTypeID = value;
                RaisePropertyChanged(nameof(ToolTypeID));
            }
        }

        [Display(Name = "Tool Type")]
        public string ToolTypeName
        {
            get => _toolTypeName;
            set
            {
                _toolTypeName = value;
                RaisePropertyChanged(nameof(ToolTypeName));
            }
        }

        [Display(Name = "Tool Surface ID")]
        public int ToolSurfaceID
        {
            get => _toolSurfaceID;
            set
            {
                _toolSurfaceID = value;
                RaisePropertyChanged(nameof(ToolSurfaceID));
            }
        }

        [Display(Name = "Rough / Finish")]
        public string ToolSurfaceName
        {
            get => _toolSurfaceName;
            set
            {
                _toolSurfaceName = value;
                RaisePropertyChanged(nameof(ToolSurfaceName));
            }
        }

        [Display(Name = "Cutting Speed")]
        public decimal CuttingSpeed
        {
            get => _cuttingSpeed;
            set
            {
                _cuttingSpeed = value;
                RaisePropertyChanged(nameof(CuttingSpeed));
            }
        }

        [Display(Name = "Feed Rate (f) in mm/rev")]
        public decimal FeedRate
        {
            get => _feedRate;
            set
            {
                _feedRate = value;
                RaisePropertyChanged(nameof(FeedRate));
            }
        }

        [Display(Name = "Drill Size")]
        public decimal DrillSize
        {
            get => _drillSize;
            set
            {
                _drillSize = value;
                RaisePropertyChanged(nameof(DrillSize));
            }
        }

        [Display(Name = "Pitch")]
        public decimal ThreadPitch
        {
            get => _threadPitch;
            set
            {
                _threadPitch = value;
                RaisePropertyChanged(nameof(ThreadPitch));
            }
        }

        [Display(Name = "Depth of Cut for Each Pass")]
        public decimal DepthOfCutEachPass
        {
            get => _depthOfCutEachPass;
            set
            {
                _depthOfCutEachPass = value;
                RaisePropertyChanged(nameof(DepthOfCutEachPass));
            }
        }
        #endregion

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
