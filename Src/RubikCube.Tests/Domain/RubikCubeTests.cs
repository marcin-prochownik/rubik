using RubikCube.Application;
using RubikCube.Domain;

namespace RubikCube.Tests.Domain;

public class RubikCubeTests
{
    [Fact]
    public void WhenCubesFrontFaceIsRotatedClockWise_ThenFrontFaceShouldBeRotatedCorrectly()
    {
        // Arrange
        var cube = new RubikCube.Domain.RubikCube();
        
        // Act
        cube.Rotate(FaceType.Front, RotateDirection.Clockwise);
        
        // Assert
        AssertCubeLook(cube, [
            "   WWW      ",
            "   WWW      ",
            "   OOO      ",
            "OOYGGGWRRBBB",
            "OOYGGGWRRBBB",
            "OOYGGGWRRBBB",
            "   RRR      ",
            "   YYY      ",
            "   YYY      "
        ]);
    }
    
    private static void AssertCubeLook(RubikCube.Domain.RubikCube cube, string[] expected)
    {
        var actual = RubikCubeTextPresenter.Present(cube);
        
        for (var i = 0; i < 9; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }
}