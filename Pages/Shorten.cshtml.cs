using Microsoft.AspNetCore.Mvc.RazorPages;

namespace URL_Shortener.Pages
{
    public class ShortenModel : PageModel
    {
        public string ShortUrl { get; set; }

        // ����������� ShortUrl �������� ����������� id ��� �������� ��������
        public void OnGet(string id)
        {
            ShortUrl = id;
        }
    }
}
