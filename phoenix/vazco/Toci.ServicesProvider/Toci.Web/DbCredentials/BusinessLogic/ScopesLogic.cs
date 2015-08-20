﻿using System;
using System.Collections.Generic;
using System.Linq;
using DbCredentials.Config;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;

namespace DbCredentials.BusinessLogic
{
    public class ScopesLogic
    {
        private const int notSaved = 0;
        private const bool exist = true;
        DbQuery dbQuery;

        public ScopesLogic(DbConfig dbConfig)
        {
            dbQuery = new DbQuery(dbConfig);
        }
        public bool AddScope(Scopes model)
        {
            if (IsScopeExist(model))
            {
                return exist;
            }
            try
            {
                return dbQuery.Save(model) != notSaved;
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("Cannot add scope.");
            }
        }

        public bool IsScopeExist(Scopes model)
        {
            var list = dbQuery.Load(model).Cast<Scopes>().ToList();
            return list.Any(item => item.scopename.Equals(model.scopename));
        }

        public Scopes GetScopeId(Scopes model)
        {
            AddScope(model);

            var list = dbQuery.Load(model).Cast<Scopes>().ToList();

            foreach (var item in list.Where(item => item.scopename.Equals(model.scopename)))
            {
                model.scopeid = item.scopeid;
                return model;
            }

            //list.Any(item => item.scopename.Equals(model.scopename) model.scopeid = item.scopeid);
            return model;     
        }

        public List<Scopes> GetScopesId(List<Scopes> scopesList)
        {
            return scopesList.Select(GetScopeId).ToList();
        }

        public List<Scopes> LoadScopes(Scopes model)
        {
            return dbQuery.Load(model).Cast<Scopes>().ToList();
        }

        public bool DeleteScope(Scopes model)
        {
            if (!IsScopeExist(model))
            {
                throw new Exception("Scope does not exist. ");
            }
            try
            {
                dbQuery.Delete(model, Scopes.SCOPENAME);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete scope. " + ex.Message);
            }
        }

        public bool UpdateScope(Scopes model)
        {
            if (!IsScopeExist(model))
            {
                throw new Exception("Scope does not exist. ");
            }
            try
            {
                
                dbQuery.Update(GetScopeId(model), Scopes.SCOPEID);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update scope. " + ex.Message);
            }
        }
    }
}