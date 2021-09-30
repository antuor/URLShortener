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

        /// <summary>
        /// Получает короткий адрес, ищет соответствие в базе
        /// и перенаправляет по длиному адресу.
        /// </summary>
        /// <param name="id">Короткая ссылка.</param>
        /// <returns>Переадресацию по длиной ссылке.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<URLs>> GetURLs(string id)
        {
            var uRLs = await _context.URL.FindAsync(id);

            if (uRLs == null)
            {
                return NotFound();
            }

            return Redirect(uRLs.SourceUrl);
        }

        /// <summary>
        /// Добавляет в базу полученный на вход объект URL.
        /// </summary>
        /// <param name="urls">Объект, содержащий ссылки.</param>
        /// <returns>Статус 409, при нахождении дубликата, 
        /// или 201, если конфликтов не было.</returns>
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
                if (URLsExists(urls.ShortUrl))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PostURLs", new { id = urls.ShortUrl }, urls);
        }

        /// <summary>
        /// Производит поиск в базе по длиной ссылке и возвращает объект URL.
        /// </summary>
        /// <param name="sourceUrl">Длиная ссылка для сравнения.</param>
        /// <returns>Объект URLs, содержащий длиную и короткую ссылки,
        /// или null, если поиск не дал результатов.</returns>
        [HttpGet("api/find")]
        public URLs FindURLBySource(string sourceUrl)
        {
            return _context.URL.SingleOrDefault(e => e.SourceUrl == sourceUrl);
        }

        /// <summary>
        /// Производит поиск в базе по короткой ссылке (ключу)
        /// </summary>
        private bool URLsExists(string shortUrl)
        {
            return _context.URL.Any(e => e.ShortUrl == shortUrl);
        }
    }
}
