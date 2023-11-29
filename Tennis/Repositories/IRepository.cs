namespace Tennis.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> List();
        public T Get(int id);
        public bool Create(T item);
        public bool Edit(T item);
        public bool Delete(int id);
        public bool SaveChanges();
    }
}
