using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistente.Extracao
{
    public class Autenticacao
    {
        public Jira GetInstanciaJira()
        { 
            string UserName = "paula.calefi@getninjas.com.br";
            string Senha = "jEZkla9Ecla4fQEJyNeuFBC3";
            string Servico = "https://gogogoninjas.atlassian.net/";
            return Jira.CreateRestClient(Servico, UserName, Senha);
        }
        
    }
}
