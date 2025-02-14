using System.Text.Json;

namespace Winform
{
    public class BaseGridForm<T> : Form
    {
        protected DataGridView gridView;
        protected Button showButton;
        private Uri _customUri;

        public BaseGridForm(Uri uri)
        {
            _customUri = uri;
            InitializeBaseComponents();
        }

        private void InitializeBaseComponents()
        {
            // Initialize the Button
            showButton = new Button
            {
                Text = typeof(T).Name, // Use the type name directly
                Dock = DockStyle.Top,  // Button at the top
                Height = 40            // Set button height to avoid shrinking
            };

            // Attach the event handler
            showButton.Click += ShowButton_Click;

            // Initialize the DataGridView
            gridView = new DataGridView
            {
                Dock = DockStyle.Fill,  // DGV fills remaining space (bottom)
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Add controls to the form
            this.Controls.Add(gridView);  // DGV added first so it stays at bottom
            this.Controls.Add(showButton); // Button added second (on top)

            this.Text = "Base Grid Form";  // Default title for all inherited forms
        }

        // Event handler for button click
        private async void ShowButton_Click(object sender, EventArgs e)
        {

            using var client = new HttpClient();

            // Await the response asynchronously
            HttpResponseMessage response = await client.GetAsync(_customUri);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                var items = JsonSerializer.Deserialize<List<T>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Bind data to DataGridView
                gridView.DataSource = items;
            }
            else
            {
                MessageBox.Show($"Errore: {response.StatusCode}");
            }
        }
    }
}
