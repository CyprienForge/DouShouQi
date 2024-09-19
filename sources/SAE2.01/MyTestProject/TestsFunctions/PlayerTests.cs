using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Essentials;
using MyTestProject.Data;

namespace MyTestProject.TestsFunctions
{
    public class PlayerTests
    {
        [Theory]
        [MemberData(nameof(DataTests.Data_TestPlayersEquals), MemberType = typeof(DataTests))]
        public void TestPlayersEquals(Player player1, object player2, bool expectedResult)
        {
            bool result = player1.Equals(player2 as Player);
            Assert.Equal(result, expectedResult);
        }
    }
}
