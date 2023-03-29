namespace ComicChronology
{
    partial class mainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BottomPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PlanPage = new System.Windows.Forms.TabPage();
            this.ComicsPage = new System.Windows.Forms.TabPage();
            this.comicsPageSplitContainer = new System.Windows.Forms.SplitContainer();
            this.comicsDataGridView = new System.Windows.Forms.DataGridView();
            this.comicsListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comicsDetailSplitContainer = new System.Windows.Forms.SplitContainer();
            this.comicPeriodComboBox = new System.Windows.Forms.ComboBox();
            this.comicNameTextBox = new System.Windows.Forms.TextBox();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.ComicsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comicsPageSplitContainer)).BeginInit();
            this.comicsPageSplitContainer.Panel1.SuspendLayout();
            this.comicsPageSplitContainer.Panel2.SuspendLayout();
            this.comicsPageSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comicsDataGridView)).BeginInit();
            this.comicsListContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comicsDetailSplitContainer)).BeginInit();
            this.comicsDetailSplitContainer.Panel1.SuspendLayout();
            this.comicsDetailSplitContainer.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomPanel
            // 
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(0, 386);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(784, 25);
            this.BottomPanel.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.PlanPage);
            this.tabControl1.Controls.Add(this.ComicsPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 386);
            this.tabControl1.TabIndex = 1;
            // 
            // PlanPage
            // 
            this.PlanPage.Location = new System.Drawing.Point(4, 24);
            this.PlanPage.Margin = new System.Windows.Forms.Padding(0);
            this.PlanPage.Name = "PlanPage";
            this.PlanPage.Padding = new System.Windows.Forms.Padding(3);
            this.PlanPage.Size = new System.Drawing.Size(776, 358);
            this.PlanPage.TabIndex = 0;
            this.PlanPage.Text = "Plan";
            this.PlanPage.UseVisualStyleBackColor = true;
            // 
            // ComicsPage
            // 
            this.ComicsPage.Controls.Add(this.comicsPageSplitContainer);
            this.ComicsPage.Location = new System.Drawing.Point(4, 24);
            this.ComicsPage.Margin = new System.Windows.Forms.Padding(0);
            this.ComicsPage.Name = "ComicsPage";
            this.ComicsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ComicsPage.Size = new System.Drawing.Size(776, 358);
            this.ComicsPage.TabIndex = 1;
            this.ComicsPage.Text = "Comics";
            this.ComicsPage.UseVisualStyleBackColor = true;
            // 
            // comicsPageSplitContainer
            // 
            this.comicsPageSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comicsPageSplitContainer.IsSplitterFixed = true;
            this.comicsPageSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.comicsPageSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.comicsPageSplitContainer.Name = "comicsPageSplitContainer";
            // 
            // comicsPageSplitContainer.Panel1
            // 
            this.comicsPageSplitContainer.Panel1.Controls.Add(this.comicsDataGridView);
            // 
            // comicsPageSplitContainer.Panel2
            // 
            this.comicsPageSplitContainer.Panel2.Controls.Add(this.comicsDetailSplitContainer);
            this.comicsPageSplitContainer.Size = new System.Drawing.Size(770, 352);
            this.comicsPageSplitContainer.SplitterDistance = 354;
            this.comicsPageSplitContainer.TabIndex = 0;
            // 
            // comicsDataGridView
            // 
            this.comicsDataGridView.AllowUserToAddRows = false;
            this.comicsDataGridView.AllowUserToDeleteRows = false;
            this.comicsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.comicsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.comicsDataGridView.ContextMenuStrip = this.comicsListContextMenuStrip;
            this.comicsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comicsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.comicsDataGridView.MultiSelect = false;
            this.comicsDataGridView.Name = "comicsDataGridView";
            this.comicsDataGridView.ReadOnly = true;
            this.comicsDataGridView.RowTemplate.Height = 25;
            this.comicsDataGridView.ShowEditingIcon = false;
            this.comicsDataGridView.Size = new System.Drawing.Size(354, 352);
            this.comicsDataGridView.TabIndex = 0;
            // 
            // comicsListContextMenuStrip
            // 
            this.comicsListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.comicsListContextMenuStrip.Name = "comicsListContextMenuStrip";
            this.comicsListContextMenuStrip.Size = new System.Drawing.Size(108, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // comicsDetailSplitContainer
            // 
            this.comicsDetailSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comicsDetailSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.comicsDetailSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.comicsDetailSplitContainer.Name = "comicsDetailSplitContainer";
            this.comicsDetailSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // comicsDetailSplitContainer.Panel1
            // 
            this.comicsDetailSplitContainer.Panel1.Controls.Add(this.comicPeriodComboBox);
            this.comicsDetailSplitContainer.Panel1.Controls.Add(this.comicNameTextBox);
            this.comicsDetailSplitContainer.Size = new System.Drawing.Size(412, 352);
            this.comicsDetailSplitContainer.SplitterDistance = 88;
            this.comicsDetailSplitContainer.TabIndex = 0;
            // 
            // comicPeriodComboBox
            // 
            this.comicPeriodComboBox.FormattingEnabled = true;
            this.comicPeriodComboBox.Location = new System.Drawing.Point(3, 32);
            this.comicPeriodComboBox.Name = "comicPeriodComboBox";
            this.comicPeriodComboBox.Size = new System.Drawing.Size(400, 23);
            this.comicPeriodComboBox.TabIndex = 1;
            this.comicPeriodComboBox.Visible = false;
            // 
            // comicNameTextBox
            // 
            this.comicNameTextBox.Location = new System.Drawing.Point(3, 3);
            this.comicNameTextBox.Name = "comicNameTextBox";
            this.comicNameTextBox.Size = new System.Drawing.Size(400, 23);
            this.comicNameTextBox.TabIndex = 0;
            this.comicNameTextBox.Visible = false;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.Controls.Add(this.tabControl1, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.91727F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.082725F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(784, 411);
            this.mainTableLayoutPanel.TabIndex = 2;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainWindow";
            this.Text = "ComicChronology";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.ComicsPage.ResumeLayout(false);
            this.comicsPageSplitContainer.Panel1.ResumeLayout(false);
            this.comicsPageSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comicsPageSplitContainer)).EndInit();
            this.comicsPageSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comicsDataGridView)).EndInit();
            this.comicsListContextMenuStrip.ResumeLayout(false);
            this.comicsDetailSplitContainer.Panel1.ResumeLayout(false);
            this.comicsDetailSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comicsDetailSplitContainer)).EndInit();
            this.comicsDetailSplitContainer.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel BottomPanel;
        private TabControl tabControl1;
        private TabPage PlanPage;
        private TabPage ComicsPage;
        private SplitContainer comicsPageSplitContainer;
        private ContextMenuStrip comicsListContextMenuStrip;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private TableLayoutPanel mainTableLayoutPanel;
        private SplitContainer comicsDetailSplitContainer;
        private TextBox comicNameTextBox;
        private ComboBox comicPeriodComboBox;
        private DataGridView comicsDataGridView;
    }
}