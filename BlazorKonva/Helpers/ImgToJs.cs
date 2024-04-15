using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.Helpers
{
    public static class ImgToJs
    {
        /// <summary>
        /// Such image will be already ready to be used inside Javascript Image class as source
        /// <para/>
        /// Image type is also auto handled (jpg/png/...)
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static string GetBase64Img(string FilePath)
        {
            var imageType = new FileInfo(FilePath).Extension.Trim('.');
            var imageBase64 = Convert.ToBase64String(File.ReadAllBytes(FilePath));

            var jsReadyImg = $"data:image/{imageType};base64,{imageBase64}";
            return jsReadyImg;
        }
    }
}
