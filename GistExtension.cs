using BlogEngine.Core;
using BlogEngine.Core.Web.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogEngine.Gist
{
    [Extension("This extension enables Github Gist support for BlogEngine.NET.", "1.0", "Cong Danh")]
    public class GistExtension
    {
        public GistExtension()
        {
            Post.Serving += Post_Serving;
        }

        void Post_Serving(object sender, ServingEventArgs e)
        {
            // [gist id=1234]
            e.Body = Regex.Replace(e.Body, "\\[gist\\s[^\\]]*id=(\\d+)[^\\]]*\\]","<script src=\"https://gist.github.com/$1.js\"></script>");
            // [gist]1234[/gist]
            e.Body = Regex.Replace(e.Body, "\\[gist\\](\\d+)\\[\\/gist\\]", "<script src=\"https://gist.github.com/$1.js\"></script>");
            e.Body = Regex.Replace(e.Body, "(\\n|<(br|p)\\s*/?>)\\s*https://gist\\.github\\.com/(\\w+/)?(\\d+)/?\\s*(\\n|<(br|p)\\s*/?>|</p>|</li>)", "<script src=\"https://gist.github.com/$4.js\"></script>");
            e.Body = Regex.Replace(e.Body, "\\[gist\\s+https://gist\\.github\\.com/(\\w+/)?(\\d+)/?\\s*\\]", "<script src=\"https://gist.github.com/$2.js\"></script>");
        }
    }
}
