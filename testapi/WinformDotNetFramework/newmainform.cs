using System.Collections.Generic;
using System.Windows.Forms;

namespace WinformDotNetFramework
{
    public partial class newmainform : Form
    {
        private MDIContainerForm mdiContainer;
        private List<Form> childForms = new List<Form>();

        public newmainform()
        {
            InitializeComponent();

            // Crea l'MDI container una sola volta nell'inizializzazione
            mdiContainer = new MDIContainerForm()
            {
                IsMdiContainer = true,
                Location = new System.Drawing.Point(this.Location.X + panel2.Location.X + 8, this.Location.Y + panel2.Location.Y + 33),
                Size = panel2.Size,
                TopMost = true,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.Manual
            };
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            // Verifica se il form mdiContainer è già visibile, se non lo è, lo mostra
            if (!mdiContainer.Visible)
            {
                mdiContainer.Show();
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Form f = new Form();
            f.Text = "Form figlio " + (childForms.Count + 1);
            f.MdiParent = mdiContainer;

            // Aggiungi un gestore per rimuovere il form dalla lista quando viene chiuso
            f.FormClosed += (s, args) => childForms.Remove(f);

            // Aggiungi il form alla lista dei form figli
            childForms.Add(f);

            f.Show();
        }

        private void newmainform_SizeChanged(object sender, System.EventArgs e)
        {
            mdiContainer.Location = new System.Drawing.Point(this.Location.X + panel2.Location.X + 8, this.Location.Y + panel2.Location.Y + 33);
            mdiContainer.Size = panel2.Size;
        }
    }



}