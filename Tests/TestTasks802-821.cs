using NUnit.Framework;
using Tasks;

namespace Tests
{
    public class TestTasks802_821
    {
        private Tasks802_821 _tasks = new Tasks802_821();

        [TestCase("123asd32gd", 3)]
        [TestCase("d32dsd2fdf12345d", 5)]
        [TestCase("dwerwerwer", 0)]
        public void Task802(string text, int expected)
        {
            var actual = _tasks.Task802(text);
            Assert.AreEqual(expected, actual);
        }


        [TestCase("qweqwe", false)]
        [TestCase("q  weqwe", false)]
        [TestCase("q  w@eqwe", true)]
        [TestCase("qw1eqwe", true)]
        [TestCase("qw_eqwe", true)]
        public void Task803(string text, bool expected)
        {
            var actual = _tasks.Task803(text);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("abc*abc", "ABC*abc")]
        [TestCase("1bc*abc", "1BC*abc")]
        [TestCase("abc", "abc")]
        [TestCase("abc*abc*abc", "ABC*abc*abc")]
        public void Task804(string text, string expected)
        {
            var actual = _tasks.Task804a(text);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("123+abc", "---+abc")]
        [TestCase("abc+abc", "abc+abc")]
        [TestCase("1234abc", "1234abc")]
        [TestCase("1234abc", "1234abc")]
        [TestCase("+1234abc", "+1234abc")]
        [TestCase("+1234+abc", "+1234+abc")]
        public void Task804b(string text, string expected)
        {
            var actual = _tasks.Task804b(text);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("aaaBBB", "aaa...")]
        [TestCase("111aaBB", "111aa..")]
        [TestCase("111a", "111a")]
        [TestCase("BBB", "BBB")]
        [TestCase("BBB", "BBB")]
        public void Task805(string text, string expected)
        {
            var actual = _tasks.Task805(text);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Ax45a216U", true)]
        [TestCase("13 123", false)]
        [TestCase("123123123", true)]
        [TestCase("12@##3", false)]
        public void Task806a(string text, bool expected)
        {
            var actual = _tasks.Task806a(text);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("100", true)]
        [TestCase("-100", true)]
        [TestCase("+100", true)]
        [TestCase("1o", false)]
        [TestCase("1005500 ", false)]
        [TestCase(" -100500 ", false)]
        public void Task806b(string text, bool expected)
        {
            var actual = _tasks.Task806b(text);
            Assert.AreEqual(expected, actual);
        }
    }
}