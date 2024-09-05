using CostMater.Data;
using CostMater.Framework;
using Microsoft.VisualBasic.Devices;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.WinForms.Input.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostMater.DataGrids
{
    public class OneTimeOperationGrid
    {
        private SfDataGrid oneTimeOperationGrid;

        public OneTimeOperationGrid(SfDataGrid oneTimeOperationGrid)
        {
            this.oneTimeOperationGrid = oneTimeOperationGrid;
        }

        public void Setup()
        {
            #region OneTimeOperationGrid
            oneTimeOperationGrid.SelectionController = new RowSelectionControllerExt(oneTimeOperationGrid);
            oneTimeOperationGrid.AllowResizingColumns = true;
            oneTimeOperationGrid.AllowTriStateSorting = true;
            oneTimeOperationGrid.ShowHeaderToolTip = true;
            oneTimeOperationGrid.ShowToolTip = true;
            oneTimeOperationGrid.EditMode = EditMode.SingleClick;
            oneTimeOperationGrid.AddNewRowText = "Click here to add new operation detail";
            oneTimeOperationGrid.AddNewRowPosition = RowPosition.FixedBottom;
            oneTimeOperationGrid.Style.AddNewRowStyle.BackColor = Color.DarkCyan;
            oneTimeOperationGrid.Style.AddNewRowStyle.TextColor = Color.White;
            oneTimeOperationGrid.Style.BorderStyle = BorderStyle.FixedSingle;
            oneTimeOperationGrid.Style.HeaderStyle.Font.Bold = true;
            oneTimeOperationGrid.Style.StackedHeaderStyle.Font.Bold = true;
            oneTimeOperationGrid.Style.SelectionStyle.BackColor = System.Drawing.SystemColors.Highlight;
            oneTimeOperationGrid.Style.SelectionStyle.TextColor = System.Drawing.SystemColors.HighlightText;
            oneTimeOperationGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            oneTimeOperationGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(22.0f);
            oneTimeOperationGrid.AutoGenerateColumns = false;
            oneTimeOperationGrid.ValidationMode = GridValidationMode.InEdit;
            oneTimeOperationGrid.AllowDeleting = true;
            oneTimeOperationGrid.RowHeight = (int)DpiAware.LogicalToDeviceUnits(21.0f);
            oneTimeOperationGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;
            oneTimeOperationGrid.SelectionMode = GridSelectionMode.Extended;
            oneTimeOperationGrid.CopyOption = CopyOptions.IncludeHeaders;
            oneTimeOperationGrid.PasteOption = PasteOptions.PasteData;
            oneTimeOperationGrid.QueryRowStyle += (sender, e) =>
            {
                //var color = ColorTranslator.FromHtml("#FF70FCA0");
                //e.Style.BackColor = color;
            };
            oneTimeOperationGrid.RecordDeleting += OneTimeOperationGrid_RecordDeleting;
            oneTimeOperationGrid.CurrentCellBeginEdit += OneTimeOperationGrid_CurrentCellBeginEdit;
            oneTimeOperationGrid.QueryCellStyle += OneTimeOperationGrid_QueryCellStyle;
            oneTimeOperationGrid.RowValidating += OneTimeOperationGrid_RowValidating;
            oneTimeOperationGrid.CurrentCellActivating += OneTimeOperationGrid_CurrentCellActivating;
            oneTimeOperationGrid.CurrentCellValidating += OneTimeOperationGrid_CurrentCellValidating;

            NumberFormatInfo nfi1 = new NumberFormatInfo();
            nfi1.NumberDecimalDigits = 0;
            nfi1.NumberGroupSizes = new int[] { };

            oneTimeOperationGrid.Columns.Add(new GridComboBoxColumn { MappingName = "OneTimeOpItemSelectedID", HeaderText = "Operations", ValueMember = "ID", DisplayMember = "Name", IDataSourceSelector = new OneTimeOperationsList(), Width=180 });
            oneTimeOperationGrid.Columns.Add(new GridTextColumn { MappingName = "ComponentID", HeaderText = "Component ID", AllowEditing = false });
            oneTimeOperationGrid.Columns.Add(new GridTextColumn { MappingName = "DrawingNo", HeaderText = "Drawing / Part No.", AllowEditing = false });
            oneTimeOperationGrid.Columns.Add(new GridNumericColumn { MappingName = "Qty", HeaderText = "Qty" });
            oneTimeOperationGrid.Columns.Add(new GridNumericColumn { MappingName = "Rate", HeaderText = "Rate", FormatMode = FormatMode.Currency });
            oneTimeOperationGrid.Columns.Add(new GridNumericColumn { MappingName = "Amount", HeaderText = "Amount", FormatMode = FormatMode.Currency });

            foreach (var column in oneTimeOperationGrid.Columns)
            {
                if (!column.AllowEditing)
                {
                    column.CellStyle.BackColor = Color.LightGray;
                }
            }

            ShowSummaryRow();
            oneTimeOperationGrid.LiveDataUpdateMode = Syncfusion.Data.LiveDataUpdateMode.AllowDataShaping;
            #endregion
        }

        private void OneTimeOperationGrid_CurrentCellValidating(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellValidatingEventArgs e)
        {
            var oneTimeOperationDetail = e.RowData as OneTimeOperationDetail;

            if (e.Column.MappingName == "OneTimeOpItemSelectedID" && !oneTimeOperationDetail.AllowOperation(Convert.ToInt32(e.NewValue)))
            {
                MessageBoxAdv.Show("Cannot add manual operation without component raw material cost. Please update component raw material cost and then retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.IsValid = false;
            }
        }

        private void OneTimeOperationGrid_CurrentCellActivating(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatingEventArgs e)
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
                ObservableCollection<OneTimeOperationDetail> lstOneTimeOperationDetail = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<OneTimeOperationDetail>;
                var oneTimeOperationDetail = new OneTimeOperationDetail
                {
                    OnetimeOpDetailID = lstOneTimeOperationDetail == null ? 1 : lstOneTimeOperationDetail.Max(x => x.OnetimeOpDetailID) + 1,
                    ComponentID = lstOneTimeOperationDetail[0].ComponentID,
                    Component = lstOneTimeOperationDetail[0].Component,
                };
                oneTimeOperationDetail.PropertyChanged += OneTimeOperation_PropertyChanged;
                lstOneTimeOperationDetail.Add(oneTimeOperationDetail);
            }

            //if(e.DataColumn?.GridColumn?.AllowEditing == false)
            //{
            //    if (KeyStateHelper.IsKeyDown(Keys.Tab))
            //    {
            //        //e.Cancel = true;
            //        System.Windows.Forms.SendKeys.Send("{TAB}");
            //        return;
            //    }
            //};
        }

        private void ShowSummaryRow()
        {
            oneTimeOperationGrid.Style.TableSummaryRowStyle.HorizontalAlignment = HorizontalAlignment.Right;
            oneTimeOperationGrid.Style.TableSummaryRowStyle.Font.Bold = true;
            oneTimeOperationGrid.TableSummaryRows.Add(new GridTableSummaryRow()
            {
                Name = "tableSumamryTrue",
                ShowSummaryInRow = false,
                Title = "Total cost for manual operations :",
                TitleColumnCount = 4,
                SummaryColumns = new System.Collections.ObjectModel.ObservableCollection<Syncfusion.Data.ISummaryColumn>()
                {
                    new GridSummaryColumn()
                    {
                        Name = "AllComponentCost",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:c}",
                        MappingName="Amount",
                    }
                }
            });
        }

        private void OneTimeOperationGrid_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
        {
            var oneTimeOperationDetail = e.DataRow.RowData as OneTimeOperationDetail;

            foreach (var column in oneTimeOperationGrid.Columns)
            {
                if (!oneTimeOperationDetail.IsColumnApplicableToOperation(column.MappingName))
                {
                    oneTimeOperationDetail.ResetValue(column.MappingName);
                }
            }
        }

        private void OneTimeOperationGrid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if (e.DataRow.RowType == RowType.DefaultRow)
            {
                var oneTimeOperationDetail = e.DataRow.RowData as OneTimeOperationDetail;
                if (!oneTimeOperationDetail.IsColumnApplicableToOperation(e.Column.MappingName))
                {
                    e.Style.BackColor = Color.LightGray;
                }
            }
        }

        private void OneTimeOperationGrid_CurrentCellBeginEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellBeginEditEventArgs e)
        {
            var oneTimeOperationDetail = e.DataRow.RowData as OneTimeOperationDetail;
            if (!oneTimeOperationDetail.IsColumnApplicableToOperation(e.DataColumn.GridColumn.MappingName))
            {
                e.Cancel = true;
            }
        }

        private void OneTimeOperationGrid_RecordDeleting(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventArgs e)
        {
            var oneTimeOperation = e.Items[0] as OneTimeOperationDetail;

            if (oneTimeOperation != null && oneTimeOperation.Component.LstOneTimeOperationDetail.Count == 1)
            {
                MessageBoxAdv.Show("Atleast one operation is required.", "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Cancel the deletion
            }
            else
            {
                ObservableCollection<OneTimeOperationDetail> lstOneTimeOperationDetail = ((Syncfusion.WinForms.DataGrid.SfDataGrid)e.OriginalSender).DataSource as ObservableCollection<OneTimeOperationDetail>;
                int deleteIndex = lstOneTimeOperationDetail.IndexOf(oneTimeOperation);
                if(deleteIndex > -1)
                {
                    lstOneTimeOperationDetail.RemoveAt(deleteIndex);
                }                
                oneTimeOperation.PropertyChanged -= OneTimeOperation_PropertyChanged;
            }
        }

        public static void LstOneTimeOperation_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) 
        {
            if (e.NewItems != null)
            {
                var oneTimeOperation = e.NewItems[0] as OneTimeOperationDetail;
                oneTimeOperation.Component.RecalculateOneTimeOperationCost();
            }

            if (e.OldItems != null)
            {
                var oneTimeOperation = e.OldItems[0] as OneTimeOperationDetail;
                oneTimeOperation.Component.RecalculateOneTimeOperationCost();
                oneTimeOperation.PropertyChanged -= OneTimeOperationGrid.OneTimeOperation_PropertyChanged;
            }
        }
        public static void OneTimeOperation_PropertyChanged(object sender, PropertyChangedEventArgs e) 
        {
            List<string> excludeProps = new List<string>() { nameof(OneTimeOperationDetail.Amount) };

            if (excludeProps.Contains(e.PropertyName))
                return;

            var oneTimeOperation = sender as OneTimeOperationDetail;
            
            if (oneTimeOperation != null)
            {
                oneTimeOperation.CalculateCost();
                oneTimeOperation.Component.RecalculateOneTimeOperationCost();
            }
        }        
    }
}
