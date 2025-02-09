using RubikCube.Domain;

namespace RubikCube.Application;

public static class StringRotationsMapper
{
    /// <summary>
    /// Converts a string to a list of rotations.
    /// </summary>
    /// <remarks>
    /// String format:
    /// - whitespace separated collection of rotations
    /// - each rotation is a single character: F, B, L, R, U, D
    /// - each rotation can be followed by a single character ' for counter-clockwise rotation
    ///
    /// Example: "F R' U"
    /// </remarks>
    /// <param name="input"></param>
    /// <returns>The collection of rotations.</returns>
    public static Tuple<FaceType, RotateDirection>[] Map(string input)
    {
        return input.ToUpper().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(ParseSingleRotation)
            .ToArray();
    }

    private static Tuple<FaceType, RotateDirection> ParseSingleRotation(string input)
    {
        return input switch
        {
            "F" => Tuple.Create(FaceType.Front, RotateDirection.Clockwise),
            "B" => Tuple.Create(FaceType.Back, RotateDirection.Clockwise),
            "U" => Tuple.Create(FaceType.Up, RotateDirection.Clockwise),
            "D" => Tuple.Create(FaceType.Down, RotateDirection.Clockwise),
            "L" => Tuple.Create(FaceType.Left, RotateDirection.Clockwise),
            "R" => Tuple.Create(FaceType.Right, RotateDirection.Clockwise),
            "F'" => Tuple.Create(FaceType.Front, RotateDirection.CounterClockwise),
            "B'" => Tuple.Create(FaceType.Back, RotateDirection.CounterClockwise),
            "U'" => Tuple.Create(FaceType.Up, RotateDirection.CounterClockwise),
            "D'" => Tuple.Create(FaceType.Down, RotateDirection.CounterClockwise),
            "L'" => Tuple.Create(FaceType.Left, RotateDirection.CounterClockwise),
            "R'" => Tuple.Create(FaceType.Right, RotateDirection.CounterClockwise),
            _ => throw new ArgumentException($"Specified rotation '{input}' is not valid.")
        };
    }
}