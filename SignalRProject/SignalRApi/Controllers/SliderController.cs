using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            var values = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(values);    
            return Ok("Özellik Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Özellik Silindi");
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var values = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(values);
            return Ok("Özellik Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            return Ok(_mapper.Map<GetByIdSliderDto>(value));
        }
    }
}
