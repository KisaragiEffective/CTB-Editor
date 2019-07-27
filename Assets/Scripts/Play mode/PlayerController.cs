﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float maxRange = 5;
    public float dashSpeedBoost = 2;
    public float speed = 5;
    float hInput;

    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        if (!(transform.position.x >= maxRange && hInput > 0) //Going out of right range
            && !(transform.position.x <= -maxRange && hInput < 0)) //going out of left range
        {
            float movement = hInput * speed;
            if (Input.GetKey(KeyCode.LeftShift))
                movement *= dashSpeedBoost;
            // Flip section
            Vector3 scale = transform.localScale;
            if (hInput > 0)
            {
                scale.x = 1; // ( o_o)
            }
            else if (hInput < 0)
            {
                scale.x = -1; // (o_o )
            }
            // Flips
            transform.localScale = scale;
            transform.position += new Vector3(movement*Time.deltaTime, 0);
        }
    }
}
