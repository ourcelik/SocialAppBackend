using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.GraphQL
{
    public class Match : Entities.Concrete.Match, IEntity
    {
        [NotMapped]
        public Profile MatchProfile { get; set; }
        [NotMapped]
        public Profile MatchedProfile { get; set; }
        [NotMapped]
        public ChatLevel  ChatLevel { get; set; }

    }

}