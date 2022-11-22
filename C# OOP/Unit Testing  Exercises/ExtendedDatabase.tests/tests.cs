using System;
using System.Collections.Generic;

namespace ExtendedDatabase.tests
{
    using NUnit.Framework;
    public class ExtendedDataBaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(new Person(20000, "Gosho"));
        }

        [TestCaseSource(nameof(Create_Insatnce))]
        public void Test_Construcotr(Person[] people, int excepctedCount)
        {
            database = new Database(people);
            Assert.AreEqual(excepctedCount, database.Count);
        }
        [TestCaseSource(nameof(Create_AddMethod_Insatnce))]
        public void Test_Add_Method(Person[] ctorPeople, Person[] peopleToAdd, int expectedResult)
        {
            database = new Database(ctorPeople);
            foreach (Person person in peopleToAdd)
            {
                database.Add(person);
            }
            Assert.AreEqual(expectedResult, database.Count);
        }
        [TestCaseSource(nameof(Add_Method_ShouldThrow_AnException))]
        public void Test_AddMethod_ShouldNotWork(Person[] ctorPeople, Person[] peopleToAdd)
        {
            database = new Database(ctorPeople);
            foreach (Person person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(1000, "Aleks"));
            });
        }

        [Test]

        public void AddMethod_WithException_SameId()
        {
            database = new Database(new Person(9999, "Skull"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(9999, "Aleks"));
            });
        }

        [Test]

        public void AddMethod_WithException_SameUserName()
        {
            database = new Database(new Person(99991, "Aleks"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(9999, "Aleks"));
            });
        }

        [Test]
        public void Remove_Method_With_InvalidCount()
        {
            database.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void RemoveMethod_ShouldWork()
        {
            int dataBaseCountAfterRemoveMethod = database.Count - 1;
            database.Remove();
            Assert.AreEqual(dataBaseCountAfterRemoveMethod, database.Count);
        }

        [TestCaseSource(nameof(Create_AddRange_Instance))]
        public void AddRange_Method_ShouldNotWork(Person[] peopleToAdd1, Person[]peopleToAdd2)
        {
            Person[] people = new Person[18];
            int index = 0;
            for (int i = 0; i < peopleToAdd1.Length; i++)
            {
                people[index++] = peopleToAdd1[i];
            }

            for (int i = 0; i < peopleToAdd2.Length; i++)
            {
                people[index++] = peopleToAdd2[i];
            }
            Assert.Throws<ArgumentException>(() =>
            {
                database = new Database(people);
            });
        }
        [Test]
        public void FindBy_UserName_ShouldWork()
        {
            Person person = database.FindByUsername("Gosho");
            Assert.AreEqual(person.UserName, "Gosho");
        }
        [Test]
        public void FindBy_UserName_ShouldNotWork_WithNull()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                Person person = database.FindByUsername(null);
            });
        }
        [Test]
        public void FindBy_UserName_ShouldNotWork_WithEmptyString()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                Person person = database.FindByUsername("");
            });
        }
        [Test]
        public void FindBy_UserName_ShouldNotWork_With_NoExisting_UserName()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = database.FindByUsername("Ivan");
            });
        }
        [Test]
        public void FindBy_UserId_ShouldWork()
        {
            Person person = database.FindById(20000);
            Assert.AreEqual(20000, person.Id);
        }
        [Test]
        public void FindBy_Negative_UserId_Should_NotWork()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Person person = database.FindById(-20);
            });
        }
        [Test]
        public void FindBy_NoExisting_UserId_Should_NotWork()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = database.FindById(99487934);
            });
        }



        public static IEnumerable<TestCaseData> Create_Insatnce()
        {
            TestCaseData[] tests = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1329, "Gosho"),
                        new Person(9999, "Vesko")
                    },
                    2),
                new TestCaseData(new Person[]
                {
                    new Person(1111,"Bob")

                },
                1)
            };
            foreach (TestCaseData item in tests)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> Create_AddMethod_Insatnce()
        {
            TestCaseData[] tests = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1329, "Gosho"),
                        new Person(9999, "Vesko")
                    },

                new Person[]
                    {
                        new Person(1211,"Bob"),
                        new Person(1311,"Kris")
                    },
                    4)
            };
            foreach (TestCaseData item in tests)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> Add_Method_ShouldThrow_AnException()
        {
            TestCaseData[] tests = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1329, "Gosho"),
                        new Person(9999, "Vesko")
                    },

                    new Person[]
                    {
                        new Person(99991,"Bob"),
                        new Person(1311,"Kris"),
                        new Person(1351,"Kris1"),
                        new Person(1361,"Kris2"),
                        new Person(1411,"Kris3"),
                        new Person(1511,"Kris4"),
                        new Person(1611,"Kris5"),
                        new Person(1711,"Kris6"),
                        new Person(1811,"Kris7"),
                        new Person(1911,"Kris8"),
                        new Person(13311,"Kris9"),
                        new Person(131451,"Kris10"),
                        new Person(131167,"Kris11"),
                        new Person(131199,"Kris12"),
                    }
                    )
            };
            foreach (TestCaseData item in tests)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> Create_AddRange_Instance()
        {
            TestCaseData[] tests = new TestCaseData[]
            {
                new TestCaseData(

                    new Person[]
                    {
                        new Person(99991,"Bob"),
                        new Person(1311,"Kris"),
                        new Person(1351,"Kris1"),
                        new Person(1361,"Kris2"),
                        new Person(1411,"Kris3"),
                        new Person(1511,"Kris4"),
                        new Person(1611,"Kris5"),
                        new Person(1711,"Kris6"),
                        new Person(1811,"Kris7"),
                        new Person(1911,"Kris8"),

                    },
                    new Person[]
                    {
                        new Person(13311,"Kris9"),
                        new Person(131451,"Kris10"),
                        new Person(131167,"Kris11"),
                        new Person(531199,"Kris12"),
                        new Person(431199,"Kris14"),
                        new Person(331199,"Kris15"),
                        new Person(231199,"Kris17"),
                        new Person(2311993,"Kris99"),
                    }
                    )
            };
            foreach (TestCaseData item in tests)
            {
                yield return item;
            }
        }

    }
}