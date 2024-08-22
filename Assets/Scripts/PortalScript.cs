using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform destination;
    GameObject player;

    public GameObject m_Text;

    private bool onCollider;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        onCollider = false;
    }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Player"))
//         {
//             if (Vector2.Distance(player.transform.position, transform.position) > 0.7f)
//             {
//                 player.transform.position = destination.transform.position;
//             }
//         }
//     }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && onCollider)
        {
            Debug.Log("W pressed");
            player.transform.position = destination.transform.position;
        }
    } 

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Entered");
        if(other.gameObject.CompareTag("Player"))
        {
            m_Text.SetActive(true);
            onCollider = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        onCollider = false;
        if(m_Text != null && m_Text.activeInHierarchy)
        {
            m_Text.SetActive(false);
        }
    }
}
