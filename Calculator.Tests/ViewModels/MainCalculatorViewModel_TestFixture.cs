using System;
using System.Collections.Generic;
using System.Text;
using Calculator.ViewModels;
using NUnit.Framework;

namespace Calculator.Tests.ViewModels
{
    [TestFixture]
    public class MainCalculatorViewModel_TestFixture
    {
        private MainCalculatorViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            _viewModel = new MainCalculatorViewModel();
            _viewModel.Init();
        }



        [Test]
        public void InitShouldSetEntryTo0()
        {
            // Arrange
            // Setup() enough

            // Act
            // Setup() enough

            // Assert
            Assert.AreEqual("0", _viewModel.CalculatorEntry);
        }


        [Test]
        public void Pressing0AfterInitShouldChangeNothing()
        {
            // Arrange
            // Setup() enough

            // Act
            _viewModel.NumericEntryCommand.Execute("0");

            // Assert
            Assert.AreEqual("0", _viewModel.CalculatorEntry);
        }


        [Test]
        public void Pressing0After1ShouldMake10()
        {
            // Arrange
            // Setup() enough

            // Act
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("0");

            // Assert
            Assert.AreEqual("10", _viewModel.CalculatorEntry);
        }


        [Test]
        public void PressingDecimalAsFirstEntryShouldMake0Point()
        {
            // Arrange
            // Setup() enough

            // Act
            _viewModel.DecimalCommand.Execute(null);

            // Assert
            Assert.AreEqual("0.", _viewModel.CalculatorEntry);
        }

        [Test]
        public void PressingDecimalTwicwAsFirstEntryShouldMake0Point()
        {
            // Arrange
            // Setup() enough

            // Act
            _viewModel.DecimalCommand.Execute(null);
            _viewModel.DecimalCommand.Execute(null);

            // Assert
            Assert.AreEqual("0.", _viewModel.CalculatorEntry);
        }

        [Test]
        public void Pressing12Decimal34ShouldMake12Point34()
        {
            // Arrange
            // Setup() enough

            // Act
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");
            _viewModel.DecimalCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("3");
            _viewModel.NumericEntryCommand.Execute("4");

            // Assert
            Assert.AreEqual("12.34", _viewModel.CalculatorEntry);
        }


        [Test]
        public void PressingClearShouldMake0()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");
            _viewModel.NumericEntryCommand.Execute("3");
            _viewModel.NumericEntryCommand.Execute("4");

            // Act
            _viewModel.ClearCommand.Execute(null);

            // Assert
            Assert.AreEqual("0", _viewModel.CalculatorEntry);
        }

        [Test]
        public void Pressing0AfterClearShouldChangeNothing()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");

            // Act
            _viewModel.ClearCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("0");

            // Assert
            Assert.AreEqual("0", _viewModel.CalculatorEntry);
        }

        [Test]
        public void PressingDecimalAfterClearShouldMake0Point()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");

            // Act
            _viewModel.ClearCommand.Execute(null);
            _viewModel.DecimalCommand.Execute(null);

            // Assert
            Assert.AreEqual("0.", _viewModel.CalculatorEntry);
        }

        [Test]
        public void PressingDecimalTwiceAfterClearShouldMake0Point()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");


            // Act
            _viewModel.ClearCommand.Execute(null);
            _viewModel.DecimalCommand.Execute(null);
            _viewModel.DecimalCommand.Execute(null);

            // Assert
            Assert.AreEqual("0.", _viewModel.CalculatorEntry);
        }


        [Test]
        public void ShouldTrapDivideByZero()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");
            _viewModel.NumericEntryCommand.Execute("3");
            _viewModel.NumericEntryCommand.Execute("4");

            // Act
            _viewModel.DivideCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("0");
            _viewModel.EqualsCommand.Execute(null);


            // Assert
            Assert.AreEqual("Error", _viewModel.CalculatorEntry);
        }

        [Test]
        public void ShouldDivideByTen()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");
            _viewModel.NumericEntryCommand.Execute("3");
            _viewModel.NumericEntryCommand.Execute("4");

            // Act
            _viewModel.DivideCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("0");
            _viewModel.EqualsCommand.Execute(null);


            // Assert
            Assert.AreEqual("123.4", _viewModel.CalculatorEntry);
        }


        [Test]
        public void ShouldAdd12and14()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");

            // Act
            _viewModel.PlusCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("4");
            _viewModel.EqualsCommand.Execute(null);


            // Assert
            Assert.AreEqual("26", _viewModel.CalculatorEntry);
        }


        [Test]
        public void ShouldSubtract12From14()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("4");

            // Act
            _viewModel.SubtractCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");
            _viewModel.EqualsCommand.Execute(null);


            // Assert
            Assert.AreEqual("2", _viewModel.CalculatorEntry);
        }


        [Test]
        public void ShouldSubtract14From12()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("2");

            // Act
            _viewModel.SubtractCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("4");
            _viewModel.EqualsCommand.Execute(null);


            // Assert
            Assert.AreEqual("-2", _viewModel.CalculatorEntry);
        }


        [Test]
        public void ShouldMultiply6And8()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("6");

            // Act
            _viewModel.MultiplyCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("8");
            _viewModel.EqualsCommand.Execute(null);


            // Assert
            Assert.AreEqual("48", _viewModel.CalculatorEntry);
        }

        [Test]
        public void AnswerShouldTruncateOneThirdTo8Decimals()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("1");
            _viewModel.NumericEntryCommand.Execute("0");
            // Act
            _viewModel.DivideCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("3");
            _viewModel.EqualsCommand.Execute(null);


            // Assert
            Assert.AreEqual("3.33333333", _viewModel.CalculatorEntry);

        }

        [Test]
        public void AnswerShouldTruncateTwoThirdsTo8Decimals()
        {
            // Arrange
            _viewModel.NumericEntryCommand.Execute("2");
            _viewModel.NumericEntryCommand.Execute("0");
            // Act
            _viewModel.DivideCommand.Execute(null);
            _viewModel.NumericEntryCommand.Execute("3");
            _viewModel.EqualsCommand.Execute(null);


            // Assert
            Assert.AreEqual("6.66666666", _viewModel.CalculatorEntry);

        }
    }
}
