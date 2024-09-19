using CostMater.Data;
using CostMater.Framework;
using DetailsView.Data;
using Syncfusion.Data;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Data;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.Input.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CostMater.DataGrids
{
    public class LaserAndBendingDetailGrid
    {
        private SfDataGrid laserAndBendingDetailGrid;
        public bool hasValidationError = false;
        const string operationSelectionRequiredError = "Operation cannot be empty.";

        public LaserAndBendingDetailGrid(SfDataGrid laserAndBendingDetailGrid)
        {
            this.laserAndBendingDetailGrid = laserAndBendingDetailGrid;
        }

        public void Setup()
        {
            #region laserAndBendingDetailGrid
            laserAndBendingDetailGrid.SelectionController = new RowSelectionControllerExt(laserAndBendingDetailGrid);
            laserAndBendingDetailGrid.AllowResizingColumns = true;
            laserAndBendingDetailGrid.AllowTriStateSorting = true;
            laserAndBendingDetailGrid.ShowHeaderToolTip = true;
            laserAndBendingDetailGrid.ShowToolTip = true;
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
            laserAndBendingDetailGrid.SelectionMode = GridSelectionMode.Single;
            laserAndBendingDetailGrid.SelectionUnit = SelectionUnit.Cell;
            laserAndBendingDetailGrid.CopyOption = CopyOptions.IncludeHeaders;
            laserAndBendingDetailGrid.PasteOption = PasteOptions.PasteData;
            //laserAndBendingDetailGrid.NotifyEventsToParentDataGrid = true;

            laserAndBendingDetailGrid.RecordDeleting += LaserAndBendingDetailGrid_RecordDeleting;
            laserAndBendingDetailGrid.CurrentCellBeginEdit += LaserAndBendingDetailGrid_CurrentCellBeginEdit;
            laserAndBendingDetailGrid.QueryCellStyle += LaserAndBendingDetailGrid_QueryCellStyle;
            laserAndBendingDetailGrid.CurrentCellValidating += LaserAndBendingDetailGrid_CurrentCellValidating;
            laserAndBendingDetailGrid.RowValidating += LaserAndBendingDetailGrid_RowValidating;
            laserAndBendingDetailGrid.RowValidated += LaserAndBendingDetailGrid_RowValidated;
            laserAndBendingDetailGrid.CurrentCellActivating += LaserAndBendingDetailGrid_CurrentCellActivating;
            laserAndBendingDetailGrid.SelectionChanged += LaserAndBendingDetailGrid_SelectionChanged;
            laserAndBendingDetailGrid.CellButtonClick += LaserAndBendingDetailGrid_CellButtonClick;

            laserAndBendingDetailGrid.Columns.Add(new GridButtonColumn { MappingName = "Button", HeaderText="Action", DefaultButtonText="Delete", AllowDefaultButtonText=true});
            laserAndBendingDetailGrid.Columns.Add(new GridComboBoxColumn { MappingName = "OperationNameSelectedID", HeaderText = "Operations", ValueMember = "ID", DisplayMember = "Name", IDataSourceSelector = new LaserAndBendingList(), Width = 210 });
            laserAndBendingDetailGrid.Columns.Add(new GridTextColumn { MappingName = "LaserAndBendingDetailID", HeaderText = "Laser ID", AllowEditing = false });
            laserAndBendingDetailGrid.Columns.Add(new GridTextColumn { MappingName = "ComponentID", HeaderText = "Component ID", AllowEditing = false });
            laserAndBendingDetailGrid.Columns.Add(new GridTextColumn { MappingName = "DrawingNo", HeaderText = "Drawing / Part No.", AllowEditing = false });
            laserAndBendingDetailGrid.Columns.Add(new GridComboBoxColumn { MappingName = "MaterialShapeSelectedID", HeaderText = "Cutting Profile", ValueMember = "ID", DisplayMember = "Name", IDataSourceSelector = new MaterialShapeList() });

            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Length", HeaderText = "Length" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Width", HeaderText = "Width" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Thickness", HeaderText = "Thickness", AllowEditing = false });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Diameter", HeaderText = "Diameter" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "OD", HeaderText = "Outer Diameter" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "NoOfSides", HeaderText = "No. of sides" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Side1", HeaderText = "Side 1" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Side2", HeaderText = "Side 2" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Side3", HeaderText = "Side 3" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Perimeter", HeaderText = "Perimeter" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "Qty", HeaderText = "Qty" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "LaserCost", HeaderText = "Laser Cost", AllowEditing = false, FormatMode = FormatMode.Currency });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "NoOfBend", HeaderText = "No. of bend" });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "BendRate", HeaderText = "Rate per Bend", FormatMode = FormatMode.Currency });
            laserAndBendingDetailGrid.Columns.Add(new GridNumericColumn { MappingName = "BendTotalCost", HeaderText = "Bending Cost", AllowEditing = false, FormatMode = FormatMode.Currency });


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

        private void LaserAndBendingDetailGrid_CellButtonClick(object sender, CellButtonClickEventArgs e)
        {
            LaserAndBendingDetail laserAndBendingDetail = (e.Record as DataRow).RowData as LaserAndBendingDetail;

            if (laserAndBendingDetail != null && laserAndBendingDetail.Component.LstLaserAndBendingDetail.Count == 1)
            {
                MessageBoxAdv.Show("Atleast one operation is required.", "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ObservableCollection<LaserAndBendingDetail> lstlaserAndBendingDetail = laserAndBendingDetail.Component.LstLaserAndBendingDetail;
                laserAndBendingDetail.PropertyChanged -= LaserAndBendingDetail_PropertyChanged;
                lstlaserAndBendingDetail.Remove(laserAndBendingDetail);
                MessageBoxAdv.Show("Record deleted successfully.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LaserAndBendingDetailGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                SelectedCellInfo selectedCellInfo = e.AddedItems[0] as SelectedCellInfo;
                LaserAndBendingDetail laserAndBendingDetail = selectedCellInfo?.RowData as LaserAndBendingDetail;

                if (selectedCellInfo != null && laserAndBendingDetail != null)
                {
                    bool allowEdit = selectedCellInfo.Column.AllowEditing ? laserAndBendingDetail.IsSideApplicableToTheShape(laserAndBendingDetail.OperationNameSelectedID, laserAndBendingDetail.MaterialShapeSelectedID, selectedCellInfo.Column.MappingName) : selectedCellInfo.Column.AllowEditing;
                    if (!allowEdit)
                    {
                        laserAndBendingDetailGrid.Style.SelectionStyle.BackColor = Color.LightGray;
                        laserAndBendingDetailGrid.Style.CurrentCellStyle.BackColor = Color.LightGray;
                        laserAndBendingDetailGrid.Style.SelectionStyle.TextColor = Color.Black;
                    }
                    else
                    {
                        laserAndBendingDetailGrid.Style.SelectionStyle.BackColor = System.Drawing.SystemColors.Highlight;
                        laserAndBendingDetailGrid.Style.SelectionStyle.TextColor = System.Drawing.SystemColors.HighlightText;
                    }
                }
            }
            
        }

        private void LaserAndBendingDetailGrid_RowValidated(object sender, RowValidatedEventArgs e)
        {
            hasValidationError = false;
        }

        private void LaserAndBendingDetailGrid_CurrentCellValidating(object sender, CurrentCellValidatingEventArgs e)
        {
            var laserAndBendingDetail = e.RowData as LaserAndBendingDetail;

            if (e.Column.MappingName == nameof(LaserAndBendingDetail.OperationNameSelectedID))
            {
                int operationId = Convert.ToInt32(e.NewValue);
                if (!laserAndBendingDetail.AllowOperation(operationId))
                {
                    MessageBoxAdv.Show("Cannot add laser and bending without component raw material cost. Please update component raw material cost and then retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.IsValid = false;
                }
                else if(operationId == 2 || operationId == 3)
                {
                    foreach (var column in laserAndBendingDetailGrid.Columns)
                    {
                        if (!laserAndBendingDetail.IsSideApplicableToTheShape(operationId, Convert.ToInt32(e.NewValue), column.MappingName))
                        {
                            laserAndBendingDetail.ResetValue(column.MappingName);
                        }
                    }
                }
                
            }
            else if(laserAndBendingDetail.OperationNameSelectedID == 1 && e.Column.MappingName == nameof(LaserAndBendingDetail.MaterialShapeSelectedID))
            {
                foreach (var column in laserAndBendingDetailGrid.Columns)
                {
                    if (!laserAndBendingDetail.IsSideApplicableToTheShape(1, Convert.ToInt32(e.NewValue), column.MappingName))
                    {
                        laserAndBendingDetail.ResetValue(column.MappingName);
                    }
                }
            }
            else if (laserAndBendingDetail.OperationNameSelectedID == 2 && e.Column.MappingName == nameof(LaserAndBendingDetail.MaterialShapeSelectedID))
            {
                foreach (var column in laserAndBendingDetailGrid.Columns)
                {
                    if (!laserAndBendingDetail.IsSideApplicableToTheShape(1, Convert.ToInt32(e.NewValue), column.MappingName))
                    {
                        laserAndBendingDetail.ResetValue(column.MappingName);
                    }
                }
            }
        }

        private void LaserAndBendingDetailGrid_CurrentCellActivating(object sender, CurrentCellActivatingEventArgs e)
        {
            if (e.DataRow.RowType == RowType.AddNewRow)
            {
                if (KeyStateHelper.IsKeyDown(Keys.ShiftKey) && KeyStateHelper.IsKeyDown(Keys.Tab))
                {
                    System.Windows.Forms.SendKeys.Send("{UP}");
                    return;
                }
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
        }

        private void ShowSummaryRow()
        {
            laserAndBendingDetailGrid.Style.TableSummaryRowStyle.HorizontalAlignment = HorizontalAlignment.Right;
            laserAndBendingDetailGrid.Style.TableSummaryRowStyle.Font.Bold = true;
            laserAndBendingDetailGrid.TableSummaryRows.Add(new GridTableSummaryRow()
            {
                Name = "tableSumamryTrue",
                ShowSummaryInRow = false,
                Title = "Total cost for laser and bending work : ",
                TitleColumnCount = 4,
                Position = VerticalPosition.Bottom,
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
                if (!laserAndBendingDetail.IsSideApplicableToTheShape(laserAndBendingDetail.OperationNameSelectedID, laserAndBendingDetail.MaterialShapeSelectedID, column.MappingName))
                {
                    laserAndBendingDetail.ResetValue(column.MappingName);
                }
            }

            if (laserAndBendingDetail.MaterialShapeSelectedID > 0 && laserAndBendingDetail.OperationNameSelectedID == 0)
            {
                MessageBoxAdv.Show(operationSelectionRequiredError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.ErrorMessage = operationSelectionRequiredError;
                e.IsValid = false;
                hasValidationError = true;
            }
        }

        private void LaserAndBendingDetailGrid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if(e.DataRow.RowType == RowType.DefaultRow)
            {
                var laserAndBendingDetail = e.DataRow.RowData as LaserAndBendingDetail;
                if(!laserAndBendingDetail.IsSideApplicableToTheShape(laserAndBendingDetail.OperationNameSelectedID, laserAndBendingDetail.MaterialShapeSelectedID,e.Column.MappingName))
                {
                    e.Style.BackColor = Color.LightGray;
                }
            }
        }      

        private void LaserAndBendingDetailGrid_CurrentCellBeginEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellBeginEditEventArgs e)
        {
            var laserAndBendingDetail = e.DataRow.RowData as LaserAndBendingDetail;
            if (!laserAndBendingDetail.IsSideApplicableToTheShape(laserAndBendingDetail.OperationNameSelectedID, laserAndBendingDetail.MaterialShapeSelectedID, e.DataColumn.GridColumn.MappingName))
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
                laserAndBendingDetail.Component.CalculateCost();
            }

            if (e.OldItems != null)
            {
                var laserAndBendingDetail = e.OldItems[0] as LaserAndBendingDetail;
                laserAndBendingDetail.Component.CalculateCost();
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
                laserAndBendingDetail.Component.CalculateCost();
            }
        }
    }
}
