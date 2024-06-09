using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.utils
{
    public class ImgConvert
    {
        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            string base64String = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                base64String = Convert.ToBase64String(imageBytes);
            }
            return base64String;
        }


        public static Image Base64ToImage(string base64String)
        {
            Image image = null;
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                image = Image.FromStream(ms);
            }
            return image;

        }

        public static Image ByteArrayToImage(byte[] byteArray)
        {
            Image image = null;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            byte[] imageBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageBytes =  ms.ToArray();
            }
            return imageBytes;
        }

        public static Image RedimencionarImagen(Image imgProd, int ancho, int alto)
        {
            Bitmap imgRedimencionada = new Bitmap(ancho, alto);
            Graphics grafico = Graphics.FromImage(imgRedimencionada);
            grafico.DrawImage(imgProd, 0, 0, ancho, alto);
            return imgRedimencionada;
        }
    }
}
