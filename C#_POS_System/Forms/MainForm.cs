using C__POS_System.Forms;
using C__POS_System.Models;
using C__POS_System.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace C__POS_System
{
    public partial class MainForm : Form
    {
        private readonly ProductService _productService = new ProductService();
        private readonly OrderService _orderService = new OrderService();
        private List<OrderItem> _currentOrderItems = new List<OrderItem>();

        public MainForm()
        {
            InitializeComponent();
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnOrder.Click += BtnOrder_Click;
            //CancelO.Click += CancelOrder_Click;
            btnFood.Click += (s, e) => LoadProductsByCategory(1);
            btnCoffee.Click += (s, e) => LoadProductsByCategory(2);

            if (btnAll != null)
            {
                btnAll.Click += btnAll_Click;
            }
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProducts("All");
        }

        private void LoadProducts(string filter)
        {
            try
            {
                List<Product> products;
                if (filter == "All")
                    products = _productService.GetAllProducts();
                else
                    products = _productService.SearchProducts(filter);

                flowLayoutPanel4.Controls.Clear();

                foreach (var product in products)
                {
                    flowLayoutPanel4.Controls.Add(CreateProductCard(product));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductsByCategory(int categoryId)
        {
            try
            {
                var products = _productService.GetProductsByCategory(categoryId);
                flowLayoutPanel4.Controls.Clear();

                foreach (var product in products)
                {
                    flowLayoutPanel4.Controls.Add(CreateProductCard(product));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Control CreateProductCard(Product product)
        {
            var card = new Panel
            {
                Size = new Size(335, 250),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Margin = new Padding(6),
                Tag = product
            };

            var pic = new PictureBox
            {
                Tag = product,
                Image = LoadProductImage(product.Imaage),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(10, 10),
                Size = new Size(315, 150),
                BackColor = Color.Transparent
            };

            var lblName = new Label
            {
                Tag = product,
                Text = product.Name,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Location = new Point(10, 170),
                Size = new Size(315, 32),
                AutoEllipsis = true
            };

            var lblPrice = new Label
            {
                Tag = product,
                Text = product.Price.ToString("C"),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Green,
                Location = new Point(10, 208),
                Size = new Size(315, 30)
            };

            card.Controls.Add(pic);
            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);

            foreach (Control c in new Control[] { card, pic, lblName, lblPrice })
            {
                c.Click += ProductButton_Click;
                c.Cursor = Cursors.Hand;
            }

            return card;
        }

        private Image LoadProductImage(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    return Image.FromFile(imagePath);
                }
            }
            catch { }

            var placeholder = new Bitmap(315, 150);
            using (var g = Graphics.FromImage(placeholder))
            {
                g.Clear(SystemColors.Control);
                g.DrawString("No Image", new Font("Segoe UI", 9F), Brushes.Gray,
                    new RectangleF(0, 60, 315, 20),
                    new StringFormat { Alignment = StringAlignment.Center });
            }
            return placeholder;
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var product = (Product)ctrl.Tag;

            var existing = _currentOrderItems.FirstOrDefault(i => i.ProductId == product.Id);
            if (existing != null)
            {
                existing.Qty++;
            }
            else
            {
                _currentOrderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Qty = 1
                });
            }

            RefreshOrderGrid();
        }

        private void RefreshOrderGrid()
        {
            cartPanel.Controls.Clear();
            decimal total = 0;

            foreach (var item in _currentOrderItems)
            {
                cartPanel.Controls.Add(CreateOrderItemCard(item));
                total += item.Total;
            }

            materialLabel1.Text = $"Total : {total:C}";
        }
        // Design Current Order 
        private Control CreateOrderItemCard(OrderItem item)
        {
            var card = new Panel
            {
                Size = new Size(330, 65),
                //BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(3, 3, 3, 3),
                Tag = item
            };

            var lblName = new Label
            {
                Text = item.ProductName,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(8, 8),
                Size = new Size(200, 20),
                AutoEllipsis = true
            };

            var btnRemove = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "X",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                FillColor = Color.FromArgb(253, 237, 237),
                ForeColor = Color.FromArgb(211, 47, 47),
                BorderRadius = 5,
                Location = new Point(288, 2),
                Size = new Size(31, 31),
                Tag = item
            };
            btnRemove.Click += BtnRemove_Click;

            var lblUnit = new Label
            {
                Text = item.UnitPrice.ToString("C"),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(8, 34),
                Size = new Size(100, 16)
            };

            var btnMinus = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "-",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                FillColor = Color.FromArgb(227, 242, 253),
                ForeColor = Color.FromArgb(25, 118, 210),
                BorderRadius = 5,
                Location = new Point(120, 28),
                Size = new Size(31, 31),
                Tag = item
            };
            btnMinus.Click += BtnMinus_Click;

            var lblQty = new Label
            {
                Text = item.Qty.ToString(),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(150, 28),
                Size = new Size(32, 28)
            };

            var btnPlus = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "+",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FillColor = Color.FromArgb(232, 245, 233),
                ForeColor = Color.FromArgb(46, 125, 50),
                BorderRadius = 5,
                Location = new Point(184, 28),
                Size = new Size(31, 31),
                Tag = item
            };
            btnPlus.Click += BtnPlus_Click;

            var lblTotal = new Label
            {
                Text = item.Total.ToString("C"),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.Green,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(216, 28),
                Size = new Size(96, 28)
            };

            card.Controls.Add(lblName);
            card.Controls.Add(btnRemove);
            card.Controls.Add(lblUnit);
            card.Controls.Add(btnMinus);
            card.Controls.Add(lblQty);
            card.Controls.Add(btnPlus);
            card.Controls.Add(lblTotal);
            return card;
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            var item = (OrderItem)((Guna.UI2.WinForms.Guna2Button)sender).Tag;
            item.Qty--;
            if (item.Qty <= 0)
            {
                _currentOrderItems.Remove(item);
            }
            RefreshOrderGrid();
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            var item = (OrderItem)((Guna.UI2.WinForms.Guna2Button)sender).Tag;
            item.Qty++;
            RefreshOrderGrid();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var item = (OrderItem)((Guna.UI2.WinForms.Guna2Button)sender).Tag;
            _currentOrderItems.Remove(item);
            RefreshOrderGrid();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                LoadProducts("All");
            else
                LoadProducts(txtSearch.Text.Trim());
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            if (_currentOrderItems.Count == 0)
            {
                MessageBox.Show("No items in the order.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                decimal total = _currentOrderItems.Sum(i => i.Total);
                Order order = new Order
                {
                    Date = DateTime.Now,
                    Total = total,
                    Items = _currentOrderItems
                };

                int orderId = _orderService.AddOrder(order);
                MessageBox.Show($"Order #{orderId} placed successfully!\nTotal: {total:C}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _currentOrderItems.Clear();
                RefreshOrderGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelOrder_Click(object sender, EventArgs e)
        {
            _currentOrderItems.Clear();
            RefreshOrderGrid();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadProducts("All");
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ShowProducts showProduct = new ShowProducts();
            showProduct.ShowDialog();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
