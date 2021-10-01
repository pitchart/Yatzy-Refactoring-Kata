using System.Linq;

namespace Yatzy
{
    public class Yatzy
    {
        public int Chance(int d1, int d2, int d3, int d4, int d5)
        {
            var dices = new int[] {d1, d2, d3, d4, d5};

            return dices.Sum();
        }

        public int yatzy(params int[] dice)
        {
            var counts = new int[6];
            foreach (var die in dice)
                counts[die - 1]++;
            for (var i = 0; i != 6; i++)
                if (counts[i] == 5)
                    return 50;
            return 0;
        }

        public int Ones(int d1, int d2, int d3, int d4, int d5)
        {
            var dices = new[] { d1, d2, d3, d4, d5 };

            return SumOf(dices, 1);
        }

        public int Twos(int d1, int d2, int d3, int d4, int d5)
        {
            var dices = new[] { d1, d2, d3, d4, d5 };

            return SumOf(dices, 2);
        }

        public int Threes(int d1, int d2, int d3, int d4, int d5)
        {
            var dices = new[] { d1, d2, d3, d4, d5 };

            return SumOf(dices, 3);
        }

        public int Fours(int d1, int d2, int d3, int d4, int d5)
        {
            var dices = new[] { d1, d2, d3, d4, d5 };

            return SumOf(dices, 4);
        }

        public int Fives(int d1, int d2, int d3, int d4, int d5)
        {
            var dices = new[] { d1, d2, d3, d4, d5 };

            return SumOf(dices, 5);
        }

        public int Sixes(int d1, int d2, int d3, int d4, int d5)
        {
            var dices = new[] { d1, d2, d3, d4, d5 };

            return SumOf(dices, 6);
        }

        public int ScorePair(int d1, int d2, int d3, int d4, int d5)
        {
            var dices = new[] { d1, d2, d3, d4, d5 };
            var pair =
            dices
                    .OrderByDescending(d => d)
                    .GroupBy(d => d)
                    .FirstOrDefault(x => Enumerable.Count<int>(x) > 1);
            return pair?.Sum() ?? 0;
            ;
        }

        public int TwoPair(int d1, int d2, int d3, int d4, int d5)
        {
            var counts = new int[6];
            counts[d1 - 1]++;
            counts[d2 - 1]++;
            counts[d3 - 1]++;
            counts[d4 - 1]++;
            counts[d5 - 1]++;
            var n = 0;
            var score = 0;
            for (var i = 0; i < 6; i += 1)
                if (counts[6 - i - 1] >= 2)
                {
                    n++;
                    score += 6 - i;
                }

            if (n == 2)
                return score * 2;
            return 0;
        }

        public int FourOfAKind(int _1, int _2, int d3, int d4, int d5)
        {
            int[] tallies;
            tallies = new int[6];
            tallies[_1 - 1]++;
            tallies[_2 - 1]++;
            tallies[d3 - 1]++;
            tallies[d4 - 1]++;
            tallies[d5 - 1]++;
            for (var i = 0; i < 6; i++)
                if (tallies[i] >= 4)
                    return (i + 1) * 4;
            return 0;
        }

        public int ThreeOfAKind(int d1, int d2, int d3, int d4, int d5)
        {
            int[] t;
            t = new int[6];
            t[d1 - 1]++;
            t[d2 - 1]++;
            t[d3 - 1]++;
            t[d4 - 1]++;
            t[d5 - 1]++;
            for (var i = 0; i < 6; i++)
                if (t[i] >= 3)
                    return (i + 1) * 3;
            return 0;
        }

        public int SmallStraight(int d1, int d2, int d3, int d4, int d5)
        {
            int[] tallies;
            tallies = new int[6];
            tallies[d1 - 1] += 1;
            tallies[d2 - 1] += 1;
            tallies[d3 - 1] += 1;
            tallies[d4 - 1] += 1;
            tallies[d5 - 1] += 1;
            if (tallies[0] == 1 &&
                tallies[1] == 1 &&
                tallies[2] == 1 &&
                tallies[3] == 1 &&
                tallies[4] == 1)
                return 15;
            return 0;
        }

        public int LargeStraight(int d1, int d2, int d3, int d4, int d5)
        {
            int[] tallies;
            tallies = new int[6];
            tallies[d1 - 1] += 1;
            tallies[d2 - 1] += 1;
            tallies[d3 - 1] += 1;
            tallies[d4 - 1] += 1;
            tallies[d5 - 1] += 1;
            if (tallies[1] == 1 &&
                tallies[2] == 1 &&
                tallies[3] == 1 &&
                tallies[4] == 1
                && tallies[5] == 1)
                return 20;
            return 0;
        }

        public int FullHouse(int d1, int d2, int d3, int d4, int d5)
        {
            int[] tallies;
            var _2 = false;
            int i;
            var _2_at = 0;
            var _3 = false;
            var _3_at = 0;


            tallies = new int[6];
            tallies[d1 - 1] += 1;
            tallies[d2 - 1] += 1;
            tallies[d3 - 1] += 1;
            tallies[d4 - 1] += 1;
            tallies[d5 - 1] += 1;

            for (i = 0; i != 6; i += 1)
                if (tallies[i] == 2)
                {
                    _2 = true;
                    _2_at = i + 1;
                }

            for (i = 0; i != 6; i += 1)
                if (tallies[i] == 3)
                {
                    _3 = true;
                    _3_at = i + 1;
                }

            if (_2 && _3)
                return _2_at * 2 + _3_at * 3;
            return 0;
        }

        private int SumOf(int[] dices, int value)
        {
            return dices.Where(x => x == value).Sum();
        }
    }
}
