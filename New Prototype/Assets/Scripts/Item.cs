using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IGrabable
{
    [SerializeField] private InputReader inputReader = default;
    private void OnEnable()
    {
        inputReader.grabEvent += OnGrab;
    }

    private void OnDisable()
    {
        inputReader.grabEvent -= OnGrab;
        inputReader.grabEvent -= OnRelease;
    }

    public void OnGrab()
    {
        transform.SetParent(FindObjectOfType<PlayerStateMachine>().transform);
        inputReader.grabEvent -= OnGrab;
        inputReader.grabEvent += OnRelease;
    }

    public void OnRelease()
    {
        transform.SetParent(null);
        inputReader.grabEvent -= OnRelease;
        inputReader.grabEvent += OnGrab;
    }
}
