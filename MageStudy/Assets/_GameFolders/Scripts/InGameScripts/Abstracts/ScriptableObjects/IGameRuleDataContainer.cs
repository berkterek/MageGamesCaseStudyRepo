namespace MageStudy.Abstracts.ScriptableObjects
{
    public interface IGameRuleDataContainer
    {
        public int CorrectAnswerPoint { get; }
        public int WrongAnswerPoint { get; }
        public int TimesEndPoint { get; }
    }
}