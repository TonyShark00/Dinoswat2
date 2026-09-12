using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ScrollingBG : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
