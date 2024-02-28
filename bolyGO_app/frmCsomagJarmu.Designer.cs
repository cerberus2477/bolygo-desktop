using System;
using System.Windows.Forms;

namespace bolyGO_app
{
    partial class frmCsomagJarmu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCsomagJarmu = new System.Windows.Forms.DataGridView();
            this.iBtnSelect = new FontAwesome.Sharp.IconButton();
            this.stbKereses = new bolyGO_app.sajatTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsomagJarmu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCsomagJarmu
            // 
            this.dgvCsomagJarmu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCsomagJarmu.Location = new System.Drawing.Point(0, 60);
            this.dgvCsomagJarmu.Margin = new System.Windows.Forms.Padding(5);
            this.dgvCsomagJarmu.Name = "dgvCsomagJarmu";
            this.dgvCsomagJarmu.Size = new System.Drawing.Size(728, 495);
            this.dgvCsomagJarmu.TabIndex = 5;
            //this.dgvCsomagJarmu.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCsomagJarmu_CellBeginEdit);
            // 
            // iBtnSelect
            // 
            this.iBtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iBtnSelect.BackColor = System.Drawing.Color.Transparent;
            this.iBtnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iBtnSelect.FlatAppearance.BorderSize = 0;
            this.iBtnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iBtnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iBtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBtnSelect.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iBtnSelect.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.iBtnSelect.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iBtnSelect.IconSize = 35;
            this.iBtnSelect.Location = new System.Drawing.Point(692, 0);
            this.iBtnSelect.Name = "iBtnSelect";
            this.iBtnSelect.Size = new System.Drawing.Size(36, 36);
            this.iBtnSelect.TabIndex = 12;
            this.iBtnSelect.UseVisualStyleBackColor = false;
            this.iBtnSelect.Click += new System.EventHandler(this.iBtnSelect_Click);
            // 
            // stbKereses
            // 
            this.stbKereses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stbKereses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(46)))));
            this.stbKereses.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.stbKereses.BorderFocusColor = System.Drawing.Color.HotPink;
            this.stbKereses.BorderRadius = 0;
            this.stbKereses.BorderSize = 2;
            this.stbKereses.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stbKereses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.stbKereses.Location = new System.Drawing.Point(0, 0);
            this.stbKereses.Margin = new System.Windows.Forms.Padding(4);
            this.stbKereses.Multiline = false;
            this.stbKereses.Name = "stbKereses";
            this.stbKereses.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.stbKereses.PlaceholderColor = System.Drawing.Color.Silver;
            this.stbKereses.PlaceholderText = "Keresés";
            this.stbKereses.Size = new System.Drawing.Size(685, 36);
            this.stbKereses.TabIndex = 11;
            this.stbKereses.Texts = "";
            this.stbKereses.UnderlinedStyle = true;
            this.stbKereses._TextChanged += new System.EventHandler(this.stbKereses__TextChanged);
            // 
            // frmCsomagJarmu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 555);
            this.Controls.Add(this.iBtnSelect);
            this.Controls.Add(this.stbKereses);
            this.Controls.Add(this.dgvCsomagJarmu);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(744, 594);
            this.Name = "frmCsomagJarmu";
            this.Text = "Csomagokhoz elérhető járművek kezelése";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsomagJarmu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvCsomagJarmu;
        public sajatTextBox stbKereses;
        private FontAwesome.Sharp.IconButton iBtnSelect;
    }
}