using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Assistente.Extracao;
using Atlassian.Jira;

namespace Assistente
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        public Jira jira;
        private void FormPrincipal_Load(object sender, EventArgs e)
         {
            Autenticacao Auth = new Autenticacao();
            jira = Auth.GetInstanciaJira();
            Projetos Projetos = new Projetos();
            var x = Projetos.GetProjetos(jira);
            cbxProjeto.Items.AddRange(x.ToArray());
        }
        private async Task GetIssueAsync()
        {
            string UserName = "paula.calefi@getninjas.com.br";
            string Senha = "jEZkla9Ecla4fQEJyNeuFBC3";
            string Servico = "https://gogogoninjas.atlassian.net/";
            //var jira = Jira.CreateRestClient(Servico, UserName, Senha);
            Jira jira;
            jira = Jira.CreateRestClient("https://gogogoninjas.atlassian.net/", UserName, Senha);
            // use LINQ syntax to retrieve issues
            var ag = jira.Projects.GetProjectAsync("AG");

            var issues = from it in jira.Issues.Queryable
                         where it.Project == "Agile" && it.ResolutionDate <= Convert.ToDateTime("2020-04-23")
                         orderby it.Created
                         select it;
            var item = issues.First();
            var array = issues.ToList();
            var worklog = item.GetWorklogsAsync();
            var teste = worklog.Result;
            var log  = item.GetChangeLogsAsync();
            var issuer = await jira.Issues.GetIssueAsync("AG-25");



            // add a worklog
            //await issuer.AddWorklogAsync("1h");

            // add worklog with new remaining estimate
            //await issuer.AddWorklogAsync("1m", WorklogStrategy.NewRemainingEstimate, "4h");

            // retrieve worklogs
            var worklogs = await issuer.GetWorklogsAsync();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Project projetoSelecionado = (Project)cbxProjeto.SelectedItem;
            CancellationToken token = new CancellationToken();
            string jql = "project = " + projetoSelecionado.Key;
            IEnumerable<Issue> jiraIssues = jira.Issues.GetIssuesFromJqlAsync(jql, 50, 0, token).Result;
            Dictionary<string, int> distribuicao = new Dictionary<string, int>();
            Dictionary<int, int> Modas = new Dictionary<int, int>();
           
            int Somatorio = 0;

            foreach (var issue in jiraIssues)
            {
                if (issue.ResolutionDate != null)
                {
                    DateTime DataInicio = Convert.ToDateTime(issue.Created);
                    DateTime DataFim = Convert.ToDateTime(issue.ResolutionDate);
                    int dias = (int)DataFim.Subtract(DataInicio).TotalDays;
                    distribuicao.Add(issue.Key.ToString(), dias);
                    Somatorio += dias;
                    if (!Modas.ContainsKey(dias))
                    {
                        Modas.Add(dias, 1);
                    }
                    else
                    {
                        var x = Modas[dias];
                        Modas.Remove(dias);
                        Modas.Add(dias, x + 1);
                    }
                }
            }
            double valorPercentil = rb95.Checked ? 0.95 : rb80.Checked ? 0.8 : rb70.Checked ? 0.7 : 0.5;
            var media = Somatorio / distribuicao.Count;
            var moda = Modas.FirstOrDefault(x => x.Value == Modas.Values.Max()).Key;
            var percentil = CalculaPercentil(distribuicao.Values.ToArray(), valorPercentil);
            PreparaChart(distribuicao, media, moda, percentil, valorPercentil);
            
        }
        public double CalculaPercentil(int[] sequence, double percentil)
        {
            Array.Sort(sequence);
            int N = sequence.Length;
            double n = (N - 1) * percentil + 1;
            // Another method: double n = (N + 1) * excelPercentile;
            if (n == 1d) return sequence[0];
            else if (n == N) return sequence[N - 1];
            else
            {
                int k = (int)n;
                double d = n - k;
                return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            }
        }

        public void PreparaChart(Dictionary<string, int> distribuicao, int media, int moda, double percentil, double valorPercentil)
        {
            this.LeadTimeChart.Series.Clear();
            this.LeadTimeChart.Titles.Add("Histograma");
            this.LeadTimeChart.BackHatchStyle = ChartHatchStyle.None;
            Series leadtimeSerie = this.LeadTimeChart.Series.Add("LeadTime");
            leadtimeSerie.ChartType = SeriesChartType.Column;

            Series mediaSerie = this.LeadTimeChart.Series.Add("Media: " +media);
            mediaSerie.ChartType = SeriesChartType.Line;
            mediaSerie.Color = Color.Red;
            mediaSerie.BorderWidth = 3;

            Series modaSerie = this.LeadTimeChart.Series.Add("Moda: "+ moda);
            modaSerie.ChartType = SeriesChartType.Line;
            modaSerie.Color = Color.Black;
            modaSerie.BorderWidth = 3;

            Series percentilSerie = this.LeadTimeChart.Series.Add("Percentil " + valorPercentil*10 + "%: " + percentil);
            percentilSerie.ChartType = SeriesChartType.Line;
            percentilSerie.Color = Color.Purple;
            percentilSerie.BorderWidth = 3;

            foreach (var item in distribuicao)
            {
                leadtimeSerie.Points.AddXY(item.Key.ToString(), item.Value);
                mediaSerie.Points.AddXY(item.Key, media);
                modaSerie.Points.AddXY(item.Key, moda);
                percentilSerie.Points.AddXY(item.Key, percentil);
            }
        }
    }
}
