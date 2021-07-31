using WebAutopark.Core.Entities.Base;

namespace WebAutopark.Core.Entities
{
    public class Detail : Entity
    {
        public int DetailId { get; set; }
        
        public string Name { get; set; }

        public override string EntityName => "Detail";
    }
}
