namespace TtRGenerator
{
    partial class FormEditGameDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditGameDetails));
            dgvAllVertices = new DataGridView();
            VertexName = new DataGridViewTextBoxColumn();
            Latitude = new DataGridViewTextBoxColumn();
            Longitude = new DataGridViewTextBoxColumn();
            VertexId = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox4 = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            button6 = new Button();
            progressBar1 = new ProgressBar();
            label9 = new Label();
            button4 = new Button();
            textBox7 = new TextBox();
            button3 = new Button();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label8 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvAllVertices).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvAllVertices
            // 
            dgvAllVertices.AllowUserToAddRows = false;
            dgvAllVertices.AllowUserToDeleteRows = false;
            dgvAllVertices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllVertices.Columns.AddRange(new DataGridViewColumn[] { VertexName, Latitude, Longitude, VertexId });
            dgvAllVertices.Location = new Point(6, 37);
            dgvAllVertices.Name = "dgvAllVertices";
            dgvAllVertices.ReadOnly = true;
            dgvAllVertices.RightToLeft = RightToLeft.No;
            dgvAllVertices.RowHeadersWidth = 51;
            dgvAllVertices.Size = new Size(179, 383);
            dgvAllVertices.TabIndex = 27;
            dgvAllVertices.CellClick += dgvAllVertices_CellClick;
            // 
            // VertexName
            // 
            VertexName.DataPropertyName = "VertexName";
            VertexName.HeaderText = "City name";
            VertexName.MinimumWidth = 6;
            VertexName.Name = "VertexName";
            VertexName.ReadOnly = true;
            VertexName.Width = 125;
            // 
            // Latitude
            // 
            Latitude.DataPropertyName = "Latitude";
            Latitude.HeaderText = "Latitude";
            Latitude.MinimumWidth = 6;
            Latitude.Name = "Latitude";
            Latitude.ReadOnly = true;
            Latitude.Visible = false;
            Latitude.Width = 125;
            // 
            // Longitude
            // 
            Longitude.DataPropertyName = "Longitude";
            Longitude.HeaderText = "Longitude";
            Longitude.MinimumWidth = 6;
            Longitude.Name = "Longitude";
            Longitude.ReadOnly = true;
            Longitude.Visible = false;
            Longitude.Width = 125;
            // 
            // VertexId
            // 
            VertexId.DataPropertyName = "VertexId";
            VertexId.HeaderText = "VertexId";
            VertexId.MinimumWidth = 6;
            VertexId.Name = "VertexId";
            VertexId.ReadOnly = true;
            VertexId.Visible = false;
            VertexId.Width = 125;
            // 
            // button1
            // 
            button1.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(601, 409);
            button1.Name = "button1";
            button1.Size = new Size(141, 29);
            button1.TabIndex = 26;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.Location = new Point(454, 409);
            button2.Name = "button2";
            button2.Size = new Size(141, 29);
            button2.TabIndex = 25;
            button2.Text = "Confirm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(6, 14);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 17;
            label3.Text = "City list";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(191, 37);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 29;
            label5.Text = "City name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(191, 90);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 30;
            label6.Text = "Latitude";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label7.Location = new Point(191, 143);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 31;
            label7.Text = "Longitude";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(191, 60);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(155, 27);
            textBox4.TabIndex = 32;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(textBox7);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(dgvAllVertices);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(388, 426);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(progressBar1);
            groupBox2.Location = new Point(191, 320);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(166, 67);
            groupBox2.TabIndex = 42;
            groupBox2.TabStop = false;
            // 
            // button6
            // 
            button6.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button6.Location = new Point(6, 17);
            button6.Name = "button6";
            button6.Size = new Size(155, 29);
            button6.TabIndex = 39;
            button6.Text = "Get data from file";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 52);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(155, 10);
            progressBar1.TabIndex = 40;
            progressBar1.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label9.Location = new Point(197, 397);
            label9.Name = "label9";
            label9.Size = new Size(135, 20);
            label9.TabIndex = 51;
            label9.Text = "Number of cities: 0";
            // 
            // button4
            // 
            button4.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button4.Location = new Point(191, 199);
            button4.Name = "button4";
            button4.Size = new Size(155, 29);
            button4.TabIndex = 36;
            button4.Text = "Delete selected city";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(191, 393);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(155, 27);
            textBox7.TabIndex = 35;
            textBox7.Text = "VertexId";
            textBox7.Visible = false;
            // 
            // button3
            // 
            button3.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button3.Location = new Point(191, 199);
            button3.Name = "button3";
            button3.Size = new Size(155, 29);
            button3.TabIndex = 34;
            button3.Text = "Add new city";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(191, 166);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(155, 27);
            textBox6.TabIndex = 34;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(191, 113);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(155, 27);
            textBox5.TabIndex = 33;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Gill Sans Ultra Bold Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label8.Location = new Point(460, 26);
            label8.Name = "label8";
            label8.Size = new Size(68, 42);
            label8.TabIndex = 35;
            label8.Text = "Edit";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(454, 95);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 27);
            textBox1.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(454, 72);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 18;
            label2.Text = "Game Name";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(485, 155);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 182);
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // FormEditGameDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label8);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormEditGameDetails";
            Text = "Edit selected game";
            Load += FormEditGameDetails_Load;
            Click += FormEditGameDetails_Click;
            ((System.ComponentModel.ISupportInitialize)dgvAllVertices).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAllVertices;
        private Button button1;
        private Button button2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox4;
        private GroupBox groupBox1;
        private Button button3;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox7;
        private Label label8;
        private Button button4;
        private DataGridViewTextBoxColumn VertexName;
        private DataGridViewTextBoxColumn Latitude;
        private DataGridViewTextBoxColumn Longitude;
        private DataGridViewTextBoxColumn VertexId;
        private Label label9;
        private TextBox textBox1;
        private Label label2;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private Button button6;
        private ProgressBar progressBar1;
    }
}