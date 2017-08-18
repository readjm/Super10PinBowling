using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest
{
    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl1()
    {
        Player player = new Player();
        int[] rolls = { 1 };
        player.rolls = rolls.ToList();
        string rollString = "1";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(player, false));
    }

    [Test]
    public void T02BowlX()
    {
        Player player = new Player();
        int[] rolls = { 10 };
        player.rolls = rolls.ToList();
        string rollString = "X ";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(player, false));
    }

    [Test]
    public void T03Bowl19()
    {
        Player player = new Player();
        int[] rolls = { 1,9 };
        player.rolls = rolls.ToList();
        string rollString = "1/";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(player, false));
    }

    [Test]
    public void T04BowlStrikeInLastFrame()
    {
        Player player = new Player();
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1 };
        player.rolls = rolls.ToList();
        string rollString = "111111111111111111X11";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(player, false));
    }

    [Test]
    public void T05BowlStrikeInLastFrame()
    {
        Player player = new Player();
        int[] rolls = { 0 };
        player.rolls = rolls.ToList();
        string rollString = "-";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(player, false));
    }

    [Test]
    public void T06Bowl010()
    {
        Player player = new Player();
        int[] rolls = { 0, 10 };
        player.rolls = rolls.ToList();
        string rollString = "-/";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(player, false));
    }

    [Test]
    public void T07Bowl73XX()
    {
        Player player = new Player();
        int[] rolls = { 7, 3, 10, 10 };
        player.rolls = rolls.ToList();
        string rollString = "7/X X ";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(player, false));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG01GoldenCopyB1of3()
    {
        Player player = new Player();
        int[] rolls = { 10, 9, 1, 9, 1, 9, 1, 9, 1, 7, 0, 9, 0, 10, 8, 2, 8, 2, 10 };
        player.rolls = rolls.ToList();
        string rollsString = "X 9/9/9/9/7-9-X 8/8/X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(player, false));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG02GoldenCopyB2of3()
    {
        Player player = new Player();
        int[] rolls = { 8, 2, 8, 1, 9, 1, 7, 1, 8, 2, 9, 1, 9, 1, 10, 10, 7, 1 };
        player.rolls = rolls.ToList();
        string rollsString = "8/819/718/9/9/X X 71";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(player, false));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB3of3()
    {
        Player player = new Player();
        int[] rolls = { 10, 10, 9, 0, 10, 7, 3, 10, 8, 1, 6, 3, 6, 2, 9, 1, 10 };
        player.rolls = rolls.ToList();
        string rollsString = "X X 9-X 7/X 8163629/X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(player, false));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG04GoldenCopyC1of3()
    {
        Player player = new Player();
        int[] rolls = { 7, 2, 10, 10, 10, 10, 7, 3, 10, 10, 9, 1, 10, 10, 9 };
        player.rolls = rolls.ToList();
        string rollsString = "72X X X X 7/X X 9/XX9";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(player, false));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG05GoldenCopyC2of3()
    {
        Player player = new Player();
        int[] rolls = { 10, 10, 10, 10, 9, 0, 10, 10, 10, 10, 10, 9, 1 };
        player.rolls = rolls.ToList();
        string rollsString = "X X X X 9-X X X X X9/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(player, false));
    }
}
