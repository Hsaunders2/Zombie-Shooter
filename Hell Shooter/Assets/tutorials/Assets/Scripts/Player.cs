/**********************************************************
 * 
 * Player.cs
 * - controls the gun animation for the player
 * - sets a bool on the animator component when the mouse is down or up
 * 
 * 
 * private variables
 * - gunAnim
 *   - the Animator component we will set our firing animations on
 *   
 *   
 * private methods
 * - Start
 *   - We get a reference to the Animator component here, stored in our gunAnim variable
 *   
 * - Update
 *   - We check if the mouse is down or not
 *   - if the mouse button is down, we set the "isFiring" bool value in our Animator to true, activating the fire animation on our player
 *   - if the mouse button is up, we set the "isFiring" bool value in our Animator to false, activating the idle animation on our player
 * 
 * 
 **********************************************************/
using UnityEngine;

public class Player : MonoBehaviour
{

    /**************************************
     * 
     * PRIVATE VARIABLES
     * 
     *************************************/
    
    /*
     * gunAnim
     * stores a reference to the Animator component on this GameObject
     * We store a reference here because we will use the Animator component in the Update method
     * As we know, Update runs 30-60 times per second, so we don't want to be calling GetComponent
     * constantly.
     */ 
    private Animator gunAnim;

    /*
     * Start
     * this method is provided by Monobehaviour that only runs ONCE when the Player is spawned
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
     * we can use this to get a reference to the Animator component for later use
     */
    private void Start ()
    {
        /*
         * GET THE ANIMATOR COMPONENT
         * see link: https://docs.unity3d.com/ScriptReference/Component.GetComponent.html
         */
        gunAnim = GetComponent<Animator>();
    }


    /*
     * Update
     * this method is provided by Monobehaviour that runs CONSTANTLY (30-60 times per second) while this GameObject is active
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
     * we can use this to list for mouse button presses, which we can then use to set the firing and idle animations on the player
     */
    private void Update ()
    {
        /*
         * CHECK IF THE LEFT MOUSE BUTTON IS DOWN
         * We use Input.GetMouseButton to check if the left mouse button is held down
         * NOTE: the zero in the parameters is an index for each mouse button:
         * - 0 = left mouse button
         * - 1 = right mouse button
         * - 2 = middle mouse button
         */
        if (Input.GetMouseButton(0)) // left mouse button is down
        {
            /*
             * SET THE ANIMATION TO "Player firing"
             * Here we set the bool called "isFiring" we setup in the Animator view in the editor
             * We want to use the "Player firing" animation, so we set the "isFiring" bool to true
             * This will automatically play the "Player firing" animation in the game
             * Please check the Animator view in the editor for more details
             * see link: https://docs.unity3d.com/ScriptReference/Animator.SetBool.html
             */
            gunAnim.SetBool("isFiring", true);
        }
        else // left mouse button is not down
        { 
            /*
             * SET THE ANIMATION TO "Player firing idle"
             * Here we set the bool called "isFiring" we setup in the Animator view in the editor
             * We want to use the "Player firing" animation, so we set the "isFiring" bool to false
             * This will automatically play the "Player firing idle" animation in the game
             * Please check the Animator view in the editor for more details
             * see link: https://docs.unity3d.com/ScriptReference/Animator.SetBool.html
             */
            gunAnim.SetBool("isFiring", false);
        }
    }
}
