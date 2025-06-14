using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]private string prefabName;
    [SerializeField]private Transform parent;
    private void OnEnable()
    {
        BallScript.onBallGrab.AddListener(SpawnBall);
        SpawnBall();
    }

    private void SpawnBall(){
        GameObject ball = ObjectPoolManager.Instance.GetPooledObject(prefabName);
        ball.SetActive(true);
    }
}
