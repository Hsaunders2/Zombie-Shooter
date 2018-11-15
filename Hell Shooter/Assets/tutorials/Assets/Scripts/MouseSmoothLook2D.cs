/*******************************************************
 * 
 * MouseSmoothLook2D.cs
 *  - rotates the GameObject to face the mouse cursor
 *  - uses a smoothing variable to animate over time
 *  - uses an adjustment angle variable to adjust for artwork facing a different way
 * 
 * 
 * 
 * public variables:
 *  - theCamera
 *    - the main camera of the game
 *    - used to calculate the mouse position in the game world
 *    
 *  - smoothing
 *    - the speed of rotation towards the mouse cursor
 *  
 *  - adjustmentAngle
 *    - adjusts the angle if the artwork is facing a different rotation
 *    
 *    
 * private variables: none
 *    
 *    
 * Monobehaviour methods
 *  - Update
 *    - runs contantly (30-60 times per second)
 *    - only runs while this script is active
 *    - see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
 * 
 * 
 *******************************************************/
using UnityEngine;

public class MouseSmoothLook2D : MonoBehaviour
{
    /*********************
     * 
     * PUBLIC VARIABLES
     * A "public" variable is declared outside of any methods.
     * We can change these in the editor without changing any of the code.
     * 
     *********************/

    /*
     * theCamera
     * we will want to get the mouse position, the Camera component has funcitonality to do this
     * set this variable in the editor by dragging the a GameObject with a Camera component onto this variable in the editor
     * The Camera we want is the main game Camera
     * see link: https://docs.unity3d.com/ScriptReference/Camera.html
     */
    public Camera theCamera;


    /*
     * smoothing
     * smoothing is a float (a decimal number) to set how fast we rotate towards the target.
     * smoothing has a default setting of "5.0f", this setting can be changed in the editor!
     * NOTE: ALL float number values MUST end with an "f"
     */
    public float smoothing = 5.0f;


    /*
     * adjustmentAngle
     * this will add a number to the rotation of the GameObject, allowing us to adjust it so our GameObject's art is facing the right direction
     * we can set this in the editor
     */
    public float adjustmentAngle = 0.0f;


    /*
     * Update
     * A method (also known as an "Event Function") provided by Monobehaviour that will run constantly.
     * Update is a general purpose update method, used for any types code, but may look a little "jerky" running Physics movement using it.
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
     * 
     * In this method we will be getting our current position, the mouse position and calculating an angle from those two positions.
     * We will animate the rotation to smoothly rotate towards the mouse cursor
     */
    void Update()
    {
        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = target - transform.position;

        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
    }
}
