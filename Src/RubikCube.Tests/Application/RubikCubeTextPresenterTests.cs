using RubikCube.Application;

namespace RubikCube.Tests.Application;

public class RubikCubeTextPresenterTests
{
    [Fact]
    public void WhenCubeIsInInitialState_ShouldPresentCorrectly()
    {
        // Arrange
        var cube = new RubikCube.Domain.RubikCube();
        
        // Act
        var result = RubikCubeTextPresenter.Present(cube);
        
        // Assert
        Assert.Equal("   WWW      ", result[0]);
        Assert.Equal("   WWW      ", result[1]);
        Assert.Equal("   WWW      ", result[2]);
        Assert.Equal("OOOGGGRRRBBB", result[3]);
        Assert.Equal("OOOGGGRRRBBB", result[4]);
        Assert.Equal("OOOGGGRRRBBB", result[5]);
        Assert.Equal("   YYY      ", result[6]);
        Assert.Equal("   YYY      ", result[7]);
        Assert.Equal("   YYY      ", result[8]);
    }
}