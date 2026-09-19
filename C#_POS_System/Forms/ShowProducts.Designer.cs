namespace C__POS_System.Forms
{
    partial class ShowProducts
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            btnAddNew = new Guna.UI2.WinForms.Guna2Button();
            pSearch = new Guna.UI2.WinForms.Guna2TextBox();
            ComboSeach = new Guna.UI2.WinForms.Guna2ComboBox();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            flowLayoutProducts = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(101, 24);
            label1.Name = "label1";
            label1.Size = new Size(210, 31);
            label1.TabIndex = 0;
            label1.Text = "Show All Products";
            // 
            // btnAddNew
            // 
            btnAddNew.BorderRadius = 5;
            btnAddNew.CustomizableEdges = customizableEdges1;
            btnAddNew.DisabledState.BorderColor = Color.DarkGray;
            btnAddNew.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddNew.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddNew.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddNew.FillColor = Color.Green;
            btnAddNew.Font = new Font("Segoe UI", 9F);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Location = new Point(760, 11);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddNew.Size = new Size(111, 43);
            btnAddNew.TabIndex = 1;
            btnAddNew.Text = "+ Add new ";
            btnAddNew.Click += btnAddNew_Click;
            // 
            // pSearch
            // 
            pSearch.BorderColor = Color.Green;
            pSearch.BorderRadius = 5;
            pSearch.CustomizableEdges = customizableEdges3;
            pSearch.DefaultText = "";
            pSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            pSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            pSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            pSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            pSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            pSearch.Font = new Font("Segoe UI", 9F);
            pSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            pSearch.Location = new Point(337, 17);
            pSearch.Margin = new Padding(3, 4, 3, 4);
            pSearch.Name = "pSearch";
            pSearch.PlaceholderText = "Searching";
            pSearch.SelectedText = "";
            pSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pSearch.Size = new Size(243, 36);
            pSearch.TabIndex = 2;
            // 
            // ComboSeach
            // 
            ComboSeach.BackColor = Color.Transparent;
            ComboSeach.BorderColor = Color.Green;
            ComboSeach.BorderRadius = 5;
            ComboSeach.CustomizableEdges = customizableEdges5;
            ComboSeach.DrawMode = DrawMode.OwnerDrawFixed;
            ComboSeach.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboSeach.FocusedColor = Color.FromArgb(94, 148, 255);
            ComboSeach.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ComboSeach.Font = new Font("Segoe UI", 10F);
            ComboSeach.ForeColor = Color.FromArgb(68, 88, 112);
            ComboSeach.ItemHeight = 30;
            ComboSeach.Location = new Point(586, 17);
            ComboSeach.Name = "ComboSeach";
            ComboSeach.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ComboSeach.Size = new Size(168, 36);
            ComboSeach.TabIndex = 3;
            ComboSeach.SelectedIndexChanged += ComboSeach_SelectedIndexChanged;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.White;
            btnBack.BorderColor = Color.Red;
            btnBack.BorderRadius = 10;
            btnBack.CustomizableEdges = customizableEdges7;
            btnBack.DisabledState.BorderColor = Color.DarkGray;
            btnBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBack.FillColor = Color.Green;
            btnBack.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(12, 3);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnBack.Size = new Size(62, 31);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // flowLayoutProducts
            // 
            flowLayoutProducts.AutoScroll = true;
            flowLayoutProducts.Location = new Point(12, 80);
            flowLayoutProducts.Name = "flowLayoutProducts";
            flowLayoutProducts.Size = new Size(860, 360);
            flowLayoutProducts.TabIndex = 5;
            // 
            // ShowProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 450);
            Controls.Add(flowLayoutProducts);
            Controls.Add(btnBack);
            Controls.Add(ComboSeach);
            Controls.Add(pSearch);
            Controls.Add(btnAddNew);
            Controls.Add(label1);
            Name = "ShowProducts";
            Text = "ShowProducts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnAddNew;
        private Guna.UI2.WinForms.Guna2TextBox pSearch;
        private Guna.UI2.WinForms.Guna2ComboBox ComboSeach;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private FlowLayoutPanel flowLayoutProducts;
    }
}