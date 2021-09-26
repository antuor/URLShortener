using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URL_Shortener.Data;
using URL_Shortener.Models;

namespace URL_Shortener.Controllers
{
    [Route("")]
    [ApiController]
    public class URLsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public URLsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // Получает короткий адрес, ищет соответствие в базе
        // и перенаправляет по длиному адресу
        [HttpGet("{id}")]
        public async Task<ActionResult<URLs>> GetURLs(string id)
        {
            var uRLs = await _context.URL.FindAsync(id);

            if (uRLs == null)
            {
                return NotFound();
            }

            return Redirect(uRLs.sourceUrl);
        }

        // Добавляет в базу полученный на вход объект URL
        [HttpPost("api/create")]
        public async Task<ActionResult<URLs>> PostURLs(URLs urls)
        {
            _context.URL.Add(urls);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (URLsExists(urls.shortUrl))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PostURLs", new { id = urls.shortUrl }, urls);
        }

        // Производит поиск в базе по длиной ссылке и возвращает объект URL
        [HttpGet("api/find")]
        public URLs FindURLBySource(string sourceUrl)
        {
            return _context.URL.SingleOrDefault(e => e.sourceUrl == sourceUrl);
        }

        // Производит поиск в базе по короткой ссылке (ключу)
        private bool URLsExists(string shortUrl)
        {
            return _context.URL.Any(e => e.shortUrl == shortUrl);
        }
    }
}
