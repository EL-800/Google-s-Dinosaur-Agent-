using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class DinosaurAgentRay : DinosaurAgent
{
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(dinosaurController.transform.position.y);         
    }
}
