namespace backtpp.Interfaces
{
    public interface IGenericService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity data);
        bool Delete(long id);
        void Update(TEntity data);

    }
}
