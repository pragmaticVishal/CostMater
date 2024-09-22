#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CostMater.Data;
using CostMater.DataGrids;
using DetailsView.Data;
using Newtonsoft.Json;
using Syncfusion.Data.Extensions;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Component = DetailsView.Data.Component;
namespace DetailsView
{
    public partial class Form1 : Form
    {
        private string _currentProjectPath = null;
        public event EventHandler CtrlEPressed;
        public event EventHandler CtrlOPressed;
        public event EventHandler CtrlSPressed;
        public event EventHandler CtrlRPressed;
        private ComponentGrid componentGrid1;
        private MachiningParamGrid machiningParamGrid;
        private LaserAndBendingDetailGrid laserAndBendingDetailGrid1;
        private CostMaterProject costMaterProject;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            CtrlEPressed += Form1_CtrlEPressed;
            CtrlOPressed += Form1_CtrlOPressed;
            CtrlSPressed += Form1_CtrlSPressed;
            CtrlRPressed += Form1_CtrlRPressed;
            ObservableCollection<MachiningParameter> lstMachiningParam = MachiningParameterRepository.GetAll();
            ObservableCollection<Component> lstComponent = new ComponentRepository().GetAll();
            costMaterProject = new CostMaterProject(lstComponent, lstMachiningParam);
            SetupDataGrids(costMaterProject.lstComponent, costMaterProject.lstMachiningParam);
        }

        private void Form1_CtrlRPressed(object sender, EventArgs e)
        {
            costMaterProject.lstComponent.ForEach(x => x.LstProcess.ForEach(x => x.CalculateCost()));
            costMaterProject.lstComponent.ForEach(x => x.LstLaserAndBendingDetail.ForEach(x => x.CalculateCost()));
            costMaterProject.lstComponent.ForEach(x => x.LstOneTimeOperationDetail.ForEach(x => x.CalculateCost()));
            costMaterProject.lstComponent.ForEach(x => x.CalculateCost());

            MessageBoxAdv.Show("Cost recalculated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetupDataGrids(ObservableCollection<Component> lstComponent, ObservableCollection<MachiningParameter> lstMachiningParam)
        {
            machiningParamGrid = new MachiningParamGrid(this.sfDGMachiningParam, lstMachiningParam);
            machiningParamGrid.SetUp();

            componentGrid1 = new ComponentGrid(this.componentGrid, lstComponent);
            componentGrid1.Setup();

            SfDataGrid machiningGrid = new SfDataGrid() { Parent = componentGrid };
            MachiningGrid machiningGrid1 = new MachiningGrid(machiningGrid);
            machiningGrid1.Setup();

            SfDataGrid oneTimeOperationGrid = new SfDataGrid() { Parent = componentGrid };
            OneTimeOperationGrid oneTimeOperationGrid1 = new OneTimeOperationGrid(oneTimeOperationGrid);
            oneTimeOperationGrid1.Setup();

            SfDataGrid laserAndBendingDetailGrid = new SfDataGrid() { Parent = componentGrid };
            laserAndBendingDetailGrid1 = new LaserAndBendingDetailGrid(laserAndBendingDetailGrid);
            laserAndBendingDetailGrid1.Setup();

            #region Master-Detail Relation in Grid

            GridViewDefinition laserAndBendingDetailView = new GridViewDefinition();
            laserAndBendingDetailView.RelationalColumn = "LstLaserAndBendingDetail";
            laserAndBendingDetailView.DataGrid = laserAndBendingDetailGrid;
            //laserAndBendingDetailView.DataGrid.Style.HeaderStyle.BackColor = ColorTranslator.FromHtml("#CAECCF");
            this.componentGrid.DetailsViewDefinitions.Add(laserAndBendingDetailView);

            GridViewDefinition oneTimeOperationDetailView = new GridViewDefinition();
            oneTimeOperationDetailView.RelationalColumn = "LstOneTimeOperationDetail";
            oneTimeOperationDetailView.DataGrid = oneTimeOperationGrid;
            //oneTimeOperationDetailView.DataGrid.Style.HeaderStyle.BackColor = ColorTranslator.FromHtml("#CAECCF");
            this.componentGrid.DetailsViewDefinitions.Add(oneTimeOperationDetailView);

            GridViewDefinition machiningDetailView = new GridViewDefinition();
            machiningDetailView.RelationalColumn = "LstProcess";
            machiningDetailView.DataGrid = machiningGrid;
            //componentDetailView.DataGrid.Style.HeaderStyle.BackColor = ColorTranslator.FromHtml("#CAECCF");
            this.componentGrid.DetailsViewDefinitions.Add(machiningDetailView);

            #endregion
        }


        #region ExcelExport
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.E))
            {
                OnCtrlEPressed(EventArgs.Empty);
                return true; // Indicate that the key press was handled
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                OnCtrlSPressed(EventArgs.Empty);
                return true;
            }

            if (keyData == (Keys.Control | Keys.O))
            {
                OnCtrlOPressed(EventArgs.Empty);
                return true;
            }

            if (keyData == (Keys.Control | Keys.R))
            {
                OnCtrlRPressed(EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OnCtrlEPressed(EventArgs e)
        {
            CtrlEPressed?.Invoke(this, e);
        }

        private void OnCtrlOPressed(EventArgs e)
        {
            CtrlOPressed?.Invoke(this, e);
        }

        private void OnCtrlRPressed(EventArgs e)
        {
            CtrlRPressed?.Invoke(this, e);
        }

        private void OnCtrlSPressed(EventArgs e)
        {
            CtrlSPressed?.Invoke(this, e);
        }

        private void ImportProjectData()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Costmater files (*.costmater)|*.costmater|All files (*.*)|*.*",
                    FileName = "ProjectData.costmater"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string jsonContent = File.ReadAllText(openFileDialog.FileName);
                        costMaterProject = JsonConvert.DeserializeObject<CostMaterProject>(jsonContent);
                        componentGrid1.Reset(costMaterProject.lstComponent);
                        machiningParamGrid.Reset(costMaterProject.lstMachiningParam);
                        _currentProjectPath = openFileDialog.FileName;

                        MessageBoxAdv.Show("Data imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBoxAdv.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message);
            }
        }

        private void SaveProjectData()
        {
            this.costMaterProject.lstComponent = this.componentGrid.DataSource as ObservableCollection<Component>;
            this.costMaterProject.lstMachiningParam = this.machiningParamGrid.machiningParamGrid.DataSource as ObservableCollection<MachiningParameter>;
            string json = JsonConvert.SerializeObject(this.costMaterProject,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                });

            try
            {
                if (string.IsNullOrEmpty(_currentProjectPath))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        //Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                        Filter = "Costmater files (*.costmater)|*.costmater|All files (*.*)|*.*",
                        FileName = "ProjectData.costmater"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _currentProjectPath = saveFileDialog.FileName;
                        File.WriteAllText(saveFileDialog.FileName, json);
                        MessageBoxAdv.Show("Costmater file has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    File.WriteAllText(_currentProjectPath, json);
                    MessageBoxAdv.Show("Costmater file has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message);
            }
        }

        private void ExportExcel()
        {
            var options = new ExcelExportingOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            options.AllowOutlining = true;
            options.ExportStackedHeaders = true;
            options.ExportStyle = true;
            options.ExportBorders = true;
            //options.ExcludeColumns = new List<string>() { "Button", "BendTotalCost" };
            options.CellExporting += Options_CellExporting;
            var excelEngine = componentGrid.ExportToExcel(componentGrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];

            try
            {
                SaveFileDialog saveFilterDialog = new SaveFileDialog
                {
                    FilterIndex = 2,
                    Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
                };

                if (saveFilterDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    using (Stream stream = saveFilterDialog.OpenFile())
                    {
                        if (saveFilterDialog.FilterIndex == 1)
                            workBook.Version = ExcelVersion.Excel97to2003;
                        else if (saveFilterDialog.FilterIndex == 2)
                            workBook.Version = ExcelVersion.Excel2010;
                        else
                            workBook.Version = ExcelVersion.Excel2013;
                        workBook.SaveAs(stream);
                    }
                    if (MessageBoxAdv.Show(this.componentGrid, "Do you want to view the workbook?", "Workbook has been created",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        Open(saveFilterDialog.FileName);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message);
            }
        }

        private void Options_CellExporting(object sender, Syncfusion.WinForms.DataGridConverter.Events.DataGridCellExcelExportingEventArgs e)
        {
            if(e.ColumnName == "Button")
                e.Handled = true;
        }

        private void Form1_CtrlSPressed(object sender, EventArgs e)
        {
            if (componentGrid1.hasValidationError || laserAndBendingDetailGrid1.hasValidationError)
            {
                MessageBoxAdv.Show("There are validation errors. Please fix them before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveProjectData();
            }
        }

        private void Form1_CtrlOPressed(object sender, EventArgs e)
        {
            ImportProjectData();
        }

        private void Form1_CtrlEPressed(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void Open(string fileName)
        {
#if !NETCORE
                System.Diagnostics.Process.Start(fileName);
#else
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = "/c start " + fileName
            };
            System.Diagnostics.Process.Start(psi);
#endif
        }
        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void costingTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.SuspendLayout();
            //this.ResumeLayout();
            //menuStrip2.Invalidate();
            //menuStrip2.Update();
            this.costingTabCtrl.SelectedTab.Invalidate(true);
            this.costingTabCtrl.SelectedTab.Update();
            this.Invalidate();
            this.Update();
            this.sfDGMachiningParam.Invalidate();
            this.sfDGMachiningParam.Update();
            this.componentGrid.Invalidate();
            this.componentGrid.Update();

        }
    }
}
