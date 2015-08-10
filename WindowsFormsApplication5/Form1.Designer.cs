namespace WindowsFormsApplication5
{
    partial class Form1
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
            this.pnlCS = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlInputs = new System.Windows.Forms.Panel();
            this.pnlDraw = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCS
            // 
            this.pnlCS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCS.Location = new System.Drawing.Point(26, 84);
            this.pnlCS.Name = "pnlCS";
            this.pnlCS.Size = new System.Drawing.Size(332, 287);
            this.pnlCS.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.GhostWhite;
            this.btnAdd.Location = new System.Drawing.Point(381, 84);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 44);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.UseWaitCursor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.GhostWhite;
            this.btnNew.Location = new System.Drawing.Point(381, 248);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 44);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Новый";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.GhostWhite;
            this.btnSave.Location = new System.Drawing.Point(381, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 44);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlInputs
            // 
            this.pnlInputs.AutoScroll = true;
            this.pnlInputs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInputs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInputs.Location = new System.Drawing.Point(26, 12);
            this.pnlInputs.Name = "pnlInputs";
            this.pnlInputs.Size = new System.Drawing.Size(449, 66);
            this.pnlInputs.TabIndex = 6;
            // 
            // pnlDraw
            // 
            this.pnlDraw.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlDraw.Location = new System.Drawing.Point(380, 168);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(95, 44);
            this.pnlDraw.TabIndex = 7;
            this.pnlDraw.Text = "Отрисовать";
            this.pnlDraw.UseVisualStyleBackColor = false;
            this.pnlDraw.Click += new System.EventHandler(this.pnlDraw_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Location = new System.Drawing.Point(358, 84);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(17, 287);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(499, 389);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pnlDraw);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnlCS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCS;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Button pnlDraw;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

