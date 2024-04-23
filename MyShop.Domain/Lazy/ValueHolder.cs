using System;

namespace MyShop.Domain.Lazy;

public interface IValueHolder<T>
{
    T GetValue(object parameter);
}
public class ValueHolder<T>(Func<object, T> getValue) : IValueHolder<T>
{
    private readonly Func<object, T> getValue = getValue;
    private T value;

    public T GetValue(object parameter)
    {
        value ??= getValue(parameter);

        return value;
    }
}
