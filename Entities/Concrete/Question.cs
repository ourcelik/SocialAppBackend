using Core.Entities;

namespace Entities.Concrete
{
    public class Question : IEntity
    {
        public int QuestionId { get; set; }
        public string QuestionType { get; set; }
    }

}