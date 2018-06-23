namespace NetCore.Infrastructure.SharedKernel
{
    public abstract class DomainEntity<T>
    {
        public T Id { set; get; }

        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}