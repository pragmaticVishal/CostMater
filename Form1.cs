#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CostMater.DataGrids;
using DetailsView.Data;
using Newtonsoft.Json;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.XlsIO;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using Component = DetailsView.Data.Component;
using Syncfusion.Windows.Forms;
using System.Threading.Tasks;

namespace DetailsView
{
    public partial class Form1 : Form
    {
        private string _currentProjectPath = null;
        public event EventHandler CtrlEPressed;
        public event EventHandler CtrlOPressed;
        public event EventHandler CtrlSPressed;
        private ComponentGrid componentGrid1;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            CtrlEPressed += Form1_CtrlEPressed;
            CtrlOPressed += Form1_CtrlOPressed;
            CtrlSPressed += Form1_CtrlSPressed;
            SetupDataGrids(new ComponentRepository().GetAll());
        }

        private void SetupDataGrids(ObservableCollection<Component> lstComponent)
        {
            componentGrid1 = new ComponentGrid(this.componentGrid, lstComponent);
            componentGrid1.Setup();

            SfDataGrid machiningGrid = new SfDataGrid();
            MachiningGrid machiningGrid1 = new MachiningGrid(machiningGrid);
            machiningGrid1.Setup();

            SfDataGrid oneTimeOperationGrid = new SfDataGrid();
            OneTimeOperationGrid oneTimeOperationGrid1 = new OneTimeOperationGrid(oneTimeOperationGrid);
            oneTimeOperationGrid1.Setup();

            SfDataGrid laserAndBendingDetailGrid = new SfDataGrid();
            LaserAndBendingDetailGrid laserAndBendingDetailGrid1 = new LaserAndBendingDetailGrid(laserAndBendingDetailGrid);
            laserAndBendingDetailGrid1.Setup();

            #region Master-Detail Relation in Grid

            GridViewDefinition laserAndBendingDetailView = new GridViewDefinition();
            laserAndBendingDetailView.RelationalColumn = "LstLaserAndBendingDetail";
            laserAndBendingDetailView.DataGrid = laserAndBendingDetailGrid;
            this.componentGrid.DetailsViewDefinitions.Add(laserAndBendingDetailView);

            GridViewDefinition oneTimeOperationDetailView = new GridViewDefinition();
            oneTimeOperationDetailView.RelationalColumn = "LstOneTimeOperationDetail";
            oneTimeOperationDetailView.DataGrid = oneTimeOperationGrid;
            this.componentGrid.DetailsViewDefinitions.Add(oneTimeOperationDetailView);

            GridViewDefinition componentDetailView = new GridViewDefinition();
            componentDetailView.RelationalColumn = "LstProcess";
            componentDetailView.DataGrid = machiningGrid;
            this.componentGrid.DetailsViewDefinitions.Add(componentDetailView);

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
                        ObservableCollection<Component> lstComponent = JsonConvert.DeserializeObject<ObservableCollection<Component>>(jsonContent);
                        componentGrid1.Reset(lstComponent);
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
            string json = JsonConvert.SerializeObject(this.componentGrid.DataSource as ObservableCollection<Component>,
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

        private void Form1_CtrlSPressed(object sender, EventArgs e)
        {
            SaveProjectData();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
