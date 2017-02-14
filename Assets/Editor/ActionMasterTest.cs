using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest
{
    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.ENDTURN;
    private ActionMaster.Action endGame = ActionMaster.Action.ENDGAME;
    private ActionMaster.Action tidy = ActionMaster.Action.TIDY;
    private ActionMaster.Action reset = ActionMaster.Action.RESET;

    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void T01_OneStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02_Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03_Bowl82SpareReturnsEndTurn()
    {
        int[] rolls = {8, 2};
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04_Bowl010SpareCorrectlyIncrementsBowl()
    {
        int[] rolls = {0, 10};
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05_LastFrameSpareReturnsReset()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 2, 8 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06_LastFrameFirstStrikeReturnsReset()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};

        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07_LastFrameSecondStrikeReturnsReset()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};

        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08_LastFrameThrow20ExtraBowl5ReturnsTidy()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 5 };

        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09_LastFrameExtraBowlReturnsEndGame()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10_LastFrame25ReturnsEndGame()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 2, 5 };

        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
}