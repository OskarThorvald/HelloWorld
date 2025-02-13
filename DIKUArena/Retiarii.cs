namespace DIKUArena;
using System;

public class Retiarii : Gladiator {
    public Retiarii(string name) : base(name) {
        MaxHealth = 15;
        Health = 15;
        Dodge = 15;
    }
    public override void GetExperience() {
        Level++;
        Strength += 2;
        MaxHealth += 5;
        Dodge += 8;
        Health = MaxHealth;
        DoubleStrike += 5;
    }
}
