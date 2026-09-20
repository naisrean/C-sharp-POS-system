namespace C__POS_System.Forms
{
    partial class ShowOrders
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            ComboSeach = new Guna.UI2.WinForms.Guna2ComboBox();
            orderSearch = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // ComboSeach
            // 
            ComboSeach.BackColor = Color.Transparent;
            ComboSeach.BorderColor = Color.Green;
            ComboSeach.BorderRadius = 5;
            ComboSeach.CustomizableEdges = customizableEdges1;
            ComboSeach.DrawMode = DrawMode.OwnerDrawFixed;
            ComboSeach.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboSeach.FocusedColor = Color.FromArgb(94, 148, 255);
            ComboSeach.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ComboSeach.Font = new Font("Segoe UI", 10F);
            ComboSeach.ForeColor = Color.FromArgb(68, 88, 112);
            ComboSeach.ItemHeight = 30;
            ComboSeach.Location = new Point(598, 3);
            ComboSeach.Name = "ComboSeach";
            ComboSeach.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ComboSeach.Size = new Size(127, 36);
            ComboSeach.TabIndex = 6;
            ComboSeach.SelectedIndexChanged += ComboSeach_SelectedIndexChanged_1;
            // 
            // orderSearch
            // 
            orderSearch.BorderColor = Color.Green;
            orderSearch.BorderRadius = 5;
            orderSearch.CustomizableEdges = customizableEdges3;
            orderSearch.DefaultText = "";
            orderSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            orderSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            orderSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            orderSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            orderSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            orderSearch.Font = new Font("Segoe UI", 9F);
            orderSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            orderSearch.Location = new Point(257, 10);
            orderSearch.Margin = new Padding(3, 10, 3, 4);
            orderSearch.Name = "orderSearch";
            orderSearch.PlaceholderText = "Seaching ";
            orderSearch.SelectedText = "";
            orderSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            orderSearch.Size = new Size(335, 36);
            orderSearch.TabIndex = 5;
            orderSearch.TextChanged += this.orderSearch_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(71, 0);
            label1.Name = "label1";
            label1.Size = new Size(180, 38);
            label1.TabIndex = 4;
            label1.Text = "View orders ";
            label1.Click += this.label1_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.White;
            btnBack.BorderColor = Color.Red;
            btnBack.BorderRadius = 10;
            btnBack.CustomizableEdges = customizableEdges5;
            btnBack.DisabledState.BorderColor = Color.DarkGray;
            btnBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBack.FillColor = Color.Green;
            btnBack.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(3, 3);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnBack.Size = new Size(62, 31);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 4;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(3, 3);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 51;
            guna2DataGridView1.Size = new Size(797, 365);
            guna2DataGridView1.TabIndex = 8;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 29;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnBack);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(orderSearch);
            flowLayoutPanel1.Controls.Add(ComboSeach);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 67);
            flowLayoutPanel1.TabIndex = 9;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(guna2DataGridView1);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 67);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(800, 383);
            flowLayoutPanel2.TabIndex = 10;
            // 
            // ShowOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Name = "ShowOrders";
            Text = "ShowOrders";
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Guna.UI2.WinForms.Guna2ComboBox ComboSeach;
        private Guna.UI2.WinForms.Guna2TextBox orderSearch;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}