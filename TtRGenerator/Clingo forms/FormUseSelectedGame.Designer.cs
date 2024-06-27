namespace TtRGenerator
{
    partial class FormUseSelectedGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUseSelectedGame));
            label1 = new Label();
            dgvAllVertices = new DataGridView();
            VertexName = new DataGridViewTextBoxColumn();
            Latitude = new DataGridViewTextBoxColumn();
            Longitude = new DataGridViewTextBoxColumn();
            button1 = new Button();
            label6 = new Label();
            button2 = new Button();
            label7 = new Label();
            label8 = new Label();
            button3 = new Button();
            textBox1 = new TextBox();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAllVertices).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Gill Sans Ultra Bold Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(398, 44);
            label1.Name = "label1";
            label1.Size = new Size(256, 42);
            label1.TabIndex = 48;
            label1.Text = "Using: Game Name";
            // 
            // dgvAllVertices
            // 
            dgvAllVertices.AllowUserToAddRows = false;
            dgvAllVertices.AllowUserToDeleteRows = false;
            dgvAllVertices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllVertices.Columns.AddRange(new DataGridViewColumn[] { VertexName, Latitude, Longitude });
            dgvAllVertices.Location = new Point(12, 67);
            dgvAllVertices.Name = "dgvAllVertices";
            dgvAllVertices.ReadOnly = true;
            dgvAllVertices.RightToLeft = RightToLeft.No;
            dgvAllVertices.RowHeadersWidth = 51;
            dgvAllVertices.Size = new Size(349, 371);
            dgvAllVertices.TabIndex = 45;
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
            Latitude.FillWeight = 70F;
            Latitude.HeaderText = "Latitude";
            Latitude.MinimumWidth = 6;
            Latitude.Name = "Latitude";
            Latitude.ReadOnly = true;
            Latitude.Width = 80;
            // 
            // Longitude
            // 
            Longitude.DataPropertyName = "Longitude";
            Longitude.FillWeight = 70F;
            Longitude.HeaderText = "Longitude";
            Longitude.MinimumWidth = 6;
            Longitude.Name = "Longitude";
            Longitude.ReadOnly = true;
            Longitude.Width = 90;
            // 
            // button1
            // 
            button1.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(398, 409);
            button1.Name = "button1";
            button1.Size = new Size(322, 29);
            button1.TabIndex = 44;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(12, 44);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 37;
            label6.Text = "City list";
            // 
            // button2
            // 
            button2.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.Location = new Point(398, 103);
            button2.Name = "button2";
            button2.Size = new Size(322, 29);
            button2.TabIndex = 49;
            button2.Text = "Generate board without parameter";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label7.Location = new Point(226, 44);
            label7.Name = "label7";
            label7.Size = new Size(135, 20);
            label7.TabIndex = 50;
            label7.Text = "Number of cities: 0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label8.Location = new Point(398, 165);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 51;
            label8.Text = "Set parameter: ";
            // 
            // button3
            // 
            button3.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button3.Location = new Point(398, 208);
            button3.Name = "button3";
            button3.Size = new Size(322, 29);
            button3.TabIndex = 52;
            button3.Text = "Generate board with parameter";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(509, 161);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(133, 27);
            textBox1.TabIndex = 53;
            textBox1.Text = "5";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Gill Sans Ultra Bold Condensed", 6F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label9.Location = new Point(398, 191);
            label9.Name = "label9";
            label9.Size = new Size(250, 14);
            label9.TabIndex = 54;
            label9.Text = "The parameter determines the number of closest cities.";
            // 
            // FormUseSelectedGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label9);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(dgvAllVertices);
            Controls.Add(button1);
            Controls.Add(label6);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormUseSelectedGame";
            Text = "Using selected game";
            Load += FormUseSelectedGame_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAllVertices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvAllVertices;
        private DataGridViewTextBoxColumn VertexName;
        private DataGridViewTextBoxColumn Latitude;
        private DataGridViewTextBoxColumn Longitude;
        private Button button1;
        private Label label6;
        private Button button2;
        private Label label7;
        private Label label8;
        private Button button3;
        private TextBox textBox1;
        private Label label9;
    }
}