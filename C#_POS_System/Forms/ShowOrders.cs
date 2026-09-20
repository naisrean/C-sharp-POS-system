using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using C__POS_System.Models;
using C__POS_System.Services;

namespace C__POS_System.Forms
{
    public partial class ShowOrders : Form
    {
        private readonly OrderService _orderService = new OrderService();
        private DataTable _ordersTable = new DataTable();

        public ShowOrders()
        {
            InitializeComponent();
            ComboSeach.Items.AddRange(new object[] { "Order ID", "Date", "Product Name" });
            ComboSeach.SelectedIndex = 0;
            ComboSeach.SelectedIndexChanged += ComboSeach_SelectedIndexChanged;
            orderSearch.TextChanged += OrderSearch_TextChanged;
            Load += ShowOrders_Load;
        }

        private void ShowOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                List<Order> orders = _orderService.GetAllOrders();
                _ordersTable = new DataTable();
                _ordersTable.Columns.Add("Order ID", typeof(int));
                _ordersTable.Columns.Add("Date", typeof(DateTime));
                _ordersTable.Columns.Add("Product Name", typeof(string));
                _ordersTable.Columns.Add("Unit Price", typeof(decimal));
                _ordersTable.Columns.Add("Qty", typeof(int));
                _ordersTable.Columns.Add("Total", typeof(decimal));

                foreach (var order in orders)
                {
                    foreach (var item in _orderService.GetOrderItems(order.Id))
                    {
                        _ordersTable.Rows.Add(order.Id, order.Date, item.ProductName, item.UnitPrice, item.Qty, item.Total);
                    }
                }

                RenderOrders(_ordersTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderOrders(DataTable table)
        {
            guna2DataGridView1.DataSource = table;

            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            guna2DataGridView1.ColumnHeadersHeight = 40;
            guna2DataGridView1.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn col in guna2DataGridView1.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.Green;
                col.HeaderCell.Style.ForeColor = Color.White;
                col.HeaderCell.Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (guna2DataGridView1.Columns["Unit Price"] != null)
            {
                guna2DataGridView1.Columns["Unit Price"].DefaultCellStyle.Format = "C2";
            }
            if (guna2DataGridView1.Columns["Total"] != null)
            {
                guna2DataGridView1.Columns["Total"].DefaultCellStyle.Format = "C2";
            }
            guna2DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void ApplyFilter()
        {
            if (_ordersTable.Rows.Count == 0) return;

            string keyword = orderSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                RenderOrders(_ordersTable);
                return;
            }

            DataView view = _ordersTable.DefaultView;
            string filterColumn;
            switch (ComboSeach.SelectedItem?.ToString())
            {
                case "Date":
                    filterColumn = "Date";
                    break;
                case "Product Name":
                    filterColumn = "Product Name";
                    break;
                default:
                    filterColumn = "OrderID";
                    break;
            }

            if (filterColumn == "Date")
            {
                DateTime date;
                if (DateTime.TryParse(keyword, out date))
                {
                    view.RowFilter = "Date >= '" + date.ToString("yyyy-MM-dd") + "' AND Date < '" + date.AddDays(1).ToString("yyyy-MM-dd") + "'";
                }
            }
            else
            {
                view.RowFilter = $"[{filterColumn}] LIKE '%{keyword.Replace("'", "''")}%'";
            }

            RenderOrders(view.ToTable());
        }

        private void OrderSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ComboSeach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ComboSeach_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}