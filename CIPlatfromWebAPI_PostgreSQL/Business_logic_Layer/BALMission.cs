using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALMission
    {
        private readonly DALMission _dalMission;

        public BALMission(DALMission dalMission)
        {
            _dalMission = dalMission;
        }

        public List<Missions> MissionList()
        {
            return _dalMission.MissionList();
        }




        public async Task<Missions> GetMissionByIdAsync(int id)
        {
            return await _dalMission.GetMissionByIdAsync(id);
        }

        public string AddMission(AddMissionModel mission)
        {
            return _dalMission.AddMission(mission);
        }


        public async Task<string> UpdateMissionAsync(UpdateMissionModel mission)
        {
            return await _dalMission.UpdateMissionAsync(mission);
        }

        public async Task<string> DeleteMissionAsync(int id)
        {
            return await _dalMission.DeleteMissionAsync(id);
        }




        public async Task<List<MissionSkill>> GetMissionSkillsAsync()
        {
            return await _dalMission.GetMissionSkillsAsync();
        }

        public async Task<List<MissionTheme>> GetMissionThemesAsync()
        {
            return await _dalMission.GetMissionThemesAsync();
        }

        public List<Missions> ClientSideMissionList(int userId)
        {
            return _dalMission.ClientSideMissionList(userId);
        }

        public string ApplyMission(MissionApplication missionApplication)
        {
            return _dalMission.ApplyMission(missionApplication);
        }

        public string MissionApplicationApprove(int id)
        {
            return _dalMission.MissionApplicationApprove(id);
        }
    }
}
