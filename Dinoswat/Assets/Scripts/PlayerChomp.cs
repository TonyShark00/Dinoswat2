using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChomp : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            anim.SetTrigger("Chomp");
            // TODO: also do a hitbox/overlap check here to actually damage an enemy
        }
    }
}