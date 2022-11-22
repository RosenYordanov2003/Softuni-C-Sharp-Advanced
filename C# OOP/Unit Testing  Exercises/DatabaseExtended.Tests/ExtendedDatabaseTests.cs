namespace DatabaseExtended.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using ExtendedDatabase;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database databse;
        [TestCaseSource(nameof(Test_Constructor_Params))]

        public void Test_Constructor(Person[] people, int expectedCount)
        {
            databse = new Database(people);
            Assert.AreEqual(expectedCount,databse.Count);
        }

        public static IEnumerable<TestCaseData> Test_Constructor_Params()
        {
            TestCaseData[] tests = new TestCaseData[]
            {
                new TestCaseData
                (
                    new Person[]
                    {
                        new Person(10223,"Gosho"),
                        new Person(9999,"Vesko")
                    },
                    2)
            };
            foreach (TestCaseData item in tests)
            {
                yield return item;
            }
        }
    }
   
}