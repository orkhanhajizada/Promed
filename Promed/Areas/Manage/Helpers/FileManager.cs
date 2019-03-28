using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Promed.Areas.Manage.Helpers
{
    public static class FileManager
    {
        public static string Upload(HttpPostedFileBase File)
        {
            string filename = DateTime.Now.ToString("yyyMMddHHmmssfff") + File.FileName;

            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), filename);

            File.SaveAs(path);

            return filename;
        }

        public static void Delete(string filename)
        {
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), filename);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

        }

    }
}