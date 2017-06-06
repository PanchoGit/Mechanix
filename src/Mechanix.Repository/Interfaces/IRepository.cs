namespace Mechanix.Repository.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        TEntity Get(TId id);

        TEntity Save(TEntity entity);

        void Delete(TId id);
    }
}
