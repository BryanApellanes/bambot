namespace Bambot.Etc
{
    public interface IShadowPasswordSetter
    {
        string Salt { get; set; }
        ShadowPassword Set(string password);
    }
}