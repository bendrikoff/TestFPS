using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed=10.0f;
    public int damage = 1;

    private void OnTriggerEnter(Collider other) {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        if(player!=null)
        {
            print("player hit");
        }
        Destroy(this.gameObject);
        
    }

    void Update()
    {
        transform.Translate(0,0,speed*Time.deltaTime);
    }
}
