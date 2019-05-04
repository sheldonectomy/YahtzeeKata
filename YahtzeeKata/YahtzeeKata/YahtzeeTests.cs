using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeKata
{
    [TestFixture]
    public class YahtzeeTests
    {
        Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        [Test]
        public void ThreeOnesReturnsCorrectResult()
        {
            Assert.AreEqual(3, 
                _game.GetScore(new int[5]
                {
                    1, 1, 1, 3, 5
                }, ScoreCategory.Units, 1));
        }

        [Test]
        public void FourOnesReturnsCorrectResult()
        {
            Assert.AreEqual(4,
                _game.GetScore(new int[5]
                {
                    1, 1, 1, 1, 5
                }, ScoreCategory.Units, 1));
        }

        [Test]
        public void ThreeTwosReturnsCorrectResult()
        {
            Assert.AreEqual(6,
                _game.GetScore(new int[5]
                {
                    2, 2, 2, 1, 5
                }, ScoreCategory.Units, 2));
        }

        [Test]
        public void FourTwosReturnsCorrectResult()
        {
            Assert.AreEqual(8,
                _game.GetScore(new int[5]
                {
                    2, 2, 2, 2, 5
                }, ScoreCategory.Units, 2));
        }

        [Test]
        public void FourThreessReturnsCorrectResult()
        {
            Assert.AreEqual(12,
                _game.GetScore(new int[5]
                {
                    3, 3, 3, 3, 5
                }, ScoreCategory.Units, 3));
        }

        [Test]
        public void PairOfThreessReturnsCorrectResult()
        {
            Assert.AreEqual(6,
                _game.GetScore(new int[5]
                {
                    3, 3, 1, 2, 5
                }, ScoreCategory.Pair));
        }

        [Test]
        public void PairReturnsMaximumPair()
        {
            Assert.AreEqual(10,
                _game.GetScore(new int[5]
                {
                    3, 3, 5, 5, 6
                }, ScoreCategory.Pair));
        }

        [Test]
        public void PairReturnsMaximumPairWhenThereAreThree()
        {
            Assert.AreEqual(8,
                _game.GetScore(new int[5]
                {
                    2, 2, 4, 4, 4
                }, ScoreCategory.Pair));
        }

        [Test]
        public void TowPairsReturnsCorrectScore()
        {
            Assert.AreEqual(16,
                _game.GetScore(new int[5]
                {
                    3, 3, 5, 5, 6
                }, ScoreCategory.TwoPairs));
        }

        [Test]
        public void ThreeOfAKindReturnsCorrectScore()
        {
            Assert.AreEqual(15,
                _game.GetScore(new int[5]
                {
                    3, 3, 5, 5, 5
                }, ScoreCategory.ThreeOfAKind));
        }

        [Test]
        public void ThreeOfAKindWhenThereAreFourReturnsCorrectScore()
        {
            Assert.AreEqual(15,
                _game.GetScore(new int[5]
                {
                    3, 5, 5, 5, 5
                }, ScoreCategory.ThreeOfAKind));
        }

        [Test]
        public void FourOfAKindReturnsCorrectScore()
        {
            Assert.AreEqual(20,
                _game.GetScore(new int[5]
                {
                    3, 5, 5, 5, 5
                }, ScoreCategory.FourOfAKind));
        }

        [Test]
        public void FourOfAKindWhenThereAreFiveReturnsCorrectScore()
        {
            Assert.AreEqual(20,
                _game.GetScore(new int[5]
                {
                    5, 5, 5, 5, 5
                }, ScoreCategory.FourOfAKind));
        }

        [Test]
        public void FullHouseReturnsCorrectScore()
        {
            Assert.AreEqual(21,
                _game.GetScore(new int[5]
                {
                    5, 5, 5, 3, 3
                }, ScoreCategory.FullHouse));
        }

        [Test]
        public void NotFullHouseReturnsCorrectScore()
        {
            Assert.AreEqual(0,
                _game.GetScore(new int[5]
                {
                    5, 5, 1, 3, 3
                }, ScoreCategory.FullHouse));
        }

        [Test]
        public void YahtzeeReturnsCorrectScore()
        {
            Assert.AreEqual(50,
                _game.GetScore(new int[5]
                {
                    5, 5, 5, 5, 5
                }, ScoreCategory.Yahtzee));
        }

        [Test]
        public void FailedYahtzeeReturnsCorrectScore()
        {
            Assert.AreEqual(0,
                _game.GetScore(new int[5]
                {
                    5, 5, 2, 5, 5
                }, ScoreCategory.Yahtzee));
        }

        [Test]
        public void SmallStraightReturnsCorrectScore()
        {
            Assert.AreEqual(15,
                _game.GetScore(new int[5]
                {
                    1, 3, 2, 5, 4
                }, ScoreCategory.SmallStraight));
        }

        [Test]
        public void FailedSmallStraightReturnsCorrectScore()
        {
            Assert.AreEqual(0,
                _game.GetScore(new int[5]
                {
                    1, 3, 2, 6, 4
                }, ScoreCategory.SmallStraight));
        }

        [Test]
        public void LargeStraightReturnsCorrectScore()
        {
            Assert.AreEqual(20,
                _game.GetScore(new int[5]
                {
                    6, 3, 2, 5, 4
                }, ScoreCategory.LargeStraight));
        }

        [Test]
        public void FailedLargeStraightReturnsCorrectScore()
        {
            Assert.AreEqual(0,
                _game.GetScore(new int[5]
                {
                    6, 3, 1, 5, 4
                }, ScoreCategory.LargeStraight));
        }

        [Test]
        public void ChanceReturnsCorrectScore()
        {
            Assert.AreEqual(19,
                _game.GetScore(new int[5]
                {
                    6, 3, 1, 5, 4
                }, ScoreCategory.Chance));
        }

    }
}
