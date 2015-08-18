﻿using System;
using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.DevelopersList
{
    public interface IPortfolioBusinessModel
    {
        string ProjectName { get; set; }

        IEnumerable<ISkillBusinessModel> Skills { get; set; }

        IDeveloperBusinessModel ProjectTeamLeader { get; set; }

        //data od data do itd
        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        int WeeksSpent { get; }
    }
}