using Products_flying_cargo_YU.Dto;
using Products_flying_cargo_YU.Models;
using ProductsWForm.AddFormFolder;
using ProductsWForm.Service;

namespace ProductsWForm
{
    public partial class ProductsF : Form
    {
        private readonly ApiService _apiService;
        public ProductsF()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadProductsAsync();
            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.MultiSelect = false;
            dataGridViewProducts.ReadOnly = true;
        }

        private List<ProductsDto> allProducts = new List<ProductsDto>();

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
            await LoadProductsAsync();
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                allProducts = await _apiService.GetProductsAsync();

                dataGridViewProducts.DataSource = allProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri dobavljanju proizvoda: {ex.Message}");
            }
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row!");
                return;
            }

            var selectedRow = dataGridViewProducts.SelectedRows[0];

            var product = new ProductsDto
            {
                ProductID = Convert.ToInt32(selectedRow.Cells["ProductID"].Value),
                ProductName = selectedRow.Cells["ProductName"].Value.ToString(),
                Price = Convert.ToDecimal(selectedRow.Cells["Price"].Value),
                Description = selectedRow.Cells["Description"].Value?.ToString(),
                StockQuantity = Convert.ToInt32(selectedRow.Cells["StockQuantity"].Value),
                CreatedAt = Convert.ToDateTime(selectedRow.Cells["CreatedAt"].Value),
                CategoryID = selectedRow.Cells["CategoryID"].Value != null
                    ? Convert.ToInt32(selectedRow.Cells["CategoryID"].Value)
                    : (int?)null,
                CategoryName = selectedRow.Cells["CategoryName"].Value?.ToString()
            };

            EditProduct editForm = new EditProduct(product);
            editForm.ShowDialog();

            _ = LoadProductsAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row!");
                return;
            }

            var product = (ProductsDto)dataGridViewProducts.CurrentRow.DataBoundItem;

            var confirmResult = MessageBox.Show($"Are you sure to delete {product.ProductName}?",
                                         "Confirm Delete",
                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _apiService.DeleteProductAsync(product.ProductID);
                    MessageBox.Show("Product successfully deleted!");
                    await LoadProductsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška pri brisanju proizvoda: {ex.Message}");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Trim().ToLower();

            var filtered = allProducts
                .Where(p => p.ProductName.ToLower().Contains(filterText))
                .ToList();

            dataGridViewProducts.DataSource = filtered;
        }
    }
}
