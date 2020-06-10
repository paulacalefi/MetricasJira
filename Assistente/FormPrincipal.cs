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
            string jqlString = "";// PrepareJqlbyDates("2014-03-01", "2014-03-31");
            CancellationToken token = new CancellationToken();
            IEnumerable<Issue> jiraIssues = jira.Issues.GetIssuesFromJqlAsync("project = AG", 999, 0, token).Result;
            int cont = 0;
            chart1.DataSource = jiraIssues;
            //chart1.Series.Add();
            foreach (var issue in jiraIssues)
            {
                cont++;
                //System.Console.WriteLine(issue.Key.Value + " -- " + issue.);
            }
            Project projetoSelecionado = (Project)cbxProjeto.SelectedItem;

        }
    }
}
