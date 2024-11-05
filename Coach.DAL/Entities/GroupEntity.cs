using System.ComponentModel.DataAnnotations.Schema;

namespace Coach.DAL.Entities
{
    public class GroupEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public short Price { get; set; }             
        public List<SportsmenEntity> Sportsmens { get; set; } = [];
    }
}
