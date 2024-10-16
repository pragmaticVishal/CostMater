#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Forms;

namespace DetailsView
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            componentGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            costingTabCtrl = new System.Windows.Forms.TabControl();
            costingPage = new System.Windows.Forms.TabPage();
            menuStrip2 = new System.Windows.Forms.MenuStrip();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            costConfigPage = new System.Windows.Forms.TabPage();
            sfDGMachiningParam = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            ((System.ComponentModel.ISupportInitialize)componentGrid).BeginInit();
            costingTabCtrl.SuspendLayout();
            costingPage.SuspendLayout();
            menuStrip2.SuspendLayout();
            costConfigPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDGMachiningParam).BeginInit();
            SuspendLayout();
            // 
            // componentGrid
            // 
            componentGrid.AccessibleName = "Table";
            componentGrid.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
            componentGrid.AllowResizingColumns = true;
            componentGrid.AllowTriStateSorting = true;
            componentGrid.AutoGenerateColumns = false;
            componentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            componentGrid.Location = new System.Drawing.Point(3, 30);
            componentGrid.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            componentGrid.Name = "componentGrid";
            componentGrid.RowHeight = 21;
            componentGrid.ShowHeaderToolTip = false;
            componentGrid.ShowToolTip = false;
            componentGrid.Size = new System.Drawing.Size(1292, 548);
            componentGrid.TabIndex = 0;
            componentGrid.Text = "sfDataGrid1";
            componentGrid.ValidationMode = Syncfusion.WinForms.DataGrid.Enums.GridValidationMode.InEdit;
            // 
            // costingTabCtrl
            // 
            costingTabCtrl.Controls.Add(costingPage);
            costingTabCtrl.Controls.Add(costConfigPage);
            costingTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            costingTabCtrl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            costingTabCtrl.HotTrack = true;
            costingTabCtrl.Location = new System.Drawing.Point(0, 0);
            costingTabCtrl.Name = "costingTabCtrl";
            costingTabCtrl.SelectedIndex = 0;
            costingTabCtrl.Size = new System.Drawing.Size(1306, 611);
            costingTabCtrl.TabIndex = 2;
            costingTabCtrl.SelectedIndexChanged += costingTabCtrl_SelectedIndexChanged;
            // 
            // costingPage
            // 
            costingPage.Controls.Add(componentGrid);
            costingPage.Controls.Add(menuStrip2);
            costingPage.Location = new System.Drawing.Point(4, 26);
            costingPage.Name = "costingPage";
            costingPage.Padding = new System.Windows.Forms.Padding(3);
            costingPage.Size = new System.Drawing.Size(1298, 581);
            costingPage.TabIndex = 0;
            costingPage.Text = "Costing";
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem7, toolStripMenuItem8, refreshToolStripMenuItem1, toolStripMenuItem9 });
            menuStrip2.Location = new System.Drawing.Point(3, 3);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            menuStrip2.Size = new System.Drawing.Size(1292, 27);
            menuStrip2.TabIndex = 2;
            menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem3, toolStripMenuItem4, refreshToolStripMenuItem, toolStripMenuItem5, toolStripMenuItem6 });
            toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(38, 19);
            toolStripMenuItem2.Text = "File";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            toolStripMenuItem3.Size = new System.Drawing.Size(161, 22);
            toolStripMenuItem3.Text = "Open";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            toolStripMenuItem4.Size = new System.Drawing.Size(161, 22);
            toolStripMenuItem4.Text = "Save";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R;
            refreshToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += Form1_CtrlRPressed;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E;
            toolStripMenuItem5.Size = new System.Drawing.Size(161, 22);
            toolStripMenuItem5.Text = "Export";
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4;
            toolStripMenuItem6.Size = new System.Drawing.Size(161, 22);
            toolStripMenuItem6.Text = "Exit";
            toolStripMenuItem6.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new System.Drawing.Size(49, 19);
            toolStripMenuItem7.Text = "Open";
            toolStripMenuItem7.Click += Form1_CtrlOPressed;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new System.Drawing.Size(46, 19);
            toolStripMenuItem8.Text = "Save";
            toolStripMenuItem8.Click += Form1_CtrlSPressed;
            // 
            // refreshToolStripMenuItem1
            // 
            refreshToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            refreshToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R;
            refreshToolStripMenuItem1.Size = new System.Drawing.Size(63, 19);
            refreshToolStripMenuItem1.Text = "Refresh";
            refreshToolStripMenuItem1.Click += Form1_CtrlRPressed;
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new System.Drawing.Size(56, 19);
            toolStripMenuItem9.Text = "Export";
            toolStripMenuItem9.Click += Form1_CtrlEPressed;
            // 
            // costConfigPage
            // 
            costConfigPage.Controls.Add(sfDGMachiningParam);
            costConfigPage.Location = new System.Drawing.Point(4, 26);
            costConfigPage.Name = "costConfigPage";
            costConfigPage.Padding = new System.Windows.Forms.Padding(3);
            costConfigPage.Size = new System.Drawing.Size(1298, 581);
            costConfigPage.TabIndex = 1;
            costConfigPage.Text = "Cost Config";
            costConfigPage.UseVisualStyleBackColor = true;
            // 
            // sfDGMachiningParam
            // 
            sfDGMachiningParam.AccessibleName = "Table";
            sfDGMachiningParam.AllowResizingColumns = true;
            sfDGMachiningParam.AllowTriStateSorting = true;
            sfDGMachiningParam.AutoGenerateColumns = false;
            sfDGMachiningParam.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            sfDGMachiningParam.Dock = System.Windows.Forms.DockStyle.Fill;
            sfDGMachiningParam.EditMode = Syncfusion.WinForms.DataGrid.Enums.EditMode.SingleClick;
            sfDGMachiningParam.Location = new System.Drawing.Point(3, 3);
            sfDGMachiningParam.Name = "sfDGMachiningParam";
            sfDGMachiningParam.SelectionUnit = Syncfusion.WinForms.DataGrid.Enums.SelectionUnit.Cell;
            sfDGMachiningParam.ShowGroupDropArea = true;
            sfDGMachiningParam.Size = new System.Drawing.Size(1292, 575);
            sfDGMachiningParam.Style.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            sfDGMachiningParam.Style.HeaderStyle.Font.Bold = true;
            sfDGMachiningParam.Style.SelectionStyle.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            sfDGMachiningParam.TabIndex = 0;
            sfDGMachiningParam.Text = "sfDGMachiningParam";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1306, 611);
            Controls.Add(costingTabCtrl);
            Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            Name = "Form1";
            Text = "CostMater";
            ((System.ComponentModel.ISupportInitialize)componentGrid).EndInit();
            costingTabCtrl.ResumeLayout(false);
            costingPage.ResumeLayout(false);
            costingPage.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            costConfigPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sfDGMachiningParam).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid componentGrid;
        private System.Windows.Forms.TabControl costingTabCtrl;
        private System.Windows.Forms.TabPage costingPage;
        private System.Windows.Forms.TabPage costConfigPage;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDGMachiningParam;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
    }
}

