using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assistente.Extracao
{
    public class Projetos
    {
        public Array idsExcluidos;
        public Projetos()
        { 
        }
        public List<Project> GetProjetos(Jira jira)
        {
            var projetos = jira.Projects.GetProjectsAsync();

            return projetos.Result.ToList(); //.Select(;
        }
        public List<Project> LimpaProjetos(List<Project> projetos)
        {
            List<Project> projetosLimpos = new List<Project>();
            foreach(Project p in projetos)
            {
                if (p.Id.Contains("1"))
                {
                    projetosLimpos.Add(p);
                }
            }
        return projetosLimpos;
        }
    }
}
