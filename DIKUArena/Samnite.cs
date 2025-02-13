namespace DIKUArena;
using System;

public class Samnite : Gladiator {
    public Samnite(string name) : base(name) {
        Strength = 6;
        Dodge = 5;
    }

    public override void GetExperience() {
        Level++;
        Strength += 3;
        MaxHealth += 15;
        Dodge += 2;
        Health = MaxHealth;
        DoubleStrike += 5;

    }
}
