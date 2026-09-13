using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRockLaunch : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform launchPoint;
    public int killsRequired = 10;

    public SpriteRenderer IndicatorRenderer;
    public Sprite[] IndicatorSprites;

    private Animator anim;
    private int killsAtLastLaunch = 0; // tracks kill count baseline

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool shiftHeld = Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed;

        int killsSinceLastLaunch = GameManager.Instance.killCount - killsAtLastLaunch; //gets number of new kills
        bool canLaunch = killsSinceLastLaunch >= killsRequired; //no. of kills since last time

        IndicatorRenderer.sprite = canLaunch ? IndicatorSprites[0] : IndicatorSprites[1];

        if (shiftHeld && Keyboard.current.dKey.wasPressedThisFrame && canLaunch)
        {
            LaunchRock();
        }
    }

    void LaunchRock()
    {
        killsAtLastLaunch = GameManager.Instance.killCount; // reset the baseline, "spending" the kills
        anim.SetTrigger("rockLaunch");
        Instantiate(rockPrefab, launchPoint.position, Quaternion.identity);
    }
}