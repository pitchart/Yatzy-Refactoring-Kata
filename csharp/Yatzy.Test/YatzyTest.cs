using Xunit;

namespace Yatzy.Test
{
    public class YatzyTest
    {
        private Yatzy _yatzy = new Yatzy();

        [Theory]
        [InlineData(2,3,4,5,1,15)]
        [InlineData(3,3,4,5,1,16)]
        public void Chance_scores_sum_of_all_dice(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, _yatzy.Chance(d1, d2, d3, d4, d5));
        }

        [Theory]
        [InlineData(1,2,3,4,5,1)]
        [InlineData(1, 2, 1, 4, 5,2)]
        [InlineData(6, 2, 2, 4, 5, 0)]
        [InlineData(1, 2, 1, 1, 1, 4)]
        public void Ones_scores_sum_of_all_ones(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, _yatzy.Ones(d1, d2, d3, d4, d5));
        }

        [Fact]
        public void Fact_2s()
        {
            Assert.Equal(4, _yatzy.Twos(1, 2, 3, 2, 6));
            Assert.Equal(10, _yatzy.Twos(2, 2, 2, 2, 2));
        }

        [Fact]
        public void Fact_threes()
        {
            Assert.Equal(6, _yatzy.Threes(1, 2, 3, 2, 3));
            Assert.Equal(12, _yatzy.Threes(2, 3, 3, 3, 3));
        }

        [Fact]
        public void fives()
        {
            Assert.Equal(10, new Yatzy().Fives(4, 4, 4, 5, 5));
            Assert.Equal(15, new Yatzy().Fives(4, 4, 5, 5, 5));
            Assert.Equal(20, new Yatzy().Fives(4, 5, 5, 5, 5));
        }

        [Fact]
        public void four_of_a_knd()
        {
            Assert.Equal(12, _yatzy.FourOfAKind(3, 3, 3, 3, 5));
            Assert.Equal(20, _yatzy.FourOfAKind(5, 5, 5, 4, 5));
            Assert.Equal(12, _yatzy.FourOfAKind(3, 3, 3, 3, 3));
        }

        [Fact]
        public void fours_Fact()
        {
            Assert.Equal(12, new Yatzy().Fours(4, 4, 4, 5, 5));
            Assert.Equal(8, new Yatzy().Fours(4, 4, 5, 5, 5));
            Assert.Equal(4, new Yatzy().Fours(4, 5, 5, 5, 5));
        }

        [Fact]
        public void fullHouse()
        {
            Assert.Equal(18, _yatzy.FullHouse(6, 2, 2, 2, 6));
            Assert.Equal(0, _yatzy.FullHouse(2, 3, 4, 5, 6));
        }

        [Fact]
        public void largeStraight()
        {
            Assert.Equal(20, _yatzy.LargeStraight(6, 2, 3, 4, 5));
            Assert.Equal(20, _yatzy.LargeStraight(2, 3, 4, 5, 6));
            Assert.Equal(0, _yatzy.LargeStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void one_pair()
        {
            Assert.Equal(6, _yatzy.ScorePair(3, 4, 3, 5, 6));
            Assert.Equal(10, _yatzy.ScorePair(5, 3, 3, 3, 5));
            Assert.Equal(12, _yatzy.ScorePair(5, 3, 6, 6, 5));
        }

        [Fact]
        public void sixes_Fact()
        {
            Assert.Equal(0, new Yatzy().Sixes(4, 4, 4, 5, 5));
            Assert.Equal(6, new Yatzy().Sixes(4, 4, 6, 5, 5));
            Assert.Equal(18, new Yatzy().Sixes(6, 5, 6, 6, 5));
        }

        [Fact]
        public void smallStraight()
        {
            Assert.Equal(15, _yatzy.SmallStraight(1, 2, 3, 4, 5));
            Assert.Equal(15, _yatzy.SmallStraight(2, 3, 4, 5, 1));
            Assert.Equal(0, _yatzy.SmallStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void three_of_a_kind()
        {
            Assert.Equal(9, _yatzy.ThreeOfAKind(3, 3, 3, 4, 5));
            Assert.Equal(15, _yatzy.ThreeOfAKind(5, 3, 5, 4, 5));
            Assert.Equal(9, _yatzy.ThreeOfAKind(3, 3, 3, 3, 5));
        }

        [Fact]
        public void two_Pair()
        {
            Assert.Equal(16, _yatzy.TwoPair(3, 3, 5, 4, 5));
            Assert.Equal(16, _yatzy.TwoPair(3, 3, 5, 5, 5));
        }

        [Fact]
        public void Yatzy_scores_50()
        {
            var expected = 50;
            var actual = _yatzy.yatzy(4, 4, 4, 4, 4);
            Assert.Equal(expected, actual);
            Assert.Equal(50, _yatzy.yatzy(6, 6, 6, 6, 6));
            Assert.Equal(0, _yatzy.yatzy(6, 6, 6, 6, 3));
        }
    }
}
