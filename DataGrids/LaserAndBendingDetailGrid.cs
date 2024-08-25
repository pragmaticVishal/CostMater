using CostMater.Data;
using DetailsView.Data;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostMater.DataGrids
{
    public class LaserAndBendingDetailGrid
    {
        private SfDataGrid laserAndBendingDetailGrid;

        public LaserAndBendingDetailGrid(SfDataGrid laserAndBendingDetailGrid)
        {
            this.laserAndBendingDetailGrid = laserAndBendingDetailGrid;
        }

        public void Setup()
        {
            #region laserAndBendingDetailGrid
            laserAndBendingDetailGrid.EditMode = EditMode.SingleClick;
            laserAndBendingDetailGrid.AddNewRowText = "Click here to add new laser and bending detail";
            laserAndBendingDetailGrid.Style.AddNewRowStyle.BackColor = Color.DarkCyan;
            laserAndBendingDetailGrid.Style.AddNewRowStyle.TextColor = Color.White;
            laserAndBendingDetailGrid.Style.BorderStyle = BorderStyle.FixedSingle;
            laserAndBendingDetailGrid.Style.HeaderStyle.Font.Bold = true;
            laserAndBendingDetailGrid.Style.StackedHeaderStyle.Font.Bold = true;
            laserAndBendingDetailGrid.Style.SelectionStyle.BackColor = System.Drawing.SystemColors.Highlight;
            laserAndBendingDetailGrid.Style.SelectionStyle.TextColor = System.Drawing.SystemColors.HighlightText;
            laserAndBendingDetailGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            laserAndBendingDetailGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(22.0f);
            laserAndBendingDetailGrid.AutoGenerateColumns = false;
            laserAndBendingDetailGrid.ValidationMode = GridValidationMode.InEdit;
            laserAndBendingDetailGrid.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
            laserAndBendingDetailGrid.AllowDeleting = true;
            laserAndBendingDetailGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(21.0f);
            laserAndBendingDetailGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;


            laserAndBendingDetailGrid.RecordDeleting += LaserAndBendingDetailGrid_RecordDeleting;
            laserAndBendingDetailGrid.AddNewRowInitiating += LaserAndBendingDetailGrid_AddNewRowInitiating;
            //laserAndBendingDetailGrid.View.RecordPropertyChanged += View_RecordPropertyChanged;

            laserAndBendingDetailGrid.Columns.Add(new GridTextColumn { MappingName = "OperationName", HeaderText = "Operation", AllowEditing = false });
            laserAndBendingDetailGrid.Columns.Add(new GridTextColumn { MappingName = "ComponentID", HeaderText = "Component ID", AllowEditing = false });
            laserAndBendingDetailGrid.Columns.Add(new GridTextColumn { MappingName = "DrawingNo", HeaderText = "Drawing / Part No.", AllowEditing = false });
            laserAndBendingDetailGrid.Columns.Add(new GridComboBoxColumn { MappingName = "MaterialShapeSelectedID", HeaderText = "Material Shape", ValueMember = "ID", DisplayMember = "Name", IDataSourceSelector = new MaterialShapeList() });

            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Length", HeaderText = "Length" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Width", HeaderText = "Width" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Thickness", HeaderText = "Thickness" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Diameter", HeaderText = "Diameter" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "OD", HeaderText = "Outer Diameter" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "ID", HeaderText = "Inner Diameter" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Side1", HeaderText = "Side 1" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Side2", HeaderText = "Side 2" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Side3", HeaderText = "Side 3" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Perimeter", HeaderText = "Perimeter" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "NoOfStart", HeaderText = "No. of start" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Qty", HeaderText = "Qty" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "LaserCost", HeaderText = "Laser Cost", AllowEditing = false });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "NoOfBend", HeaderText = "No. of bend" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "BendRate", HeaderText = "Rate" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "BendTotalCost", HeaderText = "Bending Cost", AllowEditing = false });


            foreach (var column in laserAndBendingDetailGrid.Columns)
            {
                if (!column.AllowEditing)
                {
                    column.CellStyle.BackColor = Color.LightGray;
                }
            }

            #endregion
        }

        private void View_RecordPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "MaterialShapeSelectedID")
            {
                laserAndBendingDetailGrid.View.PropertyChanged -= View_RecordPropertyChanged;
            }
        }

        private void LaserAndBendingDetailGrid_RecordDeleting(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventArgs e)
        {
            var laserAndBendingDetail = e.Items[0] as LaserAndBendingDetail;

            if (laserAndBendingDetail != null && laserAndBendingDetail.Component.LstOneTimeOperationDetail.Count == 1)
            {
                MessageBox.Show("Atleast one operation is required.", "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Cancel the deletion
            }
            else
            {
                laserAndBendingDetail.PropertyChanged -= LaserAndBendingDetail_PropertyChanged;
            }
        }

        private void LaserAndBendingDetailGrid_AddNewRowInitiating(object sender, Syncfusion.WinForms.DataGrid.Events.AddNewRowInitiatingEventArgs e)
        {
            ObservableCollection<LaserAndBendingDetail> lstLaserAndBendingDetail = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<LaserAndBendingDetail>;
            var laserAndBendingDetail = new LaserAndBendingDetail
            {
                LaserAndBendingDetailID = lstLaserAndBendingDetail == null ? 1 : lstLaserAndBendingDetail.Max(x => x.LaserAndBendingDetailID) + 1,
                ComponentID = lstLaserAndBendingDetail[0].ComponentID,
                Component = lstLaserAndBendingDetail[0].Component,
            };
            laserAndBendingDetail.PropertyChanged += LaserAndBendingDetail_PropertyChanged;

            e.NewObject = laserAndBendingDetail;
        }

        public static void LstLaserAndBendingDetail_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) 
        {
            if (e.NewItems != null)
            {
                var laserAndBendingDetail = e.NewItems[0] as LaserAndBendingDetail;
                laserAndBendingDetail.Component.RecalculateLaserAndBendingCost();
            }

            if (e.OldItems != null)
            {
                foreach (OneTimeOperationDetail oneTimeOperationDetail in e.OldItems)
                {
                    oneTimeOperationDetail.PropertyChanged -= OneTimeOperationGrid.OneTimeOperation_PropertyChanged;
                }
            }
        }

        public static void LaserAndBendingDetail_PropertyChanged(object sender, PropertyChangedEventArgs e) 
        {
            List<string> excludeProps = new List<string>() { nameof(LaserAndBendingDetail.Perimeter), nameof(LaserAndBendingDetail.BendTotalCost),
            nameof(LaserAndBendingDetail.LaserCost)};

            if (excludeProps.Contains(e.PropertyName))
                return;

            var laserAndBendingDetail = sender as LaserAndBendingDetail;
            if (laserAndBendingDetail != null)
            {
                CalculatePerimeter(laserAndBendingDetail);
                CalculateCost(laserAndBendingDetail);
                laserAndBendingDetail.Component.RecalculateLaserAndBendingCost();
            }
        }

        private static void CalculatePerimeter(LaserAndBendingDetail laserAndBendingDetail)
        {
            switch (laserAndBendingDetail.MaterialShapeSelectedID)
            {
                case 1:
                    laserAndBendingDetail.Perimeter = 2 * (laserAndBendingDetail.Length + laserAndBendingDetail.Width);
                    break;
                case 2:
                    laserAndBendingDetail.Perimeter = 2 * (laserAndBendingDetail.Length + laserAndBendingDetail.Width);
                    break;
                case 3:
                    laserAndBendingDetail.Perimeter = 2 * (laserAndBendingDetail.Length + laserAndBendingDetail.Width);
                    break;
                case 4:
                    laserAndBendingDetail.Perimeter = laserAndBendingDetail.Side1 + laserAndBendingDetail.Side2;
                    break;
                case 5:
                    laserAndBendingDetail.Perimeter = 3.1416M * laserAndBendingDetail.Diameter;
                    break;
                case 6:
                    laserAndBendingDetail.Perimeter = 3.1416M * laserAndBendingDetail.OD;
                    break;
                case 7:
                    laserAndBendingDetail.Perimeter = 2 * (laserAndBendingDetail.Length + laserAndBendingDetail.Width);
                    break;
                case 8:
                    laserAndBendingDetail.Perimeter = 2 * (laserAndBendingDetail.Side1 + laserAndBendingDetail.Side2);
                    break;
                case 9:
                    laserAndBendingDetail.Perimeter = 2 * (laserAndBendingDetail.Length + laserAndBendingDetail.Width);
                    break;
                case 10:
                    laserAndBendingDetail.Perimeter = 2 * (laserAndBendingDetail.Side1 + laserAndBendingDetail.Side2);
                    break;
                case 11:
                    laserAndBendingDetail.Perimeter = laserAndBendingDetail.Side1 + laserAndBendingDetail.Side2 + laserAndBendingDetail.Side3;
                    break;
                case 12:
                    laserAndBendingDetail.Perimeter = (2 * laserAndBendingDetail.Length) + (3.1416M * laserAndBendingDetail.Diameter);
                    break;
                default:
                    break;
            }
        }

        private static void CalculateCost(LaserAndBendingDetail laserAndBendingDetail)
        {
            laserAndBendingDetail.BendTotalCost = laserAndBendingDetail.NoOfBend * laserAndBendingDetail.BendRate;
            if (laserAndBendingDetail.NoOfStart > 0)
            {
                laserAndBendingDetail.LaserCost = (laserAndBendingDetail.Perimeter * 0.06M * laserAndBendingDetail.Thickness) + (laserAndBendingDetail.NoOfStart * 1 * laserAndBendingDetail.Thickness);
            }
            else
            {
                laserAndBendingDetail.LaserCost = 0;
            }
        }
    }
}
