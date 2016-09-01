using OmarStory.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace OmarStory.Converters
{
    public static class BitmapConversion
    {
        public static Bitmap ToWinFormsBitmap(this BitmapSource bitmapsource)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(stream);

                using (var tempBitmap = new Bitmap(stream))
                {
                    // According to MSDN, one "must keep the stream open for the lifetime of the Bitmap."
                    // So we return a copy of the new bitmap, allowing us to dispose both the bitmap and the stream.
                    return new Bitmap(tempBitmap);
                }
            }
        }

        public static BitmapSource ToWpfBitmap(this Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);

                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        } 
    }

    public static class Support
    {
        public static int ToInt(this string str)
        {
            int id;
            return Int32.TryParse(str, out id) ? id : -1;
        }

        public static string GetNameItem(Result result)
        {
            switch (result.Code)
            {
                case ("O"):
                {
                   return Global.AllItemsDB.AllObjects.Single(x => x.Id == result.Id).Name;
                }
                case ("B"):
                {
                    return Global.AllItemsDB.AllBackgrounds.Single(x => x.Id == result.Id).Name;
                }
                case ("F"):
                {
                    return Global.AllItemsDB.AllChars.Single(x => x.Id == result.Id).Name;
                }
                case ("S"):
                {
                    return Global.AllItemsDB.AllStatuses.Single(x => x.Id == result.Id).Name;
                }
                default:
                {
                  return string.Empty;
                }
            }
        }
    }

    public static class Deserialize
    {
        public static IEnumerable<Condition> ToListConditions(string str)
        {
            List<Condition> conditions = new List<Condition>();

            foreach (var cond in str.Split('.'))
            {
                conditions.Add(new Condition(cond));
            }

            return conditions;
        }

        public static string FromListConditions(IEnumerable<Condition> conditions)
        {
            string stringConditions = String.Empty;

            foreach (var condition in conditions)
            {
                stringConditions += condition.Raw + ".";
            }
            stringConditions = stringConditions.Substring(0, stringConditions.Length - 1);

            return stringConditions;
        }

        public static IEnumerable<Result> ToListResults(string str)
        {
            List<Result> result = new List<Result>();

            foreach (var res in str.Split('.'))
            {
                if (res != string.Empty)
                {
                    result.Add(new Result(res));
                }
            }

            return result;
        }

        public static string FromListResults(IEnumerable<Result> results)
        {
            string stringResult = String.Empty;

            foreach (var result in results)
            {
                stringResult += result.Raw + ".";
            }
            stringResult = stringResult.Substring(0, stringResult.Length - 1);

            return stringResult;
        }
    }
}
