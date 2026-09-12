using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class EnemyCollision : MonoBehaviour{
    private void OnCollisionEnter2D(Collision2D other){

        if(other.transform.tag=="Player" && Keyboard.current.wKey.wasPressedThisFrame){
            Destroy(gameObject);
        }
    }
}
