using Products_flying_cargo_YU.Dto;
using Products_flying_cargo_YU.Models;
using ProductsWForm.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsWForm
{
    public partial class EditProduct : Form
    {
        private readonly ProductsDto _product;
        private readonly ApiService _apiService;

        public EditProduct(ProductsDto product)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _product = product;

            txtProductName.Text = _product.ProductName;
            txtPrice.Text = _product.Price.ToString();
            txtDescription.Text = _product.Description;
            txtStockQtt.Text = _product.StockQuantity.ToString();

            LoadCategoriesAsync();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _product.ProductName = txtProductName.Text;
                _product.Price = decimal.Parse(txtPrice.Text);
                _product.Description = txtDescription.Text;
                _product.StockQuantity = int.Parse(txtStockQtt.Text);
                int selectedCategoryId = (int)cmbCategory.SelectedValue;

                var apiService = new ApiService();
                await _apiService.UpdateProductAsync(_product.ProductID, _product, selectedCategoryId);

                MessageBox.Show("Proizvod je uspešno izmenjen!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom izmene proizvoda: {ex.Message}");
            }
        }

        private async void LoadCategoriesAsync()
        {
            try
            {
                var categories = await _apiService.GetCategoriesAsync();

                cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;

                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";

                var autoComplete = new AutoCompleteStringCollection();
                autoComplete.AddRange(categories.Select(c => c.CategoryName).ToArray());

                cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbCategory.AutoCompleteCustomSource = autoComplete;

                if (_product.CategoryID.HasValue)
                {
                    cmbCategory.SelectedValue = _product.CategoryID.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri učitavanju kategorija: {ex.Message}");
            }
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
