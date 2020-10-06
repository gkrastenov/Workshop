namespace TheGeneral.Tests
{
    using NUnit.Framework;
    using System;
    public class Tests
    {
        private OperationSuccessCalculator calculator;
        private int incorrectInputWidth = 201;
        private int incorrectInputHight = 301;

        [SetUp]
        public void Setup()
        {
            this.calculator = new OperationSuccessCalculator();
        }

        [Test]
        public void AttackShouldWorkCorrect()
        {
            Assert.IsTrue(calculator.IsAttackSuccesful(25, 10));
            Assert.IsFalse(calculator.IsAttackSuccesful(22, 10));
        }

        [Test]
        public void DefenceShouldWorkCorrect()
        {
            Assert.IsTrue(calculator.IsDefenceSuccesful(25, 25));
            Assert.IsFalse(calculator.IsDefenceSuccesful(24, 24));
        }

        [Test]
        public void DefenceShouldThrowAnExceptionForIncorrectInput()
        {
            Assert.Throws<InvalidOperationException>(()
                => calculator.IsDefenceSuccesful(this.incorrectInputWidth,
                this.incorrectInputHight));
           // TODO : Can check for correct message from exeption
        }

        [Test]
        public void AttackShouldThrowAnExceptionForIncorrectInput()
        {
            Assert.Throws<InvalidOperationException>(()
                 => calculator.IsAttackSuccesful(this.incorrectInputWidth,
                this.incorrectInputHight));
            // TODO : Can check for correct message from exeption
        }

    }
}