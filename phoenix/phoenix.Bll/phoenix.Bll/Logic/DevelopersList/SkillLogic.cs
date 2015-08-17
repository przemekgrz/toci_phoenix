﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class SkillLogic : DbLogic,ISkillLogic
    {
        public IEnumerable<ISkillBusinessModel> GetUserSkills(int userId)
        {
            List<developers_skills> developersSkills= FetchModelsByColumnValue<developers_skills, int>
                ("id_users", SelectClause.Equal, userId);

            List<ISkillBusinessModel> skills =
                developersSkills.Select(skill => GetSkillById(skill.IdSkillsTechnologies)).ToList();

            return skills;
        }

        public IEnumerable<ISkillBusinessModel> GetPortfolioSkills(int portfolioId)
        {
            List<portfolio_skills_technologies> portfolioSkills = FetchModelsByColumnValue<portfolio_skills_technologies, int>
                ("fk_id_portfolio", SelectClause.Equal, portfolioId);
            List<ISkillBusinessModel> skills = 
                portfolioSkills.Select(skill => GetSkillById(skill.FkIdSkillsTechnologies)).ToList();

            return skills;
        }

        public ISkillBusinessModel GetSkillById(int skillId)
        {
            return Mapper.Map<ISkillBusinessModel>( FetchModelById<skills_technologies>(skillId) );
        }
    }
}