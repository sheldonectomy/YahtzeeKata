using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahtzeeKata
{

    public enum ScoreCategory
    {
        Units = 1,
        Pair = 2,
        TwoPairs = 3,
        ThreeOfAKind = 4,
        FourOfAKind = 5,
        SmallStraight = 6,
        LargeStraight = 7,
        FullHouse = 8,
        Yahtzee = 9,
        Chance = 10
    }

    public class Game
    {
        public int GetScore(int[] dice, ScoreCategory category, 
            int scoringDice = 0)
        {
            var result = 0;
            List<int> singles = new List<int>();
            List<int> pairs = new List<int>();
            int threeOfAKind = 0;
            int fourOfAKind = 0;
            bool yahtzee = false;
            bool smallStraight = true;
            bool largeStraight = true;


            singles.AddRange(dice.Where(a => a == scoringDice));
            for(int x = 1; x <= 6; x++)
            {
                var matchingDice = dice.Where(a => a == x);
                if (matchingDice.Count() >= 2)
                {
                    pairs.Add(x);
                }
                if (matchingDice.Count() >= 3)
                {
                    threeOfAKind = x;
                }
                if (matchingDice.Count() >= 4)
                {
                    fourOfAKind = x;
                }
                smallStraight = smallStraight 
                    && (dice.Contains(x) || x == 6);

                largeStraight = largeStraight
                    && (dice.Contains(x) || x == 1);
            }
            yahtzee = dice.Distinct().Count() == 1;

            return category == ScoreCategory.Units ? singlesScore(singles, scoringDice) :
                category == ScoreCategory.Pair ? pairsScore(pairs) :
                category == ScoreCategory.TwoPairs ? twoPairsScore(pairs) :
                category == ScoreCategory.ThreeOfAKind ? threeOfAKindScore(threeOfAKind) :
                category == ScoreCategory.FourOfAKind ? fourOfAKindScore(fourOfAKind) :
                category == ScoreCategory.FullHouse ? fullHouseScore(pairs, threeOfAKind) :
                category == ScoreCategory.SmallStraight ? smallStraight ? 15 : 0 :
                category == ScoreCategory.LargeStraight ? largeStraight ? 20 : 0 :
                category == ScoreCategory.Yahtzee ? yahtzee ? 50 : 0 : 
                category == ScoreCategory.Chance ? chance(dice) : 0;
        }

        private int singlesScore(List<int> singles, int scoringDice)
        {
            return singles.Count() * scoringDice;
        }

        private int pairsScore(List<int> pairs)
        {
            return pairs?.LastOrDefault() * 2 ?? 0;
        }

        private int twoPairsScore(List<int> pairs)
        {
            return pairs.Count < 2 ? 0 :
                (pairs[0] * 2) + (pairs[1] * 2);
        }

        private int threeOfAKindScore(int score)
        {
            return score * 3;
        }

        private int fourOfAKindScore(int score)
        {
            return score * 4;
        }

        private int fullHouseScore(List<int> pairs, int threeOfAKind)
        {
            var result = 0;
            if(threeOfAKind > 0)
            {
                if(pairs.Any(a => a != threeOfAKind))
                {
                    result = (pairs.First(a => a != threeOfAKind) * 2)
                        + (threeOfAKind * 3);
                }
            }
            return result;
        }

        private int chance(int[] dice)
        {
            return dice.Sum(a => a);
        }

    }
}
