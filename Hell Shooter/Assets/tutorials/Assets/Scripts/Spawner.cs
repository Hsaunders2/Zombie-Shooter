/**********************************************************
 * 
 * Spawner.cs
 * - spawns a prefab into the scene using the Spawn method
 * - can adjust angle the prefab spawns in at, useful for artwork not facing the right way
 * 
 * 
 * public variables
 * - prefabToSpawn
 *   - the prefab from the Project view to spawn
 *   
 * - adjustmentAngle
 *   - changes the z rotation angle of the item when it is spawned
 *   - useful if the imported artwork is facing a different way
 *   
 *   
 * public custom methods
 * - Spawn
 *   - this will spawn the prefab into the scene
 *   - we give it a position and rotation, based on the transform this script is attached to
 *   - we add the adjustmentAngle here as well
 *   
 * 
 **********************************************************/

using UnityEngine;

public class Spawner : MonoBehaviour
{
    /**************************************
     * 
     * PUBLIC VARIABLES
     * these can be changed in the Editor!
     * 
     *************************************/

    /*
     * prefabToSpawn
     * the prefab from the Project view to be spawned
     * NOTE: make sure the prefab is from the Project view!
     */
    public GameObject prefabToSpawn;

    /*
     * adjustmentAngle
     * this will add a number to the rotation of the GameObject, 
     * allowing us to adjust it so our GameObject's art is facing the right direction
     */
    public float adjustmentAngle = 0;



    /**************************************
     * 
     * PUBLIC METHODS
     * 
     *************************************/

    /*
     * Spawn
     * This method is called from other classes, such as the OnDie event on the zombie
     * This method will spawn the public variable, prefabToSpawn as a GameObject in the scene
     */
    public void Spawn ()
    {
        /*
         * GET THE ROTATION OF THIS GAMEOBJECT IN DEGREES
         * To spawn our prefab, we want to know which way we are currently facing
         * We will create a variable to store our rotation.
         * for ease of use, we can get the angles in degrees using transform.eulerAngles
         * see link: https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html
         */
        Vector3 rotationInDegrees = transform.eulerAngles;

        /*
         * ADD THE adjustmentAngle TO THE Z ANGLE OF THE ROTATION
         * Here we add our public variable, adjustmentAngle to the Z axis of the 
         * rotationInDegrees variable, this will point our spawned object in the correct direction
         */ 
        rotationInDegrees.z += adjustmentAngle;

        /*
         * CONVERT THE ROTATION IN DEGREES TO RADIANS
         * Now we have adjusted our rotation, we need to convert the rotationInDegrees variable
         * to a rotation in radians.
         * We can do this using Quaternion.Euler
         * Quaternion.Euler will take a Vector3 variable with angles X,Y and Z in degrees
         * and convert it into a Quaternion variable with angles in radians
         * see link: https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
         */
        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
        
        /*
         * SPAWN THE DAMN THING ALREADY!!!!
         * Here, call the Instantiate method to spawn our item into the scene!
         * We will give it the public variable, prefabToSpawn, as the item we wish to spawn into the scene
         * We will give it a position, which is our current position (transform.position)
         * We will give it a rotation, which is our rotationInRadians variable we created above
         * 
         * Instantiate has 3 parameters:
         * - the prefab we want to spawn (prefabToSpawn)
         * - a position (transform.position)
         * - a rotation (rotationInRadians)
         */ 
        Instantiate(prefabToSpawn, transform.position, rotationInRadians);
	}
}
