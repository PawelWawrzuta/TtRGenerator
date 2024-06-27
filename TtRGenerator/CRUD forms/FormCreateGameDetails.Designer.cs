namespace TtRGenerator
{
    partial class FormCreateGameDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateGameDetails));
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            dgvAllVertices = new DataGridView();
            VertexName = new DataGridViewTextBoxColumn();
            Latitude = new DataGridViewTextBoxColumn();
            Longitude = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            button5 = new Button();
            button3 = new Button();
            label5 = new Label();
            label6 = new Label();
            textBox6 = new TextBox();
            textBox4 = new TextBox();
            label7 = new Label();
            textBox5 = new TextBox();
            progressBar1 = new ProgressBar();
            button6 = new Button();
            button2 = new Button();
            button4 = new Button();
            label8 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvAllVertices).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(30, 21);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 0;
            label1.Text = "Game name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(193, 27);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(30, 77);
            button1.Name = "button1";
            button1.Size = new Size(193, 29);
            button1.TabIndex = 2;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans Ultra Bold Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(463, 59);
            label2.Name = "label2";
            label2.Size = new Size(154, 27);
            label2.TabIndex = 3;
            label2.Text = "New game name";
            label2.Visible = false;
            // 
            // dgvAllVertices
            // 
            dgvAllVertices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllVertices.Columns.AddRange(new DataGridViewColumn[] { VertexName, Latitude, Longitude });
            dgvAllVertices.Location = new Point(30, 44);
            dgvAllVertices.Name = "dgvAllVertices";
            dgvAllVertices.RowHeadersWidth = 51;
            dgvAllVertices.Size = new Size(348, 389);
            dgvAllVertices.TabIndex = 4;
            dgvAllVertices.Visible = false;
            dgvAllVertices.CellClick += dgvAllVertices_CellClick;
            // 
            // VertexName
            // 
            VertexName.DataPropertyName = "VertexName";
            VertexName.HeaderText = "City name";
            VertexName.MinimumWidth = 6;
            VertexName.Name = "VertexName";
            VertexName.Width = 125;
            // 
            // Latitude
            // 
            Latitude.DataPropertyName = "Latitude";
            Latitude.FillWeight = 70F;
            Latitude.HeaderText = "Latitude";
            Latitude.MinimumWidth = 6;
            Latitude.Name = "Latitude";
            Latitude.Width = 80;
            // 
            // Longitude
            // 
            Longitude.DataPropertyName = "Longitude";
            Longitude.FillWeight = 70F;
            Longitude.HeaderText = "Longitude";
            Longitude.MinimumWidth = 6;
            Longitude.Name = "Longitude";
            Longitude.Width = 90;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Location = new Point(463, 89);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(209, 222);
            groupBox1.TabIndex = 34;
            groupBox1.TabStop = false;
            groupBox1.Visible = false;
            // 
            // button5
            // 
            button5.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button5.Location = new Point(6, 185);
            button5.Name = "button5";
            button5.Size = new Size(155, 29);
            button5.TabIndex = 35;
            button5.Text = "Delete selected city";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button3.Location = new Point(6, 185);
            button3.Name = "button3";
            button3.Size = new Size(155, 29);
            button3.TabIndex = 34;
            button3.Text = "Add new city";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(6, 23);
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
            label6.Location = new Point(6, 76);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 30;
            label6.Text = "Latitude";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(6, 152);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(155, 27);
            textBox6.TabIndex = 34;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 46);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(155, 27);
            textBox4.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label7.Location = new Point(6, 129);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 31;
            label7.Text = "Longitude";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 99);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(155, 27);
            textBox5.TabIndex = 33;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 52);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(155, 10);
            progressBar1.TabIndex = 40;
            progressBar1.Visible = false;
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
            // button2
            // 
            button2.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.Location = new Point(610, 404);
            button2.Name = "button2";
            button2.Size = new Size(141, 29);
            button2.TabIndex = 36;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button4.Location = new Point(463, 404);
            button4.Name = "button4";
            button4.Size = new Size(141, 29);
            button4.TabIndex = 35;
            button4.Text = "Confirm";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Gill Sans Ultra Bold Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label8.Location = new Point(463, 21);
            label8.Name = "label8";
            label8.Size = new Size(101, 42);
            label8.TabIndex = 37;
            label8.Text = "Create";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(206, 21);
            label3.Name = "label3";
            label3.Size = new Size(135, 20);
            label3.TabIndex = 38;
            label3.Text = "Number of cities: 0";
            label3.Visible = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(progressBar1);
            groupBox2.Location = new Point(463, 317);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(209, 67);
            groupBox2.TabIndex = 41;
            groupBox2.TabStop = false;
            groupBox2.Visible = false;
            // 
            // FormCreateGameDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(groupBox1);
            Controls.Add(dgvAllVertices);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormCreateGameDetails";
            Text = "Adding new game";
            Load += FormCreateGameDetails_Load;
            Click += FormCreateGameDetails_Click;
            ((System.ComponentModel.ISupportInitialize)dgvAllVertices).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private DataGridView dgvAllVertices;
        private GroupBox groupBox1;
        private Label label5;
        private Label label6;
        private TextBox textBox6;
        private TextBox textBox4;
        private Label label7;
        private TextBox textBox5;
        private Button button2;
        private Button button4;
        private Label label8;
        private DataGridViewTextBoxColumn VertexName;
        private DataGridViewTextBoxColumn Latitude;
        private DataGridViewTextBoxColumn Longitude;
        private Label label3;
        private Button button6;
        private ProgressBar progressBar1;
        private Button button5;
        private Button button3;
        private GroupBox groupBox2;
    }
}