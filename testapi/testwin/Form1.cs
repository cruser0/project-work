namespace testwin
{
    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://localhost:5069/api/customer").Result;

                var responsebody = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show(responsebody);
            }
        }
    }
}