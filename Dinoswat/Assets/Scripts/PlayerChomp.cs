using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChomp : MonoBehaviour
{
    public GameObject chompHitbox;
    public float hitboxActiveTime = 0.2f;

    public Rigidbody2D rb;
    public float jumpChompForce = 8f; // separate, maybe smaller jump for the combo

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        chompHitbox.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            bool spaceHeld = Keyboard.current.spaceKey.isPressed;

            if (spaceHeld)
            {
                DoJumpChomp();
            }
            else
            {
                DoChomp();
            }
        }
    }

    private void DoChomp()
    {
        anim.SetTrigger("Chomp");
        StartCoroutine(ActivateHitbox());
    }

    private void DoJumpChomp()
    {
        anim.SetTrigger("Chomp");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpChompForce);
        StartCoroutine(ActivateHitbox());
    }

    private System.Collections.IEnumerator ActivateHitbox()
    {
        chompHitbox.SetActive(true);
        yield return new WaitForSeconds(hitboxActiveTime);
        chompHitbox.SetActive(false);
    }
}