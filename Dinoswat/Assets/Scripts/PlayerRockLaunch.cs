using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRockLaunch : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform launchPoint; // empty child in front of the dino
    public int killsRequired = 10;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool shiftHeld = Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed;

        if (shiftHeld && Keyboard.current.dKey.wasPressedThisFrame && GameManager.Instance.killCount >= killsRequired)
        {
            LaunchRock();
        }
    }

    void LaunchRock()
    {
        anim.SetTrigger("rockLaunch");
        Instantiate(rockPrefab, launchPoint.position, Quaternion.identity);
    }
}