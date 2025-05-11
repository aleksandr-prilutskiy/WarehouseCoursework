using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WarehouseCoursework.ClassFolder
{
    internal class Img
    {
        public static BitmapImage ConvertByteArrayToImage(byte[] array)
        {
            if (array != null) //если байтовый массив не пустой
            {
                using (var ms = new MemoryStream(array, 0, array.Length)) //записываем полученные данные в массив для дальнейшего преобразования
                {
                    var image = new BitmapImage(); //Инициализирует новый экземпляр класса BitmapImage, 
                                                   //который в основном существует для поддержки синтаксиса XAML (XAML) 
                                                   //и предоставляет дополнительные свойства для загрузки битовой карты
                    image.BeginInit(); //Сигнализирует о начале инициализации объекта BitmapImage.
                    image.CacheOption = BitmapCacheOption.OnLoad; //CacheOption Получает BitmapCacheOption для использования данным экземпляром BitmapImage.
                                                                  //BitmapCacheOption.OnLoad Кэширует в памяти все изображение во время загрузки. Все запросы данных изображения выполняются из хранилища в памяти.
                    image.StreamSource = ms; //Получает исходный поток BitmapImage.
                    image.EndInit(); //Сигнализирует о завершении инициализации объекта BitmapImage.
                    return image;
                }
            }
            return null;
        }

        public static byte[] ConvertImageToByteArray(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;
            Bitmap bitMap = new Bitmap(fileName);
            ImageFormat bmpFormat = bitMap.RawFormat;
            var imageToConvert = System.Drawing.Image.FromFile(fileName);
            using (var ms = new MemoryStream())
            {
                imageToConvert.Save(ms, bmpFormat);
                return ms.ToArray();
            }
        }

        public static byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
    }
}
