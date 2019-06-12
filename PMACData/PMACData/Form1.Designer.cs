namespace PMACData
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dongho = new System.Windows.Forms.Label();
            this.lbFilePMAC = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDatabase = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.btCopy = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pMacStatus = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stasusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btCopyData = new System.Windows.Forms.Button();
            this.btupdateVa = new System.Windows.Forms.Button();
            this.btTachMang = new System.Windows.Forms.Button();
            this.btSanLuong = new System.Windows.Forms.Button();
            this.btDoBe = new System.Windows.Forms.Button();
            this.btBackup = new System.Windows.Forms.Button();
            this.btDHHu = new System.Windows.Forms.Button();
            this.cbMaDMA = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btNet01 = new System.Windows.Forms.Button();
            this.btNet90 = new System.Windows.Forms.Button();
            this.btThatThoat = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "The last write time for this directory PMAC DATA :";
            // 
            // dongho
            // 
            this.dongho.AutoSize = true;
            this.dongho.Location = new System.Drawing.Point(467, 59);
            this.dongho.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.dongho.Name = "dongho";
            this.dongho.Size = new System.Drawing.Size(30, 23);
            this.dongho.TabIndex = 3;
            this.dongho.Text = "dd";
            // 
            // lbFilePMAC
            // 
            this.lbFilePMAC.AutoSize = true;
            this.lbFilePMAC.Location = new System.Drawing.Point(467, 110);
            this.lbFilePMAC.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbFilePMAC.Name = "lbFilePMAC";
            this.lbFilePMAC.Size = new System.Drawing.Size(30, 23);
            this.lbFilePMAC.TabIndex = 4;
            this.lbFilePMAC.Text = "dd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "The last write time for this Database :";
            // 
            // lbDatabase
            // 
            this.lbDatabase.AutoSize = true;
            this.lbDatabase.Location = new System.Drawing.Point(467, 151);
            this.lbDatabase.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbDatabase.Name = "lbDatabase";
            this.lbDatabase.Size = new System.Drawing.Size(30, 23);
            this.lbDatabase.TabIndex = 6;
            this.lbDatabase.Text = "dd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 201);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Application iPMAC-TANHOA";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(709, 193);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 34);
            this.stop.TabIndex = 8;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // btCopy
            // 
            this.btCopy.Location = new System.Drawing.Point(709, 104);
            this.btCopy.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btCopy.Name = "btCopy";
            this.btCopy.Size = new System.Drawing.Size(75, 34);
            this.btCopy.TabIndex = 9;
            this.btCopy.Text = "Copy";
            this.btCopy.UseVisualStyleBackColor = true;
            this.btCopy.Click += new System.EventHandler(this.btCopy_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbStatus.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Location = new System.Drawing.Point(467, 194);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(116, 30);
            this.lbStatus.TabIndex = 11;
            this.lbStatus.Text = "label5";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(623, 192);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(80, 34);
            this.start.TabIndex = 12;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(15, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(768, 34);
            this.label5.TabIndex = 13;
            this.label5.Text = "THEO DÕI ỨNG DỤNG PMAC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pMacStatus
            // 
            this.pMacStatus.Icon = ((System.Drawing.Icon)(resources.GetObject("pMacStatus.Icon")));
            this.pMacStatus.Text = "Pmac Status";
            this.pMacStatus.Visible = true;
            this.pMacStatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pMacStatus_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stasusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 332);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stasusLabel
            // 
            this.stasusLabel.Name = "stasusLabel";
            this.stasusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cyan;
            this.button1.Location = new System.Drawing.Point(28, 235);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Hide";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.Red;
            this.btExit.Location = new System.Drawing.Point(101, 236);
            this.btExit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(68, 32);
            this.btExit.TabIndex = 16;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btCopyData
            // 
            this.btCopyData.Location = new System.Drawing.Point(623, 234);
            this.btCopyData.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btCopyData.Name = "btCopyData";
            this.btCopyData.Size = new System.Drawing.Size(80, 34);
            this.btCopyData.TabIndex = 17;
            this.btCopyData.Text = "Copy";
            this.btCopyData.UseVisualStyleBackColor = true;
            this.btCopyData.Click += new System.EventHandler(this.btCopyData_Click);
            // 
            // btupdateVa
            // 
            this.btupdateVa.Location = new System.Drawing.Point(171, 235);
            this.btupdateVa.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btupdateVa.Name = "btupdateVa";
            this.btupdateVa.Size = new System.Drawing.Size(93, 32);
            this.btupdateVa.TabIndex = 19;
            this.btupdateVa.Text = "Value";
            this.btupdateVa.UseVisualStyleBackColor = true;
            this.btupdateVa.Click += new System.EventHandler(this.btupdateVa_Click);
            // 
            // btTachMang
            // 
            this.btTachMang.Location = new System.Drawing.Point(508, 236);
            this.btTachMang.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btTachMang.Name = "btTachMang";
            this.btTachMang.Size = new System.Drawing.Size(75, 34);
            this.btTachMang.TabIndex = 20;
            this.btTachMang.Text = "TM";
            this.btTachMang.UseVisualStyleBackColor = true;
            this.btTachMang.Click += new System.EventHandler(this.btTachMang_Click);
            // 
            // btSanLuong
            // 
            this.btSanLuong.Location = new System.Drawing.Point(273, 236);
            this.btSanLuong.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btSanLuong.Name = "btSanLuong";
            this.btSanLuong.Size = new System.Drawing.Size(108, 32);
            this.btSanLuong.TabIndex = 18;
            this.btSanLuong.Text = "Sản Lượng";
            this.btSanLuong.UseVisualStyleBackColor = true;
            this.btSanLuong.Click += new System.EventHandler(this.btSanLuong_Click);
            // 
            // btDoBe
            // 
            this.btDoBe.Location = new System.Drawing.Point(403, 236);
            this.btDoBe.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btDoBe.Name = "btDoBe";
            this.btDoBe.Size = new System.Drawing.Size(93, 34);
            this.btDoBe.TabIndex = 18;
            this.btDoBe.Text = "Dò Bể";
            this.btDoBe.UseVisualStyleBackColor = true;
            this.btDoBe.Click += new System.EventHandler(this.btDoBe_Click);
            // 
            // btBackup
            // 
            this.btBackup.Location = new System.Drawing.Point(709, 234);
            this.btBackup.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btBackup.Name = "btBackup";
            this.btBackup.Size = new System.Drawing.Size(75, 34);
            this.btBackup.TabIndex = 21;
            this.btBackup.Text = "Backup";
            this.btBackup.UseVisualStyleBackColor = true;
            this.btBackup.Click += new System.EventHandler(this.btBackup_Click);
            // 
            // btDHHu
            // 
            this.btDHHu.Location = new System.Drawing.Point(273, 280);
            this.btDHHu.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btDHHu.Name = "btDHHu";
            this.btDHHu.Size = new System.Drawing.Size(108, 34);
            this.btDHHu.TabIndex = 22;
            this.btDHHu.Text = "ĐH Hư";
            this.btDHHu.UseVisualStyleBackColor = true;
            this.btDHHu.Click += new System.EventHandler(this.btDHHu_Click);
            // 
            // cbMaDMA
            // 
            this.cbMaDMA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaDMA.FormattingEnabled = true;
            this.cbMaDMA.Location = new System.Drawing.Point(171, 283);
            this.cbMaDMA.Name = "cbMaDMA";
            this.cbMaDMA.Size = new System.Drawing.Size(93, 31);
            this.cbMaDMA.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Mã DMA :";
            // 
            // btNet01
            // 
            this.btNet01.Location = new System.Drawing.Point(403, 280);
            this.btNet01.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btNet01.Name = "btNet01";
            this.btNet01.Size = new System.Drawing.Size(180, 34);
            this.btNet01.TabIndex = 25;
            this.btNet01.Text = "Network 01";
            this.btNet01.UseVisualStyleBackColor = true;
            this.btNet01.Click += new System.EventHandler(this.btNet01_Click);
            // 
            // btNet90
            // 
            this.btNet90.Location = new System.Drawing.Point(623, 280);
            this.btNet90.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btNet90.Name = "btNet90";
            this.btNet90.Size = new System.Drawing.Size(161, 34);
            this.btNet90.TabIndex = 25;
            this.btNet90.Text = "Network 90";
            this.btNet90.UseVisualStyleBackColor = true;
            this.btNet90.Click += new System.EventHandler(this.btNet90_Click);
            // 
            // btThatThoat
            // 
            this.btThatThoat.Location = new System.Drawing.Point(709, 59);
            this.btThatThoat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btThatThoat.Name = "btThatThoat";
            this.btThatThoat.Size = new System.Drawing.Size(75, 34);
            this.btThatThoat.TabIndex = 9;
            this.btThatThoat.Text = "Tỉ Lệ";
            this.btThatThoat.UseVisualStyleBackColor = true;
            this.btThatThoat.Click += new System.EventHandler(this.btThatThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(792, 354);
            this.Controls.Add(this.btNet90);
            this.Controls.Add(this.btNet01);
            this.Controls.Add(this.cbMaDMA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btDHHu);
            this.Controls.Add(this.btBackup);
            this.Controls.Add(this.btTachMang);
            this.Controls.Add(this.btupdateVa);
            this.Controls.Add(this.btDoBe);
            this.Controls.Add(this.btSanLuong);
            this.Controls.Add(this.btCopyData);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.start);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btThatThoat);
            this.Controls.Add(this.btCopy);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbDatabase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbFilePMAC);
            this.Controls.Add(this.dongho);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "PMAC Status";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dongho;
        private System.Windows.Forms.Label lbFilePMAC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button btCopy;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NotifyIcon pMacStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stasusLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btCopyData;
        private System.Windows.Forms.Button btupdateVa;
        private System.Windows.Forms.Button btTachMang;
        private System.Windows.Forms.Button btSanLuong;
        private System.Windows.Forms.Button btDoBe;
        private System.Windows.Forms.Button btBackup;
        private System.Windows.Forms.Button btDHHu;
        private System.Windows.Forms.ComboBox cbMaDMA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btNet01;
        private System.Windows.Forms.Button btNet90;
        private System.Windows.Forms.Button btThatThoat;
    }
}

