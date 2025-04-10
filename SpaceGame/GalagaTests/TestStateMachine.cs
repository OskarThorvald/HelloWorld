namespace GalagaTests;

using NUnit.Framework;
using Galaga;
using Galaga.States;
using DIKUArcade.Input;

public class TestStateMachine {
    private StateMachine stateMachine;

    [SetUp]
    public void InitiateStateMachine() {
        stateMachine = new StateMachine();
    }

    [Test]
    public void TestInitialState() {
        Assert.IsInstanceOf(typeof(MainMenu), stateMachine.ActiveState);
    }

    [Test]
    public void TestEventNewGame() {
        // Inital state is main menu, no need to change state
        // Already on new game button, click enter
        stateMachine.ActiveState.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Enter);

        // Assert that state is GameRunning
        Assert.IsInstanceOf(typeof(GameRunning), stateMachine.ActiveState);
    }

    // Not really a state test but still added for extra testing
    [Test]
    public void TestEventQuit() {
        // Initial state is main menu, no need to change state
        // Move down to quit button and click enter
        stateMachine.ActiveState.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Down);
        stateMachine.ActiveState.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Enter);  

        // Assert that game is not running
        Assert.True(!Game.IsRunning);
    }

    [Test]
    public void TestEventGamePaused() {
        // Change state to GameRunning state
        stateMachine.ActiveState = new GameRunning(stateMachine);

        // Perform GamePaused state event
        stateMachine.ActiveState.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Escape);

        // Assert that state is GamePaused
        Assert.IsInstanceOf(typeof(GamePaused), stateMachine.ActiveState);
    }

    [Test]
    public void TestEventContinue() {
        // Save the GameRunning instance to make sure continue event goes back
        // to same GameRunning instance
        GameRunning gameRunning = new GameRunning(stateMachine);
        stateMachine.ActiveState = gameRunning;

        // Perform GamePaused state event
        stateMachine.ActiveState.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Escape);

        // Already on continue button, click enter
        stateMachine.ActiveState.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Enter);

        // Assert that state is same instance of GameRunning instance as before
        Assert.AreSame(gameRunning, stateMachine.ActiveState);

    }

    [Test]
    public void TestEventMainMenu() {
        // Change state to GamePaused state
        stateMachine.ActiveState = new GamePaused(stateMachine);

        // Move down to Main menu button and click enter
        stateMachine.ActiveState.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Down);
        stateMachine.ActiveState.HandleKeyEvent(KeyboardAction.KeyPress, KeyboardKey.Enter);  

        // Assert that state is MainMenu
        Assert.IsInstanceOf(typeof(MainMenu), stateMachine.ActiveState);
    }
}
