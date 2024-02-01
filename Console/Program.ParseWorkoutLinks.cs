using AngleSharp.Dom;
using AngleSharp.Html.Dom;

public partial class Program
{
    public static List<string> ParseWorkoutLinks(IDocument document)
    {
        IHtmlAnchorElement[] links = document
            .QuerySelectorAll(".et_pb_button")
            .Cast<IHtmlAnchorElement>()
            .ToArray();

        List<string> stringLinks = [];
        stringLinks.AddRange(links.Select(link => link.Href));

        return stringLinks;
    }
}