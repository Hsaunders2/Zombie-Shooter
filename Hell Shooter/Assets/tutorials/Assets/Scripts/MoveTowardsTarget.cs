/**********************************************************
 * 
 * MoveTowardsTarget.cs
 * - moves the GameObject towards a target transform's position
 * - speed can be controlled using the public speed variable
 * - the movement code will not run if a target transform is not provided
 * 
 * 
 * public variables
 * - target
 *   - the transform component of the target to move towards
 *   - see link: https://docs.unity3d.com/ScriptReference/Transform.html
 *   
 * - speed
 *   - the speed at which this GameObject moves towards the target transform
 *    
 * 
 **********************************************************/


using UnityEngine;


/*
 * The MoveTowardsTarget class inherits from Monobehaviour, which lets us add it as a component to a GameObject
 * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
 */
public class MoveTowardsTarget : MonoBehaviour
{
    /*
     * target
     * The Transform component of the GameObject we want to move towards
     * This could be the player GameObject!
     * see link: https://docs.unity3d.com/ScriptReference/Transform.html
     */
    public Transform target;


    /*
     * speed
     * the speed we will move tarwards the target at
     */ 
    public float speed = 5.0f;


    /*
     * Update
     * this method is provided by Monobehaviour that runs CONSTANTLY (30-60 times per second) while this GameObject is active
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
     * we can use this to move our GameObject a small amount each time it runs
     */
    private void Update()
    {
        /*
         * CHECK WE HAVE A TARGET TRANSFORM
         * if the public variable, target has NOT been set in the editor we cannot run the movement code!
         * We check here it is set, otherwise we will get an error!
         * In unity, we use "null" to mean "empty" or "no value"
         * We use the != (not equal) operator to check the target is NOT EQUAL to null
         * see link: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/not-equal-operator
         */
        if (target != null)
        {
            /*
             * GET OUR GAMEOBJECT'S CURRENT POSITION
             * we need our GameObject's current position, which is a Vector3, as part of our movement.
             * the position is found on our Transform component, we use "transform.position" to get it.
             * see link: https://docs.unity3d.com/ScriptReference/Transform-position.html
             */
            Vector3 currentPosition = transform.position;

            /*
             * GET OUR TARGET'S CURRENT POSITION
             * Our target variable is a Transform, we can get it's current position using target.position
             * see link: https://docs.unity3d.com/ScriptReference/Transform-position.html
             */
            Vector3 targetPosition = target.position;
            
            /*
             * SET THE CURRENT SPEED
             * our speed in its default 5.0 value will move our GameObject extremely fast!
             * We can reduce it to a smaller value by multiplying it by a tiny value, like 0.01.
             * That way, we can set a larger number in the editor, like 5 or 10 and still have it move 
             * at a more sensible speed
             */ 
            float currentSpeed = speed * 0.01f;


            /*
             * MOVE TOWARDS THE TARGET
             * We use the Vector3 method, MoveTowards to move towards our target.
             * MoveTowards takes 3 paramters: 
             * - our current position (currentPosition)
             * - the target position (targetPosition)
             * - a speed to move at (currentSpeed)
             * see link: https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
             */
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, currentSpeed);
        }
    }


}
