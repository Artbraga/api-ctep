namespace Entities.Base
{
    public abstract class BaseDTO<T> : BaseDTO where T : BaseEntity
    {
        protected BaseDTO() { }
        protected BaseDTO(T entity) { }
        public abstract T ToEntity();
    }

    public abstract class BaseDTO
    {
        public int Id { get; set; }
    }
}
