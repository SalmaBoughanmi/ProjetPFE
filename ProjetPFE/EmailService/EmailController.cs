using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetPFE.Contracts.services;
using ProjetPFE.Contracts;
using ProjetPFE.EmailService.EmailEntities;
using ProjetPFE.EmailService.Interfaces;

namespace ProjetPFE.EmailService
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
         private readonly IEmailSender _emailSender;





        public EmailController(IEmailSender emailSender)
        {
           
            _emailSender = emailSender;


        }
        [HttpGet(Name = "EmailConfiguration")]
        public async Task<IEnumerable<EmailConfiguration>> Get()
        {
            var message = new Message(new string[] { "codemazetest@mailinator.com" },
                "Test email async",
                "This is the content from our async email.",
                null);
            await _emailSender.SendEmailAsync(message);
            return Enumerable.Range(1, 5).Select(index => new EmailConfiguration
            {

                
            })
            .ToArray();
        }
        [HttpPost]
        public async Task<IEnumerable<EmailConfiguration>> Post()
        {
            var rng = new Random();
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            var message = new Message(new string[] { "codemazetest@mailinator.com" }, "Test mail with Attachments", "This is the content from our mail with attachments.", files);
            await _emailSender.SendEmailAsync(message);
            return Enumerable.Range(1, 5).Select(index => new EmailConfiguration
            {
               
            })
            .ToArray();
        }
    }
}
