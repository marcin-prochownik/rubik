namespace RubikCube.Domain.Extensions;

public static class ArrayExtensions
{
    public static void ShiftRight<T>(this T[] array, int count)
    {
        for (var i = 0; i < count; i++)
        {
            array.ShiftRightOnce();
        }
    }
    
    private static void ShiftRightOnce<T>(this T[] array)
    {
        T last = array[^1];
        
        for (var i = array.Length - 1; i > 0; i--)
        {
            array[i] = array[i - 1];
        }
        
        array[0] = last;
    }
}