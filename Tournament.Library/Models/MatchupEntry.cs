using System;

namespace Tournament.Library.Models
{
    public class MatchupEntry
    {
        /// <summary>
        /// reprezentuje jeden tym v zapase
        /// </summary>
        public Team TeamCompeting { get; set; }
        /// <summary>
        /// reprezentuje skore v zapase
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// reprezentuje zapas ve kterem se ten tym stal vitezem
        /// </summary>
        public Matchup ParentMatchup { get; set; }

        public MatchupEntry()
        {
            
        }

        public MatchupEntry( double score)
        {
            Console.WriteLine();
            Score = score;

        }
    }
}