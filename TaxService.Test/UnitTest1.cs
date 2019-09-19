using NUnit.Framework;
using Tax;
using Tax.Model;
using Tax.SubService;

namespace Tests
{
    public class Tests
    {
        MainTax _mainTax = new MainTax();
        ExceptIncome _exceptIncome = new ExceptIncome();


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Ignore("Waing Model")]
        public void TestMainTax()
        {
            
        }

        [Test]
        [TestCase(150000, true, true, false)]
        [TestCase(100000, true, true, true)]
        [TestCase(119999.75, true, true, true)]
        [TestCase(120000, true, true, true)]
        [TestCase(120000.25, true, true, false)]
        [TestCase(150000, false, true, false)]
        [TestCase(150000, true, false, false)]
        [TestCase(150000, false, false, true)]
        public void InspectTaxPayer(decimal annualIncome, bool workThai, bool statusStayThai, bool result)
        {
            var model = _mainTax.InspectTaxPayer(annualIncome, workThai, statusStayThai);
            Assert.AreEqual(model, result);
        }

        [Test]
        [Ignore("Waing Model")]
        public void ExceptIncome_MainCalculate()
        {
            
        }

        [Test]
        [TestCase(300000, 300000)]
        [TestCase(299999.75, 299999.75)]
        [TestCase(300000.25, 300000)]
        public void ExceptIncome_AdaptUnemploy(decimal unemployFee, decimal result)
        {
            var model = _exceptIncome.AdaptUnemploy(unemployFee);
            Assert.AreEqual(model, result);
        }

        [Test]
        [TestCase(true, true, 190000)]
        [TestCase(true, false, 190000)]
        [TestCase(false, true, 190000)]
        [TestCase(false, false, 0)]
        public void ExceptIncome_DisabledAndElderly(bool isDisabled, bool isElderly, decimal result)
        {
            var model = _exceptIncome.DisabledAndElderly(isDisabled, isElderly);
            Assert.AreEqual(model, result);
        }

        [Test]
        [TestCase(200000, 500000, 200000, 300000)]
        [TestCase(300000, 100000, 100000, 0)]
        public void ExceptIncome_AdaptOtherValue(decimal value, decimal checkFund, decimal resultValue, decimal resultCheckFund)
        {
            _exceptIncome.CheckFund = checkFund;
            var model = _exceptIncome.AdaptOtherValue(value);
            decimal fund = _exceptIncome.CheckFund;
            Assert.AreEqual(model, resultValue);
            Assert.AreEqual(fund, resultCheckFund);
        }

        [Test]
        [TestCase(5000000, 600000, 500000, 500000, 0)]
        [TestCase(2000000, 600000, 500000, 300000, 200000)]
        [TestCase(2000000 ,300000, 500000, 300000, 200000)]
        [TestCase(1000000 ,300000, 500000, 150000, 350000)]
        public void ExceptIncome_AdaptProvident(decimal annualIncome, decimal providentFund, decimal checkFund, decimal resultValue, decimal resultCheckFund)
        {
            _exceptIncome.CheckFund = checkFund;
            var model = _exceptIncome.AdaptProvident(annualIncome, providentFund);
            decimal fund = _exceptIncome.CheckFund;
            Assert.AreEqual(model, resultValue);
            Assert.AreEqual(fund, resultCheckFund);
        }

        [Test]
        [TestCase(200000, 100000)]
        [TestCase(300000, 100000)]
        [TestCase(100000, 50000)]
        public void Expenses(decimal incomeDifExcept, decimal result)
        {
            var model = _mainTax.Expenses(incomeDifExcept);
            Assert.AreEqual(model, result);
        }
    }
}