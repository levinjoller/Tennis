using Xunit;

namespace Tennis.Test
{
    public class TennisTest
    {
        private ITennisScorer tennisScorer;
        public TennisTest()
        {
            tennisScorer = new TennisScorer();
        }
        private void SetScoresBasedOnTurns(int scoreCountA, int scoreCountB) {
            int turns = scoreCountA > scoreCountB ? scoreCountA : scoreCountB;
            for (int i = 0; i < turns; i++)
            {
                if (scoreCountA > i)
                {
                    tennisScorer.PlayerAScores();
                }
                if (scoreCountB > i)
                {
                    tennisScorer.PlayerBScores();
                }
            }
        }
        [Fact]
        public void InitialStateOfScorer_ReturnZeroToZero()
        {
            string actual = tennisScorer.GetScore();
            Assert.Equal("0-0", actual);
        }
        [Fact]
        public void BothPlayersScoreOnce_ReturnFifteenToFifteen()
        {
            SetScoresBasedOnTurns(1, 1);
            string actual = tennisScorer.GetScore();
            Assert.Equal("15-15", actual);
        }
        [Fact]
        public void PlayerBIsOneAheadWithThirty_ReturnFifteenToThirty()
        {
            SetScoresBasedOnTurns(1, 2);
            string actual = tennisScorer.GetScore();
            Assert.Equal("15-30", actual);
        }
        [Fact]
        public void PlayerAIsAheadWithFourty_ReturnFourtyToZero()
        {
            SetScoresBasedOnTurns(3, 0);
            string actual = tennisScorer.GetScore();
            Assert.Equal("40-0", actual);
        }
        [Fact]
        public void BothPlayersScoreFourty_ReturnDeuce()
        {
            SetScoresBasedOnTurns(3, 3);
            string actual = tennisScorer.GetScore();
            Assert.Equal("Deuce", actual);
        }
        [Fact]
        public void PlayerBAdvantage_ReturnAndvantageForB()
        {
            SetScoresBasedOnTurns(3, 4);
            string actual = tennisScorer.GetScore();
            Assert.Equal("-Advantage", actual);
        }
        [Fact]
        public void PlayerAScoresFourTimesInARow_ReturnGameForA()
        {
            SetScoresBasedOnTurns(4, 0);
            string actual = tennisScorer.GetScore();
            Assert.Equal("Game-", actual);
        }
        [Fact]
        public void ThreeTimesDeuce_ReturnDeuce()
        {
            SetScoresBasedOnTurns(6, 6);
            string actual = tennisScorer.GetScore();
            Assert.Equal("Deuce", actual);
        }
        [Fact]
        public void AfterTwoTimesDeucePlayerAAdvantage_ReturnAndvantageForA()
        {
            SetScoresBasedOnTurns(6, 5);
            string actual = tennisScorer.GetScore();
            Assert.Equal("Advantage-", actual);
        }
        [Fact]
        public void AfterTwoTimesDeucePlayerBScoresTwoTimes_ReturnGameForB()
        {
            SetScoresBasedOnTurns(4, 6);
            string actual = tennisScorer.GetScore();
            Assert.Equal("-Game", actual);
        }
    }
}