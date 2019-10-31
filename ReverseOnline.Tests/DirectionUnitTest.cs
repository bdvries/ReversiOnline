using NUnit.Framework;
using ReversiOnline.Reversi;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseOnline.Tests
{
    public class DirectionUnitTests
    {
        [Test]
        public void DirectionArgumentsAreBetweenMinusOneAndOne()
        {
            // Then
            Assert.Catch<ArgumentException>(() => new Direction(2, 1));
            Assert.Catch<ArgumentException>(() => new Direction(-1, -5));
        }

        [Test]
        public void DirectionArgumentsAreSetCorrectely()
        {
            // Given
            var horizontal = 1;
            var vertical = -1;

            // When
            var direction = new Direction(horizontal, vertical);

            // Then
            Assert.AreEqual(horizontal, direction.Horizontal);
            Assert.AreEqual(vertical, direction.Vertical);
        }

        [Test]
        public void DirectionsAreAddedCorrectelyToPlaces()
        {
            // Given 
            var directionN = new Direction(0, -1);
            var directionS = new Direction(0, 1);
            var directionNE = new Direction(1, -1);
            var directionW = new Direction(-1, 0);
            var boardSize = 8;
            var place = 27;

            // When
            var placeAfterN = directionN.AddDirectionToCoordinate(place, boardSize);
            var placeAfterS = directionS.AddDirectionToCoordinate(place, boardSize);
            var placeAfterNE = directionNE.AddDirectionToCoordinate(place, boardSize);
            var placeAfterW = directionW.AddDirectionToCoordinate(place, boardSize);

            // Then
            Assert.AreEqual(19, placeAfterN);
            Assert.AreEqual(35, placeAfterS);
            Assert.AreEqual(20, placeAfterNE);
            Assert.AreEqual(26, placeAfterW);
        }
    }
}
