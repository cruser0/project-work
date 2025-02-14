using System.Text.Json;

namespace Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string api = "http://localhost:5069/api/customer";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Eseguire la richiesta GET in modo sincrono
                HttpResponseMessage response = client.GetAsync(api).Result;

                if (response.IsSuccessStatusCode)
                {

                    // Leggere il contenuto della risposta
                    string json = response.Content.ReadAsStringAsync().Result;

                    // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                    var items = JsonSerializer.Deserialize<List<API.Models.DTO.CustomerDTOGet>>(json,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });



                    MessageBox.Show($"Successo! {items.Count} clienti trovati.");




                    zzz.Rows.Add(items);
                }
                else
                {
                    MessageBox.Show($"Errore: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eccezione: {ex.Message}");
            }
        }
    }
}
