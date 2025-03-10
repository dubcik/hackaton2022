﻿using System.Diagnostics;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Logging;

namespace Echo.Bot;

public class AdapterWithErrorHandler : CloudAdapter
{
	public AdapterWithErrorHandler(
		BotFrameworkAuthentication auth,
		ILogger<AdapterWithErrorHandler> logger)
		: base(auth, logger)
	{
		OnTurnError = async (turnContext, exception) =>
		{
			Debug.WriteLine("Do I got an exception here?");
			logger.LogError(
				exception, "[OnTurnError] unhandled error : {ExceptionMessage}", exception.Message);
			await turnContext.SendActivityAsync("The bot encountered an error or bug.");
			await turnContext.SendActivityAsync("To continue to run this bot, please fix the bot source code.");
			await turnContext.TraceActivityAsync(
				"OnTurnError Trace",
				exception.Message,
				"https://www.botframework.com/schemas/error",
				"TurnError");
		};
	}
}
