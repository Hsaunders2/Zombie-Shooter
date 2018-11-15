using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour {

    public int damage = 1;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        GetComponent<Collider2D>().enabled = false;

        Invoke("Timer", 0.5f);
    }

    void Timer()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
