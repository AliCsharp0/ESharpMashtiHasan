using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramWork
{
	public class FileValidation
	{
		public static bool IsValidFileName(string fileName)
		{
			fileName = Path.GetFileName(fileName).ToLower().Trim();//Path.GetFileName in ezafeh haie file ro delete mikone va be name mirese
			if (fileName.Contains(".asp") || fileName.Contains(".py") || fileName.Contains(".jsp") || fileName.Contains(".php") || fileName.Contains(".exe"))
			{
				return false;
			}
			return true;
		}

		public static bool IsValidImageSize(long fileSize)
		{
			if (fileSize < 40960 || fileSize > 2097152)// in bar asase bite choon formfile be ma bar asase bite mghdar mideh
			{
				return false;
			}
			return true;
		}
	}
}
