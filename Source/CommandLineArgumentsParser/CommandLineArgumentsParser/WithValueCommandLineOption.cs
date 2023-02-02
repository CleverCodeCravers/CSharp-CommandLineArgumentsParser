﻿namespace CommandLineArgumentsParser;

public abstract class WithValueCommandLineOption<T> : IWithValueCommandLineOption<T>
{
    public string Name { get; }

    public bool IsTypeWithSeparateValue => true;

    private T? _value;
    private bool _hasValue = false;
    public string Description { get; }
    public WithValueCommandLineOption(
        string name,
        string description,
        T? defaultValue)
    {
        Name = name;
        _value = defaultValue;
        Description = description;
    }

    public T? GetValue()
    {
        return _value;
    }

    public bool HasNoValueYet()
    {
        return !_hasValue;
    }

    public bool TryParseFrom(string[] args, ref int position)
    {
        var myName = Name.ToLower().Trim(); 
        var arg = args[position].ToLower().Trim();

        if (myName == arg) {
            if (args.Length <= position +1) {
                throw new Exception("Value missing for " + myName);
            }

            try {
                _value = ValidateAndParseValue(args[position+1]);
                _hasValue = true;
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
            position += 2;
            return true;
        }

        return false;
    }

    protected abstract T? ValidateAndParseValue(string value);
}