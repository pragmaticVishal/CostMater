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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Component = DetailsView.Data.Component;
using Process = DetailsView.Data.Process;

namespace CostMater.DataGrids
{
    public class MachiningGrid
    {
        private SfDataGrid machiningGrid;

        public MachiningGrid(SfDataGrid machiningGrid)
        {
            this.machiningGrid = machiningGrid;
        }

        public void Setup()
        {
            #region machiningGrid

            machiningGrid.EditMode = EditMode.SingleClick;
            machiningGrid.AddNewRowText = "Click here to add new machining detail";
            machiningGrid.Style.AddNewRowStyle.BackColor = Color.DarkCyan;
            machiningGrid.Style.BorderStyle = BorderStyle.FixedSingle;
            machiningGrid.Style.HeaderStyle.Font.Bold = true;
            machiningGrid.Style.StackedHeaderStyle.Font.Bold = true;
            machiningGrid.Style.SelectionStyle.BackColor = System.Drawing.SystemColors.Highlight;
            machiningGrid.Style.SelectionStyle.TextColor = System.Drawing.SystemColors.HighlightText;
            machiningGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            machiningGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(22.0f);
            machiningGrid.AutoGenerateColumns = false;
            machiningGrid.ValidationMode = GridValidationMode.InEdit;
            machiningGrid.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
            machiningGrid.AllowDeleting = true;
            machiningGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(21.0f);
            machiningGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;
            machiningGrid.AddNewRowInitiating += MachiningGrid_AddNewRowInitiating;
            machiningGrid.RecordDeleting += MachiningGrid_RecordDeleting;
            machiningGrid.CurrentCellBeginEdit += MachiningGrid_CurrentCellBeginEdit;
            machiningGrid.QueryCellStyle += MachiningGrid_QueryCellStyle;
            machiningGrid.RowValidating += MachiningGrid_RowValidating;

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };

            machiningGrid.Columns.Add(new GridTextColumn { MappingName = "ProcessID", HeaderText = "ID", AllowEditing = false });
            machiningGrid.Columns.Add(new GridTextColumn { MappingName = "ComponentID", HeaderText = "Component ID", AllowEditing = false });
            machiningGrid.Columns.Add(new GridTextColumn { MappingName = "DrawingNo", HeaderText = "Drawing / Part No.", AllowEditing = false });
            machiningGrid.Columns.Add(new GridComboBoxColumn { MappingName = "ProcessTypeID", HeaderText = "Name", ValueMember = "ProcessTypeID", DisplayMember = "ProcessTypeName", IDataSourceSelector = new ProcessTypeDataSourceSelector() });
            machiningGrid.Columns.Add(new GridComboBoxColumn { MappingName = "ToolTypeID", HeaderText = "Tool Type", ValueMember = "ToolTypeID", DisplayMember = "ToolTypeName", IDataSourceSelector = new ToolTypeDataSourceSelector() });
            machiningGrid.Columns.Add(new GridComboBoxColumn { MappingName = "ToolSurfaceID", HeaderText = "Rough / Finish", ValueMember = "ToolSurfaceID", DisplayMember = "ToolSurfaceName", IDataSourceSelector = new ToolSurfaceDataSourceSelector() });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "CuttingSpeed", HeaderText = "Cutting Speed (S)" });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "DrillSize", HeaderText = "Drill Size (D)" });

            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "FeedRate", HeaderText = "Feed Rate (f) in mm/rev" });

            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "DiameterBeforeTurning", HeaderText = "Diameter of stock before turning (D)" });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "DiameterAfterTurning", HeaderText = "Diameter of job after turning (d)" });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "DepthOfCutEachPass", HeaderText = "Depth of Cut for Each Pass in mm (dc)" });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "TotalDepthOfCut", HeaderText = "Total depth of cut (td)" });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "LengthOfCut", HeaderText = "Length of the cut in mm (L)" });

            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "ThreadDiameterToCut", HeaderText = "Diameter of the thread to cut (D)" });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "ThreadPitch", HeaderText = "Pitch (P)" });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "LengthOfThreadToCut", HeaderText = "Length of thread to cut in mm (L)" });

            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "LengthOfHoleToDrill", HeaderText = "Length of hole to drill in mm (L)" });

            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "NoOfCuts", HeaderText = "Number of Cuts", AllowEditing = false });

            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "RPM", HeaderText = "RPM (N)", AllowEditing = false });

            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "MachiningCostPerHour", HeaderText = "Machining Cost per hour" });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "MachiningTime", HeaderText = "Machining Time in minutes", AllowEditing = false });
            machiningGrid.Columns.Add(new GridNumericColumn { MappingName = "MachiningCost", HeaderText = "Machining Cost", AllowEditing = false });

            StackedHeaderRow childGridStackedHeaderRow = new StackedHeaderRow();
            childGridStackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "ProcessID,ComponentID,ProcessTypeID", HeaderText = "Operation" });
            childGridStackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "ToolTypeID,ToolSurfaceID,CuttingSpeed,DrillSize", HeaderText = "Tool Details" });
            childGridStackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "DiameterBeforeTurning,DiameterAfterTurning,DepthOfCutEachPass,TotalDepthOfCut,LengthOfCut", HeaderText = "Turning Inputs" });
            childGridStackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "ThreadDiameterToCut,ThreadPitch,LengthOfThreadToCut", HeaderText = "Threading inputs" });
            childGridStackedHeaderRow.StackedColumns.Add(new StackedColumn() { ChildColumns = "LengthOfHoleToDrill", HeaderText = "Drilling Inputs" });

            machiningGrid.StackedHeaderRows.Add(childGridStackedHeaderRow);

            foreach (var column in machiningGrid.Columns)
            {
                //column.HeaderStyle.BackColor = Color.LightSteelBlue;
                //column.HeaderStyle.TextColor = Color.White; // Optional: Set text color
                //column.HeaderStyle.Font.Bold = true; // Optional: Make header text bold
                if (!column.AllowEditing)
                {
                    column.CellStyle.BackColor = Color.LightGray;
                }
            }

            #endregion
        }

        private void MachiningGrid_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
        {
            var machingOperation = e.DataRow.RowData as Process;

            foreach (var column in machiningGrid.Columns)
            {
                if (!machingOperation.IsColumnApplicableToOperation(column.MappingName))
                {
                    machingOperation.ResetValue(column.MappingName);
                }
            }
        }

        private void MachiningGrid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if (e.DataRow.RowType == RowType.DefaultRow)
            {
                var machingOperation = e.DataRow.RowData as Process;
                if (!machingOperation.IsColumnApplicableToOperation(e.Column.MappingName))
                {
                    e.Style.BackColor = Color.LightGray;
                }
            }
        }

        private void MachiningGrid_CurrentCellBeginEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellBeginEditEventArgs e)
        {
            var machingOperation = e.DataRow.RowData as Process;
            if (!machingOperation.IsColumnApplicableToOperation(e.DataColumn.GridColumn.MappingName))
            {
                e.Cancel = true;
            }
        }

        private void MachiningGrid_RecordDeleting(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventArgs e)
        {
            var process = e.Items[0] as Process;

            if (process != null && process.Component.LstProcess.Count == 1)
            {
                MessageBoxAdv.Show("Atleast one process is required.", "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Cancel the deletion
            }
            else
            {
                process.PropertyChanged -= Process_PropertyChanged;
            }
        }

        public static void LstProcess_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                var process = e.NewItems[0] as Process;
                process.Component.RecalculateMachiningCost();
            }

            if (e.OldItems != null)
            {
                foreach (Process oldProcess in e.OldItems)
                {
                    // Handle process removed
                    oldProcess.PropertyChanged -= MachiningGrid.Process_PropertyChanged;
                    Console.WriteLine($"Process removed: {oldProcess.ProcessID}");
                }
            }
        }

        public static void Process_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
                switch (process.ProcessTypeID)
                {
                    case 2:
                        CalculateRPMForFaceTurning(process);
                        CalculateMachiningTimeForFaceTurning(process);
                        break;
                    case 1:
                    case 3:
                    case 4:
                        CalculateRPMForTurning(process);
                        CalculateNoOfCutForTurning(process);
                        CalculateMachiningTimeForTurning(process);
                        break;
                    case 5:
                        CalculateRPMForDrilling(process);
                        CalculateMachingTimeForDrilling(process);
                        break;
                    case 6:
                        CalculateRPMForThreading(process);
                        CalculateNoOfCutForThreading(process);
                        CalculateMachingTimeForThreading(process);
                        break;
                    default:
                        break;
                }

                process.MachiningCost = (process.MachiningTime * process.MachiningCostPerHour) / 60;
                process.Component.RecalculateMachiningCost();
            }
        }

        private static void CalculateNoOfCutForTurning(Process process)
        {
            if (process.DepthOfCutEachPass != 0)
            {
                process.NoOfCuts = process.TotalDepthOfCut / process.DepthOfCutEachPass;
            }
            else
            {
                process.NoOfCuts = 0;
            }
        }

        private static void CalculateNoOfCutForThreading(Process process)
        {
            if (process.ThreadPitch != 0)
            {
                process.NoOfCuts = 25 / (10 / process.ThreadPitch);
            }
            else
            {
                process.NoOfCuts = 0;
            }
        }

        private static void CalculateMachiningTimeForTurning(Process process)
        {
            if (process.FeedRate != 0 && process.RPM != 0)
            {
                process.MachiningTime = (process.LengthOfCut * process.NoOfCuts) / (process.FeedRate * process.RPM);
            }
            else
            {
                process.MachiningTime = 0;
            }
        }

        private static void CalculateMachiningTimeForFaceTurning(Process process)
        {
            if (process.FeedRate != 0 && process.RPM != 0)
            {
                process.MachiningTime = (process.LengthOfCut) / (process.FeedRate * process.RPM);
            }
            else
            {
                process.MachiningTime = 0;
            }
        }

        private static void CalculateMachingTimeForDrilling(Process process)
        {
            if (process.FeedRate != 0 && process.RPM != 0)
            {
                process.MachiningTime = process.LengthOfHoleToDrill / (process.FeedRate * process.RPM);
            }
            else
            {
                process.MachiningTime = 0;
            }
        }

        private static void CalculateMachingTimeForThreading(Process process)
        {
            if (process.FeedRate != 0 && process.RPM != 0)
            {
                process.MachiningTime = (process.LengthOfThreadToCut * process.NoOfCuts) / (process.FeedRate * process.RPM);
            }
            else
            {
                process.MachiningTime = 0;
            }
        }

        private static void CalculateRPMForTurning(Process process)
        {
            process.Average = process.DiameterBeforeTurning + (process.DiameterAfterTurning / 2);
            if (process.Average != 0)
            {
                process.RPM = 1000 * process.CuttingSpeed / (3.14M * process.Average);
            }
            else
            {
                process.RPM = 0;
            }
        }

        private static void CalculateRPMForFaceTurning(Process process)
        {
            if (process.DiameterBeforeTurning != 0)
            {
                process.RPM = 1000 * process.CuttingSpeed / (3.14M * process.DiameterBeforeTurning);
            }
            else
            {
                process.RPM = 0;
            }
        }

        private static void CalculateRPMForDrilling(Process process)
        {
            if (process.DrillSize != 0)
            {
                process.RPM = 1000 * process.CuttingSpeed / (3.14M * process.DrillSize);
            }
            else
            {
                process.RPM = 0;
            }
        }

        private static void CalculateRPMForThreading(Process process)
        {
            if (process.ThreadDiameterToCut != 0)
            {
                process.RPM = 1000 * process.CuttingSpeed / (3.14M * process.ThreadDiameterToCut);
            }
            else
            {
                process.RPM = 0;
            }
        }

        private void MachiningGrid_AddNewRowInitiating(object sender, Syncfusion.WinForms.DataGrid.Events.AddNewRowInitiatingEventArgs e)
        {
            ObservableCollection<Process> lstProcess = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<Process>;
            var process = new Process
            {
                ProcessID = lstProcess == null ? 1 : lstProcess.Max(x => x.ProcessID) + 1,
                ComponentID = lstProcess[0].ComponentID,
                Component = lstProcess[0].Component,
                MachiningCostPerHour = 300,
                //ProcessTypeID = 1,
                //ToolTypeID = 1,
                //ToolSurfaceID = 1,
                //CuttingSpeed = 40,
                //FeedRate = 1.3M,
                //DepthOfCutEachPass = 3.5M
            };
            process.PropertyChanged += Process_PropertyChanged;

            e.NewObject = process;
        }
    }
}
