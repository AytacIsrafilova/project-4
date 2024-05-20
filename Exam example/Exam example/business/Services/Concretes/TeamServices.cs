using business.Exceptions;
using business.Services.Abstracts;
using core.Model;
using core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Services.Concretes
{
    public class TeamServices : ITeamServices
    {
        private readonly ITeamRepository _teamRepository;


        public TeamServices(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public void AddTeam(Team team)
        {
            if (team == null) throw new ArgumentNullException("Team null ola bilmez !");
            if (_teamRepository.GetAll().Any(x=>x.Fullname==team.Fullname))
            {
                _teamRepository.Add(team);
                _teamRepository.Commit();
            }
        }

        public void DeleteTeam(int id)
        {
           var existTeam =_teamRepository.Get(x=>x.Id==id);
            if(existTeam == null)
            {
                throw new NullReferenceException("Team yoxdur!");
            }
            _teamRepository.Delete(existTeam);
            _teamRepository.Commit() ;

        }

        public List<Team> GetAllTeams(Func<Team, bool>? func = null)
        {
            return _teamRepository.GetAll(func);
        }

        public Team GetTeam(Func<Team, bool>? func = null)
        {
            return GetTeam(func);
        }

        public void Update(int id, Team newTeam)
        {
            var oldTeam = _teamRepository.Get(x => x.Id == id);
            if (oldTeam == null)
            {
                throw new NullReferenceException("Team yoxdur!");
            }
            if(_teamRepository.GetAll().Any(x=>x.Id==newTeam.Id))
            {
                oldTeam.Id = newTeam.Id;
                _teamRepository.Add(oldTeam);
                _teamRepository.Commit();
            }
            else
            {
                throw new DublicateTeamException("Fullname","Fullname eyni ola bilmez!");
            }

        }
    }
}
