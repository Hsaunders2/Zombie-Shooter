/*******************************************************
 * 
 * TopDownCharacterController2D.cs
 *  - controls movement along the X and Y axes
 *  - uses Rigidbody2D velocity to set movement
 * 
 * 
 * public variables:
 *  - speed
 *    - the speed of movement
 *    
 *    
 * private variables:
 *  - body2D
 *    - Rigidbody2D component
 *    
 *    
 * Monobehaviour methods
 *  - Start
 *    - runs ONCE when this script is activated
 *    - see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
 *    
 *  - FixedUpdate
 *    - runs contantly at a fixed time step
 *    - only runs while this script is active
 *    - see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
 * 
 * 
 *******************************************************/
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour
{
    /*
     * speed
     * A "public" variable is declared outside of any methods.
     * We can change this in the editor without changing any of the code.
     * speed has a default setting of "5.0f", this setting can be changed in the editor!
     * 
     * speed is a float (a decimal number) to set our movement speed.
     * NOTE: ALL float number values MUST end with an "f"
     */ 
    public float speed = 5.0f;


    /*
     * body2D
     * A "private" variable declared outside of any methods.
     * This variable CANNOT be changed in the editor, it is "invisible" to the editor 
     * and any other classes!
     * 
     * body2D is a Rigidbody2D component variable
     * NOTE: we will store our Rigidbody2D component we added in the editor in this variable,
     *       this is known as a "reference" as we are "referring" to the Rigidbody2D component.
     * 
     * see link: https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
     */
    private Rigidbody2D body2D;


    /*
     * Start
     * A method (also known as an "Event Function") provided by Monobehaviour that will run only once when a GameObject containing 
     * this script activates in the Hierarchy.
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
     * 
     * In this method we get the Rigidbody2D component using "GetComponent" and store it in
     * out private variable, "body2D"
     * see link: https://docs.unity3d.com/ScriptReference/Component.GetComponent.html
     */
    void Start()
    {
        /*
         * GET THE RIGIDBODY2D COMPONENT AND STORE IN "body2D"
         * We use GetComponent to get the Rigidbody2D component
         * see link: https://docs.unity3d.com/ScriptReference/Component.GetComponent.html
         * 
         * we assign our "body2D" private variable to the Rigidbody2D component
         * see link:  https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
         * 
         * NOTE: GetComponent requires angle brackets to get the "type" of component.
         *       We can get any type of component (including this script) this way!
         */
        body2D = GetComponent<Rigidbody2D>();
    }


    /*
     * FixedUpdate
     * A method (also known as an "Event Function") provided by Monobehaviour that will run at a fixed time step.
     * FixedUpdate is most useful for the Physics system, such adding a force or velocity to a Rigidbody2D.
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
     * 
     * In this method we will get input from the X and Y (W,A,S,D keys) using Input.GetAxis()
     * see link: https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
     * We will then create a Vector2 to store the X and Y input
     * see link: https://docs.unity3d.com/ScriptReference/Vector2.html
     * Then, we will multiply the Vector2 by our public variable "speed"
     * Finally we will set the "velocity" property of our "body2D", this will move our character!
     * see link: https://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html
     */
    void FixedUpdate()
    {
        /*
         * GETTING INPUT
         * Unity provides some pre-made inputs for left and right (Horizontal) and up and down (Vertical) in the "Input Manager" panel in the editor.
         * see link: https://docs.unity3d.com/Manual/class-InputManager.html
         */


        /*
         * GET LEFT AND RIGHT INPUT (Horizontal)
         * we create a local float variable and store our current "Horizontal" input using "Input.GetAxis"
         * see link: https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
         * this will read our "A" and "D" keys and output a number from -1 to 1
         * LEFT or "A" key is pressed = -1
         * RIGHT or "D" key is pressed = 1
         * Neither "A" or "D" key is pressed = 0
         */
        float inputX = Input.GetAxis("Horizontal");


        /*
         * GET UP AND DOWN INPUT (Vertical)
         * we create a local float variable and store our current "Vertical" input using "Input.GetAxis"
         * see link: https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
         * this will read our "W" and "S" keys and output a number from -1 to 1
         * UP or "W" key is pressed = 1
         * DOWN or "S" key is pressed = -1
         * Neither "W" or "S" key is pressed = 0
         */
        float inputY = Input.GetAxis("Vertical");


        /*
         * CREATE A Vector2 TO STORE OUR NEW VELOCITY
         * We want to set the velocity on our "body2D", but it needs a Vector2.
         * A Vector2 has 2 properties: X and Y, we can set these to our "inputX" and "inputY" variables created above.
         * see link: https://docs.unity3d.com/ScriptReference/Vector2.html
         */
        Vector2 newVelocity = new Vector2();


        /*
         * SET THE X PROPERTY OF THE "newVelocity" Vector2
         * We set our "newVelocity" x property to "inputX" (our horizontal movement)
         */
        newVelocity.x = inputX;


        /*
         * SET THE Y PROPERTY OF THE "newVelocity" Vector2
         * We set our "newVelocity" y property to "inputY" (our vertical movement)
         */
        newVelocity.y = inputY;


        /*
         * MULTIPLY THE "newVelocity" Vector2 BY "speed"
         * We want to set the speed of our movement using the public variable "speed" so we can control the speed from the editor
         * We can multiply a Vector2 by a float number to increase both its X and Y properties
         * see link: https://docs.unity3d.com/ScriptReference/Vector2-operator_multiply.html
         */
        newVelocity = newVelocity * speed;


        /*
         * SET THE "body2D" velocity TO "newVelocity"
         * we simply set the velocity here
         * "body2D" is a Rigidbody2D component, which has a "velocity" property of type Vector2
         * see link: https://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html
         */
        body2D.velocity = newVelocity;
    }
}
