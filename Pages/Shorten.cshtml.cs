using Microsoft.AspNetCore.Mvc.RazorPages;

namespace URL_Shortener.Pages
{
    public class ShortenModel : PageModel
    {
        public string ShortUrl { get; set; }

        /// <summary>
        /// Присваивает ShortUrl значение переданного id при открытии страницы.
        /// </summary>
        public void OnGet(string id)
        {
            ShortUrl = id;
        }
    }
}
