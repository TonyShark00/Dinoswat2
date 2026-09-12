using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDuck : MonoBehaviour
{
    private BoxCollider2D col;
    private Animator anim;

    private Vector2 standingSize;
    private Vector2 standingOffset;

    public Vector2 duckingSize;
    public Vector2 duckingOffset;

    private bool isDucking;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        standingSize = col.size;
        standingOffset = col.offset;
    }

    void Update()
    {
        bool duckHeld = Keyboard.current.sKey.isPressed;

        if (duckHeld && !isDucking)
        {
            isDucking = true;
            col.size = duckingSize;
            col.offset = duckingOffset;
            anim.SetBool("isDucking", true);
        }
        else if (!duckHeld && isDucking)
        {
            isDucking = false;
            col.size = standingSize;
            col.offset = standingOffset;
            anim.SetBool("isDucking", false);
        }
    }
}
