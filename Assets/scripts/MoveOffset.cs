using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveOffset : MonoBehaviour
{
    private Material currentMaterial;
    public float velocity;
    private float offset;

    void Start()
    {
        currentMaterial = GetComponent<Image>().material;
    }
    void Update()
    {
        offset += Time.deltaTime * velocity;
        if (offset >= 1)
        {
            offset = 0;
        }

        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
