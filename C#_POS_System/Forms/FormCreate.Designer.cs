namespace C__POS_System.Forms
{
    partial class FormCreate
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnBrowseImage = new Guna.UI2.WinForms.Guna2Button();
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pname = new Guna.UI2.WinForms.Guna2TextBox();
            pprice = new Guna.UI2.WinForms.Guna2TextBox();
            pcategory = new Guna.UI2.WinForms.Guna2ComboBox();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            AddProduct = new Guna.UI2.WinForms.Guna2Button();
            Cancel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.BorderRadius = 5;
            btnBrowseImage.CustomizableEdges = customizableEdges1;
            btnBrowseImage.DisabledState.BorderColor = Color.DarkGray;
            btnBrowseImage.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBrowseImage.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBrowseImage.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBrowseImage.FillColor = Color.CornflowerBlue;
            btnBrowseImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowseImage.ForeColor = Color.White;
            btnBrowseImage.Location = new Point(452, 290);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnBrowseImage.Size = new Size(242, 40);
            btnBrowseImage.TabIndex = 10;
            btnBrowseImage.Text = "Get Image";
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Select Product Image";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(98, 97);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Product Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Green;
            label2.Location = new Point(98, 192);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 1;
            label2.Text = "Product price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Green;
            label3.Location = new Point(98, 285);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Category\r\n";
            // 
            // pname
            // 
            pname.BorderColor = Color.Green;
            pname.BorderRadius = 5;
            pname.CustomizableEdges = customizableEdges3;
            pname.DefaultText = "";
            pname.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            pname.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            pname.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            pname.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            pname.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            pname.Font = new Font("Segoe UI", 9F);
            pname.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            pname.Location = new Point(98, 121);
            pname.Margin = new Padding(3, 4, 3, 4);
            pname.Name = "pname";
            pname.PlaceholderText = "Enter name ";
            pname.SelectedText = "";
            pname.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pname.Size = new Size(237, 39);
            pname.TabIndex = 3;
            // 
            // pprice
            // 
            pprice.BorderColor = Color.Green;
            pprice.BorderRadius = 5;
            pprice.CustomizableEdges = customizableEdges5;
            pprice.DefaultText = "";
            pprice.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            pprice.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            pprice.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            pprice.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            pprice.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            pprice.Font = new Font("Segoe UI", 9F);
            pprice.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            pprice.Location = new Point(98, 219);
            pprice.Margin = new Padding(3, 4, 3, 4);
            pprice.Name = "pprice";
            pprice.PlaceholderText = "Price";
            pprice.SelectedText = "";
            pprice.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pprice.Size = new Size(237, 39);
            pprice.TabIndex = 4;
            // 
            // pcategory
            // 
            pcategory.BackColor = Color.Transparent;
            pcategory.BorderColor = Color.Green;
            pcategory.BorderRadius = 5;
            pcategory.CustomizableEdges = customizableEdges7;
            pcategory.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            pcategory.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            pcategory.DrawMode = DrawMode.OwnerDrawFixed;
            pcategory.DropDownStyle = ComboBoxStyle.DropDownList;
            pcategory.FocusedColor = Color.FromArgb(94, 148, 255);
            pcategory.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            pcategory.Font = new Font("Segoe UI", 9F);
            pcategory.ForeColor = Color.Black;
            pcategory.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            pcategory.ItemHeight = 30;
            pcategory.Location = new Point(98, 309);
            pcategory.Margin = new Padding(3, 4, 3, 4);
            pcategory.Name = "pcategory";
            pcategory.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pcategory.Size = new Size(237, 36);
            pcategory.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Green;
            label4.Location = new Point(269, 9);
            label4.Name = "label4";
            label4.Size = new Size(244, 38);
            label4.TabIndex = 6;
            label4.Text = "Add new product";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(452, 97);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(242, 187);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // AddProduct
            // 
            AddProduct.BorderRadius = 5;
            AddProduct.CustomizableEdges = customizableEdges9;
            AddProduct.DisabledState.BorderColor = Color.DarkGray;
            AddProduct.DisabledState.CustomBorderColor = Color.DarkGray;
            AddProduct.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddProduct.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddProduct.FillColor = Color.Green;
            AddProduct.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddProduct.ForeColor = Color.White;
            AddProduct.Location = new Point(592, 355);
            AddProduct.Name = "AddProduct";
            AddProduct.ShadowDecoration.CustomizableEdges = customizableEdges10;
            AddProduct.Size = new Size(102, 47);
            AddProduct.TabIndex = 8;
            AddProduct.Text = "Add new ";
            AddProduct.Click += AddProduct_Click_1;
            // 
            // Cancel
            // 
            Cancel.BorderRadius = 5;
            Cancel.CustomizableEdges = customizableEdges11;
            Cancel.DisabledState.BorderColor = Color.DarkGray;
            Cancel.DisabledState.CustomBorderColor = Color.DarkGray;
            Cancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Cancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Cancel.FillColor = Color.Red;
            Cancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Cancel.ForeColor = Color.White;
            Cancel.Location = new Point(452, 355);
            Cancel.Name = "Cancel";
            Cancel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            Cancel.Size = new Size(102, 47);
            Cancel.TabIndex = 9;
            Cancel.Text = "Cancel";
            Cancel.Click += guna2Button2_Click;
            // 
            // FormCreate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 504);
            Controls.Add(Cancel);
            Controls.Add(AddProduct);
            Controls.Add(btnBrowseImage);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(pcategory);
            Controls.Add(pprice);
            Controls.Add(pname);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormCreate";
            Text = "FormCreate";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox pname;
        private Guna.UI2.WinForms.Guna2TextBox pprice;
        private Guna.UI2.WinForms.Guna2ComboBox pcategory;
        private Label label4;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button AddProduct;
        private Guna.UI2.WinForms.Guna2Button Cancel;
        private Guna.UI2.WinForms.Guna2Button btnBrowseImage;
        private OpenFileDialog openFileDialog1;
    }
}