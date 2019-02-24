﻿using System.Collections.Generic;
using aboavobr.raspberrypi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aboavobr.raspberrypi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class DebugController : ControllerBase
   {
      private readonly ILogger<DebugController> logger;
      private readonly ISerialCommunicationService serialCommunicationService;

      public DebugController(ISerialCommunicationService serialCommunicationService, ILogger<DebugController> logger)
      {
         this.serialCommunicationService = serialCommunicationService;
         this.logger = logger;
      }

      // GET api/debug
      [HttpGet]
      public ActionResult<string> Get()
      {
         return "It's alive";
      }

      // GET api/debug/logs
      [HttpGet("logs")]
      public ActionResult<string> GetLogs()
      {
         return "logs";
      }

      // GET api/debug/serial/ports
      [HttpGet("serial/ports")]
      public ActionResult<IEnumerable<string>> GetSerialPorts()
      {
         return new ActionResult<IEnumerable<string>>(serialCommunicationService.GetAvailableSerialPorts());
      }

      [HttpPost("serial")]
      public ActionResult WriteSerial(string command)
      {
         serialCommunicationService.SendMessage(command);
         
         return Ok();
      }
   }
}