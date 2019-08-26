namespace TestLogsAnalyzer.Lib
{
    public interface ILogAnalyzer
    {
        void ShowNonPassingTestsList<T>(T t);
    }
}