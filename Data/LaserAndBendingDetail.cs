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
    public class LaserAndBendingDetail : INotifyPropertyChanged, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                //if (columnName == "MaterialShapeSelectedID")
                //{
                //    switch (MaterialShapeSelectedID)
                //    {
                //        case 1:
                //            string error = "";
                //            if (Length > 2 || Length < 1)
                //            {
                //                error += "Length shall be between 1 and 2 \n";
                //            }
                //            if (Width > 2 || Width < 1)
                //            {
                //                error += "Width shall be between 1 and 2 \n";
                //            }
                //            if (Thickness > 2 || Thickness < 1)
                //            {
                //                error += "Length shall be between 1 and 2";
                //            }
                //            return error;
                //            break;
                //    }
                //}

                return string.Empty;
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public int OperationNameSelectedID
        {
            get => _operationNameSelectedID;
            set
            {
                _operationNameSelectedID = value;
                RaisePropertyChanged(nameof(OperationNameSelectedID));
            }
        }

        public int LaserAndBendingDetailID
        {
            get => _laserAndBendingDetailID;
            set
            {
                _laserAndBendingDetailID = value;
                RaisePropertyChanged(nameof(LaserAndBendingDetailID));
            }
        }
        public int ComponentID
        {
            get => _componentID;
            set
            {
                _componentID = value;
                RaisePropertyChanged(nameof(ComponentID));
            }
        }
        public int MaterialShapeSelectedID
        {
            get => _materialShapeSelectedID;
            set
            {
                _materialShapeSelectedID = value;
                RaisePropertyChanged(nameof(MaterialShapeSelectedID));
            }
        }

        public string DrawingNo
        {
            get => Component.DrawingNo;
        }

        public decimal Length
        {
            get => _length;
            set
            {
                _length = value;
                RaisePropertyChanged(nameof(Length));
            }
        }

        public decimal Width
        {
            get => _width;
            set
            {
                _width = value;
                RaisePropertyChanged(nameof(Width));
            }
        }

        public decimal Thickness
        {
            get => Component.Thickness;
        }

        public decimal Diameter
        {
            get => _diameter;
            set
            {
                _diameter = value;
                RaisePropertyChanged(nameof(Diameter));
            }
        }

        public decimal OD
        {
            get => _od;
            set
            {
                _od = value;
                RaisePropertyChanged(nameof(OD));
            }
        }

        public decimal Side1
        {
            get => _side1;
            set
            {
                _side1 = value;
                RaisePropertyChanged(nameof(Side1));
            }
        }

        public decimal Side2
        {
            get => _side2;
            set
            {
                _side2 = value;
                RaisePropertyChanged(nameof(Side2));
            }
        }

        public decimal Side3
        {
            get => _side3;
            set
            {
                _side3 = value;
                RaisePropertyChanged(nameof(Side3));
            }
        }

        public decimal Perimeter
        {
            get => _perimeter;
            set
            {
                _perimeter = value;
                RaisePropertyChanged(nameof(Perimeter));
            }
        }

        public int NoOfStart
        {
            get => _noOfStart;
        }

        public decimal Qty
        {
            get => _qty;
            set
            {
                _qty = value;
                RaisePropertyChanged(nameof(Qty));
            }
        }

        public decimal LaserCost
        {
            get => _laserCost;
            set
            {
                _laserCost = value;
                RaisePropertyChanged(nameof(LaserCost));
            }
        }

        public int NoOfBend
        {
            get => _noOfBend;
            set
            {
                _noOfBend = value;
                RaisePropertyChanged(nameof(NoOfBend));
            }
        }

        public int NoOfSides
        {
            get => _noOfSides;
            set
            {
                _noOfSides = value;
                RaisePropertyChanged(nameof(NoOfSides));
            }
        }

        public decimal BendRate
        {
            get => _bendRate;
            set
            {
                _bendRate = value;
                RaisePropertyChanged(nameof(BendRate));
            }
        }

        public decimal BendTotalCost
        {
            get => _bendTotalCost;
            set
            {
                _bendTotalCost = value;
                RaisePropertyChanged(nameof(BendTotalCost));
            }
        }

        public decimal TotalCost
        {
            get => _totalCost;
            set
            {
                _totalCost = value;
                RaisePropertyChanged(nameof(TotalCost));
            }
        }

        public Component Component
        {
            get => _component;
            set
            {
                _component = value;
                RaisePropertyChanged(nameof(Component));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private int _laserAndBendingDetailID;
        private int _componentID;
        private int _materialShapeSelectedID;
        private int _operationNameSelectedID;
        private decimal _length;
        private decimal _width;
        private decimal _diameter;
        private decimal _od;
        private decimal _side1;
        private decimal _side2;
        private decimal _side3;
        private decimal _perimeter;
        private int _noOfStart = 1;
        private decimal _qty;
        private decimal _laserCost;
        private int _noOfBend;
        private int _noOfSides;
        private decimal _bendRate;
        private decimal _bendTotalCost;
        private decimal _totalCost;
        private Component _component;
        private Dictionary<int, List<string>> dctLaserMaterialShapeAllowedSides = GetLaserAllowedSidesDct();
        private Dictionary<int, List<string>> dctBendingAllowedSides = GetBendingAllowedSidesDct();

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ResetAllFields()
        {
            _length = 0;
            _width = 0;
            _diameter = 0;
            _od = 0;
            _side1 = 0;
            _side2 = 0;
            _side3 = 0;
            _perimeter = 0;
            _qty = 0;
            _laserCost = 0;
            _noOfBend = 0;
            _noOfSides = 0;
            _bendRate = 0;
            _bendTotalCost = 0;
            _totalCost = 0;
        }
        public void CalculatePerimeter()
        {
            switch (MaterialShapeSelectedID)
            {
                case 1:
                    Perimeter = 2 * (Length + Width);
                    break;
                case 2:
                    Perimeter = Side1 + Side2;
                    break;
                case 3:
                    Perimeter = 3.1416M * Diameter;
                    break;
                case 4:
                    Perimeter = 3.1416M * OD;
                    break;
                case 5:
                    Perimeter = 2 * (Length + Width);
                    break;
                case 6:
                    Perimeter = 4 * Length;
                    break;
                case 7:
                    Perimeter = Side1 + Side2 + Side3;
                    break;
                case 8:
                    Perimeter = (2 * Length) + (3.1416M * Diameter);
                    break;
                case 9:
                    Perimeter = NoOfSides * Side1;  
                    break;
                case 10:
                    // User Input
                    break;
                case 11:
                    Perimeter = Length + Side1 + Side2 + Side3;
                    break;
                case 12:
                    Perimeter = 5 * Length;
                    break;
                case 13:
                    Perimeter = 6 * Length;
                    break;
                case 14:
                    Perimeter = 8 * Length;
                    break;
                case 15:
                    Perimeter = Convert.ToDecimal((Convert.ToDouble((2 * 3.1416M)) * Math.Sqrt(Convert.ToDouble(((Side1 * Side1) + (Side2 * Side2)) / 2))));
                    break;
                default:
                    break;
            }
        }

        public void CalculateCost()
        {
            ResetOperationAndMaterialShapeBasedOnParentMaterialType();
            
            if (_operationNameSelectedID == 0)
            {
                ResetAllFields();
            }
            else if (_operationNameSelectedID == 3)
            {
                _length = Component.Length;
            }

            CalculatePerimeter();

            if (NoOfStart > 0)
            {
                LaserCost = Qty * ((Perimeter * 0.06M * Component.Thickness) + (NoOfStart * 1 * Component.Thickness));
                BendTotalCost = 0;
            }
            else
            {
                LaserCost = 0;
            }

            if (OperationNameSelectedID == 2)
            {
                LaserCost = 0;
                BendTotalCost = NoOfBend * BendRate;
            }
            else if (OperationNameSelectedID == 3)
            {
                LaserCost = 0;
                BendTotalCost = Length * Thickness * NoOfBend * BendRate;
            }

            TotalCost = LaserCost + BendTotalCost;
        }

        public void ResetOperationAndMaterialShapeBasedOnParentMaterialType()
        {
            List<int> allowedMaterialType = new List<int>() { 1, 2, 3 };
            if (!allowedMaterialType.Contains(Component.MaterialTypeID))
            {
                _materialShapeSelectedID = 0;
                _operationNameSelectedID = 0;
            }
        }

        public bool IsSideApplicableToTheShape(int operationNameSelectedID, int materialShapeSelectedID, string sideName)
        {
            bool isSideApplicableToTheShape = true;               

            switch (operationNameSelectedID)
            {
                case 1:
                    if (dctLaserMaterialShapeAllowedSides.ContainsKey(materialShapeSelectedID) && dctLaserMaterialShapeAllowedSides[materialShapeSelectedID].Contains(sideName))
                    {
                        isSideApplicableToTheShape = false;
                    }
                    break;
                case 2:
                    if (dctBendingAllowedSides.ContainsKey(operationNameSelectedID) && dctBendingAllowedSides[operationNameSelectedID].Contains(sideName))
                    {
                        isSideApplicableToTheShape = false;
                    }
                    break;
                case 3:                    
                    if (dctBendingAllowedSides.ContainsKey(operationNameSelectedID) && dctBendingAllowedSides[operationNameSelectedID].Contains(sideName))
                    {
                        isSideApplicableToTheShape = false;
                    }
                    else if(sideName == nameof(LaserAndBendingDetail.Length))
                    {
                        isSideApplicableToTheShape = false;
                    }
                    break;
            }

            return isSideApplicableToTheShape;
        }

        private static Dictionary<int, List<string>> GetLaserAllowedSidesDct()
        {
            Dictionary<int, List<string>> dctMaterialShapeAllowedSides = new Dictionary<int, List<string>>();

            List<string> excludeAllSides = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.Thickness), nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                    nameof(LaserAndBendingDetail.Perimeter), nameof(LaserAndBendingDetail.NoOfStart), nameof(LaserAndBendingDetail.Qty),
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost), nameof(LaserAndBendingDetail.NoOfSides)
            };

            List<string> excludeSidesSheet = new List<string>() { nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.NoOfSides), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                    nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate), nameof(LaserAndBendingDetail.BendTotalCost)};

            List<string> excludeSidesAngle = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width), nameof(LaserAndBendingDetail.Diameter),
                    nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides), nameof(LaserAndBendingDetail.Side3),
                    nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate), nameof(LaserAndBendingDetail.BendTotalCost)};

            List<string> excludeSidesRound = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                    nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesCylindrical = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                     nameof(LaserAndBendingDetail.Diameter),  nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesRectangular = new List<string>() { nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesSquare = new List<string>() {  nameof(LaserAndBendingDetail.Width),
                     nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                    nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesTriangle = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesSlot = new List<string>() {  nameof(LaserAndBendingDetail.Width),
                      nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesIrregular = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                     nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesOthers = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                     nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesTrapezoid = new List<string>() { nameof(LaserAndBendingDetail.Width),
                     nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesPentagon = new List<string>() { nameof(LaserAndBendingDetail.Width),
                     nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesHexagon = new List<string>() {  nameof(LaserAndBendingDetail.Width),
                     nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesOctagon = new List<string>() {  nameof(LaserAndBendingDetail.Width),
                     nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesEllipsisOval = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                     nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side3),
                     nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            dctMaterialShapeAllowedSides.Add(0, excludeAllSides);
            dctMaterialShapeAllowedSides.Add(1, excludeSidesSheet);
            dctMaterialShapeAllowedSides.Add(2, excludeSidesAngle);
            dctMaterialShapeAllowedSides.Add(3, excludeSidesRound);
            dctMaterialShapeAllowedSides.Add(4, excludeSidesCylindrical);
            dctMaterialShapeAllowedSides.Add(5, excludeSidesRectangular);
            dctMaterialShapeAllowedSides.Add(6, excludeSidesSquare);
            dctMaterialShapeAllowedSides.Add(7, excludeSidesTriangle);
            dctMaterialShapeAllowedSides.Add(8, excludeSidesSlot);
            dctMaterialShapeAllowedSides.Add(9, excludeSidesIrregular);
            dctMaterialShapeAllowedSides.Add(10, excludeSidesOthers);
            dctMaterialShapeAllowedSides.Add(11, excludeSidesTrapezoid);
            dctMaterialShapeAllowedSides.Add(12, excludeSidesPentagon);
            dctMaterialShapeAllowedSides.Add(13, excludeSidesHexagon);
            dctMaterialShapeAllowedSides.Add(14, excludeSidesOctagon);
            dctMaterialShapeAllowedSides.Add(15, excludeSidesEllipsisOval);
            return dctMaterialShapeAllowedSides;
        }

        private static Dictionary<int, List<string>> GetBendingAllowedSidesDct()
        {
            Dictionary<int, List<string>> dctBendingAllowedSides = new Dictionary<int, List<string>>();

            List<string> excludeAllSides = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.Thickness), nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3),
                    nameof(LaserAndBendingDetail.Perimeter), nameof(LaserAndBendingDetail.NoOfStart), nameof(LaserAndBendingDetail.Qty),
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.NoOfBend), nameof(LaserAndBendingDetail.BendRate),
                    nameof(LaserAndBendingDetail.BendTotalCost)
            };

            List<string> excludeSidesBendingCount = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.Thickness), nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3), nameof(LaserAndBendingDetail.Qty),
                    nameof(LaserAndBendingDetail.Perimeter), nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.MaterialShapeSelectedID)
            };

            List<string> excludeSidesBendingDimension = new List<string>() {nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.NoOfSides),
                    nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3), nameof(LaserAndBendingDetail.Qty),
                    nameof(LaserAndBendingDetail.Perimeter), nameof(LaserAndBendingDetail.NoOfStart), 
                    nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.MaterialShapeSelectedID)
            };

            dctBendingAllowedSides.Add(0, excludeAllSides);
            dctBendingAllowedSides.Add(2, excludeSidesBendingCount);
            dctBendingAllowedSides.Add(3, excludeSidesBendingDimension);

            return dctBendingAllowedSides;
        }

        public void ResetValue(string mappingName)
        {
            switch (mappingName)
            {
                case nameof(LaserAndBendingDetail.Length):
                    Length = 0;
                    break;
                case nameof(LaserAndBendingDetail.Width):
                    Width = 0;
                    break;
                case nameof(LaserAndBendingDetail.Diameter):
                    Diameter = 0;
                    break;
                case nameof(LaserAndBendingDetail.OD):
                    OD = 0;
                    break;
                case nameof(LaserAndBendingDetail.NoOfSides):
                    NoOfSides = 0;
                    break;
                case nameof(LaserAndBendingDetail.Side1):
                    Side1 = 0;
                    break;
                case nameof(LaserAndBendingDetail.Side2):
                    Side2 = 0;
                    break;
                case nameof(LaserAndBendingDetail.Side3):
                    Side3 = 0;
                    break;
                case nameof(LaserAndBendingDetail.MaterialShapeSelectedID):
                    MaterialShapeSelectedID = 0;
                    break;
            }
        }

        internal bool AllowOperation(int operationId)
        {
            return !(operationId > 0 && Component.RawMaterialCost == 0);
        }
    }
}
