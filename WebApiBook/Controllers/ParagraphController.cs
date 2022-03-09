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
        private readonly IUniqueWord _uniqueWordRepo;
        private readonly IWatchlistWord _watchlistWord;

        public ParagraphController(IUniqueWord uniqueWordRepo, IWatchlistWord watchlistWordRepo)
        {
            _uniqueWordRepo = uniqueWordRepo;
            _watchlistWord = watchlistWordRepo;
        }


        [HttpPost]
        public IActionResult PostParagraph([FromBody] WatchlistWord paragraph)
        {
            IEnumerable<string> allWords = paragraph.Word.Split(' ');
            IEnumerable<string> uniqueWords = allWords.GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key);
            Console.WriteLine("uniqueWords", uniqueWords.Count());
            //TODO: Implement
            _watchlistWord.AddWatchlistWord(paragraph);
            
            return Ok(new { uniqueWords = uniqueWords.Count() });
        }
    }
}
