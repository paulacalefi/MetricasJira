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
            IEnumerable<Issue> jiraIssues = jira.Issues.GetIssuesFromJqlAsync(jql, 999, 0, token).Result;
            Dictionary<int, int> leadTime = new Dictionary<int, int>();
           
            foreach (var issue in jiraIssues)
            {
                if (issue.ResolutionDate != null)
                {
                    DateTime DataInicio = Convert.ToDateTime(issue.Created);
                    DateTime DataFim = Convert.ToDateTime(issue.ResolutionDate);

                }
            }
        }
        public double Percentil(int[] sequence, double percentil)
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
    }
}
