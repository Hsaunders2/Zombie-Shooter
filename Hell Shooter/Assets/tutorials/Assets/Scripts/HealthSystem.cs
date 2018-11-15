/*******************************************************
 * 
 * 
 * HealthSystem.cs
 * - controls the health variable.
 * - removes health using the TakeDamage method.
 * - sends out a custom UnityEvent (onDamaged) if the health variable changes.
 * - sends out a UnityEvent (onDie) if the health is less than 1.
 * 
 * public variables
 * - health
 *   - an int (whole number) representing the current health of the GameObject.
 *   - set this in the editor for starting health.
 *   
 * - onDie
 *   - a UnityEvent that will "Invoke" when the health variable is less than 1.
 *   - see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
 *   
 * - onDamaged
 *   - a custom UnityEvent that will "Invoke" when the health variable changes value.
 *   - the onDamaged event will send the new health value (an int).
 *   - NOTE: we can use this for things like health bars.
 * 
 * 
 *******************************************************/

using UnityEngine;


/*
 * Unity events are in a separate code library to the standard UnityEngine code.
 * We use the "Events" library to access UnityEvent functionality for the event sused in this class
 */ 
using UnityEngine.Events;


/*
 * Custom events require a class declaration to be used.
 * For use in the Unity Editor, they also require the [System.Serializable] attribute below.
 * This will allow us to configure the custom event in the editor
 * see link: https://docs.unity3d.com/ScriptReference/Serializable.html
 */
[System.Serializable]

/*
 * The custom UnityEvent class called "OnDamagedEvent".
 * Note how this class inherits from UnityEvent.
 * Also not the <int> after the inheritance part.
 * This is the "custom" part of our custom event - the data we want to send!
 * The <int> will be the health value we send with the event, like this: onDamaged.Invoke(health)
 * note how the <int> turn into a parameter when used with the "Invoke" part of the custom event.
 * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent_1.html
 * 
 * NOTE: you can send up to 4 parameters in custom UnityEvents!
 * NOTE: without the [System.Serializable] attribute above this class declaration, you wont see this event in the editor!
 */
public class OnDamagedEvent : UnityEvent<int> { }


/*
 * The HealthSystem class inherits from Monobehaviour, which lets us add it as a component to a GameObject
 * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
 */
public class HealthSystem : MonoBehaviour
{
    /*************************************
     * 
     * PUBLIC VARIABLES
     * 
     *************************************/ 


    /*
     * health
     * the current health of the GameObject (player or zombie)
     * set this in the editor for starting health.
     * changing this through the TakeDamage method will send events when the health value is updated
     */ 
    public int health = 10;


    /*
     * onDie
     * this is a UnityEvent. UnityEvents can tell other GameObject that something happenned.
     * This UnityEvent will tell other GameObjects that our health has run out
     * We can set which GameObjects can "listen" for when the health runs out in the Editor
     * see link: https://docs.unity3d.com/Manual/UnityEvents.html
     * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
     */
    public UnityEvent onDie;


    /*
     * onDamaged
     * this is a custom UnityEvent. This custom UnityEvent will send a int value when it runs.
     * The int value will be the current health amount.
     * We can use this for things like health bars.
     * see link: https://docs.unity3d.com/Manual/UnityEvents.html
     * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent_1.html
     */
    public OnDamagedEvent onDamaged;



    /*************************************
     * 
     * PUBLIC METHODS
     * 
     *************************************/

    /*
     * TakeDamage
     * this public method is called by other GameObjects, like the bullet.
     * when a bullet intersects with the Collider2D on this GameObject, the bullet will
     * use SendMessage to run this method, giving it an amount of damage.
     * TakeDamage will then remove the damage given by the bullet and send and event updating the health
     * value and dying if the health is less than 1
     */
    public void TakeDamage(int damage)
    {
        /*
         * REMOVE THE DAMAGE FROM THE CURRENT HEALTH
         * here we minus the damage given by the TakeDamage method's "damage" parameter
         * giving us a new value for our health
         */ 
        health -= damage;


        /*
         * SEND THE onDamaged CUSTOM EVENT
         * here we use the Invoke method on the custom event and give it our current health value.
         * We can use this to update other GameObject that may want to know about our GameObjects's health
         * like a health bar.
         * see link: https://docs.unity3d.com/Manual/UnityEvents.html
         * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent_1.html
         */
        onDamaged.Invoke(health);


        /*
         * CHECK IF health IS LESS THAN 1
         * If our new health value is less than 1, send the onDie event
         */ 
        if (health < 1)
        {
            /*
             * SEND THE onDie EVENT
             * here we use the Invoke method and give it no parameters.
             * onDie is a standard UnityEvent, which have no parameters to send.
             * We can use this in the Editor to destroy the GameObject, or activate 
             * an animation etc.
             * see link: https://docs.unity3d.com/Manual/UnityEvents.html
             * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
             */
            onDie.Invoke();
        }
    }
}
