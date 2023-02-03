using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private BGMovement bg;
    private ObstacleGeneration obstacleGeneration;
    private ScoreController scoreController;    

    private void Awake()
    {
        obstacleGeneration= GetComponent<ObstacleGeneration>();
        scoreController= GetComponent<ScoreController>();
    }

    public void End()
    {
        scoreController.Stop();
        List<ObstacleController> obstacleControllers = obstacleGeneration.GetComponentsInChildren<ObstacleController>().ToList();
        foreach (ObstacleController obstacle in obstacleControllers)
        {
            obstacle.enabled = false;
            Animator animator;
            obstacle.gameObject.TryGetComponent(out animator);
            if (animator)
                animator.enabled = false;
        }
        obstacleGeneration.enabled = false;
        bg.enabled = false;
    }

    public void ResetGame()
    {
        List<ObstacleController> obstacleControllers = obstacleGeneration.GetComponentsInChildren<ObstacleController>().ToList();
        foreach (ObstacleController obstacle in obstacleControllers)
            Destroy(obstacle.gameObject);
        obstacleGeneration.enabled = true;
        obstacleGeneration.ResetGeneration();
        bg.enabled = true;
        scoreController.ResetScore();
    }
}
