using RubikCube.Application;
using RubikCube.Domain;

namespace RubikCube.Tests.Application;

public class StringRotationsMapperTests
{
    [Theory]
    [MemberData(nameof(ValidRotations))]
    public void ShouldMapValidStringToRotations(string input, Tuple<FaceType, RotateDirection>[] expected)
    {
        // Act
        var result = StringRotationsMapper.Map(input);

        // Assert
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> ValidRotations =
    [
        ["", new Tuple<FaceType, RotateDirection>[] { }],
        ["   ", new Tuple<FaceType, RotateDirection>[] { }],

        ["F", new[] { Tuple.Create(FaceType.Front, RotateDirection.Clockwise) }],
        ["R", new[] { Tuple.Create(FaceType.Right, RotateDirection.Clockwise) }],
        ["U", new[] { Tuple.Create(FaceType.Up, RotateDirection.Clockwise) }],
        ["D", new[] { Tuple.Create(FaceType.Down, RotateDirection.Clockwise) }],
        ["L", new[] { Tuple.Create(FaceType.Left, RotateDirection.Clockwise) }],
        ["B", new[] { Tuple.Create(FaceType.Back, RotateDirection.Clockwise) }],

        ["F'", new[] { Tuple.Create(FaceType.Front, RotateDirection.CounterClockwise) }],
        ["R'", new[] { Tuple.Create(FaceType.Right, RotateDirection.CounterClockwise) }],
        ["U'", new[] { Tuple.Create(FaceType.Up, RotateDirection.CounterClockwise) }],
        ["D'", new[] { Tuple.Create(FaceType.Down, RotateDirection.CounterClockwise) }],
        ["L'", new[] { Tuple.Create(FaceType.Left, RotateDirection.CounterClockwise) }],
        ["B'", new[] { Tuple.Create(FaceType.Back, RotateDirection.CounterClockwise) }],

        [
            "F R'", new[]
            {
                Tuple.Create(FaceType.Front, RotateDirection.Clockwise),
                Tuple.Create(FaceType.Right, RotateDirection.CounterClockwise)
            }
        ],
        
        [
            "  f   R'  r  ", new[]
            {
                Tuple.Create(FaceType.Front, RotateDirection.Clockwise),
                Tuple.Create(FaceType.Right, RotateDirection.CounterClockwise),
                Tuple.Create(FaceType.Right, RotateDirection.Clockwise)
            }
        ],
    ];
}