using RestSharp.Extensions;
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
using System.Windows.Controls;
using System.Windows.Forms;


namespace bolyGO_app
{
    public partial class frmCsomagJarmu : Form
    {    
        SQLKezelo sqlkezelo = new SQLKezelo();
        static string DBtableName = "csomagjarmu";
        static string sqlSelect;
        static bool csomag = false;
        static string csomagid;
        public frmCsomagJarmu()
        {
            InitializeComponent();

            dgvCsomagJarmu.AllowUserToDeleteRows = false;

            SelectCsomag();

            //automatikus méretezése az oszlopoknak
            dgvCsomagJarmu.AutoResizeColumns();
            dgvCsomagJarmu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void iBtnSelect_Click(object sender, EventArgs e)
        {
            if (csomag)
            {
                if (dgvCsomagJarmu.CurrentRow != null)
                {
                    csomagid = dgvCsomagJarmu.CurrentRow.Cells["id"].Value.ToString();
                    csomag = false;
                    SelectVehicles();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Nincs kijelölt sor!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
            }
        }

        //1. kiválasztjuk a csomagot
        private void SelectCsomag()
        {
            sqlSelect = $"SELECT csomag.id, csomag.nev, bolygo.nev as `bolygonev`, csomag.kezdes, csomag.vege, csomag.ar, csomag.leiras " +
                        $"FROM csomag INNER JOIN bolygo ON csomag.bolygoid = bolygo.id " +
                        $"WHERE csomag.id > -1";
            sqlkezelo.fillDGV(this.dgvCsomagJarmu, DBtableName, sqlSelect);
            dgvCsomagJarmu.ReadOnly = true;
            this.iBtnSelect.Visible = true;
            csomag = true;
        }

        //2. kilistázzuk a járműveket, ahol jelölőnégyzetekkel tudjuk állítani, hogy az adott csomag tartalmazza-e azokat
        private void SelectVehicles()
        {
            sqlSelect = $"SELECT id, nev, CASE((SELECT COUNT(*) FROM csomagjarmu WHERE csomagid = {csomagid} AND jarmuid = j.id )>0) WHEN 0 THEN 0 ELSE 1 END AS `Tartalmazza` FROM jarmu AS j WHERE id > -1 ORDER BY id;";

            sqlkezelo.fillDGV(this.dgvCsomagJarmu, DBtableName, sqlSelect);

            dgvCsomagJarmu.ReadOnly = false;

            dgvCsomagJarmu.Columns["id"].ReadOnly = true;
            dgvCsomagJarmu.Columns["nev"].ReadOnly = true;

            csomag = false;
        }

        //dgv frissítése a keresés alapján (minden egyezés)
        private void stbKereses__TextChanged(object sender, EventArgs e)
        {
            if (csomag)
            {
                sqlSelect = $"SELECT csomag.id, csomag.nev, bolygo.nev as `bolygonev`, csomag.kezdes, csomag.vege, csomag.ar, csomag.leiras " +
                            $"FROM csomag INNER JOIN bolygo ON csomag.bolygoid = bolygo.id " +
                            $"WHERE csomag.id > -1 AND (csomag.id LIKE '%{stbKereses.Texts}%' OR csomag.nev LIKE '%{stbKereses.Texts}%' OR bolygo.nev LIKE '%{stbKereses.Texts}%' OR csomag.kezdes LIKE '%{stbKereses.Texts}%' OR csomag.vege LIKE '%{stbKereses.Texts}%' OR csomag.ar LIKE '%{stbKereses.Texts}%') ORDER BY csomag.id";

                sqlkezelo.fillDGV(this.dgvCsomagJarmu, DBtableName, sqlSelect);
            }
            else
            {
                /*sqlSelect = $"SELECT id, nev, CASE ((SELECT COUNT(*) FROM csomagjarmu WHERE csomagid = {csomagid} AND jarmuid = j.id )>0) WHEN 0 THEN 0 ELSE 1 END AS `Tartalmazza` FROM jarmu AS j" +
                    $"WHERE id > -1 AND (id LIKE '%{stbKereses.Texts}%' OR nev LIKE '%{stbKereses.Texts}%') ORDER BY id;";

                sqlkezelo.fillDGV(this.dgvCsomagJarmu, DBtableName, sqlSelect);*/
            }
        }

        /*private void dgvCsomagJarmu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvCsomagJarmu.CurrentCell != null)
            {
                if (dgvCsomagJarmu.CurrentCell.Value.ToString().Equals("0"))
                {
                    dgvCsomagJarmu.CurrentCell.Value = "1";
                    dgvCsomagJarmu.EndEdit();
                }
                else
                {
                    dgvCsomagJarmu.CurrentCell.Value = "0";
                    dgvCsomagJarmu.EndEdit();
                }
            }
        }*/
    }
}
