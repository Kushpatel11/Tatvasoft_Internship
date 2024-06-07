using Business_logic_Layer;
using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly BALMission _balMission;
        private readonly ResponseResult result = new ResponseResult();

        public MissionController(BALMission balMission)
        {
            _balMission = balMission;
        }

        [HttpGet]
        [Route("MissionList")]
        public ActionResult<ResponseResult> MissionList()
        {
            try
            {
                result.Data = _balMission.MissionList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
                return StatusCode(500, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("MissionDetailById/{id}")]
        public async Task<ActionResult<ResponseResult>> GetMissionById(int id)
        {
            try
            {
                result.Data = await _balMission.GetMissionByIdAsync(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
                return StatusCode(500, ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("AddMission")]
        public ActionResult<ResponseResult> AddMission(AddMissionModel mission)
        {
            try
            {
                result.Data = _balMission.AddMission(mission);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
                return StatusCode(500, ex.Message);
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("UpdateMission")]
        public async Task<ActionResult<ResponseResult>> UpdateMission(UpdateMissionModel mission)
        {
            try
            {
                result.Data = await _balMission.UpdateMissionAsync(mission); 
                result.Result = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                result.Result= ResponseStatus.Error;
                result.Message = ex.Message;
                return StatusCode(500, ex.Message);
            }
            return Ok(result);
        }

        //DeleteMission
        [HttpDelete]
        [Route("DeleteMission/{id}")]
        public async Task<ActionResult<ResponseResult>> DeleteMission(int id)
        {
            try
            {
                result.Data = await _balMission.DeleteMissionAsync(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
                return StatusCode(500, ex.Message);
            }
            return Ok(result);
        }


        /*
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public MissionController(BALMission balMission, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _balMission = balMission;
            _environment = environment;
        }







        // this should be in common controller
        [HttpPost]
             [Route("UploadImage")]
             public async Task<IActionResult> UploadImage([FromForm] List<IFormFile> upload)//upload class which gives file path :)
             {
                 try
                 {
                     string filePath = "";
                     string fullPath = "";
                     var files = Request.Form.Files;
                     List<string> fileList = new List<string>();
                     if (files != null && files.Count > 0)
                     {
                         foreach (var file in files)
                         {
                             string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                             filePath = Path.Combine("UploadMissionImage", "Mission"); // Mission, MissionDoc, userskill smn like that idk
                             string fileRootPath = Path.Combine(_environment.WebRootPath, filePath);

                             if (!Directory.Exists(fileRootPath))
                             {
                                 Directory.CreateDirectory(fileRootPath);
                             }

                             string name = Path.GetFileNameWithoutExtension(fileName);
                             string extenxion = Path.GetExtension(fileName);
                             string fullFileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extenxion;
                             fullPath = Path.Combine(fileRootPath, fullFileName);
                             using (var stream = new FileStream(fullPath, FileMode.Create))
                             {
                                 await file.CopyToAsync(stream);
                             }
                             fileList.Add(fullPath);
                         }
                     }
                     return Ok(fileList);
                 }
                 catch(Exception ex)
                 {
                     return BadRequest(ex.Message);
                 }
             }*/


        [HttpGet]
        [Route("GetMissionSkillList")]
        public async Task<ResponseResult> GetMissionSkillList()
        {
            try
            {
                result.Data = await _balMission.GetMissionSkillsAsync();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("GetMissionThemeList")]
        public async Task<ResponseResult> GetMissionThemeList()
        {
            try
            {
                result.Data = await _balMission.GetMissionThemesAsync();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("MissionApplicationApprove/{missionApplicationId}")]
        public ResponseResult MissionApplicationApprove(int missionApplicationId)
        {
            try
            {
                result.Data = _balMission.MissionApplicationApprove(missionApplicationId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
       
    }
}
