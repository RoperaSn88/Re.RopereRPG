using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayer : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = player.transform.position;
    }
}
