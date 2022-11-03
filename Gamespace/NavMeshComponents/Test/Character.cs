using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Character : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform player;
    public Transform destination;

    public bool isEditorMode;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        startRotation = transform.rotation;

    
    }
    private void Update()
    {
        if (!isEditorMode)
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }

     
 
    }
    public void MoveToPlayer()
    {
        if (player != null)
        {
            agent.destination = player.position;
        }
        else
        {
            Debug.LogError("cannot find player");
        }
    }
    public void MoveToPosition()
    {
        if (destination != null)
        {
            agent.destination = destination.position;
        }
        else
        {
            Debug.LogError("cannot find destiontion");
        }
    }
}
