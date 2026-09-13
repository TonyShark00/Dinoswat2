using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField]
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(GameManager.Instance.scrollSpeed * Time.deltaTime, 0);
    }
}