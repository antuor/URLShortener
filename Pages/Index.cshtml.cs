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

        // ���� �������� ���� �� ����� ����������
        private readonly string _hostPath;

        // ������������ ��� ��������� ��������� �����
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

        // �������� ��� �������� ������ ��� ������� �� �����
        [BindProperty]
        public URLs Urls { get; set; }

        // ����� �������������� ���� ������ �� �����. �������� ���������� �� ����� ������ � ����
        // ��� ������������� ������ ���������� �������� ������ �� ����, ��� ������������� ��������
        // ��������� �����, ��������� ������� ������ ��� ����, ����� ���� � ���� � ���������� �������� ������
        public async Task<IActionResult> OnPost()
        {
            if (Urls.sourceUrl != null && Uri.IsWellFormedUriString(Urls.sourceUrl, UriKind.Absolute) == true)
            {
                _urls = _urlsController.FindURLBySource(Urls.sourceUrl);

                if (_urls != null)
                {
                    return RedirectToPage("Shorten", new { id = _hostPath + _urls.shortUrl });
                }

                var hashids     = new Hashids(Urls.sourceUrl.Trim());
                int encodeNum   = _getrandom.Next(100000, 500000);

                Urls.shortUrl = hashids.Encode(encodeNum);

                await _urlsController.PostURLs(Urls);
                return RedirectToPage("Shorten", new { id = _hostPath + Urls.shortUrl });
            }
            else
            {
                return Page();
            }
        }
    }
}
