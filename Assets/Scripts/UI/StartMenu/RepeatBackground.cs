using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    public GameObject playerPos;

    void Start()
    {
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    void Update()
    {
        startPos = playerPos.transform.position;

        transform.Translate(startPos,Space.Self);


        if (transform.position.x < startPos.x - repeatWidth){
            transform.position = startPos;
        }
    }
}
