using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] private List<GameObject> birds = new List<GameObject>();
    [SerializeField] private float minObstacleTimer = 2f, maxObstacleTimer = 5f;
    [SerializeField] private Vector3 obstacleSpawn;
    private ScoreController score;
    private float currTime;
    public List<GameObject> curr;

    private void Start()
    {
        currTime = 5f;
        score = GetComponent<ScoreController>();
    }

    public void ResetGeneration()
    {
        currTime = 5f;
        curr = new List<GameObject>(obstacles);
    }

    void Update()
    {
        if (score.GetScore() >= 600 && curr.Count <= 6)
            curr.AddRange(birds);
        currTime -= Time.deltaTime;        
        if (currTime <= 0)
        {
            int ind = Random.Range(0, curr.Count);
            Instantiate(curr[ind], obstacleSpawn + curr[ind].transform.position, Quaternion.identity, gameObject.transform);            
            currTime = Random.Range(minObstacleTimer, maxObstacleTimer) * (1 - ScoreController.scoreModifier / 2);
        }
    }
}
