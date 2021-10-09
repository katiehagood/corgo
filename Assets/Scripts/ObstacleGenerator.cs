using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float respawnTime = 10.0f;
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = getScreenBounds();
        StartCoroutine(obstacleWave());
    }

    private void spawnObstacle()
    {
        GameObject obs = Instantiate(obstaclePrefab) as GameObject;
        obs.transform.position = new Vector2(11.47f, -1.28f);
    }

    // Gets the screen boundry
    private Vector3 getScreenBounds()
    {
        float x = Screen.width;
        float y = Screen.height;
        float z = Camera.main.transform.position.z;

        return Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
    }

   IEnumerator obstacleWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            Debug.Log("spawning");
            spawnObstacle();
        }
        
    }
}
