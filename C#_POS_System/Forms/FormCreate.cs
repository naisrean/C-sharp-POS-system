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
using C__POS_System.Services;
using C__POS_System.Models;

namespace C__POS_System.Forms
{
    public partial class FormCreate : Form
    {
private readonly ProductService _productService = new ProductService();
        public bool ProductAdded { get; private set; } = false;
        private string _selectedImagePath = string.Empty;
        private readonly Product? _editingProduct;
        private readonly string? _originalImagePath;

        public FormCreate() : this(null)
        {
        }

        internal FormCreate(Product? product)
        {
            InitializeComponent();
            btnBrowseImage.Click += BtnBrowseImage_Click;
            Load += FormCreate_Load;

            _editingProduct = product;
            if (_editingProduct != null)
            {
                _originalImagePath = _editingProduct.Imaage;
                label4.Text = "Update product";
                AddProduct.Text = "Update";
            }
        }

        private void FormCreate_Load(object sender, EventArgs e)
        {
            LoadCategories();

            if (_editingProduct != null)
            {
                pname.Text = _editingProduct.Name;
                pprice.Text = _editingProduct.Price.ToString();

                try
                {
                    pcategory.SelectedValue = _editingProduct.CategoryID;
                }
                catch
                {
                }

                if (!string.IsNullOrEmpty(_originalImagePath) && File.Exists(_originalImagePath))
                {
                    _selectedImagePath = _originalImagePath;
                    pictureBox1.Image = Image.FromFile(_originalImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void LoadCategories()
        {
            try
            {
                DataTable dt = DbConnection.Db.ExecuteQuery("SELECT Id, Name FROM Categories ORDER BY Name");
                pcategory.DataSource = dt;
                pcategory.DisplayMember = "Name";
                pcategory.ValueMember = "Id";
                pcategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(_selectedImagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string SaveImage(string sourcePath)
        {
            string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductImages");
            Directory.CreateDirectory(imagesDir);

            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(sourcePath);
            string destPath = Path.Combine(imagesDir, fileName);
            File.Copy(sourcePath, destPath, true);
            return destPath;
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
           
        }

        private void AddProduct_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pname.Text))
            {
                MessageBox.Show("Please enter product name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(pprice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pcategory.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

try
            {
                string categoryName = pcategory.SelectedItem is DataRowView rowView ? rowView["Name"].ToString() : string.Empty;
                int categoryId = Convert.ToInt32(pcategory.SelectedValue);

                string imagePath = _editingProduct != null ? _originalImagePath : string.Empty;
                if (!string.IsNullOrEmpty(_selectedImagePath)
                    && !string.Equals(_selectedImagePath, _originalImagePath, StringComparison.OrdinalIgnoreCase))
                {
                    imagePath = SaveImage(_selectedImagePath);
                }

                Product product = new Product
                {
                    Name = pname.Text.Trim(),
                    Price = price,
                    CategoryName = categoryName,
                    CategoryID = categoryId,
                    Imaage = imagePath
                };

                if (_editingProduct != null)
                {
                    product.Id = _editingProduct.Id;
                    _productService.UpdateProduct(product);
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _productService.AddProduct(product);
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ProductAdded = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
