using UnityEngine;
using System.Collections;
using System;

public class Robot
{
    public enum State
    {
        D, AD, A, AS, S, IS, I, ID, F
        //D, A, S, I, F
    }

    private Network network;
    public State currentState { get; private set; }

    public IEnumerator SetCurrentState(State value)
    {
        if(value != currentState)
        {
            currentState = value;
            yield return network.GetRequest("State", value.ToString());
        }
    }

    public Robot(string ipAddress)
    {
        network = new Network(ipAddress);
        currentState = State.F;
    }

    public void setIpAddress(String ip)
    {
        network.ipAddress = ip;
    }
}
