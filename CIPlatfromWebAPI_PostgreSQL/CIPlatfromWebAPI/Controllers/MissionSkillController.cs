using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillController : ControllerBase
    {
        private readonly BALMissionSkill _balMissionSKill;

        public MissionSkillController(BALMissionSkill balMissionSKill)
        {
            _balMissionSKill = balMissionSKill;
        }

        [HttpGet]
        [Route("GetMissionSkillList")]
        public async Task<ActionResult<ResponseResult>> GetMissionSKillList()
        {
            try
            {
                var result = await _balMissionSKill.GetMissionSkillListAsync();
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Success, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetMissionSkillById/{id}")]
        public async Task<ActionResult<ResponseResult>> GetMissionSkillById(int id)
        {
            try
            {
                var result = await _balMissionSKill.GetMissionSkillByIdAync(id);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Success, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("AddMissionSkill")]
        public async Task<ActionResult<ResponseResult>> AddMissionSkill(MissionSkill missionSkill)
        {
            try
            {
                var result = await _balMissionSKill.AddMissionSkillAsync(missionSkill);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Success, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("UpdateMissionSkill")]
        public async Task<ActionResult<ResponseResult>> UpdateMissionSkill(MissionSkill missionSkill)
        {
            try
            {
                var result = await _balMissionSKill.UpdateMissionSkillAsync(missionSkill);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Success, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteMissionSkill/{id}")]
        public async Task<ActionResult<ResponseResult>> DeleteMissionSkill(int id)
        {
            try
            {
                var result = await _balMissionSKill.DeleteMissionSkillAsync(id);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Success, Message = ex.Message });
            }
        }
    }
}
