﻿using core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Services.Abstracts
{
    public interface ITeamServices
    {
        void AddTeam(Team team);
        void DeleteTeam(int id);
        void Update(int id, Team team);
        Team GetTeam(Func <Team,bool>? func=null);
        List<Team> GetAllTeams(Func<Team, bool>? func = null);
    }
}
