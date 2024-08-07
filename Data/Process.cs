using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailsView.Data
{
    public class Process : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields
        public event PropertyChangedEventHandler PropertyChanged;
        private int _processID;
        private int _componentID;
        private int _processTypeID;
        private string _processTypeName;
        private int _toolTypeID;
        private string _toolTypeName;
        private int _toolSurfaceID;
        private string _toolSurfaceName;
        private decimal _cuttingSpeed;
        private decimal _feedRate;
        private decimal _drillSize;
        private decimal _threadDiameterToCut;
        private decimal _threadPitch;
        private decimal _diameterBeforeTurning;
        private decimal _diameterAfterTurning;
        private decimal _rpm;
        private decimal _depthOfCutEachPass;
        private decimal _noOfCuts;
        private decimal _lengthOfCut;
        private decimal _lengthOfHoleToDrill;
        private decimal _lengthOfThreadToCut;
        private decimal _machingTime;
        private decimal _machiningCost;
        private decimal _average;
        private Component _component;
        private decimal _totalDepthOfCut;


        #endregion

        [Display(Name = "Process ID")]
        public Component Component
        {
            get => _component;
            set
            {
                _component = value;
            }
        }

        [Display(Name = "Process ID")]
        public int ProcessID
        {
            get => _processID;
            set
            {
                _processID = value;
                RaisePropertyChanged(nameof(ProcessID));
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

        [Display(Name = "Process Type")]
        public string ProcessTypeName
        {
            get => _processTypeName;
            set
            {
                _processTypeName = value;
                RaisePropertyChanged(nameof(ProcessTypeName));
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

        [Display(Name = "Total depth of Cut")]
        public decimal TotalDepthOfCut
        {
            get => _totalDepthOfCut;
            set
            {
                _totalDepthOfCut = value;
                RaisePropertyChanged(nameof(TotalDepthOfCut));
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

        [Display(Name = "Diameter of the thread to cut")]
        public decimal ThreadDiameterToCut
        {
            get => _threadDiameterToCut;
            set
            {
                _threadDiameterToCut = value;
                RaisePropertyChanged(nameof(ThreadDiameterToCut));
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

        [Display(Name = "Diameter of stock before turning")]
        public decimal DiameterBeforeTurning
        {
            get => _diameterBeforeTurning;
            set
            {
                _diameterBeforeTurning = value;
                RaisePropertyChanged(nameof(DiameterBeforeTurning));
            }
        }

        [Display(Name = "Diameter of job after turning")]
        public decimal DiameterAfterTurning
        {
            get => _diameterAfterTurning;
            set
            {
                _diameterAfterTurning = value;
                RaisePropertyChanged(nameof(DiameterAfterTurning));
            }
        }

        [Display(Name = "RPM")]
        public decimal RPM
        {
            get => _rpm;
            set
            {
                _rpm = value;
                RaisePropertyChanged(nameof(RPM));
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

        [Display(Name = "Number of Cuts")]
        public decimal NoOfCuts
        {
            get => _noOfCuts;
            set
            {
                _noOfCuts = value;
                RaisePropertyChanged(nameof(NoOfCuts));
            }
        }

        [Display(Name = "Length of the cut in mm")]
        public decimal LengthOfCut
        {
            get => _lengthOfCut;
            set
            {
                _lengthOfCut = value;
                RaisePropertyChanged(nameof(LengthOfCut));
            }
        }

        [Display(Name = "Length of hole to drill in mm")]
        public decimal LengthOfHoleToDrill
        {
            get => _lengthOfHoleToDrill;
            set
            {
                _lengthOfHoleToDrill = value;
                RaisePropertyChanged(nameof(_lengthOfHoleToDrill));
            }
        }

        [Display(Name = "Length of thread to cut in mm")]
        public decimal LengthOfThreadToCut
        {
            get => _lengthOfThreadToCut;
            set
            {
                _lengthOfThreadToCut = value;
                RaisePropertyChanged(nameof(_lengthOfThreadToCut));
            }
        }

        [Display(Name = "Machining Time in minutes")]
        public decimal MachiningTime
        {
            get => _machingTime;
            set
            {
                _machingTime = value;
                RaisePropertyChanged(nameof(MachiningTime));
            }
        }

        public decimal Average
        {
            get => _average;
            set
            {
                _average = value;
                RaisePropertyChanged(nameof(Average));
            }
        }


        [Display(Name = "Machining Cost")]
        public decimal MachiningCost
        {
            get => _machiningCost;
            set
            {
                _machiningCost = value;
                RaisePropertyChanged(nameof(MachiningCost));
            }
        }

        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    //case nameof(ProcessTypeID):
                    //    if (ProcessTypeID <= 0)
                    //    {
                    //        result = "Process Type ID is required.";
                    //    }
                    //    break;
                    //case nameof(ProcessTypeName):
                    //    if (string.IsNullOrWhiteSpace(ProcessTypeName))
                    //    {
                    //        result = "Process Type Name is required.";
                    //    }
                    //    break;
                    //case nameof(ComponentID):
                    //    if (ComponentID <= 0)
                    //    {
                    //        result = "Component ID is required.";
                    //    }
                    //    break;
                    //case nameof(ToolTypeID):
                    //    if (ToolTypeID <= 0)
                    //    {
                    //        result = "Tool Type ID is required.";
                    //    }
                    //    break;
                    //case nameof(ToolTypeName):
                    //    if (string.IsNullOrWhiteSpace(ToolTypeName))
                    //    {
                    //        result = "Tool Type Name is required.";
                    //    }
                    //    break;
                    //case nameof(ToolSurfaceID):
                    //    if (ToolSurfaceID <= 0)
                    //    {
                    //        result = "Tool Surface ID is required.";
                    //    }
                    //    break;
                    //case nameof(ToolSurfaceName):
                    //    if (string.IsNullOrWhiteSpace(ToolSurfaceName))
                    //    {
                    //        result = "Tool Surface Name is required.";
                    //    }
                    //    break;
                    //case nameof(CuttingSpeed):
                    //    if (CuttingSpeed <= 0)
                    //    {
                    //        result = "Cutting Speed must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(FeedRate):
                    //    if (FeedRate <= 0)
                    //    {
                    //        result = "Feed Rate must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(DrillSize):
                    //    if (DrillSize <= 0)
                    //    {
                    //        result = "Drill Size must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(ThreadDiameterToCut):
                    //    if (ThreadDiameterToCut <= 0)
                    //    {
                    //        result = "Thread Diameter to Cut must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(ThreadPitch):
                    //    if (ThreadPitch <= 0)
                    //    {
                    //        result = "Thread Pitch must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(DiameterBeforeTurning):
                    //    if (DiameterBeforeTurning <= 0)
                    //    {
                    //        result = "Diameter Before Turning must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(DiameterAfterTurning):
                    //    if (DiameterAfterTurning <= 0)
                    //    {
                    //        result = "Diameter After Turning must be greater than zero.";
                    //    }
                    //    break;
                   
                    //case nameof(DepthOfCutEachPass):
                    //    if (DepthOfCutEachPass <= 0)
                    //    {
                    //        result = "Depth of Cut for Each Pass must be greater than zero.";
                    //    }
                    //    break;
                    
                    //case nameof(LengthOfCut):
                    //    if (LengthOfCut <= 0)
                    //    {
                    //        result = "Length of the Cut must be greater than zero.";
                    //    }
                    //    break;
                    
                    //case nameof(MachiningCost):
                    //    break;
                }
                return result;
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
