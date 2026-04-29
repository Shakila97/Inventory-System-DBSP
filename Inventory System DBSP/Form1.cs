using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;

namespace Inventory_System_DBSP
{
    // Form වෙනුවට MaterialForm ලෙස වෙනස් කර ඇත
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            // MaterialSkin පෙනුම සැකසීම (Theme & Colors)
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // ඔබට DARK ලෙසද වෙනස් කළ හැක
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form එක load වන විට database එකට connect විය හැකිදැයි පරීක්ෂා කරමු
            TestDbConnection();
        }

        private void TestDbConnection()
        {
            try
            {
                // අපි කලින් හැදූ DatabaseConfig class එක භාවිතා කරමු
                using (SqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Gear.host Database සම්බන්ධතාවය සාර්ථකයි!", "සාර්ථකයි", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database එකට සම්බන්ධ වීමට නොහැක: \n" + ex.Message, "දෝෂයකි", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }
    }
}