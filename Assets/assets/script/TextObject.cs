using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObject : MonoBehaviour
{
    public object[] dialogArray = new object[99];
    object[] DialogID(int id)
    {
        // [0] = Dialog page count, [1+] = Dialog
        switch (id)
        {
            case 1:
                dialogArray[0] = 3;
                dialogArray[1] = "line 1\nline 2\nline 3\nline 4?";
                dialogArray[2] = "page 2 test";
                dialogArray[3] = "ending page test";
                return dialogArray;

            case 2:
                dialogArray[0] = 9;
                dialogArray[1] = "Welcome to the tutorial.";
                dialogArray[2] = "Do not worry. You are fast asleep in the real world.\nAny damage recieved here will be gone when you awaken.";
                dialogArray[3] = "I have created a projection for you to do battle with.";
                dialogArray[4] = "You currently have the upper hand on your opponent, you can attack before it can.";
                dialogArray[5] = "This will not always be the case. Foes can gain the upper hand on you if you aren't paying attention.\nBe sure to not let your guard down!";
                dialogArray[6] = "Depending on your condition when you enter a battle, you may want to attack first.\n If you enter damaged, you can use your opportunity to heal yourself.";
                dialogArray[7] = "In the scenario I have prepared for you, your health is the highest it can be, and you have the upper hand.";
                dialogArray[8] = "Here, the best course of action is to attack your foe.";
                dialogArray[9] = "You can attack via the variety of options in your <b>MENU<\b>.";
                return dialogArray;

            default:
                dialogArray[0] = 2;
                dialogArray[1] = "this is a bug\nplease report this\nfafa foogey";
                dialogArray[2] = "error text pg 2 :)";
                return dialogArray;
        }
    }
}
