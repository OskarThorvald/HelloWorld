using NUnit.Framework;
using Galaga.MovementStrategy;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using System.Numerics;
using Galaga;
using Galaga.HitStrategy;

public class MovementStrategyTests {

    private Enemy enemy1;
    private Enemy enemy2;
    private Enemy enemy3;

    [SetUp]
    public void Setup() {
        enemy1 = new Enemy(new DynamicShape(new Vector2(0.5f, 0.9f), new Vector2(0.1f, 0.1f)), 
                                                new NoImage(),
                                                new NoMove(),
                                                new Speed());
        enemy2 = new Enemy(new DynamicShape(new Vector2(0.5f, 0.9f), new Vector2(0.1f, 0.1f)), 
                        new NoImage(),
                        new Down(), 
                        new Speed());
        enemy3 = new Enemy(new DynamicShape(new Vector2(0.5f, 0.9f), new Vector2(0.1f, 0.1f)), 
                        new NoImage(), 
                        new ZigZagDown(), 
                        new Speed());
    }
    [Test]
    public void EnemyDoesNotMoveWithNoMove() {


        Vector2 initialPos = enemy1.Shape.Position;
        enemy1.Move();

        Assert.AreEqual(initialPos, enemy1.Shape.Position);
    }
    [Test]
    public void EnemyMovesDownMultipleTimes() {

        Vector2 initialPos = enemy2.Shape.Position;
        
        enemy2.Move();
        enemy2.Move();
        enemy2.Move();

        Assert.Less(enemy2.Shape.Position.Y, initialPos.Y);
        Assert.Greater(initialPos.Y - enemy2.Shape.Position.Y, 0);
        Assert.Less(initialPos.Y - enemy2.Shape.Position.Y, 0.3f);
    }
    [Test]
    public void EnemyXChangesWithZigZag() {


        Vector2 initialPos = enemy3.Shape.Position;
        enemy3.Move();

        Assert.AreNotEqual(initialPos.X, enemy3.Shape.Position.X);
    }
}