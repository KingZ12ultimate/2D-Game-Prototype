using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IGrabable
{
    public void OnGrab()
    {
        transform.SetParent(FindObjectOfType<PlayerStateMachine>().transform);
    }
}
