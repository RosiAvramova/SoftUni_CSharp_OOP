namespace P4.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        private const int MinSecondsValue = 0;
        private const int MazSecondsValue = 59;

        public override string Message => $"Song seconds should be between {MinSecondsValue} and {MazSecondsValue}.";
    }
}
