using CostMater.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DetailsView.Data
{
    public class Component : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields
        private int _componentID;
        private string _partName;
        private string _drawingNo;
        private int _materialID;
        private int _materialTypeID;

        private decimal _qty;
        private decimal _length;
        private decimal _width;
        private decimal _thickness;
        private decimal _diameter;
        private decimal _od;
        private decimal _id;
        private decimal _side1;
        private decimal _side2;
        private decimal _netWeight;
        private decimal _grossWeight;
        private decimal _perimeter;
        private decimal _laserCost;
        private decimal _bendTotalCost;
        private decimal _fabricationTotalCost;

        private decimal _surfaceTreatmentCost;
        private decimal _others_BO;
        private decimal _procurementCost;
        private decimal _rawMaterialRate;
        private decimal _labourCostPerPart;
        private decimal _rawMaterialCost;
        private decimal _totalCostPerPart;
        private decimal _totalCost;
        private decimal _totalMachiningCost;
        private decimal _grindingCost;
        private decimal _drillingCost;
        private decimal _hardwareCost;
        private decimal _miscellaneousCost;

        private ObservableCollection<Process> _lstProcess;
        private ObservableCollection<OneTimeOperationDetail> _lstOneTimeOperationDetail;
        private ObservableCollection<LaserAndBendingDetail> _lstLaserAndBendingDetail;

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        [Display(Name = "Component ID")]
        public int ComponentID
        {
            get => _componentID;
            set
            {
                if (_lstProcess == null)
                {
                    _lstProcess = new ObservableCollection<Process>();
                    _lstProcess.Add(new Process
                    {
                        ComponentID = value,
                        ProcessID = 1,
                        ProcessTypeID = 0,
                        ToolTypeID = 0,
                        ToolSurfaceID = 0,
                        MachiningCostPerHour = 300,
                        //CuttingSpeed = 40,
                        //FeedRate = 1.3M,
                        //DepthOfCutEachPass = 3.5M,
                        Component = this,
                    });
                };
                if(_lstOneTimeOperationDetail == null)
                {
                    _lstOneTimeOperationDetail = new ObservableCollection<OneTimeOperationDetail>();
                    _lstOneTimeOperationDetail.Add(new OneTimeOperationDetail()
                    {
                        ComponentID = value,
                        OnetimeOpDetailID = 1,
                        OneTimeOpItemSelectedID = 0,
                        Component = this,
                    });
                }
                if(_lstLaserAndBendingDetail == null)
                {
                    _lstLaserAndBendingDetail = new ObservableCollection<LaserAndBendingDetail>();
                    _lstLaserAndBendingDetail.Add(new LaserAndBendingDetail() 
                    {
                        ComponentID = value,
                        LaserAndBendingDetailID = 1,
                        MaterialShapeSelectedID = 0,
                        Component = this,
                    });
                }
                _componentID = value;
                RaisePropertyChanged(nameof(ComponentID));
            }
        }

        [Display(Name = "Part Name")]
        public string PartName
        {
            get => _partName;
            set
            {
                _partName = value;
                RaisePropertyChanged(nameof(PartName));
            }
        }

        [Display(Name = "Drawing / Part No.")]
        public string DrawingNo
        {
            get => _drawingNo;
            set
            {
                _drawingNo = value;
                RaisePropertyChanged(nameof(DrawingNo));
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

        [Display(Name = "Material Type")]
        [Required(ErrorMessage = "Material Type is required.")]
        public int MaterialTypeID
        {
            get => _materialTypeID;
            set
            {
                _materialTypeID = value;
                RaisePropertyChanged(nameof(MaterialTypeID));
            }
        }

        [Display(Name = "Total Cost")]
        public decimal TotalCost
        {
            get => _totalCost;
            set
            {
                _totalCost = value;
                RaisePropertyChanged(nameof(TotalCost));
            }
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

        [Display(Name = "Length")]
        public decimal Length
        {
            get => _length;
            set
            {
                _length = value;
                RaisePropertyChanged(nameof(Length));
            }
        }

        [Display(Name = "Width")]
        public decimal Width
        {
            get => _width;
            set
            {
                _width = value;
                RaisePropertyChanged(nameof(Width));
            }
        }

        [Display(Name = "Thickness")]
        public decimal Thickness
        {
            get => _thickness;
            set
            {
                _thickness = value;
                RaisePropertyChanged(nameof(Thickness));
            }
        }

        [Display(Name = "Diameter")]
        public decimal Diameter
        {
            get => _diameter;
            set
            {
                _diameter = value;
                RaisePropertyChanged(nameof(Diameter));
            }
        }

        [Display(Name = "OD")]
        public decimal OD
        {
            get => _od;
            set
            {
                _od = value;
                RaisePropertyChanged(nameof(OD));
            }
        }

        [Display(Name = "ID")]
        public decimal ID
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(ID));
            }
        }

        [Display(Name = "Side 1")]
        public decimal Side1
        {
            get => _side1;
            set
            {
                _side1 = value;
                RaisePropertyChanged(nameof(Side1));
            }
        }

        [Display(Name = "Side 2")]
        public decimal Side2
        {
            get => _side2;
            set
            {
                _side2 = value;
                RaisePropertyChanged(nameof(Side2));
            }
        }

        [Display(Name = "Net Weight")]
        public decimal NetWeight
        {
            get => _netWeight;
            set
            {
                _netWeight = value;
                RaisePropertyChanged(nameof(NetWeight));
            }
        }

        [Display(Name = "Gross Weight")]
        public decimal GrossWeight
        {
            get => _grossWeight;
            set
            {
                _grossWeight = value;
                RaisePropertyChanged(nameof(GrossWeight));
            }
        }

        [Display(Name = "Total Machining Cost")]
        public decimal TotalMachiningCost
        {
            get => _totalMachiningCost;
            set
            {
                _totalMachiningCost = value;
                RaisePropertyChanged(nameof(_totalMachiningCost));
            }
        }

        [Display(Name = "Laser Cost")]
        public decimal LaserCost
        {
            get => _laserCost;
            set
            {
                _laserCost = value;
                RaisePropertyChanged(nameof(LaserCost));
            }
        }

        [Display(Name = "Bending Total Cost")]
        public decimal BendTotalCost
        {
            get => _bendTotalCost;
            set
            {
                _bendTotalCost = value;
                RaisePropertyChanged(nameof(BendTotalCost));
            }
        }

        [Display(Name = "Procurement Cost")]
        public decimal ProcurementCost
        {
            get => _procurementCost;
            set
            {
                _procurementCost = value;
                RaisePropertyChanged(nameof(ProcurementCost));
            }
        }

        [Display(Name = "Fabrication total cost")]
        public decimal FabricationTotalCost
        {
            get => _fabricationTotalCost;
            set
            {
                _fabricationTotalCost = value;
                RaisePropertyChanged(nameof(FabricationTotalCost));
            }
        }

        [Display(Name = "Surface Treatment Cost")]
        public decimal SurfaceTreatmentCost
        {
            get => _surfaceTreatmentCost;
            set
            {
                _surfaceTreatmentCost = value;
                RaisePropertyChanged(nameof(SurfaceTreatmentCost));
            }
        }

        [Display(Name = "Others/B.O")]
        public decimal Others_BO
        {
            get => _others_BO;
            set
            {
                _others_BO = value;
                RaisePropertyChanged(nameof(Others_BO));
            }
        }

        [Display(Name = "Grinding Cost")]
        public decimal GrindingCost
        {
            get => _grindingCost;
            set
            {
                _grindingCost = value;
                RaisePropertyChanged(nameof(GrindingCost));
            }
        }

        [Display(Name = "Drilling Cost")]
        public decimal DrillingCost
        {
            get => _drillingCost;
            set
            {
                _drillingCost = value;
                RaisePropertyChanged(nameof(DrillingCost));
            }
        }

        [Display(Name = "Hardware Cost")]
        public decimal HardwareCost
        {
            get => _hardwareCost;
            set
            {
                _hardwareCost = value;
                RaisePropertyChanged(nameof(HardwareCost));
            }
        }

        [Display(Name = "Miscellanous Cost")]
        public decimal MiscellaneousCost
        {
            get => _miscellaneousCost;
            set
            {
                _miscellaneousCost = value;
                RaisePropertyChanged(nameof(MiscellaneousCost));
            }
        }

        [Display(Name = "Raw Material Rate")]
        public decimal RawMaterialRate
        {
            get => _rawMaterialRate;
            set
            {
                _rawMaterialRate = value;
                RaisePropertyChanged(nameof(RawMaterialRate));
            }
        }

        [Display(Name = "Labour Cost Per Part")]
        public decimal LabourCostPerPart
        {
            get => _labourCostPerPart;
            set
            {
                _labourCostPerPart = value;
                RaisePropertyChanged(nameof(LabourCostPerPart));
            }
        }

        [Display(Name = "Raw Material Cost")]
        public decimal RawMaterialCost
        {
            get => _rawMaterialCost;
            set
            {
                _rawMaterialCost = value;
                RaisePropertyChanged(nameof(RawMaterialCost));
            }
        }

        [Display(Name = "Total Cost Per Part")]
        public decimal TotalCostPerPart
        {
            get => _totalCostPerPart;
            set
            {
                _totalCostPerPart = value;
                RaisePropertyChanged(nameof(TotalCostPerPart));
            }
        }

        public ObservableCollection<Process> LstProcess
        {
            get => _lstProcess;
            set
            {
                _lstProcess = value;
                RaisePropertyChanged(nameof(LstProcess));
            }
        }

        public ObservableCollection<OneTimeOperationDetail> LstOneTimeOperationDetail
        {
            get => _lstOneTimeOperationDetail;
            set
            {
                _lstOneTimeOperationDetail = value;
                RaisePropertyChanged(nameof(LstOneTimeOperationDetail));
            }
        }

        public ObservableCollection<LaserAndBendingDetail> LstLaserAndBendingDetail
        {
            get => _lstLaserAndBendingDetail;
            set
            {
                _lstLaserAndBendingDetail = value;
                RaisePropertyChanged(nameof(LstLaserAndBendingDetail));
            }
        }

        public string Error {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    //case nameof(ComponentName):
                    //    break;
                    //case nameof(MaterialID):
                    //    if (MaterialID <= 0)
                    //    {
                    //        result = "Material is required.";
                    //    }
                    //    break;
                    //case nameof(MaterialTypeID):
                    //    if (MaterialTypeID <= 0)
                    //    {
                    //        result = "Material Type is required.";
                    //    }
                    //    break;
                    //case nameof(Qty):
                    //    if (Qty <= 0)
                    //    {
                    //        result = "Quantity must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(Length):
                    //    if (Qty > 0 && Length <= 0)
                    //    {
                    //        result = "Length must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(Width):
                    //    if (Width <= 0)
                    //    {
                    //        result = "Width must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(Thickness):
                    //    if (Thickness <= 0)
                    //    {
                    //        result = "Thickness must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(Diameter):
                    //    if (Diameter <= 0)
                    //    {
                    //        result = "Diameter must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(OD):
                    //    if (OD <= 0)
                    //    {
                    //        result = "Outer Diameter must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(ID):
                    //    if (ID <= 0)
                    //    {
                    //        result = "Inner Diameter must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(Side1):
                    //    if (Side1 <= 0)
                    //    {
                    //        result = "Side 1 must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(Side2):
                    //    if (Side2 <= 0)
                    //    {
                    //        result = "Side 2 must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(NetWeight):
                    //    if (NetWeight <= 0)
                    //    {
                    //        result = "Net Weight must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(GrossWeight):
                    //    if (GrossWeight <= 0)
                    //    {
                    //        result = "Gross Weight must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(Perimeter):
                    //    if (Perimeter <= 0)
                    //    {
                    //        result = "Perimeter must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(BendRate):
                    //    if (BendRate <= 0)
                    //    {
                    //        result = "Bending Rate must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(FabricationRate):
                    //    if (FabricationRate <= 0)
                    //    {
                    //        result = "Fabrication Rate must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(NoOfStart):
                    //    if (NoOfStart <= 0)
                    //    {
                    //        result = "Number of Start must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(LaserCost):
                    //    if (LaserCost <= 0)
                    //    {
                    //        result = "Laser Cost must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(NoOfBend):
                    //    if (NoOfBend <= 0)
                    //    {
                    //        result = "Number of Bend must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(BendTotalCost):
                    //    if (BendTotalCost <= 0)
                    //    {
                    //        result = "Bending Total Cost must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(ProcurementCost):
                    //    if (ProcurementCost <= 0)
                    //    {
                    //        result = "Procurement Cost must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(FabricationTotalCost):
                    //    if (FabricationTotalCost <= 0)
                    //    {
                    //        result = "Fabrication Total Cost must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(SurfaceTreatmentCost):
                    //    if (SurfaceTreatmentCost <= 0)
                    //    {
                    //        result = "Surface Treatment Cost must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(SurfaceTreatmentRate):
                    //    if (SurfaceTreatmentRate <= 0)
                    //    {
                    //        result = "Surface Treatment Rate must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(GrindingCost):
                    //    if (GrindingCost <= 0)
                    //    {
                    //        result = "Grinding Cost must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(RawMaterialRate):
                    //    if (RawMaterialRate <= 0)
                    //    {
                    //        result = "Raw Material Rate must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(LabourCostPerPart):
                    //    if (LabourCostPerPart <= 0)
                    //    {
                    //        result = "Labour Cost Per Part must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(RawMaterialCost):
                    //    if (RawMaterialCost <= 0)
                    //    {
                    //        result = "Raw Material Cost must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(TotalCostPerPart):
                    //    if (TotalCostPerPart <= 0)
                    //    {
                    //        result = "Total Cost Per Part must be greater than zero.";
                    //    }
                    //    break;
                    //case nameof(TotalMachiningCost):
                    //    break;
                    //case nameof(MachiningCostPerHour):
                    //    if (MachiningCostPerHour <= 0)
                    //    {
                    //        result = "Machining Cost Per Hour must be greater than zero.";
                    //    }
                    //    break;
                }
                return result;
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void RecalculateMachiningCost()
        {
            decimal machiningCost = 0;
            foreach (var process in LstProcess)
            {
                machiningCost += process.MachiningCost;
            }
            TotalMachiningCost = machiningCost;
        }

        internal void RecalculateOneTimeOperationCost()
        {
            FabricationTotalCost = LstOneTimeOperationDetail.Where(x=>x.OneTimeOpItemSelectedID == 1).Sum(x=>x.Amount);
            SurfaceTreatmentCost = LstOneTimeOperationDetail.Where(x => x.OneTimeOpItemSelectedID == 2).Sum(x => x.Amount); 
            GrindingCost = LstOneTimeOperationDetail.Where(x => x.OneTimeOpItemSelectedID == 3).Sum(x => x.Amount);
            ProcurementCost = LstOneTimeOperationDetail.Where(x => x.OneTimeOpItemSelectedID == 4).Sum(x => x.Amount);
            MiscellaneousCost = LstOneTimeOperationDetail.Where(x => x.OneTimeOpItemSelectedID == 5).Sum(x => x.Amount);
            Others_BO = LstOneTimeOperationDetail.Where(x => x.OneTimeOpItemSelectedID == 6).Sum(x => x.Amount);
            HardwareCost = LstOneTimeOperationDetail.Where(x => x.OneTimeOpItemSelectedID == 7).Sum(x => x.Amount);
        }

        internal void RecalculateLaserAndBendingCost()
        {
            LaserCost = LstLaserAndBendingDetail.Sum(x=>x.LaserCost);
            BendTotalCost = LstLaserAndBendingDetail.Sum(x=>x.BendTotalCost);
        }
    }
}
