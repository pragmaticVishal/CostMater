using CostMater.Data;
using CostMater.Framework;
using DetailsView.Data;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
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
            laserAndBendingDetailGrid.SelectionController = new RowSelectionControllerExt(laserAndBendingDetailGrid);
            laserAndBendingDetailGrid.EditMode = EditMode.SingleClick;
            laserAndBendingDetailGrid.AddNewRowText = "Click here to add new laser and bending detail";
            laserAndBendingDetailGrid.AddNewRowPosition = RowPosition.FixedBottom;
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
            laserAndBendingDetailGrid.AllowDeleting = true;
            laserAndBendingDetailGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(21.0f);
            laserAndBendingDetailGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;

            laserAndBendingDetailGrid.RecordDeleting += LaserAndBendingDetailGrid_RecordDeleting;
            laserAndBendingDetailGrid.CurrentCellBeginEdit += LaserAndBendingDetailGrid_CurrentCellBeginEdit;
            laserAndBendingDetailGrid.QueryCellStyle += LaserAndBendingDetailGrid_QueryCellStyle;
            laserAndBendingDetailGrid.RowValidating += LaserAndBendingDetailGrid_RowValidating;
            laserAndBendingDetailGrid.CurrentCellActivating += LaserAndBendingDetailGrid_CurrentCellActivating;

            laserAndBendingDetailGrid.Columns.Add(new GridComboBoxColumn { MappingName = "OperationNameSelectedID", HeaderText = "Operations", ValueMember = "ID", DisplayMember = "Name", IDataSourceSelector = new LaserAndBendingList(), Width = 180 });
            laserAndBendingDetailGrid.Columns.Add(new GridTextColumn { MappingName = "LaserAndBendingDetailID", HeaderText = "Laser ID", AllowEditing = false });
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

            ShowSummaryRow();
            laserAndBendingDetailGrid.LiveDataUpdateMode = Syncfusion.Data.LiveDataUpdateMode.AllowDataShaping;
            #endregion
        }

        private void LaserAndBendingDetailGrid_CurrentCellActivating(object sender, CurrentCellActivatingEventArgs e)
        {
            if (e.DataRow.RowType == RowType.AddNewRow)
            {
                if (KeyStateHelper.IsKeyDown(Keys.Down))
                {
                    System.Windows.Forms.SendKeys.Send("{DOWN}");
                    return;
                }
                if (KeyStateHelper.IsKeyDown(Keys.Up))
                {
                    System.Windows.Forms.SendKeys.Send("{UP}");
                    return;
                }
                ObservableCollection<LaserAndBendingDetail> lstLaserAndBendingDetail = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<LaserAndBendingDetail>;
                LaserAndBendingDetail laserAndBendingDetail = new LaserAndBendingDetail
                {
                    LaserAndBendingDetailID = lstLaserAndBendingDetail == null ? 1 : lstLaserAndBendingDetail.Max(x => x.LaserAndBendingDetailID) + 1,
                    ComponentID = lstLaserAndBendingDetail[0].ComponentID,
                    Component = lstLaserAndBendingDetail[0].Component,
                };
                laserAndBendingDetail.PropertyChanged += LaserAndBendingDetail_PropertyChanged;
                lstLaserAndBendingDetail.Add(laserAndBendingDetail);
            }

            //LaserAndBendingDetail laserAndBendingDetail1 = e.DataRow.RowData as LaserAndBendingDetail;
            //if (e.DataRow.RowType == RowType.DefaultRow && !laserAndBendingDetail1.IsSideApplicableToTheShape(e.DataColumn.GridColumn.MappingName))
            //{
            //    if (KeyStateHelper.IsKeyDown(Keys.Tab))
            //    {
            //        System.Windows.Forms.SendKeys.Send("{TAB}");
            //        return;
            //    }
            //}
        }

        private void ShowSummaryRow()
        {
            laserAndBendingDetailGrid.TableSummaryRows.Add(new GridTableSummaryRow()
            {
                Name = "tableSumamryTrue",
                ShowSummaryInRow = true,
                Title = "Total cost for laser work is {AllLaserCost} and for bending work is {AllBendingCost}",
                SummaryColumns = new System.Collections.ObjectModel.ObservableCollection<Syncfusion.Data.ISummaryColumn>()
                {
                    new GridSummaryColumn()
                    {
                        Name = "AllLaserCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="LaserCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "AllBendingCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="BendTotalCost",
                    }
                }
            });
        }

        //private void LaserAndBendingDetailGrid_CurrentCellValidating(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellValidatingEventArgs e)
        //{
        //    var laserAndBendingDetail = e.RowData as LaserAndBendingDetail;
        //    if (!e.IsValid)
        //        return;
        //    if (e.Column.MappingName == "MaterialShapeSelectedID")
        //    {
        //        switch (laserAndBendingDetail.MaterialShapeSelectedID)
        //        {
        //            case 1:
        //                if (laserAndBendingDetail.Length > 2 || laserAndBendingDetail.Length < 1)
        //                {
        //                    e.IsValid = false;
        //                    e.ErrorMessage += "1. Length shall be between 1 and 2 \n";
        //                }
        //                if (laserAndBendingDetail.Width > 2 || laserAndBendingDetail.Width < 1)
        //                {
        //                    e.IsValid = false;
        //                    e.ErrorMessage += "2. Width shall be between 1 and 2 \n";
        //                }
        //                if (laserAndBendingDetail.Thickness > 2 || laserAndBendingDetail.Thickness < 1)
        //                {
        //                    e.IsValid = false;
        //                    e.ErrorMessage += "3. Length shall be between 1 and 2";
        //                }
        //                break;
        //        }
        //    }
        //}

        private void LaserAndBendingDetailGrid_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
        {
            var laserAndBendingDetail = e.DataRow.RowData as LaserAndBendingDetail;
            
            foreach(var column in laserAndBendingDetailGrid.Columns)
            {
                if (!laserAndBendingDetail.IsSideApplicableToTheShape(column.MappingName))
                {
                    laserAndBendingDetail.ResetValue(column.MappingName);
                }
            }
        }

        private void LaserAndBendingDetailGrid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if(e.DataRow.RowType == RowType.DefaultRow)
            {
                var laserAndBendingDetail = e.DataRow.RowData as LaserAndBendingDetail;
                if(!laserAndBendingDetail.IsSideApplicableToTheShape(e.Column.MappingName))
                {
                    e.Style.BackColor = Color.LightGray;
                }
            }
        }      

        private void LaserAndBendingDetailGrid_CurrentCellBeginEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellBeginEditEventArgs e)
        {
            var laserAndBendingDetail = e.DataRow.RowData as LaserAndBendingDetail;
            if (!laserAndBendingDetail.IsSideApplicableToTheShape(e.DataColumn.GridColumn.MappingName))
            {
                e.Cancel = true;
            }
        }

        private void LaserAndBendingDetailGrid_RecordDeleting(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventArgs e)
        {
            var laserAndBendingDetail = e.Items[0] as LaserAndBendingDetail;

            if (laserAndBendingDetail != null && laserAndBendingDetail.Component.LstLaserAndBendingDetail.Count == 1)
            {
                MessageBoxAdv.Show("Atleast one operation is required.", "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Cancel the deletion
            }
            else
            {
                ObservableCollection<LaserAndBendingDetail> lstLaserAndBendingDetail = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<LaserAndBendingDetail>;
                int deleteIndex = lstLaserAndBendingDetail.IndexOf(laserAndBendingDetail);
                if (deleteIndex > -1)
                {
                    lstLaserAndBendingDetail.RemoveAt(deleteIndex);
                }
                laserAndBendingDetail.PropertyChanged -= LaserAndBendingDetail_PropertyChanged;
            }
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
                var laserAndBendingDetail = e.OldItems[0] as LaserAndBendingDetail;
                laserAndBendingDetail.Component.RecalculateLaserAndBendingCost();
                laserAndBendingDetail.PropertyChanged -= LaserAndBendingDetailGrid.LaserAndBendingDetail_PropertyChanged;
            }
        }

        public static void LaserAndBendingDetail_PropertyChanged(object sender, PropertyChangedEventArgs e) 
        {
            List<string> excludeProps = new List<string>() { nameof(LaserAndBendingDetail.Perimeter), nameof(LaserAndBendingDetail.BendTotalCost),
            nameof(LaserAndBendingDetail.LaserCost), nameof(LaserAndBendingDetail.TotalCost)};

            if (excludeProps.Contains(e.PropertyName))
                return;

            var laserAndBendingDetail = sender as LaserAndBendingDetail;
            if (laserAndBendingDetail != null)
            {
                laserAndBendingDetail.CalculateCost();
                laserAndBendingDetail.Component.RecalculateLaserAndBendingCost();
            }
        }
    }
}
