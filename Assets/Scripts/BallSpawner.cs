using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]private string prefabName;
    [SerializeField]private Transform parent;
    private void Start()
    {
        Debug.Log("Enabled SPawner");        
        SpawnBall();
        BallScript.onBallGrab += SpawnBall;
    }

    private void SpawnBall(){
        GameObject ball = ObjectPoolManager.Instance.Instantiate(prefabName,parent.position,parent.rotation);
        Debug.Log("SPawned");
        ball.gameObject.SetActive(true);
    }
}
