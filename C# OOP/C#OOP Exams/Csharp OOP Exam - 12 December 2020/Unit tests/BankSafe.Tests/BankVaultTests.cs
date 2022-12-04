using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bank;
        [SetUp]
        public void Setup()
        {
            item = new Item("Pesho", "1112");
            bank = new BankVault();
        }

        [Test]
        public void Test_ItemConstructor()
        {
            Assert.AreEqual("Pesho", item.Owner);
            Assert.AreEqual("1112", item.ItemId);
        }

        [Test]
        public void Test_BankVault_Constructor()
        {
            Assert.IsNotNull(bank.VaultCells);
        }
        [Test]
        public void Test_BankVault_AddItemMethod_With_NoExistingCell()
        {
            Assert.Throws<ArgumentException>(() => bank.AddItem("D9", item));
        }
        [Test]
        public void Test_BankVault_AddItemMethod_With_FilledCell()
        {
            bank.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", new Item("Gosho", "9900")));
        }
        [Test]
        public void Test_BankVault_Wit_Already_Existing_Item()
        {
            bank.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bank.AddItem("A2", item));
        }

        [Test]
        public void Test_BankVault_AddItemMethod_ShouldWork()
        {
            string expectedResult = string.Format($"Item:{item.ItemId} saved successfully!");
            Assert.AreEqual(expectedResult, bank.AddItem("A1", item));
            Assert.AreSame(item, bank.VaultCells["A1"]);
        }

        [Test]
        public void Test_BankVault_RemoveMethod_WithNoExisting_Cell()
        {
            Assert.Throws<ArgumentException>(() => bank.RemoveItem("Z11", new Item("Gosho", "9900")));
        }
        [Test]
        public void Test_BankVault_RemoveMethod_WithNoExisting_Item_On_This_Cell()
        {
            bank.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bank.RemoveItem("A1", new Item("Gosho", "9900")));
        }
        [Test]
        public void Test_BankVault_RemoveMethod_ShouldWork()
        {
            bank.AddItem("A1", item);
            string expectedResult = string.Format($"Remove item:{item.ItemId} successfully!");
            Assert.AreEqual(expectedResult, bank.RemoveItem("A1", item));
            Assert.AreSame(null, bank.VaultCells["A1"]);
        }
    }
}