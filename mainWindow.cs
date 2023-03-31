using System.Data.SQLite;

namespace ComicChronology
{
    public partial class mainWindow : Form
    {
        Dictionary<int, string> series;

        public mainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            DBConnection.InitDB();
            UpdateSeriesTable();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newSeriesId = DBConnection.CreateNewSeries();
            UpdateSeriesTable();
            SelectSeriesInListBox(newSeriesId);
        }
        private void SelectSeriesInListBox(int sId)
        {
            foreach (Series series in seriesListBox.Items)
            {
                if (series.Id == sId)
                    seriesListBox.SelectedItem = series;
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
    }
}