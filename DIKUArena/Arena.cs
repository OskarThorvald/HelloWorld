namespace DIKUArena;
using System;
using System.Collections.Generic;

public class Arena {
    public Arena() {
    }
    public Gladiator Battle(Gladiator g1, Gladiator g2) {
        Console.WriteLine($"The fight between {g1.Name} and {g2.Name} will begin now!");
        int round = 1;
        Gladiator current = g1;
        Gladiator inactive = g2;
        while (!g1.HasLost() && !g2.HasLost()) {
            Console.WriteLine("ROUND: {0}", round);
            current.Attack(inactive);
            if (inactive.HasLost()) {
                break;
            }
            inactive.Attack(current);

            Gladiator temp = current;
            current = inactive;
            inactive = temp;
            round++;
        }
        Gladiator winner;
        if (g1.HasLost()) {
            winner = g2;
        } else {
            winner = g1;
        }
        winner.GetExperience();
        Console.WriteLine("The winner is: {0}", winner);
        return winner;
    }
    public Gladiator RunTournament(List<Gladiator> Competitors) {
        int listLengthCom = Competitors.Count;
        List<Gladiator> winners = new List<Gladiator> { };
        for (int i = 0; i < listLengthCom; i += 2) {
            Gladiator winner;

            if (i + 1 == listLengthCom) {
                winner = Competitors[i];
            } else {
                Gladiator g1 = Competitors[i];
                Gladiator g2 = Competitors[i + 1];
                winner = Battle(g1, g2);
            }
            winners.Add(winner);
        }
        int listLengthWin = winners.Count;
        if (listLengthWin == 1) {
            return winners[0];
        } else {
            return RunTournament(winners);
        }

    }

}

