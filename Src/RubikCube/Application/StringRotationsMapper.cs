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
        switch (input)
        {
            case "F": return Tuple.Create(FaceType.Front, RotateDirection.Clockwise);
            case "B": return Tuple.Create(FaceType.Back, RotateDirection.Clockwise);
            case "U": return Tuple.Create(FaceType.Up, RotateDirection.Clockwise);
            case "D": return Tuple.Create(FaceType.Down, RotateDirection.Clockwise);
            case "L": return Tuple.Create(FaceType.Left, RotateDirection.Clockwise);
            case "R": return Tuple.Create(FaceType.Right, RotateDirection.Clockwise);

            case "F'": return Tuple.Create(FaceType.Front, RotateDirection.CounterClockwise);
            case "B'": return Tuple.Create(FaceType.Back, RotateDirection.CounterClockwise);
            case "U'": return Tuple.Create(FaceType.Up, RotateDirection.CounterClockwise);
            case "D'": return Tuple.Create(FaceType.Down, RotateDirection.CounterClockwise);
            case "L'": return Tuple.Create(FaceType.Left, RotateDirection.CounterClockwise);
            case "R'": return Tuple.Create(FaceType.Right, RotateDirection.CounterClockwise);

            default:
                throw new ArgumentException($"Specified rotation '{input}' is not valid.");
        }
    }
}