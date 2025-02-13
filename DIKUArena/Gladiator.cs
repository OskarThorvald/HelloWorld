namespace DIKUArena;
using System;

public class Gladiator {
    
    //private fields 
    private string name;
    private int level;
    private int maxHealth;
    private int health;
    private int strength;
    private int dodge;
    private int doubleStrike;
    private Random rand = new Random();

    //public fields 
    public string Name {
        get {
            return name;
        }
        set {
            name = value;
        }
    }
    public int Level {
        get {
            return level;
        }
        set {
            level = value;
        }
    }
    public int Health {
        get {
            return health;
        }
        set {
            if (value > maxHealth) {
                health = maxHealth;
            } else {
                health = value;
            }
        }
    }

    public int MaxHealth {
        get {
            return maxHealth;
        }
        set {
            maxHealth = value;
        }
    }
    public int Strength {
        get {
            return strength;
        }
        set {
            strength = value;
        }
    }
    public int Dodge {
        get {
            return dodge;
        }
        set {
            if (value > 60) {
                dodge = 60;
            } else {
                dodge = value;
            }
        }
    }
    public int DoubleStrike {
        get {
            return doubleStrike;
        }
        set {
            if (value > 60) {
                doubleStrike = 60;
            } else {
                doubleStrike = value;
            }
        }
    }

    public Gladiator(string name) {
        this.name = name;
        this.level = 1;
        this.maxHealth = 20;
        this.health = 20;
        this.strength = 4;
        this.dodge = 10;
        this.doubleStrike = 10;
    }

    public bool HasLost() {
        if (Health <= 0) {
            return true;
        } else {
            return false;
        }
    }

    public bool LoseHealth(int amount) {
        if (Dodge > rand.Next(101)) {
            Console.WriteLine($"Gladiator {Name} manages to dodge!");
            return true;
        } else {
            Health -= amount;
            return false;
        }
    }

    public void Attack(Gladiator opponent) {
        if (DoubleStrike > rand.Next(101)) {
            if (opponent.LoseHealth(Strength * 2) == false) {
                Console.WriteLine($"{Name} attacks {opponent.Name} for {Strength * 2} damage. Double Strike!. {opponent.Name} Health: {opponent.Health}");
            }

        } else {
            if (opponent.LoseHealth(Strength) == false) {
                Console.WriteLine($"{Name} attacks {opponent.Name} for {Strength} damage. Normale strike. {opponent.Name} Health: {opponent.Health}");
            }

        }
    }

    public virtual void GetExperience() {
        level += 1;
        strength += 2;
        doubleStrike += 5;
        health = maxHealth;
    }
    public override string ToString() {
        return $"Name: {Name}, Level: {Level}, Health: {Health}";
    }


}

