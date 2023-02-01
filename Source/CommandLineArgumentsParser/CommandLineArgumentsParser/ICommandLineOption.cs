namespace CommandLineArgumentsParser;

public interface ICommandLineOption
{
    string Name { get; }

    bool HasNoValueYet();
    string Description { get; }
    bool TryParseFrom(string[] args, ref int position);
    bool IsTypeWithSeparateValue { get; }
}