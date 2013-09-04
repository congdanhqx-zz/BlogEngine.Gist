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
            e.Body = Regex.Replace(e.Body, "\\[gist\\s[^\\]]*id=(\\d+)[^\\]]*\\]","<script src=\"https://gist.github.com/$1.js\"></script>");
        }
    }
}
