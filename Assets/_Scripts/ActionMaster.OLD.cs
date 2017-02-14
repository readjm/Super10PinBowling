//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class ActionMasterOld
//{
//    public enum Action {TIDY, RESET, ENDTURN, ENDGAME};

//    private int[] bowls = new int[21];
//	private int bowl = 1;
//    private bool extraBowl = false;

//    private Action Bowl(int pinsDown)
//    {
//        if (bowl <= 21)
//        {
//            bowls[bowl-1] = pinsDown;
//        }

//        if (pinsDown < 0 || pinsDown > 10) { throw new UnityException("pinsDown not between 0 and 10!"); }

//        //Extra bowl rules
//        if (extraBowl == true)
//        {
//            if (bowl == 20 && pinsDown == 10)
//            {
//                bowl += 1;
//                return Action.RESET;
//            }
//            else if (bowl == 20)
//            {
//                return Action.TIDY;
//            }
//            else if (bowl == 21)
//            {
//                return Action.ENDGAME;
//            }
//        }

//        //Determine extra bowl
//        if (bowl == 19 && pinsDown == 10)
//        {
//            bowl += 1;
//            extraBowl = true;
//            return Action.RESET;
//        }
//        else if (bowl == 20 && (bowls[19 - 1] + bowls[20 - 1] == 10))
//        {
//            bowl += 1;
//            extraBowl = true;
//            return Action.RESET;
//        }
//        else if(bowl == 20)
//        {
//            return Action.ENDGAME;
//        }

//        //Strikes and spares
//        if (bowl % 2 != 0 && pinsDown == 10) // Strike
//        {
//            bowl += 2;
//            return Action.ENDTURN;
//        }
//        else if (bowl % 2 == 0 && pinsDown == 10) //Spare on gutterball
//        {
//            bowl += 1;
//            return Action.ENDTURN;
//        }

//        // Other behaviour here
//        if (bowl % 2 != 0) // Start of frame (or last frame)
//        {
//            bowl += 1;
//            return Action.TIDY;
//        }
//        else if(bowl % 2 == 0) // End of frame
//        {
//            bowl += 1;
//            return Action.ENDTURN;
//        }

//        throw new UnityException("Not sure what action to return!");
//    }

//    public int GetBowls()
//    {
//        return bowl;
//    }

//    public static Action NextAction(List<int> pinFalls)
//    {
//        ActionMaster actionMaster = new ActionMaster();
//        Action currentAction = new Action();

//        foreach (int pinFall in pinFalls)
//        {
//            currentAction =  actionMaster.Bowl(pinFall);
//        }

//        return currentAction;
//    }
//}
