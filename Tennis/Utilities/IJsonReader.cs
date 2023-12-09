namespace Tennis.Utilities
{
    public interface IJsonReader
    {
        public T? Read<T>(string filePath);
    }
}
