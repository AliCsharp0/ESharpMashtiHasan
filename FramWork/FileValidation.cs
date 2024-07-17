using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramWork
{
	public static class FileValidation
	{
		public static bool IsValidFileName(this string fileName)
		{
			fileName = Path.GetFileName(fileName).ToLower().Trim();//Path.GetFileName in ezafeh haie file ro delete mikone va be name mirese
			if (fileName.Contains(".asp") || fileName.Contains(".py") || fileName.Contains(".jsp") || fileName.Contains(".php") || fileName.Contains(".exe"))
			{
				return false;
			}
			return true;
		}
        public static string ToPersianDateForFileName(this DateTime time)
        {
            PersianCalendar pc = new PersianCalendar();
            return $"{pc.GetYear(time).ToString()}_{pc.GetMonth(time).ToString()}_{pc.GetDayOfMonth(time).ToString()}_{time.Hour.ToString()}_{time.Minute.ToString()}_{time.Second.ToString()}_{time.Millisecond.ToString()}";
        }

        public static string ToUniqueFileName(this string FileName)
        {
            return $"{Guid.NewGuid().ToString().Replace("-", "")}__{DateTime.Now.ToPersianDateForFileName()}_{System.IO.Path.GetFileName(FileName.ToLower())}";// agar user name image ro address kamel be ma dade bashe ba in ravesh  faghat tike aghare name ro  ke ma niaz darim ro behmon mideh
        }
    }
}
