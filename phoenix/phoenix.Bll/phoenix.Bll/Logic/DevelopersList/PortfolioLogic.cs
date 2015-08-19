﻿using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class PortfolioLogic : DataAccessLogic, IPortfolioLogic
    {
        //DI
        private IDeveloperListLogic _developerListLogic;

        public PortfolioLogic(IDeveloperListLogic DeveloperListLogic)
        {
            _developerListLogic = DeveloperListLogic;
        }

        public IEnumerable<IPortfolioBusinessModel> GetUserPortfolio(int userId)
        {
            List<users_portfolio> userPortfolio = FetchModelsByColumnValue<users_portfolio, int>("id_users",
                SelectClause.Equal, userId);
            return userPortfolio.Select(p => GetElementById<IPortfolioBusinessModel, portfolio>(p.IdPortfolio)).ToList();
        }

        public IDeveloperBusinessModel GetProjectTeamLeader(int portfolioId)
        {
            portfolio portfolio = FetchModelById<portfolio>(portfolioId);
            return _developerListLogic.GetDevByUserId(portfolio.FkIdUsers);
        }

        public IEnumerable<IPortfolioBusinessModel> GetAllProjects()
        {
            return GetAllElements<IPortfolioBusinessModel, portfolio>();
        }
    }
}