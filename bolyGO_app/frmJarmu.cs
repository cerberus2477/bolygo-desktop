using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace bolyGO_app
{
    public partial class frmJarmu : Form
    {
        SQLKezelo sqlkezelo = new SQLKezelo();
        static string DBtableName = "Jarmu";
        string DBSelect = $"SELECT * FROM {DBtableName} ORDER BY id";

        public frmJarmu()
        {
            InitializeComponent();

            dgvJarmu.AllowUserToAddRows = true;
            dgvJarmu.AllowUserToDeleteRows = true;

            sqlkezelo.fillDGV(this.dgvJarmu, DBtableName, DBSelect);

            this.dgvJarmu.Columns["id"].ReadOnly = true;

            //automatikus méretezése az oszlopoknak
            dgvJarmu.AutoResizeColumns();
            dgvJarmu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        //sor törlés dialog (törlés gombra és delete billentyűre is)
        private void dgvJarmu_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvJarmu.CurrentRow != null)
            {
                DialogResult valasz = System.Windows.Forms.MessageBox.Show("Biztosan törölni szeretné a kijelölt sort?", "Törlés megerősítése", MessageBoxButtons.YesNo);

                if (valasz == DialogResult.Yes)
                {
                    sqlkezelo.DeleteRow(DBtableName, this.dgvJarmu.CurrentRow.Cells["id"].Value.ToString());
                    sqlkezelo.fillDGV(this.dgvJarmu, DBtableName, DBSelect);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nincs kijelölt sor!", "Hiba", MessageBoxButtons.OK);
            }
        }

        private void ibtnTorles_Click(object sender, EventArgs e)
        {
            if (dgvJarmu.CurrentRow != null)
            {
                DialogResult valasz = System.Windows.Forms.MessageBox.Show("Biztosan törölni szeretné a kijelölt sort?", "Törlés megerősítése", MessageBoxButtons.YesNo);

                if (valasz == DialogResult.Yes)
                {
                    sqlkezelo.DeleteRow(DBtableName, this.dgvJarmu.CurrentRow.Cells["id"].Value.ToString());
                    sqlkezelo.fillDGV(this.dgvJarmu, DBtableName, DBSelect);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nincs kijelölt sor!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtnUj_Click(object sender, EventArgs e)
        {
            sqlkezelo.newEmptyLine(this.dgvJarmu, DBtableName);
            sqlkezelo.fillDGV(this.dgvJarmu, DBtableName, DBSelect);  //adatbázisba teszünk új sort és újratöltjük a megjelenített táblázatot (dgv)
        }

        private void dgvJarmu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sqlkezelo.updateDB(this.dgvJarmu, DBtableName);
        }

        //dgv frissítése a keresés alapján (minden egyezés)
        private void stbKereses__TextChanged(object sender, EventArgs e)
        {
            sqlkezelo.fillDGV(this.dgvJarmu, DBtableName, $"SELECT * FROM {DBtableName} WHERE id LIKE '%{stbKereses.Texts}%' OR nev LIKE '%{stbKereses.Texts}%' OR osztaly LIKE '%{stbKereses.Texts}%' OR fekvohely LIKE '%{stbKereses.Texts}%' ORDER BY id");
        }
    }
}