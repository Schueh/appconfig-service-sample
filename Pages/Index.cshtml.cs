using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace AppConfigServiceSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MySettings _settings;

        public IndexModel(IOptionsSnapshot<MySettings> settings)
        {
            _settings = settings.Value;
        }

        public string Foo { get; set; }
        public string Bar { get; set; }

        public void OnGet()
        {
            Foo = _settings.Foo;
            Bar = _settings.Bar;
        }
    }
}