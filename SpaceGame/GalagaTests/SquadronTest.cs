using NUnit.Framework;
using Galaga.Squadron;
using Galaga.MovementStrategy;
using Galaga.HitStrategy;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using System.Collections.Generic;
using Galaga;

public class SquadronTests {
    private List<Image> enemyStrides;
    private List<Image> enragedStrides;
    private EntityContainer<Enemy> enemyContainer;

    [SetUp]
    public void Setup() {
        enemyStrides = ImageStride.CreateStrides(4, "GalagaTests.Images.BlueMonster.png");
    }

    [Test]
    public void NumberOfEnemiesBlockSquadron() {
        var squadron = new BlockSquadron();
        enemyContainer = squadron.CreateEnemies(
            enemyStrides, 
            () => new NoMove(), 
            () => new Speed()
        );

        Assert.AreEqual(8, enemyContainer.CountEntities());
    }

    [Test]
    public void NumberOfEnemiesHalfCircleSquadron() {
        var squadron = new HalfCircleSquadron();
        enemyContainer = squadron.CreateEnemies(
            enemyStrides, 
            () => new NoMove(), 
            () => new Speed()
        );

        Assert.AreEqual(8, enemyContainer.CountEntities());
    }

    [Test]
    public void NumberOfEnemiesZigZagSquadron() {
        var squadron = new ZigZagSquadron();
        enemyContainer = squadron.CreateEnemies(
            enemyStrides, 
            () => new NoMove(), 
            () => new Speed()
        );

        Assert.AreEqual(8, enemyContainer.CountEntities());
    }
}
