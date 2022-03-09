#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiBook.Data;
using WebApiBook.Models;
using WebApiBook.Repositories.Interfaces;

namespace WebApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParagraphController : ControllerBase
    {

        private readonly IParagraphService _paragraphService;

        public ParagraphController(IParagraphService paragraphService)
        {
            _paragraphService = paragraphService;
        }


        [HttpPost]
        public IActionResult PostParagraph([FromBody] ParagraphRequest paragraph)
        {
            int uniqueWords = _paragraphService.GetNumberOfUniqueWords(paragraph);
            
            return Ok(new { uniqueWords = uniqueWords });
        }
    }
}
