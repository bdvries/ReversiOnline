using NUnit.Framework;
using ReversiOnline.Reversi;
using System;
using System.Collections.Generic;

namespace ReverseOnline.Tests
{
    public class BoardUnitTests
    {
        ReversiBoard board;

        [SetUp]
        public void Setup()
        {
            board = new ReversiBoard();
        }

        [Test]
        public void DefaultBoardIsInitializedCorrectely()
        {
            // Then
            Assert.AreEqual(board.Board[27], Players.PLAYER1);
            Assert.AreEqual(board.Board[28], Players.PLAYER2);
            Assert.AreEqual(board.Board[35], Players.PLAYER2);
            Assert.AreEqual(board.Board[36], Players.PLAYER1);
        }

        [Test]
        public void MovesAreValidatedCorrectely()
        {
            // When
            var resultPlace28P1 = board.ValidateMove(28, Players.PLAYER1);
            var resultPlace28P2 = board.ValidateMove(28, Players.PLAYER2);

            var resultPlace29P1 = board.ValidateMove(29, Players.PLAYER1);
            var resultPlace29P2 = board.ValidateMove(29, Players.PLAYER2);

            var resultPlace30P1 = board.ValidateMove(30, Players.PLAYER1);
            var resultPlace30P2 = board.ValidateMove(30, Players.PLAYER2);

            // Then
            Assert.AreEqual(false, resultPlace28P1);
            Assert.AreEqual(false, resultPlace28P2);

            Assert.AreEqual(true, resultPlace29P1);
            Assert.AreEqual(false, resultPlace29P2);

            Assert.AreEqual(false, resultPlace30P1);
            Assert.AreEqual(false, resultPlace30P2);
        }

        [Test]
        public void IllegalMovesReturnZeroChangedDisks()
        {
            // When
            var changedDisks = board.TryMakeMove(28, Players.PLAYER1);

            // Then
            Assert.AreEqual(changedDisks, 0);
        }

        [Test]
        public void ValidMovesAreAppliedCorrectely()
        {
            // When
            board.TryMakeMove(29, Players.PLAYER1);

            // Then
            Assert.AreEqual(board.Board[28], Players.PLAYER1);
            Assert.AreEqual(board.Board[29], Players.PLAYER1);
        }

        // TODO: Maybe add more complex moves to validate and apply, also load a board.
    }
}