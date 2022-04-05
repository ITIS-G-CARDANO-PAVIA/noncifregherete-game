using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private int centerDistance = 50;
    [SerializeField]
    private float deadZone = 20;

    private RectTransform joystickTransform;
    private RectTransform centerTransform;
    [SerializeField]
    private double[] snapAngles;
    private double halfSnapArea;
    private Robot robot;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform[] arr = GetComponentsInChildren<RectTransform>();
        joystickTransform = arr[0];
        centerTransform = arr[1];
        snapAngles = new double[Enum.GetNames(typeof(Robot.State)).Length - 1];
        halfSnapArea = 360d / (snapAngles.Length * 2);
        for (int i = 0; i < snapAngles.Length; i++)
        {
            snapAngles[i] = halfSnapArea * 2 * i;
        }
        robot = new Robot("127.0.0.1");
    }

    public void OnIpChange(String ip)
    {
        robot.setIpAddress(ip);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 newPosition = eventData.position - (Vector2) joystickTransform.position;
        if(newPosition.magnitude < deadZone)
        {
            OnPointerUp(eventData);
            return;
        }
        newPosition.Normalize();
        double angle =  Math.Atan2(newPosition.y, newPosition.x) * Mathf.Rad2Deg - halfSnapArea;
        if(angle < 0)
        {
            angle += 360;
        }

        for(int i = 0; i < snapAngles.Length; i++)
        {
            double snapMax = snapAngles[i];
            if(snapMax == 0)
            {
                snapMax = 360;
            }
            double snapMin = snapMax - 2 * halfSnapArea;
            if(angle > snapMin && angle < snapMax)
            {
                newPosition.y = (float) Math.Sin(snapAngles[i] * Mathf.Deg2Rad);
                newPosition.x = (float) Math.Cos(snapAngles[i] * Mathf.Deg2Rad);
                centerTransform.localPosition = newPosition * centerDistance;
                StartCoroutine(robot.SetCurrentState((Robot.State) i));
                break;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        centerTransform.localPosition = Vector3.zero;
        StartCoroutine(robot.SetCurrentState(Robot.State.F));
    }

}
