using RubikCube.Domain.Extensions;

namespace RubikCube.Domain;

/// <summary>
/// The domain object representing a face of a Rubik's Cube. 
/// </summary>
public class Face
{
    private static readonly IDictionary<Tuple<int, int>, int> TilesPositionMap = new Dictionary<Tuple<int, int>, int>
    {
        { new Tuple<int, int>(0, 0), 0},
        { new Tuple<int, int>(1, 0), 1},
        { new Tuple<int, int>(2, 0), 2},
        { new Tuple<int, int>(2, 1), 3},
        { new Tuple<int, int>(2, 2), 4},
        { new Tuple<int, int>(1, 2), 5},
        { new Tuple<int, int>(0, 2), 6},
        { new Tuple<int, int>(0, 1), 7},
    };
    
    private readonly TileColor _color;
    private readonly TileColor[] _tiles;

    /// <summary>
    /// Creates a new instance of the face with all tiles of specified color.
    /// </summary>
    /// <param name="faceType">The type of the face</param>
    /// <param name="color">The color of face's tiles</param>
    internal Face(FaceType faceType, TileColor color)
    {
        Type = faceType;
        _color = color;
        _tiles = Enumerable.Repeat(color, 8).ToArray();
    }

    /// <summary>
    /// Gets face type.
    /// </summary>
    public FaceType Type { get; }

    /// <summary>
    /// Gets tile color at specified position.
    /// </summary>
    /// <param name="x">Tile x position (from 0 to 2)</param>
    /// <param name="y">Tile y position (from 0 to 2)</param>
    /// <returns>Color of the tile</returns>
    public TileColor GetTile(int x, int y)
    {
        if (x == 1 && y == 1)
        {
            return _color;
        }

        if (TilesPositionMap.TryGetValue(Tuple.Create(x, y), out var index))
        {
            return _tiles[index];
        }

        throw new ArgumentException($"Position ({x}, {y}) is not valid.");
    }

    /// <summary>
    /// Rotates the face in the specified direction.
    /// </summary>
    /// <param name="direction">Rotation direction.</param>
    public void Rotate(RotateDirection direction)
    {
        if (direction == RotateDirection.Clockwise)
        {
            _tiles.ShiftRight(2);
            
            // TODO: Shift adjacent tiles
        }
        else
        {
            // TODO: Implement counter-clockwise rotation
        }
    }
}