using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ClickInteraction : MonoBehaviour
{
    public Camera camera;
    public Transform player;

    [SerializeField] private float maxClickDistance = 4f;
    
    private void Awake()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }

        if (camera == null)
        {
            camera = FindObjectOfType<Camera>();
        }

        if (player == null)
        {
            player = transform;
        }
    }
    private void Update()
    {
        //Raycast
        //Create a line from one point to a direction,
        //looking for something to interact with.
        //It we can get details about the first thing we hit.

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            
            //a ray from the mouse position to the game world
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 3f);
            if (Physics.Raycast(ray, out hit))
            {
                NPCController npc = hit.transform.gameObject.GetComponent<NPCController>();

                Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.yellow, 3f);
                if (npc != null 
                    && npc.currentDialog != null 
                    && Vector3.Distance(hit.transform.position, player.position) < maxClickDistance)
                {
                    Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.green, 3f);
                    npc.currentDialog.BeginDialog();
                }
            }
        }
    }
}
