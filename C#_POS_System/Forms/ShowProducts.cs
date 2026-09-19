using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C__POS_System.Models;
using C__POS_System.Services;

namespace C__POS_System.Forms
{
    public partial class ShowProducts : Form
    {
        private readonly ProductService _productService = new ProductService();

        public ShowProducts()
        {
            InitializeComponent();
            pSearch.TextChanged += PSearch_TextChanged;
            ComboSeach.SelectedIndexChanged += ComboSeach_SelectedIndexChanged;
            Load += ShowProducts_Load;
        }

        private void ShowProducts_Load(object sender, EventArgs e)
        {
            LoadCategories();
            ApplyFilter();
        }

        private void LoadCategories()
        {
            try
            {
                DataTable dt = DbConnection.Db.ExecuteQuery("SELECT Id, Name FROM Categories ORDER BY Name");
                DataRow allRow = dt.NewRow();
                allRow["Id"] = 0;
                allRow["Name"] = "All Categories";
                dt.Rows.InsertAt(allRow, 0);

                ComboSeach.DataSource = dt;
                ComboSeach.DisplayMember = "Name";
                ComboSeach.ValueMember = "Id";
                ComboSeach.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void Guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void ApplyFilter()
        {
            try
            {
                int categoryId = 0;

                if (ComboSeach.SelectedValue != null && !(ComboSeach.SelectedValue is DataRowView))
                {
                    categoryId = Convert.ToInt32(ComboSeach.SelectedValue);
                }

                string keyword = pSearch.Text.Trim();

                List<Product> products = categoryId > 0
                    ? _productService.GetProductsByCategory(categoryId)
                    : _productService.GetAllProducts();

                if (!string.IsNullOrEmpty(keyword))
                {
                    products = products.Where(p => p.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }

                RenderProducts(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderProducts(List<Product> products)
        {
            flowLayoutProducts.Controls.Clear();
            foreach (var product in products)
            {
                flowLayoutProducts.Controls.Add(CreateProductCard(product));
            }
        }

        /// create cart with design 
        private Control CreateProductCard(Product product)
        {
            var card = new Panel
            {
                Size = new Size(170, 225),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Tag = product
            };

            var pic = new PictureBox
            {
                Image = LoadProductImage(product.Imaage),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(5, 5),
                Size = new Size(158, 110),
                BackColor = Color.Transparent
            };

            var lblName = new Label
            {
                Text = product.Name,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Location = new Point(5, 117),
                Size = new Size(158, 22),
                AutoEllipsis = true
            };

            var lblPrice = new Label
            {
                Text = product.Price.ToString("C"),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Green,
                Location = new Point(5, 143),
                Size = new Size(158, 22)
            };

            var btnEdit = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Edit",
                FillColor = Color.CornflowerBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                BorderRadius = 5,
                Location = new Point(5, 175),
                Size = new Size(74, 36),
                Tag = product
            };
            btnEdit.Click += BtnEdit_Click;

            var btnDelete = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Delete",
                FillColor = Color.Red,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                BorderRadius = 5,
                Location = new Point(89, 175),
                Size = new Size(74, 36),
                Tag = product
            };
            btnDelete.Click += BtnDelete_Click;

            card.Controls.Add(pic);
            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);
            card.Controls.Add(btnEdit);
            card.Controls.Add(btnDelete);
            return card;
        }

        private Image LoadProductImage(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    return Image.FromFile(imagePath);
                }
            }
            catch
            {
            }

            var placeholder = new Bitmap(158, 110);
            using (var g = Graphics.FromImage(placeholder))
            {
                g.Clear(SystemColors.Control);
                g.DrawString("No Image", new Font("Segoe UI", 9F), Brushes.Gray,
                    new RectangleF(0, 45, 158, 20),
                    new StringFormat { Alignment = StringAlignment.Center });
            }
            return placeholder;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var product = (Product)((Guna.UI2.WinForms.Guna2Button)sender).Tag;
            FormCreate create = new FormCreate(product);
            create.ShowDialog();
            if (create.ProductAdded)
            {
                ApplyFilter();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var product = (Product)((Guna.UI2.WinForms.Guna2Button)sender).Tag;
            if (MessageBox.Show($"Delete \"{product.Name}\"?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _productService.DeleteProduct(product.Id);
                    ApplyFilter();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormCreate create = new FormCreate();
            create.ShowDialog();
            if (create.ProductAdded)
            {
                ApplyFilter();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboSeach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}