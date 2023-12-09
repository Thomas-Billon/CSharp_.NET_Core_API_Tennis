namespace Tennis.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);
        public bool Create(T item);
        public bool Update(T item);
        public bool Delete(int id);
        public bool Save();
    }
}
