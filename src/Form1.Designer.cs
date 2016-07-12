namespace gCrop
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.r169 = new System.Windows.Forms.RadioButton();
            this.r32 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tbrCustom = new System.Windows.Forms.TextBox();
            this.tbRes = new System.Windows.Forms.TextBox();
            this.lbSaveHeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rCustom = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(40, 40);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1280, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // r169
            // 
            this.r169.AutoSize = true;
            this.r169.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.r169.Location = new System.Drawing.Point(60, 2);
            this.r169.Name = "r169";
            this.r169.Size = new System.Drawing.Size(59, 25);
            this.r169.TabIndex = 1;
            this.r169.Text = "16:9";
            this.r169.UseVisualStyleBackColor = true;
            this.r169.CheckedChanged += new System.EventHandler(this.rRation_CheckedChanged);
            // 
            // r32
            // 
            this.r32.AutoSize = true;
            this.r32.Checked = true;
            this.r32.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.r32.Location = new System.Drawing.Point(120, 2);
            this.r32.Name = "r32";
            this.r32.Size = new System.Drawing.Size(50, 25);
            this.r32.TabIndex = 2;
            this.r32.TabStop = true;
            this.r32.Text = "3:2";
            this.r32.UseVisualStyleBackColor = true;
            this.r32.CheckedChanged += new System.EventHandler(this.rRation_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbrCustom);
            this.panel1.Controls.Add(this.tbRes);
            this.panel1.Controls.Add(this.lbSaveHeight);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rCustom);
            this.panel1.Controls.Add(this.r32);
            this.panel1.Controls.Add(this.r169);
            this.panel1.Location = new System.Drawing.Point(40, 546);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 40);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(540, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbrCustom
            // 
            this.tbrCustom.Enabled = false;
            this.tbrCustom.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbrCustom.Location = new System.Drawing.Point(199, 1);
            this.tbrCustom.Margin = new System.Windows.Forms.Padding(0);
            this.tbrCustom.MaximumSize = new System.Drawing.Size(100, 25);
            this.tbrCustom.Name = "tbrCustom";
            this.tbrCustom.Size = new System.Drawing.Size(50, 25);
            this.tbrCustom.TabIndex = 4;
            this.tbrCustom.Text = "1.0";
            this.tbrCustom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbrCustom.TextChanged += new System.EventHandler(this.rRation_CheckedChanged);
            // 
            // tbRes
            // 
            this.tbRes.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRes.Location = new System.Drawing.Point(360, 0);
            this.tbRes.Margin = new System.Windows.Forms.Padding(0);
            this.tbRes.MaximumSize = new System.Drawing.Size(100, 25);
            this.tbRes.Name = "tbRes";
            this.tbRes.Size = new System.Drawing.Size(50, 25);
            this.tbRes.TabIndex = 4;
            this.tbRes.Text = "2880";
            this.tbRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbRes.TextChanged += new System.EventHandler(this.tbSaveWidth_TextChanged);
            // 
            // lbSaveHeight
            // 
            this.lbSaveHeight.AutoSize = true;
            this.lbSaveHeight.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSaveHeight.Location = new System.Drawing.Point(420, 2);
            this.lbSaveHeight.Name = "lbSaveHeight";
            this.lbSaveHeight.Size = new System.Drawing.Size(59, 21);
            this.lbSaveHeight.TabIndex = 3;
            this.lbSaveHeight.Text = "x 1920";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(300, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Res";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ratio";
            // 
            // rCustom
            // 
            this.rCustom.AutoSize = true;
            this.rCustom.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rCustom.Location = new System.Drawing.Point(180, 2);
            this.rCustom.Name = "rCustom";
            this.rCustom.Size = new System.Drawing.Size(33, 25);
            this.rCustom.TabIndex = 2;
            this.rCustom.Text = " ";
            this.rCustom.UseVisualStyleBackColor = true;
            this.rCustom.CheckedChanged += new System.EventHandler(this.rRation_CheckedChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.RadioButton r169;
		private System.Windows.Forms.RadioButton r32;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbRes;
		private System.Windows.Forms.Label lbSaveHeight;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rCustom;
        private System.Windows.Forms.TextBox tbrCustom;
    }
}

