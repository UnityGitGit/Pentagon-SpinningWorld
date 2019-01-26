﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    private WorldBody worldBody;
    [SerializeField]
    private bool isGrounded = false;
    public bool containsResource = false;

    private void Start() {
        worldBody = GetComponent<WorldBody>();
        isGrounded = World.Instance.GetGrounded(worldBody);
    }

    private void Update() {
        if (!isGrounded && World.Instance.GetGrounded(worldBody)) {
            isGrounded = true;
            //TODO: play meteor impact sound
            //TODO: show impact particles

            if (!containsResource) {
                Destroy(this.gameObject);
                //TODO: show destroy meteor particles
            }
        }
    }
}