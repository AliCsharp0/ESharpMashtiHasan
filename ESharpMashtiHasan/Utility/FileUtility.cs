using Microsoft.AspNetCore.Routing.Constraints;
using System.Globalization;

namespace ESharpMashtiHasan.Utility
{
    public static class FileUtility
    {
        public static bool IsValidImageSize( this IFormFile file , int RefrenceID)
        {
            long fileSize = file.Length;
            if (fileSize < 40960 || fileSize > 2097152)// in bar asase bite choon formfile be ma bar asase bite mghdar mideh
            {
                return false;
            }
            return true;
        }
    }
}
