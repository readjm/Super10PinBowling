using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster
{
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        
        for (int i = 1; i < rolls.Count; i += 2)
        {
            if (frameList.Count == 10) { break; }               // Prevents 11th frame score

            if (rolls[i - 1] + rolls[i] < 10)
            {                                                   // Normal "open" frame
                frameList.Add(rolls[i - 1] + rolls[i]);
            }
            else if (rolls.Count - i <= 1)                      // Insufficient look-ahead
            {
                break;
            }               
            else if (rolls[i - 1] == 10)
            {                                                   // STRIKE
                i--;                                            // Strike frame has just one bowl
                frameList.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if (rolls[i - 1] + rolls[i] == 10)
            {                                                   // Calculate SPARE bonus
                frameList.Add(10 + rolls[i + 1]);
            }
        }
        return frameList;
    }
}