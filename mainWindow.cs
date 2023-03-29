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
            int newComicsId = DBConnection.CreateNewSeries();
            UpdateSeriesTable();
        }

        private void UpdateSeriesTable()
        {
            series = DBConnection.GetAllSeries();
            comicsDataGridView.DataSource = Utils.DictionaryToDataTable(series);
        }
    }
}