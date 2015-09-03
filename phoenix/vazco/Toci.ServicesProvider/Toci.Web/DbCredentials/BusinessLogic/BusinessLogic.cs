﻿using System.Collections.Generic;
using DbCredentials.Config;
using DbCredentials.DbLogic.CredentialsModels;

namespace DbCredentials.BusinessLogic
{
    public class BusinessLogic
    {
        private ScopesLogic scopesLogic;
        ProjectsLogic projectsLogic;

        public BusinessLogic(DbConfig dbConfig)
        {
            scopesLogic=new ScopesLogic(dbConfig);
            projectsLogic=new ProjectsLogic(dbConfig);
        }
        public bool AddProject(Scopes scopesModel, Projects projectsModel)
        {
            if (!scopesLogic.AddScope(scopesModel))
            {
                return false;
            }
            projectsModel.scopeid = scopesLogic.GetScopeId(scopesModel).scopeid;

            return  projectsLogic.AddProject(projectsModel);
        }

        public Projects LoadProject(Projects model, List<Scopes> listOfScopes)
        {
            return projectsLogic.LoadProject(model, listOfScopes);
        }

        public List<Projects> LoadProjects(List<Scopes> listOfScopes)
        {
            return projectsLogic.LoadProjects(listOfScopes);
        }

        public bool DeleteProject(Projects model, List<Scopes> listOfScopes)
        {
            return projectsLogic.DeleteProject(model, listOfScopes);
        }

        public bool UpdateProject(Projects model, List<Scopes> listOfScopes)
        {
            return projectsLogic.UpdateProject(model, listOfScopes);
        }
    }
}