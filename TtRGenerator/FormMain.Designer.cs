namespace TtRGenerator
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            dgvAllGameNames = new DataGridView();
            GameName = new DataGridViewTextBoxColumn();
            GameDetailsId = new DataGridViewTextBoxColumn();
            ImageData = new DataGridViewTextBoxColumn();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            textBox2 = new TextBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvAllGameNames).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvAllGameNames
            // 
            dgvAllGameNames.AllowUserToAddRows = false;
            dgvAllGameNames.AllowUserToDeleteRows = false;
            dgvAllGameNames.AllowUserToResizeColumns = false;
            dgvAllGameNames.AllowUserToResizeRows = false;
            dgvAllGameNames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllGameNames.Columns.AddRange(new DataGridViewColumn[] { GameName, GameDetailsId, ImageData });
            dgvAllGameNames.Location = new Point(12, 37);
            dgvAllGameNames.MultiSelect = false;
            dgvAllGameNames.Name = "dgvAllGameNames";
            dgvAllGameNames.ReadOnly = true;
            dgvAllGameNames.RowHeadersWidth = 51;
            dgvAllGameNames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllGameNames.Size = new Size(204, 401);
            dgvAllGameNames.TabIndex = 0;
            dgvAllGameNames.CellClick += dgvAllGameNames_CellClick;
            // 
            // GameName
            // 
            GameName.DataPropertyName = "GameName";
            GameName.FillWeight = 130F;
            GameName.HeaderText = "Game Name";
            GameName.MinimumWidth = 6;
            GameName.Name = "GameName";
            GameName.ReadOnly = true;
            GameName.Width = 150;
            // 
            // GameDetailsId
            // 
            GameDetailsId.DataPropertyName = "GameDetailsId";
            GameDetailsId.HeaderText = "GameDetailsId";
            GameDetailsId.MinimumWidth = 6;
            GameDetailsId.Name = "GameDetailsId";
            GameDetailsId.ReadOnly = true;
            GameDetailsId.Visible = false;
            GameDetailsId.Width = 125;
            // 
            // ImageData
            // 
            ImageData.DataPropertyName = "ImageData";
            ImageData.HeaderText = "ImageData";
            ImageData.MinimumWidth = 6;
            ImageData.Name = "ImageData";
            ImageData.ReadOnly = true;
            ImageData.Visible = false;
            ImageData.Width = 125;
            // 
            // button1
            // 
            button1.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(608, 352);
            button1.Name = "button1";
            button1.Size = new Size(182, 29);
            button1.TabIndex = 1;
            button1.Text = "Add new game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Gill Sans Ultra Bold Condensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(62, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 2;
            label1.Text = "All games";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Gill Sans Ultra Bold Condensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(232, 139);
            label2.Name = "label2";
            label2.Size = new Size(126, 25);
            label2.TabIndex = 3;
            label2.Text = "Selected game";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Italic, GraphicsUnit.Point, 238);
            textBox1.Location = new Point(232, 167);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(182, 26);
            textBox1.TabIndex = 4;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // button2
            // 
            button2.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.Location = new Point(232, 387);
            button2.Name = "button2";
            button2.Size = new Size(182, 29);
            button2.TabIndex = 5;
            button2.Text = "Use selected game";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button3.Location = new Point(420, 387);
            button3.Name = "button3";
            button3.Size = new Size(182, 29);
            button3.TabIndex = 6;
            button3.Text = "Delete selected game";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button4.Location = new Point(608, 387);
            button4.Name = "button4";
            button4.Size = new Size(182, 29);
            button4.TabIndex = 7;
            button4.Text = "Edit selected game";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // timer1
            // 
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(420, 354);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(182, 27);
            textBox2.TabIndex = 8;
            textBox2.Text = "GameDetailsId";
            textBox2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Gill Sans Ultra Bold Condensed", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(420, 57);
            label3.Name = "label3";
            label3.Size = new Size(387, 46);
            label3.TabIndex = 9;
            label3.Text = "Ticket To Ride Generator";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(232, 199);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 182);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dgvAllGameNames);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "Ticket To Ride Generator";
            Load += FormMain_Load;
            Click += FormMain_Click;
            ((System.ComponentModel.ISupportInitialize)dgvAllGameNames).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAllGameNames;
        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private System.Windows.Forms.Timer timer1;
        private TextBox textBox2;
        private Label label3;
        private PictureBox pictureBox1;
        private DataGridViewTextBoxColumn GameName;
        private DataGridViewTextBoxColumn GameDetailsId;
        private DataGridViewTextBoxColumn ImageData;
    }
}
