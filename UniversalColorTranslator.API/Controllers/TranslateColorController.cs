using Microsoft.AspNetCore.Mvc;
using UniversalColorTranslator.API.Model;
using UniversalColorTranslator.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversalColorTranslator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateColorController : ControllerBase
    {
        // GET: api/<TranslateColorController>
        /// <summary>
        /// Get All List Of Collors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Colors> Get()
        {
            UniversalColorTranslatorRepository repo = new UniversalColorTranslatorRepository();
            return repo.GetColors();
        }

        // GET api/<TranslateColorController>/5
        /// <summary>
        /// get specified color from table an returns JSON
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        [HttpGet("{color}")]
        public Colors Get(string color)
        {
            UniversalColorTranslatorRepository repo = new UniversalColorTranslatorRepository();
            return repo.GetColor(color);
        }

        // GET api/<TranslateColorController>/5
        /// <summary>
        /// return the hex value of a certain color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        [HttpGet("hex/{color}")]
        public string GetHex(string color)
        {
            UniversalColorTranslatorRepository repo = new UniversalColorTranslatorRepository();
            return repo.GetColorHex(color);
        }
    }
}
