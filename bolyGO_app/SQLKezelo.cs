using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Common;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace bolyGO_app {
	class SQLKezelo {

		private static string connStr = "server=localhost;user=root;password='';port=";
		private static MySqlConnection conn = new MySqlConnection(connStr);
		private static MySqlCommand cmd;



        private static MySqlDataAdapter mda = null;
        BindingSource bsource = new BindingSource();
        DataSet ds = null;


        //sql non-query parancs futtatása
        static void runCommand(string cmdstr)
        {
            try {
                conn.Open();
                cmd = new MySqlCommand(cmdstr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.ToString(), "SQL hiba", MessageBoxButtons.OK);
            }
        }

        //adatbázis létrehozása sql fájl futtatásával
        public void createDB(int port) {
			connStr += port.ToString();
            conn = new MySqlConnection(connStr);
			try {
				runCommand(new StreamReader("bolygo_db.sql").ReadToEnd());
                conn = new MySqlConnection(connStr + ";database='bolygo_db'");
            //visszadobja a főprogramnak az errort ami majd kezeli
            } catch (Exception e) {
				conn.Close();
				throw e;
			}
		}

        public void fillDBfromSQL(string path)
        {
            try
            {
                runCommand(new StreamReader(path).ReadToEnd());
            }
            catch (Exception e)
            {
                conn.Close();
                throw e;
            }
        }

        //DataGridView táblázat feltöltése lekérdezéssel
        public void fillDGV(DataGridView dgv, string tableName, string cmdStr) {
            try
            {
                conn.Open();

                mda = new MySqlDataAdapter(cmdStr, conn);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(mda);

                ds = new DataSet();
                mda.Fill(ds, tableName);
                bsource.DataSource = ds.Tables[tableName];
                dgv.DataSource = bsource;

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.ToString());
            }
        }

        //Üres sor hozzáadása a táblázathoz (segédlet)
        public void newEmptyLine(DataGridView dgv, string table)
        {
            try
            {
                string cmdStr = $"INSERT INTO {table}";
                switch (table)
                {
                    case "Ugyfel":
                        cmdStr += "(`nev`,`lakcim`,`szul`,`nem`,`tel`,`email`) VALUES ('','','1900.01.01.','','','');";
                        break;
                    //[11:13] Nacsa Levente
                    case "Foglalas":
                        cmdStr += "(`csomagid`,`kezdes`,`vege`,`ar`) VALUES ('','1753.01.01.','1753.01.01.','')";
                        break;
                    case "Jarmu":
                        cmdStr += "(`nev`,`osztaly`,`fekvohely`) VALUES ('','','')";
                        break;
                    case "Bolygo":
                        cmdStr += "(`nev`) VALUES ('')";
                        break;
                    case "Csomag":
                        cmdStr += "(`nev`,`leiras`,`bolygoid`,`kezdes`,`vege`,`ar`) VALUES ('','','','1900.01.01.','1900.01.01.','')";
                        break;
                }

                runCommand(cmdStr);

                /* conn.Open();
                 new MySqlCommand(cmd, conn).ExecuteNonQuery();
                 conn.Close();*/

            } catch (Exception e)
            {
                conn.Close();
                MessageBox.Show($"Hiba az új sor hozzáadásánál\n{e.Message}", "SQL hiba", MessageBoxButtons.OK);
            }
        }

        //Sor törlése id alapján
        public void DeleteRow(string table, string id)
        {
            try
            {
                conn.Open();
                new MySqlCommand($"DELETE FROM {table} WHERE id = {id};", conn).ExecuteNonQuery();
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                MessageBox.Show($"Hiba a sor törlésénél\n{e.Message}","SQL hiba", MessageBoxButtons.OK);
            }
        }

        //Csomagjarmu frissitése
        public void CsomagJarmuUpdate(string csomagid, string jarmuid, bool kapcsolt)
        {
            try
            {
                conn.Open();
                if (kapcsolt)
                {
                    new MySqlCommand($"REPLACE INTO csomagjarmu (`csomagid`,`jarmuid`) VALUES ('{csomagid}','{jarmuid}');", conn).ExecuteNonQuery();
                } else
                {
                    new MySqlCommand($"DELETE FROM csomagjarmu WHERE csomagid = {csomagid} AND jarmuid = {jarmuid}", conn).ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show($"Hiba az adatok feltöltésénél.\n{e.Message}", "SQL hiba", MessageBoxButtons.OK);
            }
        }

        //Táblázat módosításainak visszamentése az adatbázisba
        public void updateDB(DataGridView dgv, string table)
        {
            bsource.ResetBindings(true);
            DataTable dt = ds.Tables[table];
            mda.Update(dt);
            dgv.BindingContext[dt].EndCurrentEdit();
        }
	}
}
