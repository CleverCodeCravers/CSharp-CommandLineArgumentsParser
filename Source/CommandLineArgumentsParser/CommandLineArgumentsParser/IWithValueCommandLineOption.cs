namespace CommandLineArgumentsParser;

public interface IWithValueCommandLineOption<T> : ICommandLineOption {
    T? GetValue();
}