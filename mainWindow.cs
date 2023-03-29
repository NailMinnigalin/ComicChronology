using System.Data.SQLite;

namespace ComicChronology
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            DBConnection.InitDB();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newComicsId = DBConnection.CreateNewSeries();
        }
    }
}