using RubikCube.Domain;

namespace RubikCube.Application;

public static class RubikCubeTextPresenter
{
    public static string[] Present(Domain.RubikCube cube)
    {
        var screen = new char[9][];
        
        for (var i = 0; i < 9; i++)
        {
            screen[i] = Enumerable.Repeat(' ', 12).ToArray();
        }

        foreach (var face in cube.Faces)
        {
            PresentFace(face, screen);
        }
        
        return screen.Select(x => new string(x)).ToArray();
    }

    private static void PresentFace(Face face, char[][] screen)
    {
        var (cx, cy) = GetFacePosition(face.Type);

        for (var y = 0; y < 3; ++y)
        {
            for (var x = 0; x < 3; ++x)
            {
                screen[cy + y - 1][cx + x - 1] = GetTileColorAsChar(face.GetTile(x, y));
            }
        }
    }

    private static char GetTileColorAsChar(TileColor tileColor)
    {
        return tileColor switch
        {
            TileColor.White => 'W',
            TileColor.Yellow => 'Y',
            TileColor.Green => 'G',
            TileColor.Blue => 'B',
            TileColor.Red => 'R',
            TileColor.Orange => 'O',
            _ => throw new ArgumentOutOfRangeException(nameof(tileColor), tileColor, "Unknown tile color.")
        };
    }

    private static (int, int) GetFacePosition(FaceType faceType)
    {
        return faceType switch
        {
            FaceType.Up => (4, 1),
            FaceType.Left => (1, 4),
            FaceType.Front => (4, 4),
            FaceType.Right => (7, 4),
            FaceType.Back => (10, 4),
            FaceType.Down => (4, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(faceType), faceType, "Unknown face type.")
        };
    }
}