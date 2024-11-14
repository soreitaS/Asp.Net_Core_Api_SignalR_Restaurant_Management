﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MessageDtos;
using System.Net.Http;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;
		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
		[HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createMessageDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7038/api/Message", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","Default");
			}
			return View();
		}
    }
}
