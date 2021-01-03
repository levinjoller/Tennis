namespace Tennis
{
    public class TennisScorer : ITennisScorer
    {
        private Score playerA;
        private Score playerB;

        protected enum Score { Zero = 0, Fifteen = 15, Thirty = 30, Fourty = 40, Advantage, Game };

        public string GetScore()
        {
            if (CheckPlayersForGameOrAdvantage())
            {
                return FormatPlayerWithGameOrAdvantage();
            }
            else if (playerA == playerB && playerA == Score.Fourty)
            {
                return "Deuce";
            }
            else
            {
                return (int)playerA + "-" + (int)playerB;
            }
        }

        private string FormatPlayerWithGameOrAdvantage()
        {
            if (playerA == Score.Game || playerA == Score.Advantage)
            {
                return playerA + "-";
            }
            else
            {
                return "-" + playerB;
            }
        }

        private bool CheckPlayersForGameOrAdvantage()
        {
            return playerA == Score.Game || playerB == Score.Game
                || playerA == Score.Advantage || playerB == Score.Advantage;
        }

        public void PlayerAScores()
        {
            CalculateCurrentScore(ref playerA, ref playerB);
        }

        public void PlayerBScores()
        {
            CalculateCurrentScore(ref playerB, ref playerA);
        }

        private void CalculateCurrentScore(ref Score scoringPlayer, ref Score oppositePlayer)
        {
            switch (scoringPlayer)
            {
                case Score.Zero:
                    scoringPlayer = Score.Fifteen;
                    break;
                case Score.Fifteen:
                    scoringPlayer = Score.Thirty;
                    break;
                case Score.Thirty:
                    scoringPlayer = Score.Fourty;
                    break;
                case Score.Fourty:
                    SetDeuceOrAdvantageOrGame(ref scoringPlayer, ref oppositePlayer);
                    break;
                case Score.Advantage:
                    scoringPlayer = Score.Game;
                    break;
                case Score.Game:
                    break;
                default:
                    break;
            }
        }

        private void SetDeuceOrAdvantageOrGame(ref Score scoringPlayer, ref Score oppositePlayer)
        {
            if (oppositePlayer == Score.Advantage)
            {
                oppositePlayer = Score.Fourty;
            }
            else if (oppositePlayer == Score.Fourty)
            {
                scoringPlayer = Score.Advantage;
            }
            else
            {
                scoringPlayer = Score.Game;
            }
        }
    }
}
