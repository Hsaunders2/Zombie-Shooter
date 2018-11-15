/**********************************************************
 * 
 * TimerEvent.cs
 * - has a timer that can be used once or repeatedly
 * - when the timer is complete, an event is sent
 * - we can configure the event in the editor to trigger things to happen in the game
 * 
 * 
 * public variables
 * - time
 *   - the amount of time to wait
 *   
 * - repeat
 *   - if the timer is only used once, set this to false
 *   - if the timer runs forever, set this to true
 *   
 * - onTimerComplete
 *   - the event that is sent when the timer completes
 *   
 *   
 * private custom methods
 * - OnTimerComplete
 *   - this will send the onTimerComplete event to any listeners created in the editor
 *   
 * 
 **********************************************************/

using UnityEngine;


/*
 * Unity events are in a separate code library to the standard UnityEngine code.
 * We use the "Events" library to access UnityEvent functionality for the event sused in this class
 */
using UnityEngine.Events;


public class TimerEvent : MonoBehaviour
{
    /**************************************
     * 
     * PUBLIC VARIABLES
     * these can be changed in the Editor!
     * 
     *************************************/

    /*
     * time
     * the time to wait before sending the event in seconds
     * default is one second
     */ 
    public float time = 1;

    /*
     * repeat
     * if this is true, the timer will repeat for ever
     * if this is false, the timer will run only once
     */ 
    public bool repeat = false;

    /*
     * onTimerComplete
     * this event is sent each time the the timer completes
     * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
     */
    public UnityEvent onTimerComplete;


    /*
     * Start
     * this method is provided by Monobehaviour that only runs ONCE when the Player is spawned
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
     * we will use this to start our timer in either forever or once only mode
     */
    private void Start ()
    {
        /*
         * REPEAT THE TIMER FOREVER IF REPEAT IS TRUE
         * here we check if the public variable, repeat is true
         * if so we will run the timer forever
         */ 
		if(repeat) // if repeat is true
        {
            /*
             * RUN THE TIMER FOREVER!!
             * we call the InvokeRepeating method on Monobehaviour for a repeating timer
             * this will run again immeditely after finishing!
             * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
             * NOTE: we give InvokeRepeating 3 parameters:
             * - the method name we want to run after the time is complete (OnTimerComplete)
             * - the time to wait before starting the timer (zero, as we want to start immeditaely)
             * - the time to complete the timer (time)
             */
            InvokeRepeating("OnTimerComplete", 0, time);
        }
        else // if repeat is false
        {
            /*
             * RUN THE TIMER ONCE
             * we call the Invoke method on Monobehaviour for a once-only timer
             * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
             * NOTE: we give Invoke 2 parameters:
             * - the method name we want to run after the time is complete (OnTimerComplete)
             * - the time to complete the timer (time)
             */
            Invoke("OnTimerComplete", time);
        }
	}
	
    /*
     * OnTimerComplete
     * this method will send our onTimerComplete event (this is why they are named the same!)
     * the onTimerComplete event uses the Invoke method to send a message to any listeners (we create listeners in the editor)
     */ 
    private void OnTimerComplete()
    {
        /*
         * SEND THE DAMN EVENT ALREADY!
         * We call the Invoke method of the onTimerComplete event to send to any listeners of the event
         * We setup listeners in the editor
         * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.Invoke.html
         * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
         */
        onTimerComplete.Invoke();
    }
}
