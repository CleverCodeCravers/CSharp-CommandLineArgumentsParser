namespace CommandLineArgumentsParser;

public interface IBoolCommandLineOption : ICommandLineOption
{
    bool GetValue();
}