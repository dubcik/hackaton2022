﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;

namespace Echo.Bot.Controllers;

[Route("")]
[ApiController]
public class BotController : ControllerBase
{
	private readonly IBotFrameworkHttpAdapter _adapter;
	private readonly IBot _bot;

	public BotController(
		IBotFrameworkHttpAdapter adapter,
		IBot bot)
	{
		_adapter = adapter;
		_bot = bot;
	}

	[HttpPost]
	[HttpGet]
	public async Task PostAsync()
	{
		await _adapter.ProcessAsync(
			Request,
			Response,
			_bot);
	}
}
