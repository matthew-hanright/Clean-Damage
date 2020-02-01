using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    private DoorOpen[] doors;

    // Start is called before the first frame update
    void Start()
    {
        doors = FindObjectsOfType<DoorOpen>();
        if (doors != null)
        {
            foreach (DoorOpen door in doors)
            {
                Debug.Log(door);
            }
        }
        else
        {
            Debug.Log("empty");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
