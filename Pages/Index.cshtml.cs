using HashidsNet;
using System;
using System.Threading.Tasks;
using URL_Shortener.Data;
using URL_Shortener.Models;
using URL_Shortener.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace URL_Shortener.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly URLsController       _urlsController;

        // Поле, хранящее путь до корня приложения.
        private readonly string _hostPath;

        // Используется для генерации случайных чисел.
        private readonly Random _getrandom;

        private URLs _urls;

        public IndexModel(ApplicationDBContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _urlsController = new URLsController(_db);
            _httpContextAccessor = httpContextAccessor;
            _hostPath = "https://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/";
            _getrandom = new Random();
            _urls = new URLs();
        }

        public void OnGet() {}

        /// <summary>
        /// Свойство для хранения длиной ссылки при запросе из формы.
        /// </summary>
        [BindProperty]
        public URLs Urls { get; set; }


        /// <summary>
        /// Метод, обрабатывающий пост запрос от формы. Проверяет, существует ли введённая ссылка в базе,
        /// при положительном ответе возвращает короткую ссылку из базы с переадресацией на страницу Shorten, 
        /// при отрицательном кодирует рандомное число, используя длинную ссылку как соль, кладёт пару в базу 
        /// и возвращает короткую ссылку с переадресацией.
        /// </summary>
        /// <returns>Переадресацию с короткой ссылкой в качестве id.</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _urls = _urlsController.FindURLBySource(Urls.SourceUrl);

                if (_urls != null)
                {
                    return RedirectToPage("Shorten", new { id = _hostPath + _urls.ShortUrl });
                }

                var hashids     = new Hashids(Urls.SourceUrl.Trim());
                int encodeNum   = _getrandom.Next(100000, 500000);

                Urls.ShortUrl = hashids.Encode(encodeNum);

                await _urlsController.PostURLs(Urls);
                return RedirectToPage("Shorten", new { id = _hostPath + Urls.ShortUrl });
            }
            else
            {
                return Page();
            }
        }
    }
}
