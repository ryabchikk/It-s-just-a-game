public class Subtitles
{
    private static SubtitlesObject _subtitlesObject;
    
    public static void Show(string message)
    {
        _subtitlesObject.Notify(message);
    }
    
    internal static void CreateNotificator(SubtitlesObject subtitlesObject)
    {
        _subtitlesObject = subtitlesObject;
    }
}
