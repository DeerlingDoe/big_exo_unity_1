using System.Runtime.CompilerServices;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    private Vector3 startPosition;

    public PlayerControl playerControl;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("obstacle")) 
            {
                transform.position = startPosition; 
            }
        else if(other.CompareTag("wall"))
        {
            transform.position = startPosition;
        }
        else if(other.CompareTag("finish"))
        {
            playerControl.speed = 0f;
        }
    }
}
