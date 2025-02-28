namespace Winform
{
    public partial class mainformtest : Form
    {
        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
        public mainformtest()
        {
            InitializeComponent();
            SetupStrip();
            IsMdiContainer = true; // Set the MDI container
            WindowState = FormWindowState.Maximized;


        }

        private void SetupStrip()
        {
            // Crea un FlowLayoutPanel

            flowLayoutPanel.Dock = DockStyle.Fill; // Imposta per riempire il contenitore
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight; // Disposizione orizzontale
            flowLayoutPanel.WrapContents = false; // Non fare il wrapping su più righe

            // Crea il primo gruppo di 2 bottoni
            FlowLayoutPanel group1 = new FlowLayoutPanel();
            group1.FlowDirection = FlowDirection.TopDown; // Colonna verticale
            group1.Width = 100; // Imposta una larghezza fissa per il gruppo
            group1.Controls.Add(new Button() { Text = "Btn 1" });
            group1.Controls.Add(new Button() { Text = "Btn 2" });

            // Crea il bottone grosso
            Button largeButton = new Button()
            {
                Text = "Big Btn",
                Width = 100,   // Imposta la larghezza del bottone grande
                Height = 80    // Imposta l'altezza maggiore
            };

            // Crea il secondo gruppo di 2 bottoni
            FlowLayoutPanel group2 = new FlowLayoutPanel();
            group2.FlowDirection = FlowDirection.TopDown; // Colonna verticale
            group2.Width = 100;
            group2.Controls.Add(new Button() { Text = "Btn 3" });
            group2.Controls.Add(new Button() { Text = "Btn 4" });

            // Aggiungi i gruppi e il bottone grande al FlowLayoutPanel principale
            flowLayoutPanel.Controls.Add(group1);
            flowLayoutPanel.Controls.Add(largeButton);
            flowLayoutPanel.Controls.Add(group2);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fotmtest1 form = new fotmtest1();
            form.MdiParent = this;
            panel1.Controls.Add(form);
            form.Show();

            TabPage tabPage = new TabPage("My Tab");

            // Aggiungi il FlowLayoutPanel alla TabPage
            tabPage.Controls.Add(flowLayoutPanel);

            // Aggiungi la TabPage al TabControl
            tabControl1.TabPages.Add(tabPage);
        }
    }
}
