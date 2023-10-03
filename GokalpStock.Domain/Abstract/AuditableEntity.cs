namespace GokalpStock.Domain.Abstract
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set;}
    }
}
