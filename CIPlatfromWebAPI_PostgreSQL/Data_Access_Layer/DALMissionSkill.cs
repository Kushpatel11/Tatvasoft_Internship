using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DALMissionSkill
    {
        private readonly AppDbContext _cIDbContext;

        public DALMissionSkill(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public async Task<List<MissionSkill>> GetMissionSkillListAsync()
        {
            return await _cIDbContext.MissionSkill.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<MissionSkill> GetMissionSkillByIdAsync(int id)
        {
            return await _cIDbContext.MissionSkill.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<string> AddMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                missionSkill.CreatedDate = DateTime.UtcNow;
                _cIDbContext.MissionSkill.Add(missionSkill);
                await _cIDbContext.SaveChangesAsync();
                return "Save Skill Successfully!";
            }
            catch(Exception ex)
            {
                throw new Exception("Error while adding Skill.", ex);
            }
        }

        public async Task<string> UpdateMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                var existingSkill = await _cIDbContext.MissionSkill.Where(x => x.Id == missionSkill.Id).FirstOrDefaultAsync();
                if (existingSkill != null)
                {
                    existingSkill.SkillName = missionSkill.SkillName;
                    existingSkill.Status = missionSkill.Status;
                    existingSkill.ModifiedDate = DateTime.UtcNow;
                    await _cIDbContext.SaveChangesAsync();
                    return "Update Skill Successfully!";
                }
                throw new Exception("Mission Skill Not Found");
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating Skill.", ex);
            }
        }

        public async Task<string> DeleteMissionSkillAsync(int id)
        {
            try
            {
                var existingSkill = await _cIDbContext.MissionSkill.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existingSkill != null)
                {
                    existingSkill.IsDeleted = true;
                    await _cIDbContext.SaveChangesAsync();
                    return "Delete Skill Successfully!";
                }
                throw new Exception("Mission Skill Not Found");
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting Skill.", ex);
            }
        }
    }
}
