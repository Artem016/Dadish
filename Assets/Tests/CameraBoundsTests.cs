using NUnit.Framework;
using UnityEngine;
using UnityEngine.Assertions;


public class CameraBoundsTests
{
    [Test]
    public void CameraPositionWithinBounds_ReturnsTrue()
    {
        float camX = 5f;
        Vector2 bottomLeft = new Vector2(0f, 0f);
        Vector2 topRight = new Vector2(10f, 10f);

        bool result = CameraFollow.IsCameraPositionWithinBoundsHorizontal(camX, bottomLeft, topRight);

        NUnit.Framework.Assert.IsTrue(result);
    }

    [Test]
    public void CameraPositionOutOfBounds_ReturnsFalse()
    {
        float camX = -1f;
        Vector2 bottomLeft = new Vector2(0f, 0f);
        Vector2 topRight = new Vector2(10f, 10f);

        bool result = CameraFollow.IsCameraPositionWithinBoundsHorizontal(camX, bottomLeft, topRight);

        NUnit.Framework.Assert.IsFalse(result);
    }
}