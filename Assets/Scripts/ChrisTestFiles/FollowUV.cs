using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour
{

    // Change this as needed for each starfield in the map. The starfield in
    // the front should have a lower parralax.
    public float parralax = 2f;

    // Update is called once per frame
    void Update()
    {
        // This is the mesh renderer whose individual material we will be
        // messing around with
        MeshRenderer MR = GetComponent<MeshRenderer>();

        // Create a reference to this instance of the material
        Material mat = MR.material;

        // Reference to material offset
        Vector2 offset = mat.mainTextureOffset;

        // Change the offset of the background based on the movements of the
        // player; divide that by the parralax value to stagger the
        // two quads' offsets
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;

        // Update the material's offset
        mat.mainTextureOffset = offset;
    } // Update
} // ScrollUV