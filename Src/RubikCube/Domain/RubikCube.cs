namespace RubikCube.Domain;

/// <summary>
/// The domain object representing a Rubik's Cube.
/// </summary>
public class RubikCube
{
    private IDictionary<FaceType, Face> _faces;
    
    /// <summary>
    /// Creates a new instance of the Rubik's Cube which is solved.
    /// </summary>
    public RubikCube()
    {
        _faces = new Dictionary<FaceType, Face>
        {
            { FaceType.Front, new Face(TileColor.Green) },
            { FaceType.Right, new Face(TileColor.Red) },
            { FaceType.Up, new Face(TileColor.White) },
            { FaceType.Down, new Face(TileColor.Yellow) },
            { FaceType.Left, new Face(TileColor.Orange) },
            { FaceType.Back, new Face(TileColor.Blue) }
        };
    }

    /// <summary>
    /// Rotates the specified face of the cube in the specified direction by 90 degrees.
    /// </summary>
    /// <param name="face">The face which should be rotated.</param>
    /// <param name="direction">The direction of the rotation.</param>
    public void Rotate(FaceType face, RotateDirection direction)
    {
        // TODO: Implement the rotation logic
    }
    
    /// <summary>
    /// Performs a sequence of rotations on the cube.
    /// </summary>
    /// <param name="rotations">A collection of rotations.</param>
    public void Rotate(params Tuple<FaceType, RotateDirection>[] rotations)
    {
        foreach (var (faceType, direction) in rotations)
        {
            Rotate(faceType, direction);
        }
    }
}