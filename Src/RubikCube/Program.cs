using RubikCube.Application;

namespace RubikCube;

class Program
{
    static void Main(string[] args)
    {
        const string sequence = "F R' U B' L D'";
        var cube = new RubikCube.Domain.RubikCube();
        cube.Rotate(StringRotationsMapper.Map(sequence));
        
        var lines = RubikCubeTextPresenter.Present(cube);
        
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
}