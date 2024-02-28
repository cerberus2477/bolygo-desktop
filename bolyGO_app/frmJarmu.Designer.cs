﻿namespace bolyGO_app
{
    partial class frmJarmu
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



            this.dgvJarmu = new System.Windows.Forms.DataGridView();
            this.ibtnUj = new FontAwesome.Sharp.IconButton();
            this.ibtnTorles = new FontAwesome.Sharp.IconButton();
            this.stbKereses = new bolyGO_app.sajatTextBox();
            this.SuspendLayout();
            // 
            // dgvUgyfelek
            // 
            this.dgvJarmu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvJarmu.Location = new System.Drawing.Point(0, 60);
            this.dgvJarmu.Margin = new System.Windows.Forms.Padding(5);
            this.dgvJarmu.Name = "dgvJarmu";
            this.dgvJarmu.Size = new System.Drawing.Size(728, 495);
            this.dgvJarmu.TabIndex = 5;
            this.dgvJarmu.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJarmu_CellValueChanged);
            this.dgvJarmu.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvJarmu_UserDeletingRow);
            // 
            // ibtnUj
            // 
            this.ibtnUj.BackColor = System.Drawing.Color.Transparent;
            this.ibtnUj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnUj.FlatAppearance.BorderSize = 0;
            this.ibtnUj.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnUj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnUj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnUj.IconChar = FontAwesome.Sharp.IconChar.Add;
            this.ibtnUj.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ibtnUj.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtnUj.IconSize = 35;
            this.ibtnUj.Location = new System.Drawing.Point(638, 0);
            this.ibtnUj.Name = "ibtnUj";
            this.ibtnUj.Size = new System.Drawing.Size(36, 36);
            this.ibtnUj.TabIndex = 6;
            this.ibtnUj.UseVisualStyleBackColor = false;
            this.ibtnUj.Click += new System.EventHandler(this.ibtnUj_Click);
            // 
            // ibtnTorles
            // 
            this.ibtnTorles.BackColor = System.Drawing.Color.Transparent;
            this.ibtnTorles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnTorles.FlatAppearance.BorderSize = 0;
            this.ibtnTorles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnTorles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnTorles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnTorles.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.ibtnTorles.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ibtnTorles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnTorles.IconSize = 35;
            this.ibtnTorles.Location = new System.Drawing.Point(680, 0);
            this.ibtnTorles.Name = "ibtnTorles";
            this.ibtnTorles.Size = new System.Drawing.Size(36, 36);
            this.ibtnTorles.TabIndex = 7;
            this.ibtnTorles.UseVisualStyleBackColor = false;
            this.ibtnTorles.Click += new System.EventHandler(this.ibtnTorles_Click);
            // 
            // stbKereses
            // 
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
            this.stbKereses.Size = new System.Drawing.Size(620, 36);
            this.stbKereses.TabIndex = 11;
            this.stbKereses.Texts = "";
            this.stbKereses.UnderlinedStyle = true;
            this.stbKereses._TextChanged += new System.EventHandler(this.stbKereses__TextChanged);
            // 
            // frmUgyfel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 555);
            this.Controls.Add(this.stbKereses);
            this.Controls.Add(this.ibtnTorles);
            this.Controls.Add(this.ibtnUj);
            this.Controls.Add(this.dgvJarmu);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(744, 594);
            this.Name = "frmUgyfel";
            this.Text = "Ügyfelek kezelése";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvJarmu;
        private FontAwesome.Sharp.IconButton ibtnUj;
        private FontAwesome.Sharp.IconButton ibtnTorles;
        public sajatTextBox stbKereses;
    }
}