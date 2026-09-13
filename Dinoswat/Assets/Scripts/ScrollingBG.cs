using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField]
    private Renderer bgRenderer; //ref to bg material used

    public float speedMultiplier = 1f; // tune this until it visually matches obstacle speed

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(GameManager.Instance.scrollSpeed * speedMultiplier * Time.deltaTime, 0);
    }
}