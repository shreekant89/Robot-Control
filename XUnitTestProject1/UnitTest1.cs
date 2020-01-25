using Robot_Control.Common;
using Robot_Control.Logic;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private IPoint _point;

        private IRoom _room;

        Position obj;

        public UnitTest1()
        {
            _point = new Point();
            _room = new Position(_point);
            obj = new Position(_point);
        }

        [Fact]
        public void PassNullInstruction_ThrowException()
        {
            var abc = obj.finalPosition("");
            Assert.True(abc.GetType() == typeof(Exception));
        }

        [Theory]
        [InlineData(0, 0, 4, 4, "RF")]
        public void PassAllInformation_ShouldPass(int x, int y, int limitx, int limity, string move)
        {
            seedData(x, y);
            seedData1(limitx, limity);
            var result = obj.finalPosition(move);
            Assert.True(Convert.ToBoolean(result));
        }

        [Theory]
        [InlineData(0, 0, 4, 4, "RFFFFFFF")]
        [InlineData(-10, -10, 4, 4, "RF")]
        public void PassAllInformationOusideLimit_ShouldFail(int x, int y, int limitx, int limity, string move)
        {
            seedData(x, y);
            seedData1(limitx, limity);
            var result = obj.finalPosition(move);
            Assert.False(Convert.ToBoolean(result));
        }


        [Theory]
        [InlineData(1,2,"RFW")]
        public void Wrong_MoveShould_raiseError(int x,int y,string move)
        {
            seedData(x, y);

            var result = obj.finalPosition(move);
            Assert.False(Convert.ToBoolean(result));
        }

        private void seedData(int x, int y)
        {
            obj.StartPosition.X = x;
            obj.StartPosition.Y = y;
        }
        private void seedData1(int limitx, int limity)
        {
            obj.X = limitx;
            obj.Y = limitx;
        }
    }
}
