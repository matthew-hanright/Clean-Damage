using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour
{

    public float parralax;

    // Update is called once per frame
    void Update()
    {
        MeshRenderer MR = GetComponent<MeshRenderer>();

        Material mat = MR.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;

        mat.mainTextureOffset = offset;
    } // Update
} // ScrollUV
