namespace GalagaTests;

using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using Galaga.HitStrategy;
using Galaga.MovementStrategy;
using System.Numerics;
using NUnit.Framework;
using System;
using Galaga;
using DIKUArcade.GUI;
using System.Diagnostics;

public class TestIHitstrategy {
    private Enemy testEnemy1;
    private Enemy testEnemy2;
    private Enemy testEnemy3;
    private Enemy testEnemy4;

    [SetUp]
    public void SetUp() {
        testEnemy1 = new Enemy(
            new DynamicShape(new Vector2(0.45f, 0.1f), new Vector2(0.1f, 0.1f)),
            new NoImage(),
            new Down(),
            new Enrage()
            );
        testEnemy2 = new Enemy(
            new DynamicShape(new Vector2(0.45f, 0.1f), new Vector2(0.1f, 0.1f)),
            new NoImage(),
            new NoMove(),
            new Teleport()
            );
        testEnemy3 = new Enemy(
            new DynamicShape(new Vector2(0.45f, 0.1f), new Vector2(0.1f, 0.1f)),
            new NoImage(),
            new Down(),
            new Speed()
            );
        testEnemy4 = new Enemy(
            new DynamicShape(new Vector2(0.45f, 0.1f), new Vector2(0.1f, 0.1f)),
            new NoImage(),
            new Down(),
            new Speed()
            );
    }

    [Test]
    public void TestHitPoints() {
        testEnemy1.Hit(testEnemy1);
        testEnemy1.Hit(testEnemy1);
       
        Assert.AreEqual(testEnemy1.HitPoints, 20);

    }
    [Test]
    public void TestEnrageSpeed (){
        float startSpeed = testEnemy1.Shape.AsDynamicShape().Velocity.Y = -0.0008f; //set inital speed
        testEnemy1.HitPoints = 21; // Next hit will make it enrage

        testEnemy1.Hit(testEnemy1);

        testEnemy1.Move();

        Assert.AreEqual(startSpeed * 4.0f, testEnemy1.Shape.AsDynamicShape().Velocity.Y);
        
    }
    [Test]
    public void TestNoEnrageSpeed (){
        float startSpeed = testEnemy1.Shape.AsDynamicShape().Velocity.Y = -0.0008f; // Set inital speed
        testEnemy1.HitPoints = 41; // Next hit will  not make it enrage

        testEnemy1.Hit(testEnemy1);

        testEnemy1.Move();

        Assert.AreEqual(startSpeed, testEnemy1.Shape.AsDynamicShape().Velocity.Y);

        
    }

    [Test]
    public void TestTeleportWithinRange(){
        //determine lower and higherbound of teleportation
        double minX = 0.1;
        double minY = 0.33;
        double max = 0.9;

        //New teleportation 
        testEnemy2.Hit(testEnemy2);

        //Test if telportation is within lower and higerbound
        Assert.That(testEnemy2.Shape.Position.X, Is.InRange(minX, max));
        Assert.That(testEnemy2.Shape.Position.Y, Is.InRange(minY, max));

        //New teleportation 
        testEnemy2.Hit(testEnemy2);
    
        //Test if telportation is within lower and higerbound
        Assert.That(testEnemy2.Shape.Position.X, Is.InRange(minX, max));
        Assert.That(testEnemy2.Shape.Position.Y, Is.InRange(minY, max));

        //New teleportation and save position
        testEnemy2.Hit(testEnemy2);

        //Test if telportation is within lower and higerbound
        Assert.That(testEnemy2.Shape.Position.X, Is.InRange(minX, max));
        Assert.That(testEnemy2.Shape.Position.Y, Is.InRange(minY, max));      
    }

    [Test]
    public void TestTeleportNewPosition(){
        testEnemy2.HitPoints = 40;
        Vector2 initalPos = testEnemy2.Shape.Position;
               
        testEnemy2.Hit(testEnemy2);
        Vector2 telePos1 = testEnemy2.Shape.Position;

        //New teleportation and save position
        testEnemy2.Hit(testEnemy2);
        Vector2 telePos2 = testEnemy2.Shape.Position;

        //New teleportation and save position
        testEnemy2.Hit(testEnemy2);
        Vector2 telePos3 = testEnemy2.Shape.Position;

        //Tests for if each new position is not equal to prior position
        Assert.AreNotEqual(initalPos, telePos1);
        Assert.AreNotEqual(telePos1, telePos2);
        Assert.AreNotEqual(telePos2, telePos3);  

    }

    [Test]
    public void TestSpeedOnce (){
        testEnemy3.Shape.AsDynamicShape().Velocity.Y = -0.0008f;
        testEnemy3.Hit(testEnemy3);

        testEnemy3.Move();

        Assert.AreEqual(-0.0008f * 2.0f, testEnemy3.Shape.AsDynamicShape().Velocity.Y);
    }
    
    [Test]
    public void TestSpeedTwice (){
        testEnemy3.Shape.AsDynamicShape().Velocity.Y = -0.0008f;
        testEnemy3.Hit(testEnemy3);
        testEnemy3.Hit(testEnemy3);

        testEnemy3.Move();

        Assert.AreEqual(-0.0008f * 4.0f, testEnemy3.Shape.AsDynamicShape().Velocity.Y);
    }

    [Test]
    public void TestSpeedZero (){
        testEnemy4.Shape.AsDynamicShape().Velocity.Y = 0.0f;
        testEnemy4.Hit(testEnemy3);

        testEnemy4.Move();

        Assert.AreEqual(0.0f, testEnemy3.Shape.AsDynamicShape().Velocity.Y);
    }



}
