using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework
{
    public partial class testChart : Form
    {
        CustomerInvoiceService _customerInvoiceService;
        CustomerInvoiceCostService _customerInvoiceCostService;

        CustomerInvoiceFilter customerInvoiceFilter = new CustomerInvoiceFilter();
        CustomerInvoiceCostFilter customerInvoiceCostFilter = new CustomerInvoiceCostFilter();

        public testChart()
        {
            _customerInvoiceService = new CustomerInvoiceService();
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            InitializeComponent();

        }



        private async void button1_Click(object sender, EventArgs e)
        {
            int output;

            if (int.TryParse(integerTextBoxUserControl1.GetText(), out output))
                customerInvoiceFilter.CustomerInvoiceSaleId = output;
            var query = await _customerInvoiceService.GetAll(customerInvoiceFilter);
            IEnumerable<CustomerInvoice> invoices = query;

            // Crea un set di ID delle fatture per una ricerca veloce
            HashSet<int> invoiceIds = new HashSet<int>(invoices.Select(i => i.CustomerInvoiceId));

            var query2 = await _customerInvoiceCostService.GetAll(customerInvoiceCostFilter);
            IEnumerable<CustomerInvoiceCost> costs = query2;

            Dictionary<int, List<CustomerInvoiceCost>> dict = new Dictionary<int, List<CustomerInvoiceCost>>();


            foreach (CustomerInvoiceCost cost in costs)
            {
                // Verifica se il cost.CustomerInvoiceId esiste tra gli ID delle fatture
                if (invoiceIds.Contains((int)cost.CustomerInvoiceId))
                {
                    if (!dict.ContainsKey((int)cost.CustomerInvoiceId))
                    {
                        dict.Add((int)cost.CustomerInvoiceId, new List<CustomerInvoiceCost>() { cost });
                    }
                    else
                    {
                        dict[((int)cost.CustomerInvoiceId)].Add(cost);
                    }
                }
            }
            CreateStackedBarChart(dict);
            return;
        }

        private void CreateStackedBarChart(Dictionary<int, List<CustomerInvoiceCost>> dict)
        {
            // Inizializza il Chart
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Aggiungi un titolo al grafico
            chart1.Titles.Clear();
            chart1.Titles.Add(new Title($"Riepilogo Costi per Fattura {integerTextBoxUserControl1.GetText()}", Docking.Top, new Font("Arial", 14, FontStyle.Bold), Color.Black));

            // Aggiungi un'area di grafico
            ChartArea chartArea = new ChartArea("MainArea");
            chart1.ChartAreas.Add(chartArea);

            // Raccogli tutti i nomi unici dai costi
            HashSet<string> allNames = new HashSet<string>();
            foreach (var invoice in dict)
            {
                foreach (var cost in invoice.Value)
                {
                    allNames.Add(cost.Name);
                }
            }

            // Crea un elenco ordinato di tutti i nomi
            List<string> orderedNames = allNames.ToList();

            // Calcola il valore massimo per dimensionare l'asse X
            double maxValue = 0;
            Dictionary<string, Dictionary<int, double>> costsByNameAndInvoice = new Dictionary<string, Dictionary<int, double>>();

            // Dizionario per tenere traccia della somma totale per ogni nome
            Dictionary<string, double> totalCostByName = new Dictionary<string, double>();

            // Prepara i dati e calcola il massimo
            foreach (var invoice in dict)
            {
                foreach (var cost in invoice.Value)
                {
                    double totalCost = (double)(cost.Cost * cost.Quantity);

                    // Aggiorna il dizionario costsByNameAndInvoice
                    if (!costsByNameAndInvoice.ContainsKey(cost.Name))
                    {
                        costsByNameAndInvoice[cost.Name] = new Dictionary<int, double>();
                        totalCostByName[cost.Name] = 0; // Inizializza la somma per questo nome
                    }

                    costsByNameAndInvoice[cost.Name][invoice.Key] = totalCost;

                    // Aggiorna la somma totale per questo nome
                    totalCostByName[cost.Name] += totalCost;

                    // Controlla se questo è il nuovo massimo
                    if (totalCost > maxValue)
                    {
                        maxValue = totalCost;
                    }
                }
            }

            // Modifica i nomi per includere la somma totale
            List<string> nameLabelsWithSum = new List<string>();
            foreach (string name in orderedNames)
            {
                double sum = totalCostByName.ContainsKey(name) ? totalCostByName[name] : 0;
                nameLabelsWithSum.Add($"{name} ({sum:0.##} €)");
            }

            // Impostazioni dell'asse Y (categorie)
            chartArea.AxisY.IsReversed = true; // Per invertire l'ordine delle barre (opzionale)
            chartArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap;
            chartArea.AxisY.Title = "Nome Costi";
            chartArea.AxisX.Interval = 1;  // Assicura che ogni etichetta venga visualizzata

            // Impostazioni dell'asse X (valori) in base al valore massimo
            chartArea.AxisX.Title = "Costo Totale";
            chartArea.AxisX.Minimum = 0;

            // Calcola l'intervallo in modo proporzionale al valore massimo
            chartArea.AxisY.Interval = Math.Ceiling(maxValue / 5 / 1000) * 1000;  // Arrotonda a migliaia

            // Se l'intervallo è troppo piccolo, imposta un minimo
            if (chartArea.AxisY.Interval < 1000)
            {
                chartArea.AxisY.Interval = 1000;
            }

            // Crea le serie per ciascun CustomerInvoiceId
            foreach (var invoice in dict)
            {
                // Creazione di una serie per ogni fattura
                var series = new Series($"Invoice {invoice.Key}")
                {
                    ChartType = SeriesChartType.StackedBar,
                    BorderWidth = 1
                };

                // Aggiungi punti per tutti i nomi (anche quelli con valore zero)
                for (int i = 0; i < orderedNames.Count; i++)
                {
                    string name = orderedNames[i];
                    string labelWithSum = nameLabelsWithSum[i];

                    double value = 0;
                    if (costsByNameAndInvoice.ContainsKey(name) &&
                        costsByNameAndInvoice[name].ContainsKey(invoice.Key))
                    {
                        value = costsByNameAndInvoice[name][invoice.Key];
                    }

                    // Usa l'etichetta con la somma
                    series.Points.AddXY(labelWithSum, value);

                    // Se il valore è zero, nascondi l'etichetta del valore
                    if (value == 0)
                    {
                        int lastIndex = series.Points.Count - 1;
                        series.Points[lastIndex].IsValueShownAsLabel = false;
                    }

                    // Imposta il tooltip con l'ID della fattura e il costo totale
                    series.Points.Last().ToolTip = $"Fattura: {invoice.Key}\nTotale: {value:0.##} €";
                }

                // Aggiungi la serie al grafico
                chart1.Series.Add(series);
            }

            // Imposta margini adeguati e spazio per le etichette
            chartArea.Position.Auto = false;
            chartArea.Position.X = 10;
            chartArea.Position.Y = 10;
            chartArea.Position.Width = 80;
            chartArea.Position.Height = 80;

            // Aumenta lo spazio per le etichette dell'asse Y per accomodare le etichette più lunghe
            chartArea.InnerPlotPosition.Auto = false;
            chartArea.InnerPlotPosition.X = 25; // Aumentato per dare più spazio alle etichette con somme
            chartArea.InnerPlotPosition.Y = 5;
            chartArea.InnerPlotPosition.Width = 65; // Ridotto per compensare l'aumento di X
            chartArea.InnerPlotPosition.Height = 85;

            // Aggiorna il grafico
            chart1.Update();
        }
    }
}
