using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarceRover;

namespace MarseRoverTestCase
{
    [TestClass]
    public class MarseRoverTestResult
    {
        [TestMethod]
        public void CheckGetNextDirection()
        {
            Rover rover = new Rover();

            //
            Assert.AreEqual('N', rover.GetNextDirection('e', 'L'));
            Assert.AreEqual('W', rover.GetNextDirection('N', 'l'));
            Assert.AreEqual('S', rover.GetNextDirection('W', 'L'));
            Assert.AreEqual('E', rover.GetNextDirection('s', 'L'));
            //Assert.AreEqual('E', rover.GetNextDirection('T', 'L'));

            //
            Assert.AreEqual('E', rover.GetNextDirection('N', 'R'));
            Assert.AreEqual('S', rover.GetNextDirection('e', 'r'));
            Assert.AreEqual('W', rover.GetNextDirection('s', 'R'));
            Assert.AreEqual('N', rover.GetNextDirection('W', 'r'));

        }

        [TestMethod]
        public void CheckGetNextPoint()
        {
            Rover rover = new Rover();
            
            CollectionAssert.AreEqual(new int[] { 3, 2 }, rover.GetNextPoint(2, 2, 'E', 1));
            CollectionAssert.AreEqual(new int[] { 2, 2 }, rover.GetNextPoint(3, 2, 'w', 1));
            CollectionAssert.AreEqual(new int[] { 4, 6 }, rover.GetNextPoint(4, 4, 'N', 2));
            CollectionAssert.AreEqual(new int[] { 3, 1 }, rover.GetNextPoint(3, 3, 's', 2));
            //CollectionAssert.AreEqual(new int[] { 3, 1 }, rover.GetNextPoint(3, 3, 'J', 2));

        }
        [TestMethod]
        public void CheckIsNotBoundaryPoint()
        {
            Plateau plateau = new Plateau();
            plateau.SetPlateau(1, 0, 0, 3, 3);

            // positive test results
            Assert.IsTrue(plateau.IsNotBoundaryPoint(new int[] { 2, 2 }, plateau));
            Assert.IsTrue(plateau.IsNotBoundaryPoint(new int[] { 0, 0 }, plateau));
            Assert.IsTrue(plateau.IsNotBoundaryPoint(new int[] { 3, 3 }, plateau));

            //negative test results
            Assert.IsFalse(plateau.IsNotBoundaryPoint(new int[] { 4, 2 }, plateau));
            Assert.IsFalse(plateau.IsNotBoundaryPoint(new int[] { 2, 4 }, plateau));
            Assert.IsFalse(plateau.IsNotBoundaryPoint(new int[] { 4, 4 }, plateau));
            Assert.IsFalse(plateau.IsNotBoundaryPoint(new int[] { -4, 2 }, plateau));
            Assert.IsFalse(plateau.IsNotBoundaryPoint(new int[] { 2, -2 }, plateau));
        }

        [TestMethod]
        public void CheckIsAnyRoverInThisPoint()
        {

            Plateau plateau = new Plateau();
            plateau.SetPlateau(1, 0, 0, 5, 5);

            Rover alphaRover = new Rover();
            alphaRover.SetRover(1, 1, 2, 'E');

            Rover betaRover = new Rover();
            betaRover.SetRover(2, 1, 2, 'N');

            Rover gamaRover = new Rover();
            gamaRover.SetRover(2, 3, 4, 'N');


            plateau.AddRoverIntoPlateau(alphaRover);
            plateau.AddRoverIntoPlateau(betaRover);
            plateau.AddRoverIntoPlateau(gamaRover);

            //Assert.IsFalse(plateau.IsAnyRoverInThisPoint(new int[]{ alphaRover.XPoint, alphaRover.YPoint }, plateau.RoverCollection));
            Assert.IsTrue(plateau.IsAnyRoverInThisPoint(alphaRover, plateau.RoverCollection));
            Assert.IsFalse(plateau.IsAnyRoverInThisPoint(gamaRover, plateau.RoverCollection));

        }

        [TestMethod]
        public void CheckIsAnyRoverInThisPointForAddNewRover()
        {

            Plateau plateau = new Plateau();
            plateau.SetPlateau(1, 0, 0, 5, 5);

            Rover alphaRover = new Rover();
            alphaRover.SetRover(1, 1, 2, 'E');
            

            Rover betaRover = new Rover();
            betaRover.SetRover(2, 1, 2, 'N');

            Rover gamaRover = new Rover();
            gamaRover.SetRover(2, 3, 4, 'N');


            plateau.AddRoverIntoPlateau(alphaRover);

            //Assert.IsFalse(plateau.IsAnyRoverInThisPoint(new int[]{ alphaRover.XPoint, alphaRover.YPoint }, plateau.RoverCollection));
            Assert.IsTrue(plateau.IsAnyRoverInThisPoint(new int[]{betaRover.XPoint, betaRover.YPoint }, plateau.RoverCollection));
            Assert.IsFalse(plateau.IsAnyRoverInThisPoint(new int[]{gamaRover.XPoint , gamaRover.YPoint}, plateau.RoverCollection));

        }
    }
}
