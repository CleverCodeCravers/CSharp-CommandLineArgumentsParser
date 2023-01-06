namespace CSharp_CommandLineArgumentsParser;

public interface IBoolCommandLineOption : ICommandLineOption
{
    bool GetValue();
}