using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C__POS_System.Models;
using C__POS_System.Services;
using Guna.UI2.WinForms;

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

                List<Product> products = _productService.GetAllProducts();

                if (categoryId > 0)
                {
                    products = products.Where(p => p.CategoryID == categoryId).ToList();
                }

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
            var card = new Guna2Panel
            {
                Size = new Size(210, 330),
                BorderRadius = 14,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(220, 220, 220),
                FillColor = product.IsActive ? Color.White : Color.FromArgb(243, 243, 243),
                Tag = product
            };

            var pic = new PictureBox
            {
                Image = LoadProductImage(product.Imaage),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(10, 10),
                Size = new Size(190, 140),
                BackColor = product.IsActive ? Color.FromArgb(247, 248, 250) : Color.FromArgb(235, 235, 235)
            };
            ApplyRoundedRegion(pic, 10);

            var lblName = new Label
            {
                Text = product.Name,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = product.IsActive ? Color.FromArgb(33, 33, 33) : Color.Gray,
                Location = new Point(10, 156),
                Size = new Size(190, 34),
                AutoEllipsis = true
            };

            var lblCategory = new Label
            {
                Text = product.CategoryName,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(130, 130, 130),
                Location = new Point(10, 193),
                Size = new Size(190, 18)
            };

            var lblPrice = new Label
            {
                Text = product.Price.ToString("C"),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(46, 125, 50),
                Location = new Point(10, 214),
                Size = new Size(190, 26)
            };

            var btnEdit = new Guna2Button
            {
                Text = "Edit",
                FillColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 8,
                Location = new Point(10, 248),
                Size = new Size(190, 34),
                Tag = product
            };
            btnEdit.Click += BtnEdit_Click;

            var btnDelete = new Guna2Button
            {
                Text = product.IsActive ? "Deactivate" : "Restore",
                FillColor = product.IsActive ? Color.FromArgb(239, 83, 80) : Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 8,
                Location = new Point(10, 286),
                Size = new Size(190, 34),
                Tag = product
            };
            btnDelete.Click += BtnDelete_Click;

            card.Controls.Add(pic);
            card.Controls.Add(lblName);
            card.Controls.Add(lblCategory);
            card.Controls.Add(lblPrice);
            card.Controls.Add(btnEdit);
            card.Controls.Add(btnDelete);

            if (!product.IsActive)
            {
                var badge = new Label
                {
                    Text = "Inactive",
                    Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(158, 158, 158),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(70, 22),
                    Location = new Point(card.Width - 78, 8)
                };
                card.Controls.Add(badge);
                badge.BringToFront();
            }

            return card;
        }

        private void ApplyRoundedRegion(Control control, int radius)
        {
            using (var path = new GraphicsPath())
            {
                int d = radius * 2;
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(control.Width - d, 0, d, d, 270, 90);
                path.AddArc(control.Width - d, control.Height - d, d, d, 0, 90);
                path.AddArc(0, control.Height - d, d, d, 90, 90);
                path.CloseFigure();
                control.Region = new Region(path);
            }
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

            var placeholder = new Bitmap(190, 140);
            using (var g = Graphics.FromImage(placeholder))
            {
                g.Clear(SystemColors.Control);
                g.DrawString("No Image", new Font("Segoe UI", 9F), Brushes.Gray,
                    new RectangleF(0, 60, 190, 20),
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
            string action = product.IsActive ? "deactivate" : "reactivate";
            if (MessageBox.Show($"{action} \"{product.Name}\"?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (product.IsActive)
                    {
                        _productService.DeleteProduct(product.Id);
                    }
                    else
                    {
                        _productService.RestoreProduct(product.Id);
                    }
                    ApplyFilter();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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