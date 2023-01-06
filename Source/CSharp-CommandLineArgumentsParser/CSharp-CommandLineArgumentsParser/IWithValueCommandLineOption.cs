namespace CSharp_CommandLineArgumentsParser;

public interface IWithValueCommandLineOption<T> : ICommandLineOption {
    T? GetValue();
}