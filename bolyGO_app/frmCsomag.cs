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


namespace bolyGO_app
{
    public partial class frmCsomag : Form
    {    
        SQLKezelo sqlkezelo = new SQLKezelo();
        static string DBtableName = "Csomag";
        static string sqlSelect = $"SELECT csomag.id, csomag.nev, bolygo.nev as `bolygonev`, csomag.kezdes, csomag.vege, csomag.ar, csomag.leiras " +
                                  $"FROM csomag INNER JOIN bolygo ON csomag.bolygoid = bolygo.id " +
                                  $"WHERE csomag.id > -1";

        public frmCsomag()
        {
            InitializeComponent();

            dgvCsomagok.AllowUserToAddRows = true;
            dgvCsomagok.AllowUserToDeleteRows = true;

            sqlkezelo.fillDGV(this.dgvCsomagok, DBtableName, sqlSelect);

            this.dgvCsomagok.Columns["id"].ReadOnly = true;

            sqlSelect = $"SELECT csomag.id, csomag.nev, bolygo.nev as `bolygonev`, csomag.kezdes, csomag.vege, csomag.ar, csomag.leiras " +
                        $"FROM csomag INNER JOIN bolygo ON csomag.bolygoid = bolygo.id " +
                        $"WHERE csomag.id > -1 AND (csomag.id LIKE '%{stbKereses.Texts}%' OR csomag.nev LIKE '%{stbKereses.Texts}%' OR bolygo.nev LIKE '%{stbKereses.Texts}%' OR csomag.kezdes LIKE '%{stbKereses.Texts}%' OR csomag.vege LIKE '%{stbKereses.Texts}%' OR csomag.ar LIKE '%{stbKereses.Texts}%') ORDER BY csomag.id";

            //automatikus méretezése az oszlopoknak
            dgvCsomagok.AutoResizeColumns();
            dgvCsomagok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        //sor törlés dialog (törlés gombra és delete billentyűre is)
        private void dgvCsomagok_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvCsomagok.CurrentRow != null)
            {
                DialogResult valasz = System.Windows.Forms.MessageBox.Show("Biztosan törölni szeretné a kijelölt sort?", "Törlés megerősítése", MessageBoxButtons.YesNo);

                if (valasz == DialogResult.Yes)
                {
                    sqlkezelo.DeleteRow(DBtableName, this.dgvCsomagok.CurrentRow.Cells["id"].Value.ToString());
                    sqlkezelo.fillDGV(this.dgvCsomagok, DBtableName, sqlSelect);
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
            if (dgvCsomagok.CurrentRow != null)
            {
                DialogResult valasz = System.Windows.Forms.MessageBox.Show("Biztosan törölni szeretné a kijelölt sort?", "Törlés megerősítése", MessageBoxButtons.YesNo);

                if (valasz == DialogResult.Yes)
                {
                    sqlkezelo.DeleteRow(DBtableName, this.dgvCsomagok.CurrentRow.Cells["id"].Value.ToString());
                    sqlkezelo.fillDGV(this.dgvCsomagok, DBtableName, sqlSelect);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nincs kijelölt sor!", "Hiba", MessageBoxButtons.OK);
            }
        }

        private void ibtnUj_Click(object sender, EventArgs e)
        {
            sqlkezelo.newEmptyLine(this.dgvCsomagok, DBtableName);
            sqlkezelo.fillDGV(this.dgvCsomagok, DBtableName, sqlSelect); //adatbázisba teszünk új sort és újratöltjük a megjelenített táblázatot (dgv)
        }

        private void dgvCsomagok_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sqlkezelo.updateDB(this.dgvCsomagok, DBtableName);
        }

        //dgv frissítése a keresés alapján (minden egyezés)
        private void stbKereses__TextChanged(object sender, EventArgs e)
        {
            sqlSelect = $"SELECT csomag.id, csomag.nev, bolygo.nev as `bolygonev`, csomag.kezdes, csomag.vege, csomag.ar, csomag.leiras " +
                        $"FROM csomag INNER JOIN bolygo ON csomag.bolygoid = bolygo.id " +
                        $"WHERE csomag.id > -1 AND (csomag.id LIKE '%{stbKereses.Texts}%' OR csomag.nev LIKE '%{stbKereses.Texts}%' OR bolygo.nev LIKE '%{stbKereses.Texts}%' OR csomag.kezdes LIKE '%{stbKereses.Texts}%' OR csomag.vege LIKE '%{stbKereses.Texts}%' OR csomag.ar LIKE '%{stbKereses.Texts}%') ORDER BY csomag.id";

            sqlkezelo.fillDGV(this.dgvCsomagok, DBtableName, sqlSelect);
        }

    }
}