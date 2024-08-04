#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Component = DetailsView.Data.Component;
using Process = DetailsView.Data.Process;

namespace DetailsView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SampleCustomization();
        }

        /// <summary>
        /// Sets the sample customization settings.
        /// </summary>
        private void SampleCustomization()
        {
            #region Create Datasource
            ComponentRepository componentRepo = new ComponentRepository();
            ObservableCollection<Component> lstComponent = componentRepo.GetAll();

            // Subscribe to CollectionChanged event
            lstComponent.CollectionChanged += LstComponent_CollectionChanged;

            // Subscribe to PropertyChanged event for each existing component
            foreach (var component in lstComponent)
            {
                component.PropertyChanged += Component_PropertyChanged;
                component.LstProcess.CollectionChanged += LstProcess_CollectionChanged;
                component.LstProcess?.ForEach(p => p.PropertyChanged += Process_PropertyChanged);
            }
            #endregion

            #region sfDataGrid1
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.DataSource = lstComponent;
            sfDataGrid1.AllowGrouping = true;
            sfDataGrid1.ShowGroupDropArea = true;
            sfDataGrid1.AddNewRowInitiating += SfDataGrid1_AddNewRowInitiating;
            sfDataGrid1.QueryCellStyle += SfDataGrid1_QueryCellStyle;
            sfDataGrid1.RowValidating += SfDataGrid1_RowValidating;
            sfDataGrid1.ShowRowHeaderErrorIcon = true;
            sfDataGrid1.ValidationMode = GridValidationMode.InEdit;
            sfDataGrid1.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;

            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "ComponentID", HeaderText = "Component ID", AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "ComponentName", HeaderText = "Component Name" });
            sfDataGrid1.Columns.Add(new GridComboBoxColumn { MappingName = "MaterialID", HeaderText = "Material", ValueMember = "MaterialID", DisplayMember = "MaterialName", IDataSourceSelector = new MaterialDataSourceSelector() });
            sfDataGrid1.Columns.Add(new GridComboBoxColumn { MappingName = "MaterialTypeID", HeaderText = "Material Type", ValueMember = "MaterialTypeID", DisplayMember = "MaterialTypeName", IDataSourceSelector = new MaterialTypeDataSourceSelector() });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "Qty", HeaderText = "Quantity" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "Length", HeaderText = "Length" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "Width", HeaderText = "Width" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "Thickness", HeaderText = "Thickness" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "Diameter", HeaderText = "Diameter" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "OD", HeaderText = "Outer Diameter" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "ID", HeaderText = "Inner Diameter" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "Side1", HeaderText = "Side 1" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "Side2", HeaderText = "Side 2" });            
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "BendRate", HeaderText = "Bend Rate" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "FabricationRate", HeaderText = "Fabrication Rate" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "RawMaterialRate", HeaderText = "Raw Material Rate" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "NoOfStart", HeaderText = "No Of Start" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "NoOfBend", HeaderText = "No Of Bend" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "ProcurementCost", HeaderText = "Procurement Cost" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "SurfaceTreatmentRate", HeaderText = "Surface Treatment Rate" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "OthersRate", HeaderText = "Others Rate" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "OthersQty", HeaderText = "Others Qty" });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "MachingCostPerHour", HeaderText = "Machining Cost Per hour" });

            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "Perimeter", HeaderText = "Perimeter", AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "NetWeight", HeaderText = "Net Weight", AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "GrossWeight", HeaderText = "Gross Weight", AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "LaserCost", HeaderText = "Laser Cost", AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "BendTotalCost", HeaderText = "Bend Total Cost", AllowEditing = false });            
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "FabricationTotalCost", HeaderText = "Fabrication Total Cost", AllowEditing = false });

            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "SurfaceTreatmentCost", HeaderText = "Surface Treatment", AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "Others_BO", HeaderText = "Others/B.O", AllowEditing = false });            
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "LabourCostPerPart", HeaderText = "Labour Cost Per Part", AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "RawMaterialCost", HeaderText = "Raw Material Cost", AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "TotalCostPerPart", HeaderText = "Total Cost Per Part", AllowEditing = false });
            sfDataGrid1.Columns.Add(new GridNumericColumn { MappingName = "TotalCost", HeaderText = "Total Cost", AllowEditing = false });

            foreach (var column in sfDataGrid1.Columns)
            {
                if (!column.AllowEditing)
                {
                    column.CellStyle.BackColor = Color.LightGray;
                }
            }
            #endregion

            #region childGrid
            SfDataGrid childGrid = new SfDataGrid();           
            childGrid.ValidationMode = GridValidationMode.InEdit;
            childGrid.AddNewRowInitiating += ChildGrid_AddNewRowInitiating;
            childGrid.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
            childGrid.AutoGenerateColumns = false;
            childGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(21.0f);
            childGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };

            childGrid.Columns.Add(new GridTextColumn { MappingName = "ProcessID", HeaderText = "Process ID", AllowEditing = false });
            childGrid.Columns.Add(new GridComboBoxColumn { MappingName = "ProcessTypeID", HeaderText = "Process Name", ValueMember = "ProcessTypeID", DisplayMember = "ProcessTypeName", IDataSourceSelector = new ProcessTypeDataSourceSelector() });
            childGrid.Columns.Add(new GridComboBoxColumn { MappingName = "ToolTypeID", HeaderText = "Tool Type", ValueMember = "ToolTypeID", DisplayMember = "ToolTypeName", IDataSourceSelector = new ToolTypeDataSourceSelector() });
            childGrid.Columns.Add(new GridComboBoxColumn { MappingName = "ToolSurfaceID", HeaderText = "Rough / Finish", ValueMember = "ToolSurfaceID", DisplayMember = "ToolSurfaceName", IDataSourceSelector = new ToolSurfaceDataSourceSelector() });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "ComponentID", HeaderText = "Component ID", AllowEditing = false });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "CuttingSpeed", HeaderText = "Cutting Speed" });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "FeedRate", HeaderText = "Feed Rate (f) in mm/rev" });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "DrillSize", HeaderText = "Drill Size" });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "ThreadDiameterToCut", HeaderText = "Diameter of the thread to cut" });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "ThreadPitch", HeaderText = "Pitch" });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "DiameterBeforeTurning", HeaderText = "Diameter of stock before turning" });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "DiameterAfterTurning", HeaderText = "Diameter of job after turning" });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "RPM", HeaderText = "RPM", AllowEditing = false });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "DepthOfCutEachPass", HeaderText = "Depth of Cut for Each Pass" });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "NoOfCuts", HeaderText = "Number of Cuts", AllowEditing = false });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "LengthOfCut", HeaderText = "Length of the cut in mm" });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "MachiningTime", HeaderText = "Machining Time in minutes", AllowEditing = false });
            childGrid.Columns.Add(new GridNumericColumn { MappingName = "MachiningCost", HeaderText = "Machining Cost", AllowEditing = false });

            foreach (var column in childGrid.Columns)
            {
                if (!column.AllowEditing)
                {
                    column.CellStyle.BackColor = Color.LightGray;
                }
            }

            #endregion

            #region Master-Detail Relation in Grid
            GridViewDefinition componentDetailView = new GridViewDefinition();
            componentDetailView.RelationalColumn = "LstProcess";
            componentDetailView.DataGrid = childGrid;
            this.sfDataGrid1.DetailsViewDefinitions.Add(componentDetailView);
            #endregion
        }

        #region Data modified events
        private void Component_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            List<string> excludeProps = new List<string>()
            { nameof(Component.NetWeight), nameof(Component.Perimeter), nameof(Component.GrossWeight), nameof(Component.BendTotalCost),
              nameof(Component.FabricationTotalCost), nameof(Component.LaserCost), nameof(Component.SurfaceTreatmentCost), nameof(Component.Others_BO),
              nameof(Component.LabourCostPerPart), nameof(Component.RawMaterialCost), nameof(Component.TotalCostPerPart), nameof(Component.TotalCost)
            };

            if (excludeProps.Contains(e.PropertyName))
                return;

            var component = sender as Component;

            if (component != null)
            {
                component.BendTotalCost = component.NoOfBend * component.BendRate;
                component.FabricationTotalCost = component.FabricationRate * component.NetWeight;
                component.LaserCost = (component.Perimeter * 0.06M * component.Thickness) + (component.NoOfStart * 1 * component.Thickness);
                component.GrossWeight = component.NetWeight * 1.2M;
                component.SurfaceTreatmentCost = component.SurfaceTreatmentRate * component.NetWeight;
                component.Others_BO = component.OthersRate * component.OthersQty;
                component.LabourCostPerPart = component.BendTotalCost + component.FabricationTotalCost + component.LaserCost + component.SurfaceTreatmentCost + component.Others_BO + component.GrindingCost + component.MachiningCost;
                component.RawMaterialCost = component.NetWeight * component.RawMaterialRate;
                component.TotalCostPerPart = component.LabourCostPerPart + component.RawMaterialCost;
                component.TotalCost = component.TotalCostPerPart * component.Qty;

                switch (component.MaterialTypeID)
                {
                    case 1:
                        component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                        component.Perimeter = 2 * (component.Length + component.Width);
                        break;
                    case 2:
                        component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                        component.Perimeter = 2 * (component.Length + component.Width);
                        break;
                    case 3:
                        component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                        component.Perimeter = 2 * (component.Length + component.Width);
                        break;
                    case 4:
                        component.NetWeight = (component.Side1 * component.Thickness * component.Length * 0.00000786M) + (component.Side2 * component.Thickness * component.Length * 0.00000786M);
                        component.Perimeter = component.Side1 + component.Side2;
                        break;
                    case 5:
                        component.NetWeight = 0.7854M * component.Diameter * component.Diameter * component.Length * 0.00000786M;
                        component.Perimeter = 3.1416M * component.Diameter;
                        break;
                    case 6:
                        component.NetWeight = (0.7854M * component.OD * component.OD * component.Length * 0.00000786M) - (0.7854M * component.ID * component.ID * component.Length * 0.00000786M);
                        component.Perimeter = 3.1416M * component.OD;
                        break;
                    case 7:
                        component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                        component.Perimeter = 2 * (component.Length + component.Width);
                        break;
                    case 8:
                        component.NetWeight = (component.Side1 * component.Side2 * component.Length * 0.00000786M) - ((component.Side1 - 2 * component.Thickness) * (component.Side2 - 2 * component.Thickness) * component.Length * 0.00000786M);
                        component.Perimeter = 2 * (component.Side1 + component.Side2);
                        break;
                    case 9:
                        component.NetWeight = component.Length * component.Width * component.Thickness * 0.00000786M;
                        component.Perimeter = 2 * (component.Length + component.Width);
                        break;
                    case 10:
                        component.NetWeight = (component.Side1 * component.Side2 * component.Length * 0.00000786M) - ((component.Side1 - 2 * component.Thickness) * (component.Side2 - 2 * component.Thickness) * component.Length * 0.00000786M);
                        component.Perimeter = 2 * (component.Side1 + component.Side2);
                        break;
                    default:                     
                        break;
                }
            }
        }

        private void LstComponent_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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

        private void LstProcess_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Process newProcess in e.NewItems)
                {
                    UpdateMachiningCost(newProcess);
                }
            }

            if (e.OldItems != null)
            {
                foreach (Process oldProcess in e.OldItems)
                {
                    // Handle process removed
                    oldProcess.PropertyChanged -= Process_PropertyChanged;
                    Console.WriteLine($"Process removed: {oldProcess.ProcessID}");
                }
            }
        }

        private void Process_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            List<string> excludeProps = new List<string>()
            { nameof(Process.NoOfCuts), nameof(Process.RPM), nameof(Process.Average), nameof(Process.MachiningTime),
              nameof(Process.MachiningCost)
            };

            if (excludeProps.Contains(e.PropertyName))
                return;

            var process = sender as Process;
            if (process != null)
            {
                //decimal MachingCostPerHour = GetMachiningCostPerHour(process);
                if (process.ThreadPitch != 0) {
                    process.NoOfCuts = 25 / (10 / process.ThreadPitch);
                }
                process.Average = process.DiameterBeforeTurning + (process.DiameterAfterTurning / 2);
                if(process.Average != 0)
                {
                    process.RPM = 1000 * process.CuttingSpeed / (3.14M * process.Average);
                }
                if(process.FeedRate != 0 && process.RPM != 0)
                {
                    process.MachiningTime = (process.LengthOfCut * process.NoOfCuts) / (process.FeedRate * process.RPM);
                }
                process.MachiningCost = process.MachiningTime * 60 * process.Component.MachiningCost;
                
                switch(process.ProcessTypeID)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    
                    default:
                        break;
                }
                UpdateMachiningCost(process);
            }
        }

        private decimal GetMachiningCostPerHour(Process process)
        {
            // Find the parent component and update its MachiningCost
            var allComponent = sfDataGrid1.DataSource as ObservableCollection<Component>;
            var component = allComponent.FirstOrDefault(c => c.ComponentID == process.ComponentID);
            return component == null ? 0 : component.MachiningCostPerHour;
        }

        private void UpdateMachiningCost(Process process)
        {
            // Find the parent component and update its MachiningCost
            var allComponent = sfDataGrid1.DataSource as ObservableCollection<Component>;
            var component = allComponent.FirstOrDefault(c => c.ComponentID == process.ComponentID);
            if (component != null)
            {
                component.CalculateMachiningCost();
            }
        }
        #endregion

        #region New row event in Master and Detail
        private void SfDataGrid1_AddNewRowInitiating(object sender, Syncfusion.WinForms.DataGrid.Events.AddNewRowInitiatingEventArgs e)
        {
            ObservableCollection<Component> lstComponent = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<Component>;
            var component = new Component { 
                ComponentID = lstComponent == null ? 1 : lstComponent.Count + 1 ,
                MaterialTypeID = 1,
                MaterialID = 1,
                MachiningCostPerHour = 300,
            };
            component.PropertyChanged += Component_PropertyChanged;
            component.LstProcess.CollectionChanged += LstProcess_CollectionChanged;
            e.NewObject = component;
        }

        private void ChildGrid_AddNewRowInitiating(object sender, Syncfusion.WinForms.DataGrid.Events.AddNewRowInitiatingEventArgs e)
        {
            ObservableCollection<Process> lstProcess = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<Process>;
            var process = new Process
            {
                ProcessID = lstProcess == null ? 1 : lstProcess.Count + 1,
                ComponentID = lstProcess[0].ComponentID,
                Component = lstProcess[0].Component,
                ProcessTypeID = 1,
                ToolTypeID = 1,
                ToolSurfaceID = 1,
                CuttingSpeed = 40,
                FeedRate = 1.3M,
                DepthOfCutEachPass = 3.5M
            };
            process.PropertyChanged += Process_PropertyChanged;

            e.NewObject = process;
        }

        #endregion

        #region Styling event in Master and Detail
        private void SfDataGrid1_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.DataRow.RowType == RowType.DefaultRow)
            {
                var dataRow = e.DataRow.RowData as Component;
                //if (dataRow != null && dataRow.MaterialTypeID != null && e.Column != null)
                //{
                //    if (dataRow.MaterialTypeID == 10 || dataRow.MaterialTypeID == 11 || dataRow.MaterialTypeID == 12)
                //    {
                //        if (e.Column.MappingName == "Length" || e.Column.MappingName == "Width" || e.Column.MappingName == "Thickness" || e.Column.MappingName == "Diameter")
                //        {
                //            e.Style.BackColor = Color.LightGray;
                //            e.Column.AllowEditing = false;
                //        }
                //    }
                //    else
                //    {
                //        if (e.Column.MappingName == "Length" || e.Column.MappingName == "Width" || e.Column.MappingName == "Thickness" || e.Column.MappingName == "Diameter")
                //        {
                //            e.Style.BackColor = Color.White;
                //            e.Column.AllowEditing = true;
                //        }
                //    }
                //}
            }

        }
        #endregion

        #region Row valiation event in Master and Detail
        private void SfDataGrid1_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
        {
            if (this.sfDataGrid1.IsAddNewRowIndex(e.DataRow.RowIndex))
            {
                var data = e.DataRow.RowData as Component;
                if (data.MaterialTypeID < 1) {
                    e.IsValid = false;
                    e.ErrorMessage = "Material Type is required.";

                    MessageBox.Show("Material Type is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}
