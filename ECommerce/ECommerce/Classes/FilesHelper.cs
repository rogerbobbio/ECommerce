using System;
using System.IO;
using System.Web;

namespace ECommerce.Classes
{
    public class FilesHelper
    {
        public static bool UploadPhoto(HttpPostedFileBase file, string folder, string name)
        {
            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(name))
            {
                return false;
            }

            try
            {                
                if (file != null)
                {                    
                    var path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                    file.SaveAs(path);
                    using (var ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }           
        }

        public static string UploadFile(HttpPostedFileBase file, string folder, string name)
        {
            var document = string.Empty;

            if (file != null)
            {
                document = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                file.SaveAs(path);
                using (var ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }

            return document;
        }
    }
}