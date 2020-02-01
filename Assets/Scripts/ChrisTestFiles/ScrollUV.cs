using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        MeshRenderer MR = GetComponent<MeshRenderer>();

        Material mat = MR.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.y += Time.deltaTime * 0.01f;

        mat.mainTextureOffset = offset;
    } // Update
} // ScrollUV
