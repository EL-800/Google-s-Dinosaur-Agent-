using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class DinosaurAgent : Agent
{    
    protected DinosaurController dinosaurController;
    protected float currReward = 1f;

    public override void OnEpisodeBegin()
    {
        currReward = 0;
        dinosaurController.ResetGame();
    }

    protected void Awake()
    {
        dinosaurController = GetComponent<DinosaurController>();        
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        dinosaurController.SetInput(Convert.ToBoolean(actions.DiscreteActions[0]), Convert.ToBoolean(actions.DiscreteActions[1]));
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = Convert.ToInt32(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space));
        discreteActions[1] = Convert.ToInt32(Input.GetKey(KeyCode.DownArrow));
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Passed")        
            AddReward(++currReward);        
    }

    protected void Update()
    {
        if (dinosaurController.GetGameState())
            EndEpisode();
        if (GetCumulativeReward() >= 1e5)
            EndEpisode();
        Debug.Log(GetCumulativeReward());
    }
}