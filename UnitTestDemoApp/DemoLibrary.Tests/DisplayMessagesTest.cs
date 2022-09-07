using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Tests
{
    public class DisplayMessagesTest
    {
        [Fact]
        public void GreetingShouldReturnGoodMorningMessage()
        {
            DisplayMessages messages = new DisplayMessages();
            string expected = "Good morning Tim";


            string actual = messages.Greeting("Tim", 2);


            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GreetingShouldReturnGoodAfternoonMessage()
        {
            DisplayMessages messages = new DisplayMessages();
            string expected = "Good afternoon Tim";


            string actual = messages.Greeting("Tim", 14);


            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("Tim", 0, "Good morning Tim")]
        [InlineData("Tim", 1, "Good morning Tim")]
        [InlineData("Tim", 2, "Good morning Tim")]
        [InlineData("Tim", 3, "Good morning Tim")]
        [InlineData("Tim", 4, "Good morning Tim")]
        [InlineData("Tim", 5, "Good morning Tim")]
        [InlineData("Tim", 6, "Good morning Tim")]
        [InlineData("Tim", 7, "Good morning Tim")]
        [InlineData("Tim", 8, "Good morning Tim")]
        [InlineData("Tim", 9, "Good morning Tim")]
        public void GreetingShouldReturnExpectedValue(
            string firstName,
            int hourOfTheDay,
            string expected)
        {
            DisplayMessages messages = new DisplayMessages();


            string actual = messages.Greeting(firstName, hourOfTheDay);


            Assert.Equal(expected, actual);
        }
    }
}
