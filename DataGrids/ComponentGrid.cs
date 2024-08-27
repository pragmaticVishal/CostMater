using CostMater.Data;
using DetailsView.Data;
using Syncfusion.Data.Extensions;
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
using Component = DetailsView.Data.Component;
using Process = DetailsView.Data.Process;

namespace CostMater.DataGrids
{
    public class ComponentGrid
    {
        private SfDataGrid _componentGrid;
        private ObservableCollection<Component> _lstComponent;
        public ComponentGrid(SfDataGrid componentGrid, ObservableCollection<Component> lstComponent) 
        {
            _componentGrid = componentGrid;
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
            _componentGrid.EditMode = EditMode.SingleClick;
            _componentGrid.AddNewRowText = "Click here to add new component detail";
            _componentGrid.Style.AddNewRowStyle.BackColor = Color.DarkCyan;
            _componentGrid.Style.BorderStyle = BorderStyle.FixedSingle;
            _componentGrid.Style.HeaderStyle.Font.Bold = true;
            _componentGrid.Style.StackedHeaderStyle.Font.Bold = true;
            _componentGrid.Style.SelectionStyle.BackColor = System.Drawing.SystemColors.Highlight;
            _componentGrid.Style.SelectionStyle.TextColor = System.Drawing.SystemColors.HighlightText;
            _componentGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _componentGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(22.0f);
            _componentGrid.AutoGenerateColumns = false;

            _componentGrid.DataSource = _lstComponent;
            _componentGrid.AllowGrouping = false;
            _componentGrid.ShowGroupDropArea = false;
            _componentGrid.AllowDeleting = true;
            _componentGrid.AddNewRowInitiating += ComponentGrid_AddNewRowInitiating;
            _componentGrid.QueryCellStyle += ComponentGrid_QueryCellStyle;
            _componentGrid.CurrentCellBeginEdit += _componentGrid_CurrentCellBeginEdit;
            _componentGrid.RowValidating += ComponentGrid_RowValidating;
            _componentGrid.RecordDeleting += (sender, e) =>
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
            };
            _componentGrid.ShowRowHeaderErrorIcon = true;
            _componentGrid.ValidationMode = GridValidationMode.InEdit;
            _componentGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;
            //sfDataGrid1.FrozenRowCount = 2;

            _componentGrid.Columns.Add(new GridTextColumn { MappingName = "ComponentID", HeaderText = "Component ID", AllowEditing = false });
            _componentGrid.Columns.Add(new GridTextColumn { MappingName = "DrawingNo", HeaderText = "Drawing / Part No." });
            _componentGrid.Columns.Add(new GridTextColumn { MappingName = "PartName", HeaderText = "Part Name" });

            _componentGrid.Columns.Add(new GridComboBoxColumn { MappingName = "MaterialID", HeaderText = "Material", ValueMember = "MaterialID", DisplayMember = "MaterialName", IDataSourceSelector = new MaterialDataSourceSelector() });
            _componentGrid.Columns.Add(new GridComboBoxColumn { MappingName = "MaterialTypeID", HeaderText = "Material Type", ValueMember = "MaterialTypeID", DisplayMember = "MaterialTypeName", IDataSourceSelector = new MaterialTypeDataSourceSelector() });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Qty", HeaderText = "Quantity" });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Length", HeaderText = "Length" });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Width", HeaderText = "Width" });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Thickness", HeaderText = "Thickness" });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Diameter", HeaderText = "Diameter" });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "OD", HeaderText = "Outer Diameter" });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "ID", HeaderText = "Inner Diameter" });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Side1", HeaderText = "Side 1" });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Side2", HeaderText = "Side 2" });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "NetWeight", HeaderText = "Net Weight", AllowEditing = false });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "GrossWeight", HeaderText = "Gross Weight", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "LaserCost", HeaderText = "Laser Cost", AllowEditing = false });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "BendTotalCost", HeaderText = "Bending Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "ProcurementCost", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "FabricationTotalCost", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "SurfaceTreatmentCost", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "TotalMachiningCost", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "GrindingCost", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "DrillingCost", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "Others_BO", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "HardwareCost", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "MiscellaneousCost", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "LabourCostPerPart", HeaderText = "Cost", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "RawMaterialRate", HeaderText = "Rate" });
            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "RawMaterialCost", HeaderText = "Amount", AllowEditing = false });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "TotalCostPerPart", HeaderText = "Total Cost Per Part", AllowEditing = false, AllowHeaderTextWrapping = true });

            _componentGrid.Columns.Add(new GridNumericColumn { MappingName = "TotalCost", HeaderText = "Total Cost", AllowEditing = false });

            StackedHeaderRow stackedHeaderRow = new StackedHeaderRow();
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "ComponentID,PartName,DrawingNo", HeaderText = "Component Details" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "MaterialID,MaterialTypeID,Qty", HeaderText = "Material Details" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "Length,Width,Thickness,Diameter,OD,ID,Side1,Side2", HeaderText = "Material Dimensions" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "NetWeight,GrossWeight", HeaderText = "Weight" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "LaserCost,BendTotalCost", HeaderText = "Laser Cutting and Bending" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "ProcurementCost", HeaderText = "Procurement" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "FabricationTotalCost", HeaderText = "Fabrication/\nPol" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "SurfaceTreatmentCost", HeaderText = "Surface \nTreat(E.P)" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "TotalMachiningCost", HeaderText = "Machining" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "GrindingCost", HeaderText = "Grinding" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "DrillingCost", HeaderText = "Drilling" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "Others_BO", HeaderText = "Others/\nB.O" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "HardwareCost", HeaderText = "Hardware" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "MiscellaneousCost", HeaderText = "Miscellaneous" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "LabourCostPerPart", HeaderText = "Total Labour \n Per Part" });
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "RawMaterialRate,RawMaterialCost", HeaderText = "Raw Material" });
            _componentGrid.StackedHeaderRows.Add(stackedHeaderRow);

            foreach (var column in _componentGrid.Columns)
            {
                //column.HeaderStyle.BackColor = Color.SlateBlue;
                //column.HeaderStyle.TextColor = Color.White; // Optional: Set text color
                //column.HeaderStyle.Font.Bold = true; // Optional: Make header text bold
                if (!column.AllowEditing)
                {
                    column.CellStyle.BackColor = Color.LightGray;
                }
            }

            ShowSummaryRow();
            _componentGrid.LiveDataUpdateMode = Syncfusion.Data.LiveDataUpdateMode.AllowDataShaping;
            #endregion
        }

        public void Reset(ObservableCollection<Component> lstComponent)
        {
            _lstComponent = lstComponent;
            _componentGrid.DataSource = _lstComponent;
            RegisterCollectionChangedHandlers();
            RegisterPropertyChangedHandlers();
        }

        private void ShowSummaryRow()
        {
            _componentGrid.TableSummaryRows.Add(new GridTableSummaryRow()
            {
                Name = "tableSumamryTrue",
                ShowSummaryInRow = true,
                Title = "Total cost for all components : {AllComponentCost}",
                SummaryColumns = new System.Collections.ObjectModel.ObservableCollection<Syncfusion.Data.ISummaryColumn>()
                {
                    new GridSummaryColumn()
                    {
                        Name = "AllComponentCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="TotalCost",
                    }
                }
            });

            
        }

        private void _componentGrid_CurrentCellBeginEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellBeginEditEventArgs e)
        {
            var component = e.DataRow.RowData as Component;
            if (!component.IsSideApplicableToTheShape(e.DataColumn.GridColumn.MappingName))
            {
                e.Cancel = true;
            }
        }

        private void ComponentGrid_AddNewRowInitiating(object sender, Syncfusion.WinForms.DataGrid.Events.AddNewRowInitiatingEventArgs e)
        {
            ObservableCollection<Component> lstComponent = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<Component>;
            var component = new Component
            {
                ComponentID = lstComponent == null ? 1 : lstComponent.Max(x => x.ComponentID) + 1,
                MaterialTypeID = 1,
                MaterialID = 1,
            };
            component.PropertyChanged += Component_PropertyChanged;
            component.LstProcess.CollectionChanged += MachiningGrid.LstProcess_CollectionChanged;
            component.LstProcess?.ForEach(p => p.PropertyChanged += MachiningGrid.Process_PropertyChanged);
            component.LstLaserAndBendingDetail.CollectionChanged += LaserAndBendingDetailGrid.LstLaserAndBendingDetail_CollectionChanged;
            component.LstLaserAndBendingDetail?.ForEach(p => p.PropertyChanged += LaserAndBendingDetailGrid.LaserAndBendingDetail_PropertyChanged);
            component.LstOneTimeOperationDetail.CollectionChanged += OneTimeOperationGrid.LstOneTimeOperation_CollectionChanged;
            component.LstOneTimeOperationDetail?.ForEach(p => p.PropertyChanged += OneTimeOperationGrid.OneTimeOperation_PropertyChanged);
            e.NewObject = component;
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
                CalculateNetWeight(component);
                component.GrossWeight = component.NetWeight * 1.2M;
                component.LabourCostPerPart = component.BendTotalCost + component.FabricationTotalCost + component.LaserCost + component.SurfaceTreatmentCost + component.Others_BO + component.GrindingCost + component.TotalMachiningCost;
                component.RawMaterialCost = component.GrossWeight * component.RawMaterialRate;
                component.TotalCostPerPart = component.LabourCostPerPart + component.RawMaterialCost + component.HardwareCost + component.MiscellaneousCost;
                component.TotalCost = component.TotalCostPerPart * component.Qty;
            }
        }

        private static void CalculateNetWeight(Component component)
        {
            switch (component.MaterialTypeID)
            {
                case 1:
                    component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                    break;
                case 2:
                    component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                    break;
                case 3:
                    component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                    break;
                case 4:
                    component.NetWeight = (component.Side1 * component.Thickness * component.Length * 0.00000786M) + (component.Side2 * component.Thickness * component.Length * 0.00000786M);
                    break;
                case 5:
                    component.NetWeight = 0.7854M * component.Diameter * component.Diameter * component.Length * 0.00000786M;
                    break;
                case 6:
                    component.NetWeight = (0.7854M * component.OD * component.OD * component.Length * 0.00000786M) - (0.7854M * component.ID * component.ID * component.Length * 0.00000786M);
                    break;
                case 7:
                    component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                    break;
                case 8:
                    component.NetWeight = (component.Side1 * component.Side2 * component.Length * 0.00000786M) - ((component.Side1 - 2 * component.Thickness) * (component.Side2 - 2 * component.Thickness) * component.Length * 0.00000786M);
                    break;
                case 9:
                    component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                    break;
                case 10:
                    component.NetWeight = (component.Side1 * component.Side2 * component.Length * 0.00000786M) - ((component.Side1 - 2 * component.Thickness) * (component.Side2 - 2 * component.Thickness) * component.Length * 0.00000786M);
                    break;
                default:
                    break;
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
                if (!component.IsSideApplicableToTheShape(e.Column.MappingName))
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

            foreach (var column in _componentGrid.Columns)
            {
                if (!component.IsSideApplicableToTheShape(column.MappingName))
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
