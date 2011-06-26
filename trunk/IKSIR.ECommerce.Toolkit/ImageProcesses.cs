using System;
using System.Web;
using System.IO;
using System.Drawing;
namespace IKSIR.ECommerce.Toolkit
{
    public class ImageProcesses
    {
        //Resimlerimizi yeniden boyutlandırtıkdan sonra geriye byte dizisi olarak döndüreceğiz. Bunun için KucukResimOlustur isimli bir metot yazıyoruz. Bu metot static olsun ki sınıfı örneklemeden metodumuzu kullanabilelim.
        public static byte[] CreateNewImage(string FilePath, int Height, int Width, string FileExtension)
        {

            FilePath = HttpContext.Current.Server.MapPath(FilePath);
            if (File.Exists(FilePath))
            {
                // Image tipinde bir değişken tanımlayıp, Image tipinin Fromfile metodunu kullanarak dosya yoluna göre resmi img değişkenenine gönderdik.
                Image img = Image.FromFile(FilePath);
                FileExtension = FileExtension.ToLower();
                byte[] buffer = null;
                //Resmin orjinal boyutlarını alıyoruz.
                int tempWidth = img.Size.Width;
                int tempHeight = img.Size.Height;
                //Resmin yeniden boyutlandırılıp boyutlandırılamayacağına bakıyoruz.
                bool newWidth = (Width > 0 && tempWidth > Width && tempWidth > Height);
                bool newHeight = (Height > 0 && tempHeight > Height && tempHeight > Width);

                if (newWidth || newHeight)
                {
                    int iStart;
                    Decimal ayrac;
                    //Resmi enine göre yeniden boyutlandırıyoruz.
                    if (newWidth)
                    {
                        iStart = tempWidth;
                        ayrac = Math.Abs((Decimal)iStart / (Decimal)Width);
                        tempWidth = Width;
                        tempHeight = (int)Math.Round((Decimal)(tempHeight / ayrac));
                    }
                    else //resmi boyuna göre yeniden boyutlandırıyoruz.
                    {
                        iStart = tempHeight;
                        ayrac = Math.Abs((Decimal)iStart / (Decimal)Height);
                        tempHeight = Height;
                        tempWidth = (int)Math.Round((Decimal)(tempWidth / ayrac));
                    }
                    // GetThumbnailImage metodunu kullanarak resmi yeniden boyutlandırıyoruz ve yeni resmi oluşturuyoruz.
                    Image newImage = img.GetThumbnailImage(tempWidth, tempHeight, null, new System.IntPtr());
                    // MemoryStream sınıfını kullanarak resmin çıktısını oluşturuyoruz.
                    using (MemoryStream ms = new MemoryStream())
                    {
                        if (FileExtension.IndexOf("jpg") > -1)
                        {
                            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        else if (FileExtension.IndexOf("png") > -1)
                        {
                            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        else if (FileExtension.IndexOf("gif") > -1)
                        {
                            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                        }
                        else
                        {
                            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        }
                        buffer = ms.ToArray();
                    }
                }
                return buffer;
            }
            else 
            {
                return null;
            }
        }
    }
}