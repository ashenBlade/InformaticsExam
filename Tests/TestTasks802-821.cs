using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        [Test]
        public void Task808a()
        {
            var texts = new []{"hello hello hello", "1 1 2", "a b c d"};
            var expected = new Dictionary<string, int>[]
                           {
                               new Dictionary<string, int>() {{"hello", 3}},
                               new Dictionary<string, int>(){{"1", 2}, {"2", 1}},
                               new Dictionary<string, int>(){{"a", 1}, {"b", 1}, {"c", 1}, {"d", 1}}
                           };
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected[i], _tasks.Task808a(texts[i]));
            }
        }

        [Test]
        public void Task808b()
        {
            var texts = new []{"hello my name", "yes no abracadabra", "a b c d"};
            var expected = new[]
                           {
                               new List<string>() {"hello", "name"}, new List<string>() {"abracadabra"},
                               new List<string>() {"a"}
                           };
            for (int i = 0; i < 3; i++)
            {
                var actual = _tasks.Task808b(texts[i]);
                Assert.AreEqual(expected[i], actual);
            }
        }

        [Test]
        public void Task808c()
        {
            var texts = new []{"hello my name", "yes no abracadabra", "a b c d", "ab abbb"};
            var expected = new[]
                           {
                               new List<string>() {"name"}, new List<string>() {"abracadabra"},
                               new List<string>() {"a", "b"}, new List<string>() {"ab", "abbb"}
                           };
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(expected[i], _tasks.Task808c(texts[i]));
            }
        }

        [Test]
        public void Task808d()
        {
            var texts = new []{"turning my name", "yes no abracadabra", "a walking swimming d", "ab 123"};
            var expected = new[]
                           {
                               new List<string>(){"turned", "my", "name"},
                               new List<string>(){"yes", "no", "abracadabra"},
                               new List<string>(){"a", "walked", "swimmed", "d"},
                               new List<string>(){"ab", "123"},
                           };
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(expected[i], _tasks.Task808d(texts[i]));
            }
        }

        [TestCase(123, "123")]
        [TestCase(12345, "12 345")]
        [TestCase(12, "12")]
        [TestCase(1234567, "1 234 567")]
        public void Task809(int number, string expected)
        {
            var actual = _tasks.Task809(number);
            Assert.AreEqual(expected, actual);
        }
    }
}