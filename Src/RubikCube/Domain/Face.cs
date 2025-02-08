namespace RubikCube.Domain;

/// <summary>
/// The domain object representing a face of a Rubik's Cube. 
/// </summary>
public class Face
{
    private readonly TileColor _color;
    private readonly TileColor[] _tiles;

    /// <summary>
    /// Creates a new instance of the face with all tiles of specified color.
    /// </summary>
    /// <param name="color"></param>
    public Face(TileColor color)
    {
        _color = color;
        _tiles = Enumerable.Repeat(color, 8).ToArray();
    }
}