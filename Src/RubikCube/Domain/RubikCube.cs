namespace RubikCube.Domain;

/// <summary>
/// The domain object representing a Rubik's Cube.
/// </summary>
public class RubikCube
{
    private readonly IDictionary<FaceType, Face> _faces;
    
    /// <summary>
    /// Creates a new instance of the Rubik's Cube which is solved.
    /// </summary>
    public RubikCube()
    {
        _faces = new Dictionary<FaceType, Face>
        {
            { FaceType.Front, new Face(FaceType.Front, TileColor.Green) },
            { FaceType.Right, new Face(FaceType.Right, TileColor.Red) },
            { FaceType.Up, new Face(FaceType.Up, TileColor.White) },
            { FaceType.Down, new Face(FaceType.Down, TileColor.Yellow) },
            { FaceType.Left, new Face(FaceType.Left, TileColor.Orange) },
            { FaceType.Back, new Face(FaceType.Back, TileColor.Blue) }
        };
    }

    /// <summary>
    /// Gets the faces of the cube.
    /// </summary>
    public IEnumerable<Face> Faces => _faces.Values;

    /// <summary>
    /// Rotates the specified face of the cube in the specified direction by 90 degrees.
    /// </summary>
    /// <param name="faceType">The face which should be rotated.</param>
    /// <param name="direction">The direction of the rotation.</param>
    public void Rotate(FaceType faceType, RotateDirection direction)
    {
        if (_faces.TryGetValue(faceType, out var face))
        {
            face.Rotate(direction);
        }
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