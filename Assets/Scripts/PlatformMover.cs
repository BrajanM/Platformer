﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float speed;


    // Update is called once per frame
    void Update()
    {
		//speed = GameHandler.GameSpeed;
		transform.position += new Vector3(-speed * Time.deltaTime, 0, 0); 
    }
}
