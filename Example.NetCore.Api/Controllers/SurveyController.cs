using Example.NetCore.DataAccess.Contracts;
using Example.NetCore.DataAccess.Entities;
using Example.NetCore.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyRepository _surveyRepository;
        public SurveyController(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] Pagination paginationDto)
        {
            var route = Request?.Path.Value; //Todo: Verify in unit test remove ?
            var surveys = await _surveyRepository.GetAllAsync(paginationDto);
            var totalRecords = await _surveyRepository.GetTotalRecorsdAsync();
            
            return Ok(surveys);
        }

        [ProducesResponseType(StatusCodes.Status201Created)] //, Type = typeof(SurveyDto)
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Survey SurveyDto)
        {
            var survey = await _surveyRepository.CreateAsync(SurveyDto);

            return Ok(survey);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurvey(int id)
        {
            bool exist = await _surveyRepository.ExistAsync(id);
            if (!exist)
                return NotFound();

            var survey = await _surveyRepository.GetAsync(id);

            return Ok(survey);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey(int id, Survey surveyDto)
        {
            bool exist = await _surveyRepository.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _surveyRepository
                .UpdateAsync(surveyDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            bool exist = await _surveyRepository.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _surveyRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
