namespace TtRGenerator
{
    partial class FormDeleteGameDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeleteGameDetails));
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            radioButton1 = new RadioButton();
            button2 = new Button();
            button1 = new Button();
            dgvAllVertices = new DataGridView();
            VertexName = new DataGridViewTextBoxColumn();
            Latitude = new DataGridViewTextBoxColumn();
            Longitude = new DataGridViewTextBoxColumn();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAllVertices).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(12, 44);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 6;
            label3.Text = "City list";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Gill Sans Ultra Bold Condensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(398, 98);
            label2.Name = "label2";
            label2.Size = new Size(131, 31);
            label2.TabIndex = 7;
            label2.Text = "Game Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(398, 271);
            label5.Name = "label5";
            label5.Size = new Size(322, 20);
            label5.TabIndex = 12;
            label5.Text = "Are you sure you want to delete selected game?";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Transparent;
            radioButton1.Location = new Point(398, 294);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(122, 24);
            radioButton1.TabIndex = 13;
            radioButton1.Text = "Yes, I am sure!";
            radioButton1.UseVisualStyleBackColor = false;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.Location = new Point(398, 324);
            button2.Name = "button2";
            button2.Size = new Size(182, 29);
            button2.TabIndex = 14;
            button2.Text = "Confirm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Gill Sans Ultra Bold Condensed", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(398, 409);
            button1.Name = "button1";
            button1.Size = new Size(322, 29);
            button1.TabIndex = 15;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            dgvAllVertices.TabIndex = 16;
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
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Gill Sans Ultra Bold Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label8.Location = new Point(398, 44);
            label8.Name = "label8";
            label8.Size = new Size(97, 42);
            label8.TabIndex = 36;
            label8.Text = "Delete";
            // 
            // FormDeleteGameDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(dgvAllVertices);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(radioButton1);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormDeleteGameDetails";
            Text = "Deleting selected game";
            Load += FormDeleteGameDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAllVertices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label2;
        private Label label5;
        private RadioButton radioButton1;
        private Button button2;
        private Button button1;
        private DataGridView dgvAllVertices;
        private DataGridViewTextBoxColumn VertexName;
        private DataGridViewTextBoxColumn Latitude;
        private DataGridViewTextBoxColumn Longitude;
        private Label label8;
    }
}