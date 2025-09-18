using Products_flying_cargo_YU.Dto;
using ProductsWForm.Service;

namespace ProductsWForm.AddFormFolder
{
    public partial class AddProduct : Form
    {
        private readonly ApiService _apiService;
        public AddProduct()
        {
            InitializeComponent();
            _apiService = new ApiService();
            this.Load += AddProduct_Load;
        }

        private List<CategoryDto> allCategories = new List<CategoryDto>();

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedValue is not int categoryId)
                {
                    MessageBox.Show("Please select a category!");
                    return;
                }

                var newProduct = new ProductsDto
                {
                    ProductName = txtProductName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Description = txtDescription.Text,
                    StockQuantity = int.Parse(txtStockQtt.Text),
                    CreatedAt = DateTime.Now
                };

                await _apiService.AddProductAsync(categoryId, newProduct);
                MessageBox.Show("Product successfully added!");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom dodavanja proizvoda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void AddProduct_Load(object sender, EventArgs e)
        {
            try
            {
                allCategories = await _apiService.GetCategoriesAsync();

                cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;

                cmbCategory.DataSource = allCategories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";

                var autoComplete = new AutoCompleteStringCollection();
                autoComplete.AddRange(allCategories.Select(c => c.CategoryName).ToArray());

                cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbCategory.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri učitavanju kategorija: {ex.Message}");
            }
        }

    }
}
