using Microsoft.AspNetCore.Mvc;

namespace JobOffers.Utilites
{
    public static class Helper
    {
        public static async Task<string> UploadImage(List<IFormFile> Files, string folderName)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/" + folderName, ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }



        public static async Task<string> UploadPDF(IFormFile File, string folderName)
        {

            if (File != null && File.Length > 0)
            {
                // Process the uploaded file here
                string fileName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".pdf";
                //var fileName = Path.GetFileName(File.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/" + folderName, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await File.CopyToAsync(stream);

                    return fileName;
                }
            }
            
            return string.Empty;
        }

    }
}
