using System;

public class SystemTime
{
    private static DateTime _date;

    public static void Set(DateTime custom)
    {
        _date = custom;
    }


    public static void Reset()
    {
        _date=DateTime.MinValue;

        
    }

    public static DateTime Now { get { return _date; }}


}