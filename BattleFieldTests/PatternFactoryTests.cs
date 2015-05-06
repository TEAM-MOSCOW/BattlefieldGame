    using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battlefield;
using System.Collections.Generic;

namespace BattleFieldTests
{
    [TestClass]
    public class PatternFactoryTests
    {
        [TestMethod]
        public void TestGenerateFirstDetonationPattern()
        {
            var cell = new Cell(5, 5);
            List<Cell> expectedResult = new List<Cell>
            {
                new Cell(4, 6),
                new Cell(4, 4),
                new Cell(5, 5),
                new Cell(6, 6),
                new Cell(6, 4)
            };
            Assert.AreEqual(PatternFactory.GenerateFirstDetonationPattern(cell), expectedResult);
        }
    }
}
