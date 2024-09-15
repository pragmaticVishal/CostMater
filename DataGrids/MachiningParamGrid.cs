using CostMater.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.Input.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostMater.DataGrids
{
    public class MachiningParamGrid
    {
        public SfDataGrid machiningParamGrid;
        public List<MachiningParameter> lstMachiningParam;

        public MachiningParamGrid(SfDataGrid machiningParamGrid, List<MachiningParameter> lstMachiningParam) 
        {
            this.machiningParamGrid = machiningParamGrid;
            this.lstMachiningParam = lstMachiningParam;
        }

        public void SetUp()
        {
            this.machiningParamGrid.QueryCellStyle += MachiningParamGrid_QueryCellStyle;
            this.machiningParamGrid.CurrentCellBeginEdit += MachiningParamGrid_CurrentCellBeginEdit;
            BindingSource machiningParamBindingSource = new BindingSource();
            machiningParamBindingSource.DataSource = this.lstMachiningParam;
            machiningParamGrid.DataSource = machiningParamBindingSource;

            machiningParamGrid.Columns.Add(new GridTextColumn { MappingName = "MachiningParameterId", HeaderText = "#", AllowEditing = false });
            machiningParamGrid.Columns.Add(new GridTextColumn { MappingName = "MaterialName", HeaderText = "Material", AllowEditing = false });
            machiningParamGrid.Columns.Add(new GridTextColumn { MappingName = "ProcessTypeName", HeaderText = "Process", AllowEditing = false });
            machiningParamGrid.Columns.Add(new GridTextColumn { MappingName = "ToolTypeName", HeaderText = "Tool Type", AllowEditing = false });
            machiningParamGrid.Columns.Add(new GridTextColumn { MappingName = "ToolSurfaceName", HeaderText = "Operation", AllowEditing = false });
            machiningParamGrid.Columns.Add(new GridNumericColumn { MappingName = "CuttingSpeed", HeaderText = "Cutting Speed (m/min)" });
            machiningParamGrid.Columns.Add(new GridNumericColumn { MappingName = "FeedRate", HeaderText = "Feed per Revolution (mm/rev)" });
            machiningParamGrid.Columns.Add(new GridNumericColumn { MappingName = "DepthOfCutEachPass", HeaderText = "Depth of Cut per Pass (mm)" });
            machiningParamGrid.Columns.Add(new GridNumericColumn { MappingName = "DrillSize", HeaderText = "Drill Size (mm)" });
            machiningParamGrid.Columns.Add(new GridNumericColumn { MappingName = "ThreadPitch", HeaderText = "Thread Pitch (mm)" });
            machiningParamGrid.Columns.Add(new GridNumericColumn { MappingName = "MachiningCostPerHour", HeaderText = "Machining Cost per hour", FormatMode = FormatMode.Currency });


            machiningParamGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "MaterialName" });
            machiningParamGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "ProcessTypeName" });

            foreach (var column in machiningParamGrid.Columns)
            {
                if (!column.AllowEditing)
                {
                    column.CellStyle.BackColor = Color.LightGray;
                }
            }
        }

        internal void Reset(List<MachiningParameter> lstMachiningParam)
        {
            this.lstMachiningParam = lstMachiningParam;
            BindingSource machiningParamBindingSource = new BindingSource();
            machiningParamBindingSource.DataSource = this.lstMachiningParam;
            machiningParamGrid.DataSource = machiningParamBindingSource;
        }

        private void MachiningParamGrid_CurrentCellBeginEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellBeginEditEventArgs e)
        {
            var machiningParam = e.DataRow.RowData as MachiningParameter;
            if (!machiningParam.IsColumnApplicable(e.DataColumn.GridColumn.MappingName))
            {
                e.Cancel = true;
            }            
        }

        private void MachiningParamGrid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if (e.DataRow.RowType == RowType.DefaultRow)
            {
                var machiningParam = e.DataRow.RowData as MachiningParameter;
                if (!machiningParam.IsColumnApplicable(e.Column.MappingName))
                {
                    e.Style.BackColor = Color.LightGray;
                }
            }
        }
    }
}
