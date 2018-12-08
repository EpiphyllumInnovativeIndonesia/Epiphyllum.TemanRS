using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Epiphyllum.TemanRS.Core.Helpers
{
    /// <summary>
    /// Represents a json helpers
    /// </summary>
    public static partial class JsonHelpers
    {
        /// <summary>
        /// Determine the json object is a valid json
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsValidJson(this string text)
        {
            text = text.Trim();
            if ((text.StartsWith("{") && text.EndsWith("}")) || //For object
                (text.StartsWith("[") && text.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(text);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
