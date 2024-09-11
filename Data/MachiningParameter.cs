using Syncfusion.XlsIO.Parser.Biff_Records;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
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
        private decimal _machiningCostPerHour;
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
                if(ProcessTypeID == 6)
                {
                    _feedRate = value;
                    _threadPitch = value;
                }
                else
                {
                    _feedRate = value;
                }
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
                if (ProcessTypeID == 6)
                {
                    _feedRate = value;
                    _threadPitch = value;
                }
                else
                {
                    _threadPitch = value;
                }
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

        [Display(Name = "Machining Cost Per hour")]
        public decimal MachiningCostPerHour
        {
            get => _machiningCostPerHour;
            set
            {
                _machiningCostPerHour = value;
                RaisePropertyChanged(nameof(MachiningCostPerHour));
            }
        }
        #endregion

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsColumnApplicable(string mappingName)
        {
            bool isApplicable = true;
            if ((ProcessTypeID == 1 || ProcessTypeID == 5) && (mappingName == nameof(ThreadPitch)))
            {
                isApplicable = false;
            }
            else if ((ProcessTypeID == 5 || ProcessTypeID == 6) && (mappingName == nameof(DepthOfCutEachPass)))
            {
                isApplicable = false;
            }
            else if ((ProcessTypeID == 1 || ProcessTypeID == 6) && (mappingName == nameof(DrillSize)))
            {
                isApplicable = false;
            }

            return isApplicable;
        }
    }
}
