namespace ExtensionTest
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void TestStringCenter()
        {
            string[] words = { "Test",  "Luminou", "Ponder", "StringExtensionsTest" };
            string[] results = { "  Test  ",  " Luminou", " Ponder ", "StringExtensionsTest" };
            for (int i = 0; i < words.Length; i++)
            {
                var testResult = words[i].Center(8);
                Assert.AreEqual(results[i], testResult);
            }
        }

        [TestMethod]
        public void TestStringCount()
        {
            string[] strs = { "I love apples, apple are my favorite fruit", "my favorite fruit", "I love apple", "applesapples" };
            int[] results = {1,0,0,2 };
            var val = "apples";
            for (int i = 0; i < strs.Length; i++)
            {
                var testResult = strs[i].Count(val);
                Assert.AreEqual(results[i], testResult);
            }
        }
    }
}   