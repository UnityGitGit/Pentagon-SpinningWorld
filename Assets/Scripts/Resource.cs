﻿using UnityEngine;

public class Resource : MonoBehaviour {
	public int repairPower = 10;
	public bool isHeld { get; private set; }
	private bool isDelivered;
	public bool canPickUp {
		get {
			if (isDelivered) { return false; }
			if (isHeld) { return false; }
			return true;
		}
	}

    private WorldBody worldBody;

	public delegate void OnDeliverDelegate();
	public event OnDeliverDelegate onDeliver;

    private void Awake() {
        worldBody = GetComponent<WorldBody>();
    }

    public void PickUp(Transform newParent) {
        worldBody.enabled = false;
        transform.SetParent(newParent);
        isHeld = true;
	    AkSoundEngine.PostEvent("Pickup", gameObject);
    }

    public void Drop() {
        worldBody.enabled = true;
        transform.SetParent(null);
        isHeld = false;
    }

	public void Deliver() {
		Drop();
		isDelivered = true;
		Destroy(gameObject);
		onDeliver?.Invoke();
	}
}