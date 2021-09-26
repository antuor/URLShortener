using Microsoft.AspNetCore.Mvc.RazorPages;

namespace URL_Shortener.Pages
{
    public class ShortenModel : PageModel
    {
        public string ShortUrl { get; set; }

        // Присваивает ShortUrl значение переданного id при открытии страницы
        public void OnGet(string id)
        {
            ShortUrl = id;
        }
    }
}
