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
    public partial class frmUgyfel : Form
    {
        SQLKezelo sqlkezelo = new SQLKezelo();
        static string DBtableName = "Ugyfel";
        string DBSelect = $"SELECT * FROM {DBtableName} ORDER BY id";
     
        public frmUgyfel()
        {
            InitializeComponent();

            dgvUgyfelek.AllowUserToAddRows = true;
            dgvUgyfelek.AllowUserToDeleteRows = true;

            sqlkezelo.fillDGV(this.dgvUgyfelek, DBtableName, DBSelect);

            this.dgvUgyfelek.Columns["id"].ReadOnly = true;

            //automatikus méretezése az oszlopoknak
            dgvUgyfelek.AutoResizeColumns();
            dgvUgyfelek.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        //sor törlés dialog (törlés gombra és delete billentyűre is)
        private void dgvUgyfelek_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvUgyfelek.CurrentRow != null)
            {
                DialogResult valasz = System.Windows.Forms.MessageBox.Show("Biztosan törölni szeretné a kijelölt sort?", "Törlés megerősítése", MessageBoxButtons.YesNo);

                if (valasz == DialogResult.Yes)
                {
                    sqlkezelo.DeleteRow(DBtableName, this.dgvUgyfelek.CurrentRow.Cells["id"].Value.ToString());
                    sqlkezelo.fillDGV(this.dgvUgyfelek, DBtableName, DBSelect);
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
            if (dgvUgyfelek.CurrentRow != null)
            {
                DialogResult valasz = System.Windows.Forms.MessageBox.Show("Biztosan törölni szeretné a kijelölt sort?", "Törlés megerősítése", MessageBoxButtons.YesNo);

                if (valasz == DialogResult.Yes)
                {
                    sqlkezelo.DeleteRow(DBtableName, this.dgvUgyfelek.CurrentRow.Cells["id"].Value.ToString());
                    sqlkezelo.fillDGV(this.dgvUgyfelek, DBtableName, DBSelect);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nincs kijelölt sor!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtnUj_Click(object sender, EventArgs e)
        {
            sqlkezelo.newEmptyLine(this.dgvUgyfelek, DBtableName);
            sqlkezelo.fillDGV(this.dgvUgyfelek, DBtableName, DBSelect);  //adatbázisba teszünk új sort és újratöltjük a megjelenített táblázatot (dgv)
        }

        private void dgvUgyfelek_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sqlkezelo.updateDB(this.dgvUgyfelek, DBtableName);
        }

        //dgv frissítése a keresés alapján (minden egyezés)
        private void stbKereses__TextChanged(object sender, EventArgs e)
        {
            sqlkezelo.fillDGV(this.dgvUgyfelek, DBtableName, $"SELECT * FROM {DBtableName} WHERE id LIKE '%{stbKereses.Texts}%' OR nev LIKE '%{stbKereses.Texts}%' OR lakcim LIKE '%{stbKereses.Texts}%' OR szul LIKE '%{stbKereses.Texts}%' OR nem LIKE '%{stbKereses.Texts}%' OR tel LIKE '%{stbKereses.Texts}%' OR email LIKE '%{stbKereses.Texts}%' ORDER BY id");
        }
    }
}