using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Cache;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml.Linq;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace bolyGO_app
{
    public partial class frmAlap : Form
    {
        private Form aktivSubform;
        private IconButton aktivBtn;
        private Panel szinesVonal;

        private SQLKezelo sqlKezelo = new SQLKezelo();
        public frmAlap()
        {
            InitializeComponent();
  
            ikonAlcim.IconChar = IconChar.Home;
            ikonAlcim.IconColor = Szinek.szoveg;

            //létrehozzuk a színes vonalat, ez lesz az aktív menüpont melett dísznek bal oldalon
            szinesVonal = new Panel();
            szinesVonal.Size = new Size(7, 60);
            pnlMenu.Controls.Add(szinesVonal);

            //kinézet és egyéb beállítások - TODO: keretnélküli app
            /*this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;*/

            this.BackColor = Szinek.hatterVilagos;
            this.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = Szinek.szoveg;
            pnlMenu.BackColor = Szinek.hatterSotet;
            pnlAlcim.BackColor = Szinek.hatterSotet;
            menuStrip.BackColor = Szinek.hatterSotet;
            menuStrip.ForeColor = Szinek.szoveg;

            ibtnUgyfelek.IconColor = Szinek.szoveg;
            ibtnCsomagok.IconColor = Szinek.szoveg;
            ibtnJarmuvek.IconColor = Szinek.szoveg;
            ibtnCsomagJarmu.IconColor = Szinek.szoveg;
            ibtnBolygo.IconColor = Szinek.szoveg;
            ibtnUjFoglalas.IconColor = Szinek.szoveg;
            ibtnFoglalasMod.IconColor = Szinek.szoveg;

            connectToDB();
        }


        public void connectToDB()
        {
            //alapértelmezett 3306ton megpróbáljuk elérni a szervert
            try
            {
                lblFeedback.Text = "Adatbázis előkészítése...";
                sqlKezelo.createDB(3306);
            }
            //ha nem sikerül bekérjük popup ablakkal (portDialog class)
            catch (Exception)
            {
                try
                {
                    using (portDialog pd = new portDialog())
                    {

                        if (pd.ShowDialog() == DialogResult.OK)
                        {
                            //létrehozzuk az adatbázist a bekért porton
                            sqlKezelo.createDB(Convert.ToInt32(pd.nudPort.Value));
                        }
                        else
                        {
                            MessageBox.Show("Nincs megadva port!\nKérem indítsa újra a programot!", "Port hiba", MessageBoxButtons.OK);
                            Environment.Exit(0);
                        }

                        pd.Dispose();
                    }

                    lblFeedback.Text += "\nKész";
                    Thread.Sleep(1000);
                    lblFeedback.Text = "Aktív kapcsolat az adatbázissal";
                    ikonFeedback.IconChar = IconChar.Check;
                    ikonFeedback.IconColor = Szinek.szin4;
                }
                catch (MySqlException a)
                {
                    MessageBox.Show($"\nA program az SQL parancs futtatása közben a következő hibába ütközött.\n{a.Message}\nEllenőrizze, hogy elindította-e a XAMPP alkalmazást és megtette-e az azon belül szükséges lépéseket.\nKérem indítsa újra a programot!", "SQL hiba", MessageBoxButtons.OK);
                }

                catch (Exception a)
                {
                    MessageBox.Show($"A program a következő hibába futott:\n{a.Message}\nKérem indítsa újra a programot!", "Hiba", MessageBoxButtons.OK);
                }
                
            }
            
        }


    
    




        private void openSubform(Form subform)
        {
            //becsukjuk az aktuálisan nyitva lévő formot
            if (aktivSubform != null)
            {
                aktivSubform.Close();
            }
            aktivSubform = subform;

            //elhelyezés
            subform.TopLevel = false;
            subform.FormBorderStyle = FormBorderStyle.None;
            subform.Dock = DockStyle.Fill;
            pnlSubform.Controls.Add(subform);
            pnlSubform.Tag = subform;
            subform.BringToFront();
            subform.Show();

            //alcímsáv
            lblAlcim.Text = subform.Text;

            //formázás
            subform.BackColor = Szinek.hatterVilagos;
            subform.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            subform.ForeColor = Szinek.szoveg;
        }

        private void openSubformWithDGV(Form subform, DataGridView dgv, sajatTextBox stb, System.Drawing.Color szin)
        {
            //becsukjuk az aktuálisan nyitva lévő formot
            if (aktivSubform != null)
            {
                aktivSubform.Close();
            }
            aktivSubform = subform;

            //elhelyezés
            subform.TopLevel = false;
            subform.FormBorderStyle = FormBorderStyle.None;
            subform.Dock = DockStyle.Fill;
            pnlSubform.Controls.Add(subform);
            pnlSubform.Tag = subform;
            subform.BringToFront();
            subform.Show();

            //alcímsáv
            lblAlcim.Text = subform.Text;

            //formázás
            subform.BackColor = Szinek.hatterVilagos;
            subform.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            subform.ForeColor = Szinek.szoveg;

            stb.PlaceholderText = "Keresés";
            stb.BorderFocusColor = Szinek.narancs;
            stb.BorderColor = szin;
            stb.UnderlinedStyle = true;
            stb.BorderRadius = 0;
            stb.BorderSize = 5;
            stb.BackColor = Szinek.hatterSotet;

            //Header, Default és Alternating rows sorok kinézetének beállítása
            dgv.EnableHeadersVisualStyles = false;

            DataGridViewCellStyle AlternatingRows = new DataGridViewCellStyle();
            DataGridViewCellStyle ColumnHeader = new DataGridViewCellStyle();
            DataGridViewCellStyle Default = new DataGridViewCellStyle();
            
            Font font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));

            AlternatingRows.BackColor = Szinek.hatterSotet;
            AlternatingRows.Font = font;
            AlternatingRows.ForeColor = Szinek.szoveg;
            AlternatingRows.SelectionBackColor = Szinek.narancs;
            AlternatingRows.SelectionForeColor = Szinek.szoveg;
            AlternatingRows.WrapMode = DataGridViewTriState.True;

            ColumnHeader.BackColor = szin;
            ColumnHeader.Font = font;
            ColumnHeader.ForeColor = szin == Szinek.szin6 ? Szinek.hatterSotet : Szinek.szoveg; //sárga háttérnél sötét szöveg
            ColumnHeader.SelectionBackColor = szin;
            ColumnHeader.SelectionForeColor = Szinek.szoveg;
            ColumnHeader.WrapMode = DataGridViewTriState.True;
            ColumnHeader.Alignment = DataGridViewContentAlignment.MiddleLeft;
            

            Default.BackColor = Szinek.hatterVilagos;
            Default.Font = font;
            Default.ForeColor = Szinek.szoveg;
            Default.SelectionBackColor = Szinek.narancs;
            Default.SelectionForeColor = Szinek.szoveg;
            Default.WrapMode = DataGridViewTriState.True;
            Default.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.AlternatingRowsDefaultCellStyle = AlternatingRows;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Szinek.hatterVilagos;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                
            dgv.ColumnHeadersDefaultCellStyle = ColumnHeader;
            dgv.ColumnHeadersHeight = 30;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle = Default;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.TabIndex = 5;

            dgv.RowHeadersVisible = false;
        }

        private void activateBtn(object senderBtn, System.Drawing.Color aktivSzin)
        {
            //visszaállítjuk az aktív gomb kinézetét
            if (aktivBtn != null)
            {
                disableBtn();               
            }

            aktivBtn = senderBtn as IconButton;

            aktivBtn.BackColor = Szinek.hatterVilagos;
            aktivBtn.ForeColor = aktivSzin;
            aktivBtn.IconColor = aktivSzin;

            aktivBtn.TextAlign = ContentAlignment.MiddleCenter;
            aktivBtn.ImageAlign = ContentAlignment.MiddleRight;
            aktivBtn.TextImageRelation = TextImageRelation.TextBeforeImage;

            //szines vonal áthelyezése
            szinesVonal.BackColor = aktivSzin;
            szinesVonal.Location = new Point(0, aktivBtn.Location.Y);
            szinesVonal.Visible = true;
            szinesVonal.BringToFront();

            ikonAlcim.IconChar = aktivBtn.IconChar;
            ikonAlcim.IconColor = aktivSzin;
        }

        private void disableBtn()
        {
            aktivBtn.BackColor = Szinek.hatterSotet;
            aktivBtn.ForeColor = Szinek.szoveg;
            aktivBtn.IconColor = Szinek.szoveg;

            aktivBtn.TextAlign = ContentAlignment.MiddleLeft;
            aktivBtn.ImageAlign = ContentAlignment.MiddleLeft;
            aktivBtn.TextImageRelation = TextImageRelation.ImageBeforeText;          
        }



        //megnyitjuk az adott subformot a menüpont választásakor
        private void ibtnUgyfelek_Click(object sender, EventArgs e)
        {
            activateBtn(sender, Szinek.szin3);
            frmUgyfel formu = new frmUgyfel();
            openSubformWithDGV(formu, formu.dgvUgyfelek, formu.stbKereses, Szinek.szin3);
        }

        private void ibtnCsomagok_Click(object sender, EventArgs e)
        {
            activateBtn(sender, Szinek.szin6);
            frmCsomag formcs = new frmCsomag();
            openSubformWithDGV(formcs, formcs.dgvCsomagok, formcs.stbKereses, Szinek.szin6);
        }

        private void ibtnJarmuvek_Click(object sender, EventArgs e)
        {
            activateBtn(sender, Szinek.szin5);
            frmJarmu formj = new frmJarmu();
            openSubformWithDGV(formj, formj.dgvJarmu, formj.stbKereses, Szinek.szin5);
        }

        private void ibtnCsomagJarmu_Click(object sender, EventArgs e)
        {
            activateBtn(sender, Szinek.szin2);
            frmCsomagJarmu formcsj = new frmCsomagJarmu();
            openSubformWithDGV(formcsj, formcsj.dgvCsomagJarmu, formcsj.stbKereses, Szinek.szin2);
        }
        private void ibtnBolygo_Click(object sender, EventArgs e)
        {
            activateBtn(sender, Szinek.szin1);
            frmBolygo formb = new frmBolygo();
            openSubformWithDGV(formb, formb.dgvBolygo, formb.stbKereses, Szinek.szin1);
        }

        private void ibtnFoglalasMod_Click(object sender, EventArgs e)
        {
            activateBtn(sender, Szinek.szin4);
            frmFoglalasMod formfoglm = new frmFoglalasMod();
            //openSubformWithDGV(formfoglm, formfoglm.dgvFoglalasok, Szinek.szin4);
        }

        private void ibtnUjFoglalas_Click(object sender, EventArgs e)
        {
            activateBtn(sender, Szinek.szin4);
            //openSubformWithDGV(new frmUjFoglalas(), Szinek.szin2);
        }

       

        
        
        private void picLogo_Click(object sender, EventArgs e)
        {
            //openSubform(new frmKezdo(false));
            if (aktivSubform != null)
            {
                aktivSubform.Close();
                aktivSubform = null;
            }

            ikonAlcim.IconChar = IconChar.Home;
            ikonAlcim.IconColor = Szinek.szoveg;
        }

        //adatok beolvasása sql fájlból az adatbázisba

        private void adatokImportálásaSQLFájlbólToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Válassza ki az .sql fájlt!",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "sql",
                Filter = "sql files (*.sql)|*.sql",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sqlKezelo.fillDBfromSQL(ofd.FileName);
                    MessageBox.Show($"Az adatok beolvasása megtörtént.", "Sikeres beolvasás", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception a)
                {
                    MessageBox.Show($"A program a következő hibába futott az fájl beolvasása közben:\n{a.Message}\n", "Hiba - Sikertelen beolvasás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw;
                }
            }
        }

       
    }
}
