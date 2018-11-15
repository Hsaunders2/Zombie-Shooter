/**********************************************************
 * 
 * AddScore.cs
 * - sends an event to add a score when this components GameObject is destroyed
 * - uses a "delegate/static event" combo to send the score 
 * - this combo is often used for sending messages to GameObjects
 * - please look at the information sheet "Messaging & Timers in Unity" on the DLE for more details
 * 
 * 
 * public variables
 * - SendScore
 *   - a delegate used for sending the score to another GameObject
 *   - this is used in conjunction with an event
 *   - we will use these in the GameUI class to add score to the player
 *   - see link: https://unity3d.com/learn/tutorials/topics/scripting/delegates
 *   
 * - OnSendScore
 *   - an event used with the SendScore delegate
 *   - OnSendScore is a "static" variable, please see link below for for information about statics
 *   - see link: https://unity3d.com/learn/tutorials/topics/scripting/statics?playlist=17117
 *   - events are a C# way to pass information between classes, we are using it to pass
 *   - score to the GameUI class
 *   - see link: https://unity3d.com/learn/tutorials/topics/scripting/events?playlist=17117
 *   
 * - scoreToAdd
 *   - the value of the score to add to the players exisitng score
 *   - if a zombie is killed with this component attached, we could set scoreToAdd to 10
 *   - and the player would get 10 points when this component is destroyed
 *   
 *   
 * private methods
 * - OnDestroy
 *   - this method will run when the GameObject that this component is attached to is destroyed
 *   - we can use this to send our score when the zombie dies
 *   
 * 
 **********************************************************/
using UnityEngine;

public class AddScore : MonoBehaviour
{
    /*
     * SendScore
     * the delegate that handles attaching the OnSendScore event to another method on different class
     * see link: https://unity3d.com/learn/tutorials/topics/scripting/delegates
     */
    public delegate void SendScore(int theScore);

    /*
     * OnSendScore
     * The event that other classes will use to get our score (the UI in this case)
     * see link: https://unity3d.com/learn/tutorials/topics/scripting/events?playlist=17117
     */
    public static event SendScore OnSendScore;

    /*
     * scoreToAdd
     * the actual score we wish to add
     * this is the points scored for killing a zombie
     * we can change this in the editor
     */ 
    public int scoreToAdd = 1;


    /*
     * when the GameObject this script is attached to (making it a component) is destroyed
     * it will run this method first
     * we can use this to send our score to the UI before this gets destroyed
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDestroy.html
     */
    private void OnDestroy()
    {
        /*
         * CHECK THE OnSendScore EVENT HAS A LISTENER
         * if another class is listening for this event (our UI in this case) it will
         * send the event
         */ 
        if (OnSendScore != null)
        {
            /*
             * SEND THE EVENT
             * here, we call the OnSendScore event and give it the scoreToAdd
             * if your UI is setup, it should pick up the score are add it to the UI
             */ 
            OnSendScore(scoreToAdd);
        }
    }
}
