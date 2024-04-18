using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ParseNotificationChannels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Static input titles
            string[] inputTitles = {
                "[BE][FE][Urgent] there is error",
                "[BE][QA][HAHA][Urgent] there is error"
            };

            // Print result from inputTitles list with Parsed channels.
            int cases = 1;
            foreach (var title in inputTitles)
            {
                List<string> channels = ParseNotificationChannels(title);
                Console.WriteLine($"Case : "\{cases}\"");
                Console.WriteLine($"Input: \"{title}\"");
                Console.WriteLine($"Output: Receive channels: {string.Join(", ", channels)}\n");
                cases = cases + 1;
            }
        }

        static List<string> ParseNotificationChannels(string title)
        {
            List<string> channels = new List<string>();

            // Regular expression pattern to match tags enclosed in square brackets
            Regex regex = new Regex(@"\[(.*?)\]");
            MatchCollection matches = regex.Matches(title);

            foreach (Match match in matches)
            {
                string tag = match.Groups[1].Value.Trim();

                if (tag.Equals("BE", StringComparison.OrdinalIgnoreCase) ||
                    tag.Equals("FE", StringComparison.OrdinalIgnoreCase) ||
                    tag.Equals("QA", StringComparison.OrdinalIgnoreCase) ||
                    tag.Equals("Urgent", StringComparison.OrdinalIgnoreCase))
                {
                    channels.Add(tag);
                }
            }

            return channels;
        }
    }
}