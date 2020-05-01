using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseManager.Core.Exceptions;
using ExpenseManager.Core.Entities;

namespace ExpenseManager.UnitTests
{
    [TestClass]
    public class ExpenseTest
    {

        [TestMethod]
        public void ShouldHaveName()
        {
            Assert.ThrowsException<BusinessRuleException>(() => new Expense("", 1), "Expense name can be empty");
            Assert.ThrowsException<BusinessRuleException>(() => new Expense(null, 1), "Expense name can be null");
        }

        [TestMethod]
        public void ShouldHaveAmmountGreaterThanZero()
        {
            Assert.ThrowsException<BusinessRuleException>(() => new Expense("Name", -1), "Negative expense ammount");
            Assert.ThrowsException<BusinessRuleException>(() => new Expense("Name", 0), "Expense ammount equals to 0");

        }

    }
}