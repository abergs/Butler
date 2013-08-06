using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButlerCore.Tests
{
    [TestClass]
    public class ButlerDocumentSortingTest
    {

        [TestMethod]
        public void TestSorting()
        {

            var doc1 = new TestDocument();
            var doc2 = new TestDocument();
            
            var docList = new List<TestDocument>() { doc1, doc2 };

            var sorting = docList[0].OrderBy();

            var result = docList.OrderBy(sorting).ToList();
            Assert.IsTrue(result[0] == doc1);
        }

    }


    public class TestDocument : ButlerDocument
    {
        public string Title { get; set; }
        public override Func<dynamic, dynamic> OrderBy()
        {
            return m => m.Title;
        }
    }
}
