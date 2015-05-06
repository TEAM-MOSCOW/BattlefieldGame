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
           var cell = new Cell(2, 4);
           List<Cell> cellsToDetonate = new List<Cell>
            {
                new Cell(1, 3),
                new Cell(3, 3),
                new Cell(2, 4),
                new Cell(1, 5),
                new Cell(3, 5)
            };
            
            CollectionAssert.AreEqual(PatternFactory.GenerateFirstDetonationPattern(cell).ToArray(), cellsToDetonate.ToArray());
        }

        public void TestGenerateSecondDetonationPattern()
        {
            var cell = new Cell(2, 4);
            List<Cell> cellsToDetonate = new List<Cell>
            {
                new Cell(1, 3),
                new Cell(3, 3),
                new Cell(2, 4),
                new Cell(1, 5),
                new Cell(3, 5),
                new Cell(2, 3),
                new Cell(2, 5),
                new Cell(1, 4),
                new Cell(3, 4)
            };

            CollectionAssert.AreEqual(PatternFactory.GenerateSecondDetonationPattern(cell).ToArray(), cellsToDetonate.ToArray());
        }
    }
}
