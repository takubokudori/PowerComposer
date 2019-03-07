using System;
using System.Collections.Generic;
using NUnit.Framework;
using PowerComposer;

namespace UnitTest
{
    [TestFixture]
    public class Tests
    {
        private static readonly Dictionary<string, string[]> EmptyDict = new Dictionary<string, string[]>();

        private static readonly Dictionary<string, string[]> dict1 = new Dictionary<string, string[]>
        {
            ["abc"] = new string[] {"a", "b", "c"},
            ["help"] = new string[] {" UNION SELECT", " OR 1=1 --", " Ruby", "Newbies"}
        };

        private static readonly Dictionary<string, string[]> dict2 = new Dictionary<string, string[]>
        {
            ["test"] = new string[] { }
        };

        private static readonly Dictionary<string, string[]> dict3 = new Dictionary<string, string[]>
        {
            ["xss"] = new string[] {"${abc}"},
            ["num"] = new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9"}
        };

        private static readonly Dictionary<string, string[]> LoopDict = new Dictionary<string, string[]>
        {
            ["a"] = new string[] {"${b}"},
            ["b"] = new string[] {"${c}"},
            ["c"] = new string[] {"${a}"}
        };

        public Tests()
        {
        }


        [Test]
        public void GenerateTest()
        {
            var prg = new RequestGenerator(new Dictionary<string, string[]>());
            var req = new string[] {"test", "testtest", "QWERTY", "", "}", "$}{", "{}"};
            prg.InitIterator();
            prg.ParseRequest(req);
            GenerateTestUnit(ref prg, true, req);
            GenerateTestUnit(ref prg, false);
        }

        [Test]
        public void GenerateVariableTest1()
        {
            var dict = dict1;
            var req = new string[] {"test${abc}qqq${help}eee"};
            var rg = new RequestGenerator();
            rg.InitIterator();
            rg.dict = dict;
            rg.ParseRequest(req);
            GenerateTestUnit(ref rg, true, new string[] {$"test{dict["abc"][0]}qqq{dict["help"][0]}eee"});
            GenerateTestUnit(ref rg, true, new string[] {$"test{dict["abc"][1]}qqq{dict["help"][1]}eee"});
            GenerateTestUnit(ref rg, true, new string[] {$"test{dict["abc"][2]}qqq{dict["help"][2]}eee"});
            GenerateTestUnit(ref rg, true, new string[] {$"testqqq{dict["help"][3]}eee"});
            GenerateTestUnit(ref rg, false, new string[] { });
        }

        [Test]
        public void GenerateVariableTest2()
        {
            var dict = dict3;
            var req = new string[] {"abcabc${xss}", "test${num}"};
            var rg = new RequestGenerator();
            rg.InitIterator();
            rg.dict = dict;
            rg.ParseRequest(req);
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc{dict["xss"][0]}", $"test{dict["num"][0]}"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc", $"test{dict["num"][1]}"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc", $"test{dict["num"][2]}"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc", $"test{dict["num"][3]}"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc", $"test{dict["num"][4]}"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc", $"test{dict["num"][5]}"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc", $"test{dict["num"][6]}"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc", $"test{dict["num"][7]}"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc", $"test{dict["num"][8]}"});
            GenerateTestUnit(ref rg, false);
        }

        [Test]
        public void GenerateUndefinedTest()
        {
            var dict = dict1;
            var req = new string[] {"abcabc${noexists}"};
            var rg = new RequestGenerator();
            rg.InitIterator();
            rg.ErrorByUndefinedVar = true;
            rg.dict = dict;
            rg.ParseRequest(req);
            var ex = Assert.Throws<GenerateException>(() => { GenerateTestUnit(ref rg, true); });
            Assert.That(ex.Message == "Undefined variable noexists");
        }

        [Test]
        public void GenerateIgnoreUndefinedTest()
        {
            var dict = dict1;
            var req = new string[] {"abcabc${abc}test${num}"};
            var rg = new RequestGenerator();
            rg.InitIterator();
            rg.ErrorByUndefinedVar = false;
            rg.dict = dict;
            rg.ParseRequest(req);
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc{dict["abc"][0]}test"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc{dict["abc"][1]}test"});
            GenerateTestUnit(ref rg, true, new string[] {$"abcabc{dict["abc"][2]}test"});
            GenerateTestUnit(ref rg, false);
        }

        [Test]
        public void GenerateUninitializedDictionaryTest()
        {
            var req = new string[] {"abcabc"};
            var rg = new RequestGenerator();
            rg.InitIterator();
            rg.ParseRequest(req);
            var ex = Assert.Throws<GenerateException>(() => { GenerateTestUnit(ref rg, true); });
            Assert.That(ex.Message == "Uninitialized Dictionary");
        }

        [Test]
        public void GESTest()
        {
            var rg = new RequestGenerator();
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("abc-xyzANN-JAL115-51419"));
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("a-zA-Z0-9"));
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("114-514"));
            Assert.AreEqual(GetList(0,9),rg.GenerateEnumArray("0-9"));
            Assert.AreEqual(GetList(9,0),rg.GenerateEnumArray("9-0"));
            Assert.AreEqual(GetList(15,30),rg.GenerateEnumArray("15-30"));
            Assert.AreEqual(GetList(1,532),rg.GenerateEnumArray("1-532"));
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("0-0"));
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("a-z"));
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("aa-zz"));
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("m-m"));
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("A-Z"));
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("HL-LN"));
//            Assert.AreEqual(new string[]{"True"},rg.GenerateEnumArray("M-M"));
//            Assert.AreEqual(new string[]{"False"},rg.GenerateEnumArray("0-a"));
//            Assert.AreEqual(new string[]{"False"},rg.GenerateEnumArray("a-A"));
//            Assert.AreEqual(new string[]{"False"},rg.GenerateEnumArray("A-2"));
//            Assert.AreEqual(new string[]{"False"},rg.GenerateEnumArray("a"));
//            Assert.AreEqual(new string[]{"False"},rg.GenerateEnumArray("a-"));
//            Assert.AreEqual(new string[]{"False"},rg.GenerateEnumArray("a-Aa"));
//            Assert.AreEqual(new string[]{"False"},rg.GenerateEnumArray("aA-Aa"));
        }

        private List<string> GetList(int s,int t,bool reverse=false)
        {
            List<string> ret=new List<string>();
            if(!reverse)for (int i = s; i <= t; i++)ret.Add(i.ToString());
            else for (int i = t; i >= s; i--)ret.Add(i.ToString());
            return ret;
        }
        [Test]
        public void GenerateEnumTest()
        {
            var req = new string[] {"abc#{1..9}def"};
            var rg = new RequestGenerator();
            rg.InitIterator();
            rg.dict = null;
            rg.ParseRequest(req);
            GenerateTestUnit(ref rg, true, new string[] {"abc1def"});
        }

        [Test]
        public void GenerateBrokenBracketsTest()
        {
            var dict = dict1;
            var req = new string[] {"${"};
            var rg = new RequestGenerator();
            rg.InitIterator();
            rg.dict = dict;
            rg.ParseRequest(req);
            var ex = Assert.Throws<GenerateException>(() => { GenerateTestUnit(ref rg, true); });
            Assert.That(ex.Message == "Broken brackets found");
        }

        private void GenerateTestUnit(ref RequestGenerator prg, bool expectedHasNext, string[] expectedReturn = null)
        {
            bool hasNext = prg.HasNext();
            if (!expectedHasNext)
            {
                Assert.False(hasNext);
                return;
            }

            Assert.True(hasNext);
            Assert.AreEqual(expectedReturn, prg.Generate());
        }
    }
}