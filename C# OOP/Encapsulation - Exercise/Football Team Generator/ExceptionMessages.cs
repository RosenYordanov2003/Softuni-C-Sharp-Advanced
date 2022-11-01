using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class ExceptionMessages
    {
        public const string NameShouldNotBeEmpty = "A name should not be empty.";
        public const string InvalidStats = "{0} should be between 0 and 100.";
        public const string NotExistingTeam = "Team {0} does not exist.";
        public const string NotExistingPlayer = "Player {0} is not in {1} team.";
    }
}
