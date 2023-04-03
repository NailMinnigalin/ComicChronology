using System.Data.SQLite;

namespace ComicChronology
{
    public partial class mainWindow : Form
    {
        Series _selectedSeries;

        public mainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            DBConnection.InitDB();
            UpdateSeriesTable();
            FillComicPeriodicityComboBox();
        }

        private void FillComicPeriodicityComboBox()
        {
            List<PeriodicityType> list = DBConnection.GetAllPeriodicityType();
            seriesPeriodicityComboBox.Items.Clear();
            foreach (PeriodicityType type in list)
            {
                seriesPeriodicityComboBox.Items.Add(type);
            }
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newSeriesId = DBConnection.CreateNewSeries();
            UpdateSeriesTable();
            SelectSeriesInListBox(newSeriesId);
            seriesListBox_DoubleClick(sender, e);
        }
        private void SelectSeriesInListBox(int sId)
        {
            for (int i = 0; i < seriesListBox.Items.Count; i++)
            {
                Series series = (Series)seriesListBox.Items[i];
                if (series.Id == sId)
                {
                    seriesListBox.SelectedItem = series;
                }
            }
        }

        private void UpdateSeriesTable()
        {
            List<Series> allSeries = DBConnection.GetAllSeries();
            seriesListBox.Items.Clear();
            foreach (Series series in allSeries)
            {
                seriesListBox.Items.Add(series);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seriesListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a series to delete.", "No Series Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Series selectedSeries = (Series)seriesListBox.SelectedItem;
            if (MessageBox.Show("Are you sure you want to delete this series?", "Delete Confirmation",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            if (selectedSeries.Id == _selectedSeries.Id)
                SetVisibilitySeriesDetailForms(false);

            try
            {
                DBConnection.DeleteSeries(selectedSeries.Id);
                UpdateSeriesTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the series: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comicsListContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (seriesListBox.SelectedItem == null)
                deleteToolStripMenuItem.Enabled = false;
            else
                deleteToolStripMenuItem.Enabled = true;
        }

        private void seriesListBox_DoubleClick(object sender, EventArgs e)
        {
            _selectedSeries = (Series)seriesListBox.SelectedItem;
            
            seriesTitleTextBox.Text = _selectedSeries.Title;
            SelectPeriodicityInSeriesPeriodicityComboBox(DBConnection.GetPeriodicityType(_selectedSeries.PeriodicityTypeId));
            numberIssuesLabel.Text = "Number of issues: " + DBConnection.GetNumberIssues(_selectedSeries.Id).ToString();

            SetVisibilitySeriesDetailForms(true);
        }

        private void SetVisibilitySeriesDetailForms(bool visibility)
        {
            seriesTitleTextBox.Visible = visibility;
            seriesPeriodicityComboBox.Visible = visibility;
            seriesDataSaveButton.Visible = visibility;
            numberIssuesLabel.Visible = visibility;
        }

        private void SelectPeriodicityInSeriesPeriodicityComboBox(PeriodicityType? periodicity)
        {
            if (periodicity == null)
            {
                seriesPeriodicityComboBox.SelectedItem = null;
                return;
            }
            
            foreach (PeriodicityType item in seriesPeriodicityComboBox.Items)
            {
                if (item.type == periodicity.type)
                {
                    seriesPeriodicityComboBox.SelectedItem = item;
                    return;
                }
            }
        }

        private void seriesDataSaveButton_Click(object sender, EventArgs e)
        {
            string newSeriesTitle = seriesTitleTextBox.Text;
            int newPeriodicityId = ((PeriodicityType)seriesPeriodicityComboBox.SelectedItem).Id;
            DBConnection.UpdateSeries(_selectedSeries.Id, newSeriesTitle, newPeriodicityId);
            UpdateSeriesTable();
        }

        private void setNumberOfIssuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numberIssues = DBConnection.GetNumberIssues(_selectedSeries.Id);
            if (numberIssues > 0 && MessageBox.Show("Are you sure you want to set number of issues for this series? This will delete all existing ones",
                "Delete Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            using (InputForm inputForm = new InputForm())
            {
                int? enteredNumberNullable = inputForm.GetEnteredNumber("Number of issues", "Enter number of issues");

                if (enteredNumberNullable.HasValue)
                {
                    SetNumberIssues(_selectedSeries.Id, enteredNumberNullable.Value);
                }
            }
        }

        private void SetNumberIssues(int seriesId, int numberIssues)
        {
            DBConnection.ClearIssues(seriesId);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = numberIssues + 1;
            progressBar1.Value = 0;
            for (int i = 1; i <= numberIssues; i++)
            {
                DBConnection.InsertIssue(seriesId, i, DateTime.MinValue, false);
                progressBar1.Value = i;
            }
        }
    }
}