namespace Repository.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
        void Dispose();
    }
}