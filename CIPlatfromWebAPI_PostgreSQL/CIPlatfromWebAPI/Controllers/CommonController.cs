using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly BALCommon _balCommon;
        private readonly ResponseResult result = new ResponseResult();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public CommonController(BALCommon balCommon, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _balCommon = balCommon;
            _environment = environment;
        }

        [HttpGet]
        [Route("CountryList")]
        public async Task<ResponseResult> GetCountryList()
        {
            try
            {
                result.Data = await _balCommon.GetCountriesAsync();
                result.Result = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("CityList/{countryId}")]
        public async Task<ResponseResult> GetCountryList(int countryId)
        {
            try
            {
                result.Data = await _balCommon.GetCitiesAsync(countryId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }


        // this should be in common controller
        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] Upload upload)//upload class which gives file path :)
        {
            try
            {
                string filePath = "";
                string fullPath = "";
                var files = Request.Form.Files;
                List<string> fileList = new List<string>();
                if (files == null && files.Count <= 0)
                {
                    return BadRequest(new ResponseResult() { Message = "Please upload necessary file", Result = ResponseStatus.Success });
                }
                foreach (var file in files)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filePath = Path.Combine("Uploads", upload.ModuleName); // Mission, MissionDoc, userskill smn like that idk
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
                return Ok(new ResponseResult() { Data = fileList, Result = ResponseStatus.Success});
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { Message = ex.Message, Result = ResponseStatus.Success });
            }
        }
    }
}
