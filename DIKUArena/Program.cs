namespace DIKUArena;
using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        //Gladiators 
        Gladiator oskar = new Samnite("Oskar S");
        Gladiator silje = new Traex("Silje T");
        Gladiator villads = new Retiarii("Villads R");
        Gladiator emma = new Gladiator("Emma T");

        //List of Gladiators
        List<Gladiator> Competitors = new List<Gladiator> { oskar, silje, villads, emma };

        //Arena 
        Arena humleby = new Arena();

        humleby.RunTournament(Competitors);
    }
}
