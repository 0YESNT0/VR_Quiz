using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System;

public class BallScript : MonoBehaviour
{
    [SerializeField]private bool hasBeenGrabbed = false;
    [SerializeField]private float RespawnDelay = 5;
    [SerializeField]private float currentDelayCountdown;
    public static Action onBallGrab;

    private XRGrabInteractable xrGrab;
    void OnEnable()
    {
        currentDelayCountdown = RespawnDelay;
        xrGrab = this.GetComponent<XRGrabInteractable>();
        xrGrab.lastSelectExited.AddListener(ReleaseBall); 
        xrGrab.selectEntered.AddListener(GrabBall); 
    }

    void Update()
    {
        if(hasBeenGrabbed == false) return;
        currentDelayCountdown -= Time.deltaTime;
        Debug.Log($"Despawn Counting Down{currentDelayCountdown}");
        if(currentDelayCountdown <= 0){
            //do despawn
            Despawn();
        }
    }

    public void ResetState(){
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }

    private void ReleaseBall(SelectExitEventArgs arg){
        Debug.LogWarning("Released Ball");
        hasBeenGrabbed = true;
    }
    private void GrabBall(SelectEnterEventArgs args){
        Debug.LogWarning("Grabbed Ball");
        currentDelayCountdown = RespawnDelay;
        hasBeenGrabbed = false;
        onBallGrab?.Invoke();
    }

    private void Despawn(){
        ObjectPoolManager.Instance.ReturnObjectToPool(this.gameObject);
    }
}
