using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 1.5f, -2.5f);

    /*void Awake()
    {
        offset = new Vector3(-10, 2, -3);
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
