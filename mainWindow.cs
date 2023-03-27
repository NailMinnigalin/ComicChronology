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
            string dbName = "ComicChronologyDB.sqlite";
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);   
            }
                
        }
    }
}