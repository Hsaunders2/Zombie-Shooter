/*******************************************************
 * 
 * 
 * Weapon.cs
 * - Spawns a bullet into the scene when the mouse button pressed down
 * - stops any more bullets from being spawned until the fire timer runs out
 * - will play any attached audio scource component on this GameObject
 * 
 * public variables
 * - bulletPrefab
 *   - A prefab for the bullet
 *   - NOTE: do not give scene GameObjects here in the editor, only prefabs from the project view
 *   - see link: https://docs.unity3d.com/Manual/Prefabs.html
 *   - see link: https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
 *   
 * - bulletSpawn
 *   - the bullet will spawn in the same position and rotation as the bulletSpawn transform.
 *   - this can be a point at the end of a weapon, like the muzzle of a gun, so bullets can spawn from the end of the barrel
 *   
 * - fireTime
 *   - the amount of time in seconds between firing bullets
 *   - this will be used in an "Invoke" timer
 *   - see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
 * 
 * 
 * private variables
 * - isFiring
 *   - check if a bullet can be fired or not
 *   - if the Invoke timer has not run out, the bullet will not be fired
 * 
 * 
 * private custom methods
 * - Fire
 *   - Spawns the bullet from our bulletPrefab into the scene
 *   - will spawn at the same position and rotation as the bulletSpawn Transform
 *   
 * - SetFiring
 *   - resets the isFiring value to false after firing the weapon
 *   - this will reset the weapon, ready to fire another bullet
 * 
 * 
 *******************************************************/

using UnityEngine;


/*
 * The Weapon class inherits from Monobehaviour, which lets us add it as a component to a GameObject
 * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
 */
public class Weapon : MonoBehaviour
{
    /*************************************
     * 
     * PUBLIC VARIABLES
     * 
     *************************************/


    /*
     * bulletPrefab
     * the prefab GameObject for the bullet to be fired
     * NOTE: only use prefab GameObjects from the Project view here!
     * see link: https://docs.unity3d.com/Manual/Prefabs.html
     * see link: https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
     */
    public GameObject bulletPrefab;

    /*
     * bulletSpawn
     * this is a Transform from the scene, create it and place it where you want to spawn your bullet
     * the bullet will spawn in the same position and rotation as the bulletSpawn transform.
     * see link: https://docs.unity3d.com/ScriptReference/Transform.html
     */
    public Transform bulletSpawn;

    /*
     * fireTime
     * the amount of time in seconds between firing bullets
     * if you want a fast fire weapon, like a pistol, set this to a low number, 
     * for a shotgun, set a higher number
     */
    public float fireTime = 0.5f;



    /*************************************
     * 
     * PRIVATE VARIABLES
     * 
     *************************************/
    
    /*
     * isFiring
     * checks if the weapon is able to fire a bullet
     * if true, a bullet cannot be fired, if false, we can fire the bullet
     */ 
    private bool isFiring = false;



    /*
     * Update
     * this method is provided by Monobehaviour that runs CONSTANTLY (30-60 times per second) while this GameObject is active
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
     * we can use this to check if the mouse has been pressed, and then fire our weapon
     */
    private void Update()
    {
        /*
         * CHECK THE MOUSE HAS BEEN PRESSED
         * we use the Input class to get our mouse button presses
         * GetMouseButton will return true constantly if our mouse button is held down
         * NOTE: we give GetMouseButton a parameter of zero. Each mouse button has a number:
         *       Left button = 0
         *       Right Button = 1
         *       Middle Button = 2
         * see link: https://docs.unity3d.com/ScriptReference/Input.GetMouseButton.html
         */
        if (Input.GetMouseButton(0)) // if this returns true we can fire our weapon (maybe!)
        {
            /*
             * CHECK WE ARE NOT ALREADY FIRING
             * here we use the private variable isFiring to check if our weapon is not currently firing
             * if it is true, we cannot fire our weapon.
             * NOTE: we use the ! (NOT) operator to check if isFiring is NOT true
             * see link: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/logical-negation-operator
             */
            if (!isFiring)
            {
                /*
                 * FIRE THE DAMN WEAPON ALREADY!!
                 * here we call the custom method Fire to actually fire the weapon!
                 */ 
                Fire();
            }
        }
    }


    /*
     * Fire
     * sets isFiring to true, so we cannot fire any more bullets at the moment
     * spawns the bullet prefab into the scene
     * plays any audio component on this GameObject, like if you have a gun sound attached
     * Creates an "Invoke" timer, which will reset our isFiring, so we can fire more bullets
     */ 
    private void Fire()
    {
        /*
         * SET isFiring TO TRUE
         * here we want to stop any other bullets from being spawned from the Update method
         * so we set this to true, please see the Update method above for how this works
         */ 
        isFiring = true;

        /*
         * GET THE POSITION OF THE bulletSpawn
         * we want to get the position to spawn our bullet in, we use the public variable, bulletSpawn
         * bulletSpawn is a Transform, which has the position property we are interested in
         * see link: https://docs.unity3d.com/ScriptReference/Transform-position.html
         */
        Vector3 bulletPosition = bulletSpawn.position;

        /*
         * GET THIS bulletSpawn's ROTATION
         * we can get our bulletSpawn rotation from its Transform component using "bulletSpawn.rotation"
         * see link: https://docs.unity3d.com/ScriptReference/Transform-rotation.html
         * "bulletSpawn.rotation" is a Quaternion, which has 4 properties: X, Y, Z and W.
         * see link: https://docs.unity3d.com/ScriptReference/Quaternion.html
         * we create a Quaternion variable to store our bulletSpawn's current rotation
         */
        Quaternion bulletRotation = bulletSpawn.rotation;

        /*
         * SPAWN THE BULLET
         * here, we call the Instantiate method to spawn a new GameObject into the scene
         * Instantiate takes 3 parameters:
         * - the bullet prefab we want to spawn
         * - a position for the spawned bullet
         * - a rotation for the spawned bullet
         * see link: https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
         * NOTE: we are spawning a COPY of the prefab into the scene, not the actual file!
         */
        Instantiate(bulletPrefab, bulletPosition, bulletRotation);


        /*
         * CHECK WE HAVE AN AUDIOSOURCE COMPONENT
         * if we have an AudioSource component on this GameObject, we can play any sound on it,
         * like a weapon firing sound!
         * see link: https://docs.unity3d.com/ScriptReference/AudioSource.html
         * we use GetComponent to see if there is an AudioSource component present.
         * we use null to check if the AudioSource actually exists or not
         * we use the != (NOT EQUAL) operator to check if the AudioSource component is equal to null (or empty)
         * see link: see link: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/not-equal-operator
         */
        if (GetComponent<AudioSource>() != null)
        {
            /*
             * PLAY THE SOUND
             * here we call the "Play" method on the AudioSource to play any sound it has attached to it
             * see link: https://docs.unity3d.com/ScriptReference/AudioSource.Play.html
             */
            GetComponent<AudioSource>().Play();
        }


        /*
         * SET AN Invoke TIMER TO RESET isFiring AFTER A SHORT TIME
         * here we use the Invoke method to call the "SetFiring" method (below this method)
         * SetFiring will reset our isFiring variable to false, allowing us to fire the weapon again!
         * Invoke has 2 parameters:
         * - the name of the method to run as a string ("SetFiring")
         * - the time to wait before running the method (fireTime)
         * 
         * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
         */
        Invoke("SetFiring", fireTime);
    }


    /*
     * SetFiring
     * Resets the public variable, isFiring to false, allowing us to fire the weapon again.
     */ 
    private void SetFiring()
    {
        /*
         * SET isFiring to false
         */ 
        isFiring = false;
    }
} 
