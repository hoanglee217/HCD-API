// File: YourProject.SharedKernel/Common/Utils/SlugGenerator.cs

using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Hcd.Common.Interfaces;

namespace Hcd.Infrastructure.Services
{
    public class SlugGenerator : ISlugGenerator
    {
        /// <summary>
        /// Converts a string to a URL-friendly slug.
        /// Handles Vietnamese characters and other special cases.
        /// </summary>
        /// <param name="value">The string to convert</param>
        /// <returns>A URL-friendly slug</returns>
        public string ToSlug(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            // Replace Đ/đ with D/d
            value = value.Replace("Đ", "D").Replace("đ", "d");

            // Convert to lowercase
            value = value.ToLowerInvariant();

            // Normalize Unicode (remove diacritics)
            value = RemoveDiacritics(value);

            // Remove special characters
            value = Regex.Replace(value, @"[^a-z0-9\s-]", "");

            // Replace spaces with hyphens
            value = Regex.Replace(value, @"\s+", "-");

            // Remove duplicate hyphens
            value = Regex.Replace(value, @"-+", "-");

            // Trim hyphens from start and end
            return value.Trim('-');
        }

        /// <summary>
        /// Helper method to remove diacritics (accent marks)
        /// </summary>
        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            foreach (char c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}