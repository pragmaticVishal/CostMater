using CostMater.Data;
using CostMater.Framework;
using DetailsView.Data;
using Syncfusion.Data.Extensions;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.Input.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Component = DetailsView.Data.Component;
using Process = DetailsView.Data.Process;

namespace CostMater.DataGrids
{
    public class ComponentGrid
    {
        string materialTypeResetError = "Material type cannot be reset if there are child rows associated with cost. Reset the child rows first and then retry.";
        string rawMaterialZeroError = "Changing {0} to 0 would result in raw material cost change to 0. Raw material cost cannot be 0 if there are child rows associated with cost.";
        public SfDataGrid componentGrid;
        private ObservableCollection<Component> _lstComponent;
        public bool hasValidationError = false;
        public ComponentGrid(SfDataGrid componentGrid, ObservableCollection<Component> lstComponent) 
        {
            this.componentGrid = componentGrid;
            _lstComponent = lstComponent;
        }

        public void Setup()
        {
            _lstComponent.CollectionChanged += LstComponent_CollectionChanged;

            // Subscribe to PropertyChanged event for each existing component
            foreach (var component in _lstComponent)
            {
                component.PropertyChanged += Component_PropertyChanged;
                component.LstProcess.CollectionChanged += MachiningGrid.LstProcess_CollectionChanged;
                component.LstProcess?.ForEach(p => p.PropertyChanged += MachiningGrid.Process_PropertyChanged);
                component.LstOneTimeOperationDetail.CollectionChanged += OneTimeOperationGrid.LstOneTimeOperation_CollectionChanged;
                component.LstOneTimeOperationDetail?.ForEach(p => p.PropertyChanged += OneTimeOperationGrid.OneTimeOperation_PropertyChanged);
                component.LstLaserAndBendingDetail.CollectionChanged += LaserAndBendingDetailGrid.LstLaserAndBendingDetail_CollectionChanged;
                component.LstLaserAndBendingDetail?.ForEach(p => p.PropertyChanged += LaserAndBendingDetailGrid.LaserAndBendingDetail_PropertyChanged);
            }

            #region componentGrid
            //componentGrid.SelectionController = new RowSelectionControllerExt(componentGrid);            
            componentGrid.EditMode = EditMode.SingleClick;
            componentGrid.AddNewRowText = "Click here to add new component detail";
            componentGrid.AddNewRowPosition = RowPosition.FixedBottom;
            componentGrid.Style.AddNewRowStyle.BackColor = Color.DarkCyan;
            componentGrid.Style.AddNewRowStyle.TextColor = Color.White;
            componentGrid.Style.BorderStyle = BorderStyle.FixedSingle;
            componentGrid.Style.HeaderStyle.Font.Bold = true;
            componentGrid.Style.StackedHeaderStyle.Font.Bold = true;
            //componentGrid.Style.HeaderStyle.BackColor = ColorTranslator.FromHtml("#EE6C4D");
            //componentGrid.Style.SelectionStyle.BackColor = System.Drawing.SystemColors.Highlight;
            //componentGrid.Style.SelectionStyle.TextColor = System.Drawing.SystemColors.HighlightText;
            componentGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            componentGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(22.0f);
            componentGrid.AutoGenerateColumns = false;

            componentGrid.DataSource = _lstComponent;
            componentGrid.AllowGrouping = false;
            componentGrid.ShowGroupDropArea = false;
            componentGrid.AllowDeleting = true;
            componentGrid.SelectionMode = GridSelectionMode.Single;
            componentGrid.SelectionUnit = SelectionUnit.Cell;
            componentGrid.CopyOption = CopyOptions.IncludeHeaders;
            componentGrid.PasteOption = PasteOptions.PasteData;
            componentGrid.QueryCellStyle += ComponentGrid_QueryCellStyle;
            componentGrid.CurrentCellBeginEdit += _componentGrid_CurrentCellBeginEdit;
            componentGrid.RowValidating += ComponentGrid_RowValidating;
            componentGrid.RowValidated += ComponentGrid_RowValidated;
            componentGrid.RecordDeleting += ComponentGrid_RecordDeleting;
            componentGrid.CurrentCellValidating += _componentGrid_CurrentCellValidating;
            componentGrid.CurrentCellValidated += ComponentGrid_CurrentCellValidated;
            componentGrid.CurrentCellActivating += _componentGrid_CurrentCellActivating;
            componentGrid.SelectionChanged += ComponentGrid_SelectionChanged;
            componentGrid.ShowRowHeaderErrorIcon = true;
            componentGrid.ValidationMode = GridValidationMode.InEdit;
            componentGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;            
            //sfDataGrid1.FrozenRowCount = 2;

            componentGrid.Columns.Add(new GridTextColumn { MappingName = "ComponentID", HeaderText = "Component ID", AllowEditing = false });
            componentGrid.Columns.Add(new GridTextColumn { MappingName = "DrawingNo", HeaderText = "Drawing / Part No." });
            componentGrid.Columns.Add(new GridTextColumn { MappingName = "PartName", HeaderText = "Part Name" });

            componentGrid.Columns.Add(new GridComboBoxColumn { MappingName = "MaterialTypeID", HeaderText = "Material Type", ValueMember = "MaterialTypeID", DisplayMember = "MaterialTypeName", IDataSourceSelector = new MaterialTypeDataSourceSelector() });
            componentGrid.Columns.Add(new GridComboBoxColumn { MappingName = "MaterialID", HeaderText = "Material", ValueMember = "MaterialID", DisplayMember = "MaterialName", IDataSourceSelector = new MaterialDataSourceSelector() });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Qty", HeaderText = "Quantity" });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Length", HeaderText = "Length" });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Width", HeaderText = "Width" });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Thickness", HeaderText = "Thickness" });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Diameter", HeaderText = "Diameter" });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "OD", HeaderText = "Outer Diameter" });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "ID", HeaderText = "Inner Diameter" });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Side1", HeaderText = "Side 1" });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Side2", HeaderText = "Side 2" });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "NetWeight", HeaderText = "Net Weight", AllowEditing = false });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "GrossWeight", HeaderText = "Gross Weight", AllowEditing = false });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "LaserCost", HeaderText = "Laser Cost", AllowEditing = false, Width = 120, FormatMode = FormatMode.Currency });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "BendTotalCost", HeaderText = "Bending Cost", AllowEditing = false, Width = 120, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "ProcurementCost", HeaderText = "Cost", AllowEditing = false, Width = 120, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "FabricationTotalCost", HeaderText = "Cost", AllowEditing = false, Width = 120, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "SurfaceTreatmentCost", HeaderText = "Cost", AllowEditing = false, Width = 120, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "TotalMachiningCost", HeaderText = "Cost", AllowEditing = false, Width = 120, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "GrindingCost", HeaderText = "Cost", AllowEditing = false, Width = 120, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Others_BO", HeaderText = "Cost", AllowEditing = false, Width = 120, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "HardwareCost", HeaderText = "Cost", AllowEditing = false, Width = 120, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "MiscellaneousCost", HeaderText = "Cost", AllowEditing = false, Width = 100, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "LabourCostPerPart", HeaderText = "Cost", AllowEditing = false, Width = 150, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "RawMaterialRate", HeaderText = "Rate", FormatMode = FormatMode.Currency });
            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "RawMaterialCost", HeaderText = "Amount", AllowEditing = false, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "TotalCostPerPart", HeaderText = "Total Cost Per Part", AllowEditing = false, AllowHeaderTextWrapping = true, Width = 150, FormatMode = FormatMode.Currency });

            componentGrid.Columns.Add(new GridNumericColumn { MappingName = "TotalCost", HeaderText = "Total Cost", AllowEditing = false, Width = 150, FormatMode = FormatMode.Currency });

            StackedHeaderRow stackedHeaderRow = new StackedHeaderRow();
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "ComponentID,PartName,DrawingNo", HeaderText = "Component Details" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "MaterialID,MaterialTypeID,Qty", HeaderText = "Material Details" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "Length,Width,Thickness,Diameter,OD,ID,Side1,Side2", HeaderText = "Material Dimensions" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "NetWeight,GrossWeight", HeaderText = "Weight" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "LaserCost,BendTotalCost", HeaderText = "Laser Cutting and Bending" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "ProcurementCost", HeaderText = "Procurement"});
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "FabricationTotalCost", HeaderText = "Fabrication/Pol" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "SurfaceTreatmentCost", HeaderText = "Surface Treat(E.P)" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "TotalMachiningCost", HeaderText = "Machining" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "GrindingCost", HeaderText = "Polishing" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "Others_BO", HeaderText = "Others/B.O" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "HardwareCost", HeaderText = "Hardware" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "MiscellaneousCost", HeaderText = "Miscellaneous" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "LabourCostPerPart", HeaderText = "Total Labour Per Part" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "RawMaterialRate,RawMaterialCost", HeaderText = "Raw Material" });
            componentGrid.StackedHeaderRows.Add(stackedHeaderRow);

            foreach (var column in componentGrid.Columns)
            {
                if (!column.AllowEditing)
                {
                    column.CellStyle.BackColor = Color.LightGray;
                }
            }

            ShowSummaryRow();
            componentGrid.LiveDataUpdateMode = Syncfusion.Data.LiveDataUpdateMode.AllowDataShaping;
            #endregion
        }

        private void ComponentGrid_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            SelectedCellInfo selectedCellInfo = e.AddedItems[0] as SelectedCellInfo;
            Component component = selectedCellInfo?.RowData as Component;

            if(selectedCellInfo != null && component != null)
            {
                if (!component.IsSideApplicableToTheShape(component.MaterialTypeID, selectedCellInfo.Column.MappingName))
                {
                    componentGrid.Style.SelectionStyle.BackColor = Color.LightGray;
                    componentGrid.Style.CurrentCellStyle.BackColor = Color.LightGray;
                    componentGrid.Style.SelectionStyle.TextColor = Color.Black;
                }
                else
                {
                    componentGrid.Style.SelectionStyle.BackColor = System.Drawing.SystemColors.Highlight;
                    componentGrid.Style.SelectionStyle.TextColor = System.Drawing.SystemColors.HighlightText;
                }
            }
            else
            {
                componentGrid.ExpandAllDetailsView();
            }
        }

        private void ComponentGrid_RowValidated(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatedEventArgs e)
        {
            hasValidationError = false;
        }

        private void ComponentGrid_CurrentCellValidated(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellValidatedEventArgs e)
        {
            hasValidationError = false;
        }

        private void _componentGrid_CurrentCellValidating(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellValidatingEventArgs e)
        {
            var component = e.RowData as Component;

            if (e.Column.MappingName == "MaterialTypeID")
            {
                if (!component.AllowMaterialIdReset(Convert.ToInt32(e.NewValue)))
                {
                    MessageBoxAdv.Show(materialTypeResetError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.ErrorMessage = materialTypeResetError;
                    e.IsValid = false;
                    hasValidationError = true;
                }
                else
                {
                    foreach (var column in componentGrid.Columns)
                    {
                        if (!component.IsSideApplicableToTheShape(Convert.ToInt32(e.NewValue), column.MappingName))
                        {
                            component.ResetValue(column.MappingName);
                        }
                    }
                }
            }
            //else if(component.IsRawMaterialCostChangingTo0(e.Column.MappingName, e.NewValue))
            //{
            //    string error = string.Format(rawMaterialZeroError, e.Column.HeaderText);
            //    MessageBoxAdv.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    e.ErrorMessage = error;
            //    e.IsValid = false;
            //    hasValidationError = true;
            //}
        }

        private void _componentGrid_CurrentCellActivating(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatingEventArgs e)
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
                ObservableCollection<Component> lstComponent = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<Component>;
                int componentId = lstComponent == null ? 1 : lstComponent.Max(x => x.ComponentID) + 1;
                Component component = ComponentRepository.CreateComponent(componentId);
                component.PropertyChanged += Component_PropertyChanged;
                component.LstProcess.CollectionChanged += MachiningGrid.LstProcess_CollectionChanged;
                component.LstProcess?.ForEach(p => p.PropertyChanged += MachiningGrid.Process_PropertyChanged);
                component.LstLaserAndBendingDetail.CollectionChanged += LaserAndBendingDetailGrid.LstLaserAndBendingDetail_CollectionChanged;
                component.LstLaserAndBendingDetail?.ForEach(p => p.PropertyChanged += LaserAndBendingDetailGrid.LaserAndBendingDetail_PropertyChanged);
                component.LstOneTimeOperationDetail.CollectionChanged += OneTimeOperationGrid.LstOneTimeOperation_CollectionChanged;
                component.LstOneTimeOperationDetail?.ForEach(p => p.PropertyChanged += OneTimeOperationGrid.OneTimeOperation_PropertyChanged);
                lstComponent.Add(component);
            }

            //if (e.DataRow.RowType == RowType.DefaultRow && e.DataColumn?.GridColumn != null && e.DataColumn.GridColumn.AllowEditing == false)
            //{
            //    if (KeyStateHelper.IsKeyDown(Keys.Tab))
            //    {
            //        //e.Cancel = true;
            //        System.Windows.Forms.SendKeys.Send("{TAB}");
            //        return;
            //    }
            //};
        }

        private void ComponentGrid_RecordDeleting(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventArgs e)
        {
            if (_lstComponent.Count == 1)
            {
                MessageBoxAdv.Show("Atleast one component is required.", "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Cancel the deletion
            }
            else
            {
                var component = e.Items[0] as Component;
                if (component != null)
                {
                    component.PropertyChanged -= Component_PropertyChanged;
                    component.LstProcess.CollectionChanged -= MachiningGrid.LstProcess_CollectionChanged;
                    component.LstProcess?.ForEach(p => p.PropertyChanged -= MachiningGrid.Process_PropertyChanged);
                    component.LstOneTimeOperationDetail.CollectionChanged -= OneTimeOperationGrid.LstOneTimeOperation_CollectionChanged;
                    component.LstOneTimeOperationDetail?.ForEach(p => p.PropertyChanged -= OneTimeOperationGrid.OneTimeOperation_PropertyChanged);
                    component.LstLaserAndBendingDetail.CollectionChanged -= LaserAndBendingDetailGrid.LstLaserAndBendingDetail_CollectionChanged;
                    component.LstLaserAndBendingDetail?.ForEach(p => p.PropertyChanged -= LaserAndBendingDetailGrid.LaserAndBendingDetail_PropertyChanged);
                }
            }
        }

        private void ShowSummaryRow()
        {
            componentGrid.Style.TableSummaryRowStyle.HorizontalAlignment = HorizontalAlignment.Right;
            componentGrid.Style.TableSummaryRowStyle.Font.Bold = true;
            componentGrid.TableSummaryRows.Add(new GridTableSummaryRow()
            {
                Name = "tableSumamryTrue",
                ShowSummaryInRow = false,
                Title = "Total cost for all components : ",
                TitleColumnCount = 4,
                Position = VerticalPosition.Bottom,
                SummaryColumns = new System.Collections.ObjectModel.ObservableCollection<Syncfusion.Data.ISummaryColumn>()
                {
                    new GridSummaryColumn()
                    {
                        Name = "LaserCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="LaserCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "BendTotalCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="BendTotalCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "ProcurementCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="ProcurementCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "FabricationTotalCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="FabricationTotalCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "SurfaceTreatmentCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="SurfaceTreatmentCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "HardwareCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="HardwareCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "Others_BO",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="Others_BO",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "TotalMachiningCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="TotalMachiningCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "MiscellaneousCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="MiscellaneousCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "LabourCostPerPart",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="LabourCostPerPart",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "RawMaterialCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="RawMaterialCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "TotalCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="TotalCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "GrindingCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="GrindingCost",
                    },
                    new GridSummaryColumn()
                    {
                        Name = "TotalCostPerPart",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="TotalCostPerPart",
                    },
                }
            });            
        }

        private void _componentGrid_CurrentCellBeginEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellBeginEditEventArgs e)
        {
            var component = e.DataRow.RowData as Component;
            if (!component.IsSideApplicableToTheShape(component.MaterialTypeID, e.DataColumn.GridColumn.MappingName))
            {
                e.Cancel = true;
            }
        }

        public static void Component_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            List<string> excludeProps = new List<string>()
            { nameof(Component.NetWeight), nameof(Component.GrossWeight), nameof(Component.LaserCost), nameof(Component.BendTotalCost),
              nameof(Component.FabricationTotalCost), nameof(Component.SurfaceTreatmentCost), nameof(Component.TotalMachiningCost), nameof(Component.Others_BO),
              nameof(Component.HardwareCost), nameof(Component.MiscellaneousCost), nameof(Component.LabourCostPerPart), nameof(Component.RawMaterialCost), 
              nameof(Component.TotalCostPerPart), nameof(Component.TotalCost)
            };

            if (excludeProps.Contains(e.PropertyName))
                return;

            var component = sender as Component;

            if (component != null)
            {
                component.CalculateCost();
            }
        }


        #region Styling event in Master and Detail
        private void ComponentGrid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if (e.Column == null)
                return;

            if (e.DataRow.RowType == RowType.DefaultRow)
            {
                var component = e.DataRow.RowData as Component;
                if (!component.IsSideApplicableToTheShape(component.MaterialTypeID, e.Column.MappingName))
                {
                    e.Style.BackColor = Color.LightGray;
                }
            }
        }

        #endregion

        #region Row valiation event in Master and Detail
        private void ComponentGrid_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
        {
            var component = e.DataRow.RowData as Component;

            foreach (var column in componentGrid.Columns)
            {
                if (!component.IsSideApplicableToTheShape(component.MaterialTypeID, column.MappingName))
                {
                    component.ResetValue(column.MappingName);
                }
            }
        }

        #endregion

        public static void LstComponent_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Component newComponent in e.NewItems)
                {
                    // Subscribe to PropertyChanged event for new components
                    // newComponent.PropertyChanged += Component_PropertyChanged;
                    // Handle new component added
                    Console.WriteLine($"New component added: {newComponent.ComponentID}");
                }
            }

            if (e.OldItems != null)
            {
                foreach (Component oldComponent in e.OldItems)
                {
                    // Unsubscribe from PropertyChanged event for removed components
                    oldComponent.PropertyChanged -= Component_PropertyChanged;
                    // Handle component removed
                    Console.WriteLine($"Component removed: {oldComponent.ComponentID}");
                }
            }
        }

        public void Reset(ObservableCollection<Component> lstComponent)
        {
            _lstComponent = lstComponent;
            componentGrid.DataSource = _lstComponent;
            RegisterCollectionChangedHandlers();
            RegisterPropertyChangedHandlers();
        }

        internal void RegisterCollectionChangedHandlers()
        {
            _lstComponent.CollectionChanged -= ComponentGrid.LstComponent_CollectionChanged;
            foreach (Component component in _lstComponent)
            {
                component.LstProcess.CollectionChanged -= MachiningGrid.LstProcess_CollectionChanged;
                component.LstOneTimeOperationDetail.CollectionChanged -= OneTimeOperationGrid.LstOneTimeOperation_CollectionChanged;
                component.LstLaserAndBendingDetail.CollectionChanged -= LaserAndBendingDetailGrid.LstLaserAndBendingDetail_CollectionChanged;
            }

            _lstComponent.CollectionChanged += ComponentGrid.LstComponent_CollectionChanged;
            foreach (Component component in _lstComponent)
            {
                component.LstProcess.CollectionChanged += MachiningGrid.LstProcess_CollectionChanged;
                component.LstOneTimeOperationDetail.CollectionChanged += OneTimeOperationGrid.LstOneTimeOperation_CollectionChanged;
                component.LstLaserAndBendingDetail.CollectionChanged += LaserAndBendingDetailGrid.LstLaserAndBendingDetail_CollectionChanged;
            }
        }

        internal void RegisterPropertyChangedHandlers()
        {
            foreach (Component component in _lstComponent)
            {
                component.PropertyChanged -= Component_PropertyChanged;
                component.LstProcess?.ForEach(p => p.PropertyChanged -= MachiningGrid.Process_PropertyChanged);
                component.LstOneTimeOperationDetail?.ForEach(p => p.PropertyChanged -= OneTimeOperationGrid.OneTimeOperation_PropertyChanged);
                component.LstLaserAndBendingDetail?.ForEach(p => p.PropertyChanged -= LaserAndBendingDetailGrid.LaserAndBendingDetail_PropertyChanged);
            }

            foreach (Component component in _lstComponent)
            {
                component.PropertyChanged += Component_PropertyChanged;
                component.LstProcess?.ForEach(p => p.PropertyChanged += MachiningGrid.Process_PropertyChanged);
                component.LstOneTimeOperationDetail?.ForEach(p => p.PropertyChanged += OneTimeOperationGrid.OneTimeOperation_PropertyChanged);
                component.LstLaserAndBendingDetail?.ForEach(p => p.PropertyChanged += LaserAndBendingDetailGrid.LaserAndBendingDetail_PropertyChanged);
            }
        }
    }
}
