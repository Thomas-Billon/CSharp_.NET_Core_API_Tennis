namespace Tennis.Data
{
    public interface IJsonReader
    {
        public T? Read<T>(string filePath);
    }
}
