using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostMater.Framework
{
    public class RowSelectionControllerExt : RowSelectionController
    {
        SfDataGrid sfDataGrid;

        public RowSelectionControllerExt(SfDataGrid sfDataGrid)
            : base(sfDataGrid)
        {
            this.sfDataGrid = sfDataGrid;
        }

        protected override void ProcessEnterKey()
        {
            AddingNewRow();
            base.ProcessEnterKey();
        }

        protected override void ProcessArrowKeysForSingleMultipleSelection(KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Tab)
                AddingNewRow();
            base.ProcessArrowKeysForSingleMultipleSelection(args);
        }

        private void AddingNewRow()
        {
            if (DataGrid.RowCount - 1 == DataGrid.CurrentCell.RowIndex && DataGrid.ColumnCount - 1 == DataGrid.CurrentCell.ColumnIndex)
            {
                sfDataGrid.View.AddNew();
                sfDataGrid.View.CommitNew();
            }
        }
    }

}
