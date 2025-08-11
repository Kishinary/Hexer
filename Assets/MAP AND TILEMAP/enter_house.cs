using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class enter_house : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Debug.Log("Enter House script started.");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        Debug.Log("OnTriggerEnter called with: " + other.name);
        
    }
}
