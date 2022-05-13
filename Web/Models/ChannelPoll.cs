namespace Web.Models;

// TODO: Add a URL method/property for linking to the Poll from the Web channel page.
// Or add it to IChannel?
public class ChannelPoll
{
    public int Id { get; set; }
    public PollChannel Channel { get; set; }
    public string Identifier { get; set; } = null!;
    public Poll Poll { get; set; } = null!;
}