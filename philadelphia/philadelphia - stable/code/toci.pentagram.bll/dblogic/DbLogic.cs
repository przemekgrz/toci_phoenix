﻿using System.Collections.Generic;
using System.Linq;
using toci.pentagram.interfaces;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace toci.pentagram.bll.dblogic
{
    public abstract class DbLogic : IDbLogic
    {
        protected IDbHandle DbHandle;
        protected DbHandleAccessDataFactory AccessDataFactory;
        private const string Id = "id";

        protected DbLogic()
        {
            DbHandleAccessData accessData = new DbHandleAccessDataFactory().Create("ksebal");
            //DbHandleAccessData accessData = new DbHandleAccessDataFactory().Create("Terry");

            DbHandle = GetDbHandle(accessData.UserName, accessData.Password,
                accessData.DbAdress, accessData.DbName);
        }

        public virtual IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName)
        {
            // podac obiekt pracujacy z baza danych
            return DbHandleFactory.GetHandle(SqlClientKind.PostgreSql, user, password, dbAddress, dbName);

        }

        protected List<T> FetchModelsFromDb<T>(IModel model) where T : Model
        {
            return model.GetDataRowsList(DbHandle.GetData(model)).Cast<T>().ToList();
        }

        protected T FetchModelFromDb<T>(IModel model) where T : Model
        {
            var modelFromDb = model.GetDataRowsList(DbHandle.GetData(model));
            return modelFromDb.Count == 0 ? default(T) : (T)modelFromDb[0];
        }

        protected T FetchModelById<T>(int id) where T : Model, new()
        {
            T model = new T {Id=id};
            model.SetSelect(Id, SelectClause.Equal);
            return FetchModelFromDb<T>(model);
        }

        protected List<TModel> FetchModelsByColumnValue<TModel, TValue>(string columnName, SelectClause clause, TValue value)
            where TModel : Model, new()
            where TValue : new()
        {
            TModel model = new TModel();
            model.SetSelect(columnName, clause, value);
            return FetchModelsFromDb<TModel>(model);
        }
    }
}