using Core.Entities;

namespace Entities.Concrete
{
    public class Question : IEntity
    {
        public int QuestionId { get; set; }
        public string _Question { get; set; }
    }

}