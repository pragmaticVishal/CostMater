using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public string OperationName
        {
            get => "Laser Cutting and Bending";
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
            get => _thickness;
            set
            {
                _thickness = value;
                RaisePropertyChanged(nameof(Thickness));
            }
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

        public decimal ID
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(ID));
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
            set
            {
                _noOfStart = value;
                RaisePropertyChanged(nameof(NoOfStart));
            }
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
        private decimal _length;
        private decimal _width;
        private decimal _thickness;
        private decimal _diameter;
        private decimal _od;
        private decimal _id;
        private decimal _side1;
        private decimal _side2;
        private decimal _side3;
        private decimal _perimeter;
        private int _noOfStart;
        private decimal _qty;
        private decimal _laserCost;
        private int _noOfBend;
        private decimal _bendRate;
        private decimal _bendTotalCost;
        private Component _component;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsSideApplicableToTheShape(string sideName)
        {
            bool isSideApplicableToTheShape = true;

            Dictionary<int, List<string>> dctMaterialShapeAllowedSides = new Dictionary<int, List<string>>();

            List<string> excludedSidesSheet = new List<string>() { nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesPlate = new List<string>() { nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesFlat = new List<string>() { nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesAngle = new List<string>() { nameof(LaserAndBendingDetail.Width), nameof(LaserAndBendingDetail.Diameter),
                    nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesRoundBar = new List<string>() { nameof(LaserAndBendingDetail.Width), 
                    nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2),
                    nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesRoundTube = new List<string>() { nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesRectBar = new List<string>() { nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesRectTube = new List<string>() {  nameof(LaserAndBendingDetail.Width), nameof(LaserAndBendingDetail.Diameter),
                    nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesSqBar = new List<string>() { nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesSqTube = new List<string>() {  nameof(LaserAndBendingDetail.Width), nameof(LaserAndBendingDetail.Diameter),
                    nameof(LaserAndBendingDetail.OD), nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesTriangle = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),nameof(LaserAndBendingDetail.ID) };

            List<string> excludedSidesSlot = new List<string>() { nameof(LaserAndBendingDetail.Width),nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesIrregularShape = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3) };

            List<string> excludedSidesOthers = new List<string>() { nameof(LaserAndBendingDetail.Length), nameof(LaserAndBendingDetail.Width),
                    nameof(LaserAndBendingDetail.Diameter), nameof(LaserAndBendingDetail.OD),
                    nameof(LaserAndBendingDetail.ID), nameof(LaserAndBendingDetail.Side1), nameof(LaserAndBendingDetail.Side2), nameof(LaserAndBendingDetail.Side3) };

            dctMaterialShapeAllowedSides.Add(1, excludedSidesSheet);
            dctMaterialShapeAllowedSides.Add(2, excludedSidesPlate);
            dctMaterialShapeAllowedSides.Add(3, excludedSidesFlat);
            dctMaterialShapeAllowedSides.Add(4, excludedSidesAngle);
            dctMaterialShapeAllowedSides.Add(5, excludedSidesRoundBar);
            dctMaterialShapeAllowedSides.Add(6, excludedSidesRoundTube);
            dctMaterialShapeAllowedSides.Add(7, excludedSidesRectBar);
            dctMaterialShapeAllowedSides.Add(8, excludedSidesRectTube);
            dctMaterialShapeAllowedSides.Add(9, excludedSidesSqBar);
            dctMaterialShapeAllowedSides.Add(10, excludedSidesSqTube);
            dctMaterialShapeAllowedSides.Add(11, excludedSidesTriangle);
            dctMaterialShapeAllowedSides.Add(12, excludedSidesSlot);
            dctMaterialShapeAllowedSides.Add(13, excludedSidesIrregularShape);
            dctMaterialShapeAllowedSides.Add(14, excludedSidesOthers);

            if (dctMaterialShapeAllowedSides.ContainsKey(MaterialShapeSelectedID) &&
                dctMaterialShapeAllowedSides[MaterialShapeSelectedID].Contains(sideName))
            {
                isSideApplicableToTheShape = false;
            }

            return isSideApplicableToTheShape;
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
                case nameof(LaserAndBendingDetail.Thickness):
                    Thickness = 0;
                    break;
                case nameof(LaserAndBendingDetail.Diameter):
                    Diameter = 0;
                    break;
                case nameof(LaserAndBendingDetail.OD):
                    OD = 0;
                    break;
                case nameof(LaserAndBendingDetail.ID):
                    ID = 0;
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
            }
        }
    }
}
