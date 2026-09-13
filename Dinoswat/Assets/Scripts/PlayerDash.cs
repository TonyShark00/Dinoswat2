using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeedBoost = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;
    public GameObject dashHitbox;

    private Animator anim;
    private bool isDashing;
    private bool canDash = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        dashHitbox.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        anim.SetTrigger("Dash");
        dashHitbox.SetActive(true);
        GameManager.Instance.scrollSpeed += dashSpeedBoost;

        yield return new WaitForSeconds(dashDuration);

        GameManager.Instance.scrollSpeed -= dashSpeedBoost;
        dashHitbox.SetActive(false);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public bool IsDashing()
    {
        return isDashing;
    }
}