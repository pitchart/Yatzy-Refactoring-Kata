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

        [Theory]
        [InlineData(1, 2, 3, 2, 6,4)]
        [InlineData(2, 2, 2, 2, 2,10)]
        public void Twos_scores_sum_of_all_twos(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, _yatzy.Twos(d1, d2, d3, d4, d5));
        }

        [Theory]
        [InlineData(1, 2, 3, 2, 3,6)]
        [InlineData(2, 3, 3, 3, 3,12)]
        public void Threes_scores_sum_of_all_threes(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, _yatzy.Threes(d1, d2, d3, d4, d5));
        }

        [Theory]
        [InlineData(4, 4, 4, 5, 5,12)]
        [InlineData(4, 4, 5, 5, 5,8)]
        [InlineData(4, 5, 5, 5, 5,4)]
        public void Fours_scores_sum_of_all_fours(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, _yatzy.Fours(d1, d2, d3, d4, d5));
        }

        [Theory]
        [InlineData(4, 4, 4, 5, 5,10)]
        [InlineData(4, 4, 5, 5, 5,15)]
        [InlineData(4, 5, 5, 5, 5,20)]
        public void Fives_scores_sum_of_all_fives(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, _yatzy.Fives(d1, d2, d3, d4, d5));
        }

        [Theory]
        [InlineData(4, 4, 4, 5, 5,0)]
        [InlineData(4, 4, 6, 5, 5,6)]
        [InlineData(6, 5, 6, 6, 5,18)]
        public void Sixes_scores_sum_of_all_sixes(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, _yatzy.Sixes(d1, d2, d3, d4, d5));
        }

        [Fact]
        public void four_of_a_knd()
        {
            Assert.Equal(12, _yatzy.FourOfAKind(3, 3, 3, 3, 5));
            Assert.Equal(20, _yatzy.FourOfAKind(5, 5, 5, 4, 5));
            Assert.Equal(12, _yatzy.FourOfAKind(3, 3, 3, 3, 3));
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

        [Theory]
        [InlineData(3, 4, 3, 5, 6, 6)]
        [InlineData(5, 3, 3, 3, 5, 10)]
        [InlineData(5, 3, 6, 6, 5, 12)]
        [InlineData(2, 3, 1, 6, 5, 0)]
        public void One_pair_scores_sum_of_highest_pair_values(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, _yatzy.ScorePair(d1, d2, d3, d4, d5));
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
