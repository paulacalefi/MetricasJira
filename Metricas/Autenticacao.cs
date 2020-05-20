
using System;
using System.Collections.Generic;
using System.Text;
using Atlassian.Jira;

namespace Metricas
{
    class Autenticacao
    {
        string UserName = "paula.calefi@getninjas.com.br";
        string Senha = "jEZkla9Ecla4fQEJyNeuFBC3";
        string Servico = "https://gogogoninjas.atlassian.net/";
        Jira jira;
        Jira.
        jira = Jira.CreateRestClient("https://gogogoninjas.atlassian.net/", UserName, Senha);
            // use LINQ syntax to retrieve issues
        var ag = jira.Projects.GetProjectAsync("AG");
    }
}
