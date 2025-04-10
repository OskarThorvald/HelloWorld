namespace GalagaTests;

using System;
using System.Numerics;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using Galaga;
using NUnit.Framework;

public class TestsPlayer {
    public Player testPlayer;
    public Player testPlayer2;

    [SetUp]
    public void Setup() {
        testPlayer = new Player(
            new DynamicShape(new Vector2(0.45f, 0.1f), new Vector2(0.1f, 0.1f)),
            new Image("GalagaTests.Images.Player.png"));
        testPlayer2 = new Player(
            new DynamicShape(new Vector2(0.99f, 0.1f), new Vector2(0.1f, 0.1f)),
            new NoImage());
    }

    [Test]
    public void Test1() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void SetMoveLeftTest() {
        // Class: val true. Should set moveLeft to -MOVEMENTSPEED.
        // which sets velocity x to -0.01f.
        testPlayer.SetMoveLeft(true);
        DynamicShape testPlayerDynamic = testPlayer.Shape.AsDynamicShape();
        Assert.True(testPlayerDynamic.Velocity.X == -0.01f);

        testPlayer2.SetMoveLeft(true);
        DynamicShape testPlayer2Dynamic = testPlayer2.Shape.AsDynamicShape();
        Assert.True(testPlayer2Dynamic.Velocity.X == -0.01f);

        // Class: val false. Should moveLeft to 0.0f.
        // which sets velocity x to 0.0f
        testPlayer.SetMoveLeft(false);
        DynamicShape testPlayerDynamic2 = testPlayer.Shape.AsDynamicShape();
        Assert.True(testPlayerDynamic2.Velocity.X == 0.0f);

        testPlayer2.SetMoveLeft(false);
        DynamicShape testPlayer2Dynamic2 = testPlayer2.Shape.AsDynamicShape();
        Assert.True(testPlayer2Dynamic2.Velocity.X == 0.0f);
    }

    [Test]
    public void SetMoveRightTest() {
        // Class: val true. Should set moveRight to MOVEMENTSPEED.
        // which sets velocity x to 0.01f.
        testPlayer.SetMoveRight(true);
        DynamicShape testPlayerDynamic = testPlayer.Shape.AsDynamicShape();
        Assert.True(testPlayerDynamic.Velocity.X == 0.01f);

        testPlayer2.SetMoveRight(true);
        DynamicShape testPlayer2Dynamic = testPlayer2.Shape.AsDynamicShape();
        Assert.True(testPlayer2Dynamic.Velocity.X == 0.01f);

        // Class: val false. Should moveRight to 0.0f.
        // which sets velocity x to 0.0f
        testPlayer.SetMoveRight(false);
        DynamicShape testPlayerDynamic2 = testPlayer.Shape.AsDynamicShape();
        Assert.True(testPlayerDynamic2.Velocity.X == 0.0f);

        testPlayer2.SetMoveRight(false);
        DynamicShape testPlayer2Dynamic2 = testPlayer2.Shape.AsDynamicShape();
        Assert.True(testPlayer2Dynamic2.Velocity.X == 0.0f);
    }

    [Test]
    public void MoveTest() {
        // Class: free movement. Movement possible in 2 directions.
        DynamicShape testPlayerDynamic = testPlayer.Shape.AsDynamicShape();
        float prevPosX;
        float curPosX;
        float diff;

        prevPosX = testPlayer.GetPosition.X;
        testPlayerDynamic.Velocity.X = 0.01f;
        testPlayer.Move();
        curPosX = MathF.Round(testPlayer.GetPosition.X, 3);
        diff = MathF.Round(curPosX - prevPosX, 3);
        Assert.True(diff == 0.01f);

        prevPosX = testPlayer.GetPosition.X;
        testPlayerDynamic.Velocity.X = -0.01f;
        testPlayer.Move();
        curPosX = MathF.Round(testPlayer.GetPosition.X, 3);
        diff = MathF.Round(prevPosX - curPosX, 3);
        Assert.True(diff == 0.01f);

        // Class: Boundary movement. Movement possible in 1 direction.
        testPlayerDynamic.Position = new Vector2(0.9f, 0.1f);
        testPlayerDynamic.Velocity.X = 0.01f;
        testPlayer.Move();
        Assert.True(testPlayer.GetPosition.X == 0.9f);

        testPlayerDynamic.Position = new Vector2(0.0f, 0.1f);
        testPlayerDynamic.Velocity.X = -0.01f;
        testPlayer.Move();
        Assert.True(testPlayer.GetPosition.X == 0.0f);
    }
}
