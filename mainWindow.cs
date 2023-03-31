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
            Series selectedSeries = (Series)seriesListBox.SelectedItem;
            DBConnection.DeleteSeries(selectedSeries.Id);
            UpdateSeriesTable();
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
            seriesTitleTextBox.Visible = true;

            SelectPeriodicityInSeriesPeriodicityComboBox(DBConnection.GetPeriodicityType(_selectedSeries.PeriodicityTypeId));
            seriesPeriodicityComboBox.Visible = true;

            seriesDataSaveButton.Visible = true;
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
    }
}