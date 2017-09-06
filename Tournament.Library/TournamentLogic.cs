using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Library.Models;

namespace Tournament.Library
{
    public static class TournamentLogic
    {
        //seradit nahodne tymy
        //zkontrolovat jestli je dost velky pokud ne tak pridat byes 2*2*2*2 - 2^4
        //vytvorit privni kolo zapasu
        //vytvorit kazde kolo po - 8 zapasech - 4 zapasech - 2 zapasech - 1 zapase

        public static void CreateRounds(Tournaments tournaments)
        {
            var randomize = RamdomizeTeamOrder(tournaments.EnteredTeams);
            int rounds = FindNumberOfRounds(randomize.Count);
            int bytes = NumbersOfBytes(rounds, randomize.Count);

            tournaments.Rounds.Add(CreateFirstRound(bytes, randomize));
            CreateOtherRounds(tournaments,rounds);
        }

        private static void CreateOtherRounds(Tournaments model, int rounds)
        {
            int round = 2;
            var previousRound = model.Rounds[0];
            var currRound = new List<Matchup>();
            var currMatchup = new Matchup();

            while (round <= rounds)
            {
                foreach (var matchup in previousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntry{ParentMatchup = matchup });

                    if (currMatchup.Entries.Count > 1 )
                    {
                        currMatchup.MatchupRounds = round;
                        currRound.Add(matchup);
                        currMatchup = new Matchup();
                    }
                }
                model.Rounds.Add(currRound);
                previousRound = currRound;
                currRound = new List<Matchup>();
                round += 1;
            }

        }

        private static List<Matchup> CreateFirstRound(int bytes, List<Team> teams)
        {
            var output = new List<Matchup>();
            var curr = new Matchup();

            foreach (var team in teams)
            {
                curr.Entries.Add(new MatchupEntry{TeamCompeting = team});
                if (bytes > 0 || curr.Entries.Count > 1 )
                {
                    curr.MatchupRounds = 1;
                    output.Add(curr);
                    curr = new Matchup();

                    if (bytes > 0)
                    {
                        bytes -= 1;
                    }
                }
            }
            return output;
        }
      
        private static int NumbersOfBytes(int rounds, int numbersOfTeams)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }
           output = totalTeams - numbersOfTeams;
            return output;
        }

        private static int FindNumberOfRounds(int teamsCount)
        {
            int output = 1;
            int val = 2;


            while (val < teamsCount)
            {
                output += 1;

                val *= 2;
            }
            return output;
        }

        private static List<Team> RamdomizeTeamOrder(List<Team> teams)
        {
            //cards.OrderBy(x => Guid.NewGuid()).ToList();
            var randomTeams = teams.OrderBy(x => Guid.NewGuid()).ToList();
            return randomTeams;
        }
    }
}
