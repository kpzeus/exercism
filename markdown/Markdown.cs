using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private const string MARKDOWN_DOUBLE_UNDERSCORE = "__";
    private const string MARKDOWN_SINGLE_UNDERSCORE = "_";
    private const char MARKDOWN_HASHMARK = '#';
    private const string MARKDOWN_ASTERISK = "*";

    private const string OPEN_TAG = "<";
    private const string CLOSE_TAG = ">";
    private const string END_TAG = "/";
    private const string OPEN_END_TAG = OPEN_TAG + END_TAG;

    private const string HTML_STRONG_TAG = "strong";
    private const string HTML_EMPHASIZED_TAG = "em";
    private const string HTML_HEADER_TAG = "h";
    private const string HTML_UNORDERED_LIST_TAG = "ul";
    private const string HTML_LIST_ITEM_TAG = "li";
    private const string HTML_PARAGRAPH_TAG = "p";

    private const string HTML_START_UNORDERED_LIST = OPEN_TAG + HTML_UNORDERED_LIST_TAG + CLOSE_TAG;
    private const string HTML_END_UNORDERED_LIST = OPEN_END_TAG + HTML_UNORDERED_LIST_TAG + CLOSE_TAG;

    private const string REGEX_MATCH_CONTENTS = "$1";

    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        StringBuilder result = new StringBuilder();
        var inList = false;

        for (int index = 0; index < lines.Length; index++)
        {
            var lineResult = ParseLine(lines[index], ref inList);
            result.Append(lineResult);
        }

        if (inList)
        {
            result.Append(HTML_END_UNORDERED_LIST);
        }
        return result.ToString();
    }

    private static string ParseLine(string markdown, ref bool inList)
    {
        var result = AttemptToParseHeader(markdown, ref inList);
        if (result != null)
        {
            return result;
        }

        result = AttemptToParseLineItem(markdown, ref inList);
        if (result != null)
        {
            return result;
        }

        result = AttemptToParseParagraph(markdown, ref inList);
        if (result != null)
        {
            return result;
        }

        throw new ArgumentException();
    }

    private static string WrapContentWithHTMLTag(string text, string tag)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(OPEN_TAG);
        sb.Append(tag);
        sb.Append(CLOSE_TAG);

        sb.Append(text);

        sb.Append(OPEN_END_TAG);
        sb.Append(tag);
        sb.Append(CLOSE_TAG);

        return sb.ToString();
    }

    private static string Parse(string markdown, string delimiter, string tag)
    {
        var pattern = delimiter + "(.+)" + delimiter;
        var replacement = WrapContentWithHTMLTag(REGEX_MATCH_CONTENTS, tag);
        return Regex.Replace(markdown, pattern, replacement);
    }

    private static string ParseDoubleUnderscore(string markdown) => Parse(markdown, MARKDOWN_DOUBLE_UNDERSCORE, HTML_STRONG_TAG);

    private static string ParseSingleUnderscore(string markdown) => Parse(markdown, MARKDOWN_SINGLE_UNDERSCORE, HTML_EMPHASIZED_TAG);

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = ParseSingleUnderscore(ParseDoubleUnderscore((markdown)));

        if (list)
        {
            return parsedText;
        }
        return WrapContentWithHTMLTag(parsedText, HTML_PARAGRAPH_TAG);
    }

    private static string AttemptToParseHeader(string markdown, ref bool inList)
    {
        var count = 0;

        for (int index = 0; index < markdown.Length; index++)
        {
            if (markdown[index] != MARKDOWN_HASHMARK)
            {
                break;
            }
            count += 1;
        }

        if (count == 0)
        {
            return null;
        }

        var headerTag = HTML_HEADER_TAG + count;
        var headerHtml = WrapContentWithHTMLTag(markdown.Substring(count + 1), headerTag);

        if (inList)
        {
            inList = false;
            return HTML_END_UNORDERED_LIST + headerHtml;
        }
        return headerHtml;
    }

    private static string AttemptToParseLineItem(string markdown, ref bool inList)
    {
        if (markdown.StartsWith(MARKDOWN_ASTERISK))
        {
            var innerHtml = WrapContentWithHTMLTag(ParseText(markdown.Substring(2), true), HTML_LIST_ITEM_TAG);

            if (inList)
            {
                return innerHtml;
            }
            else
            {
                inList = true;
                return HTML_START_UNORDERED_LIST + innerHtml;
            }
        }
        return null;
    }

    private static string AttemptToParseParagraph(string markdown, ref bool inList)
    {
        bool wasInList = inList;
        inList = false;

        if (!wasInList)
        {
            return ParseText(markdown, false);
        }
        return "</ul>" + ParseText(markdown, false);
    }
}