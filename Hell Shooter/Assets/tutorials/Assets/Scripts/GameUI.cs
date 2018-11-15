/**********************************************************
 * 
 * GameUI.cs
 * - 
 * 
 * public variables
 * - healthBar
 *   - a UI Slider, which will show our player health as a standard game health bar
 *   - the Slider has a value property, which we can set to our players current health
 *   - using the Player.OnUpdateHealth event (see Player script for details)
 *   
 * - scoreText
 *   - a UI Text, which will display our current score
 *   - the Text has a text property, which we set to our players current score
 *   - using the AddScore.OnSendScore event (see AddScore script for details)
 *   
 * - playerScore
 *   - the actual score value
 *   - we will set this first when recieving a new score, then set the scoreText to the value of playerScore
 *   
 * 
 * 
 * private custom methods
 * - UpdateHealthBar
 *   - updates the Slider UI to display the player health when the Player.OnUpdateHealth runs
 *   
 * - UpdateScore
 *   - updates the Text UI to display the player score when the AddScore.OnSendScore runs 
 *   
 *   
 * private methods
 * - OnEnable
 *   - Adds the UpdateHealthBar method to the Player.OnUpdateHealth event, this uses the delegate UpdateHealth in the Player script
 *   - Adds the UpdateScore method to the AddScore.OnSendScore event, this uses the delegate SendScore in the AddScore script
 *  
 * - OnDisable
 *   - Removes the UpdateHealthBar method from the Player.OnUpdateHealth event
 *   - Removes the UpdateScore method from the AddScore.OnSendScore event
 *   
 * 
 * 
 **********************************************************/
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    /*
     * healthBar
     * a Slider UI component that will display the player health as a standard health bar
     * see link: https://docs.unity3d.com/ScriptReference/UI.Slider.html
     */
    public Slider healthBar;

    /*
     * scoreText
     * a Text UI component that will display the player score in text form
     * see link: https://docs.unity3d.com/ScriptReference/UI.Text.html
     */
    public Text scoreText;

    /*
     * stores the current total player score
     */ 
    public int playerScore = 0;

    /*
     * OnEnable
     * this method is provided by Monobehaviour that runs EVERY TIME the Enemy GameObject is activated
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnEnable.html
     * we will use this to attach the player health and score events
     */
    private void OnEnable()
    {
        /*
         * ATTACH THE PLAYER HEALTH UPDATE EVENT
         * we attach our UpdateHealthBar method to the player OnUpdateHealth event
         * UpdateHealthBar will now run every time the event is called
         */ 
        Player.OnUpdateHealth += UpdateHealthBar;

        /*
         * ATTACH THE ADD SCORE EVENT
         * we attach our UpdateScore method to the addscore OnSendScore event
         * UpdateScore will now run every time the event is called
         */
        AddScore.OnSendScore += UpdateScore;
    }

    /*
     * OnDisable
     * this method is provided by Monobehaviour that runs EVERY TIME the Enemy GameObject is deactivated
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDisable.html
     * we will use this to remove the player health and score events
     */
    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
    }
    

    /*
     * UpdateHealthBar
     * updates the health bar value property on the Slider UI, using the health parameter
     */ 
    private void UpdateHealthBar(int health)
    {
        /*
         * SET THE SLIDER VALUE TO THE health PARAMETER
         * see link: https://docs.unity3d.com/ScriptReference/UI.Slider-value.html
         */
        healthBar.value = health;
    }


    /*
     * UpdateScore
     * sets the scoreText text property to the theScore parameter
     */ 
    private void UpdateScore(int theScore)
    {
        /*
         * ADD THE NEW SCORE TO THE CURRENT PLAYER SCORE
         */
        playerScore += theScore;

        /*
         * SET THE TEXT TO THE playerScore VARIABLE
         * see link: https://docs.unity3d.com/ScriptReference/UI.Text-text.html
         */
        scoreText.text = "SCORE: "+ playerScore.ToString();
    }
}
