using System.Collections.Generic;

namespace Tournament.Library.Models
{
    /// <summary>
    /// Reprezentuje jeden turnaj se vsemi koly,zapasy,cenami,prijmy
    /// </summary>

    public class Tournaments
    {
        public int Id { get; set; }
        /// <summary>
        /// jmeno nesouci turnaj
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// mnozstvi penez ,ktere musi mit kazdy tym aby mohl vstoupit do turnaje
        /// </summary>
        public decimal EntryFee { get; set; }
        /// <summary>
        /// sada tymu ktere vstoupily do turnaje
        /// </summary>
        public List<Team> EnteredTeams { get; set; } = new List<Team>();
        /// <summary>
        /// seznam cen pro ruzne umisteni
        /// </summary>

        public List<Prize> Prizes { get; set; } = new List<Prize>();
        /// <summary>
        /// zapasy kol
        /// </summary>
        public List<List<Matchup>> Rounds { get; set; }  = new List<List<Matchup>>();
    }
}