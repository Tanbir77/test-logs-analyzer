namespace TestLogsAnalyzer.Lib
{
    public interface IReadableFile
    {
        void LoadContent(string fileName);
        T GetContent<T>();
    }
}
