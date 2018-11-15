/**********************************************************
 * 
 * Enemy.cs
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
 * The custom UnityEvent class called "EnemySpawnedEvent".
 * Note how this class inherits from UnityEvent.
 * Also not the <Transform> after the inheritance part.
 * This is the "custom" part of our custom event - the data we want to send!
 * The <Transform> will be the player tansform component we send with the event, like this: onSpawn.Invoke(player.transform)
 * note how the <Transform> turn into a parameter when used with the "Invoke" part of the custom event.
 * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent_1.html
 * 
 * NOTE: you can send up to 4 parameters in custom UnityEvents!
 * NOTE: without the [System.Serializable] attribute above this class declaration, you wont see this event in the editor!
 */
public class EnemySpawnedEvent : UnityEvent<Transform> { }


public class Enemy : MonoBehaviour
{
    /*
     * onSpawn
     * this is a custom UnityEvent. This custom UnityEvent will send a Tranform when it runs.
     * The Tranform value will be the current player transform component.
     * We can use this for things like moveing towards and looking at the player in the scene.
     * see link: https://docs.unity3d.com/Manual/UnityEvents.html
     * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent_1.html
     */
    public EnemySpawnedEvent onSpawn;


    /*
     * Start
     * this method is provided by Monobehaviour that only runs ONCE when the Enemy is spawned
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
     * we will use this to get the player in the scene and send our onSpawn event
     */
    private void Start()
    {
        /*
         * FIND THE PLAYER IN THE SCENE
         * we create a local GameObject variable for the player
         * we use GameObject.FindWithTag to find the player in the scene
         * NOTE: our player's GameObject in the scene needs to have a tag of "Player"
         * see link: https://docs.unity3d.com/ScriptReference/GameObject.FindWithTag.html
         * see link: https://docs.unity3d.com/Manual/Tags.html
         */
        GameObject player = GameObject.FindWithTag("Player");

        /*
         * SEND THE onSpawn EVENT USING Invoke
         * Here we send the onSpawn event using the Invoke method of the event
         * because our onSpawn event is a custom one, it needs to send a transform with the event
         * We use the player GameObject we just found in the scene (see code above)
         * to get the players transform component, we use player.transform
         * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.Invoke.html
         * see link: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
         */
        onSpawn.Invoke(player.transform);
    }
}
