namespace MageStudy.DataEntities
{
    public partial struct QuestionEntity
    {
        public string Category { get; set; }
        public string Question { get; set; }
        public string[] Choices { get; set; }
        public string Answer{ get; set; }
    }
}