using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster {
	public enum Action {TIDY, RESET, ENDTURN, ENDGAME, UNDEFINED};
	
	public static Action NextAction (List<int> rolls) {
		Action nextAction = Action.UNDEFINED;

        int rollNumber = 0;
        for (int i = 0; i < rolls.Count; i++) // Step through rolls
        {
			
			if (rollNumber == 20)
            {
				nextAction = Action.ENDGAME;
			}
            else if ( rollNumber >= 18 && rolls[i] == 10) // Handle last-frame special cases
            { 
				nextAction = Action.RESET;
			}
            else if ( rollNumber == 19 )
            {
				if (rolls[i-1]==10 && rolls[i]==0)
                {
					nextAction = Action.TIDY;
				}
                else if (rolls[i-1] + rolls[i] == 10)
                {
					nextAction = Action.RESET;
				}
                else if (rolls [i-1] + rolls[i] >= 10) // Roll 21 awarded
                {  
					nextAction = Action.TIDY;
				}
                else
                {
					nextAction = Action.ENDGAME;
				}
			}
            else if (rollNumber % 2 == 0) // First bowl of frame
            { 
                if (rolls[i] == 10)
                {
					//rolls.Insert (i, 0); // Insert virtual 0 after strike
					nextAction = Action.ENDTURN;
                    rollNumber++;
				}
                else
                {
					nextAction = Action.TIDY;
				}
			}
            else // Second bowl of frame
            { 
				nextAction = Action.ENDTURN;
			}
            rollNumber++;
		}
        return nextAction;
	}
}