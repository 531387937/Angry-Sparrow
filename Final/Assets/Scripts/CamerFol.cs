﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFol : MonoBehaviour {
    public float m_DampTime = 0.2f;                 // Approximate time for the camera to refocus.
    public float m_ScreenEdgeBuffer = 4f;           // Space between the top/bottom most target and the screen edge.
    public float m_MinSize = 6.5f;                  // The smallest orthographic size the camera can be.
    [HideInInspector] public Transform[] m_Targets; // All the targets the camera needs to encompass.
    Rigidbody rig;

    private Camera m_Camera;                        // Used for referencing the camera.
    private float m_ZoomSpeed;                      // Reference speed for the smooth damping of the orthographic size.
    private Vector3 m_MoveVelocity;                 // Reference velocity for the smooth damping of the position.
    private Vector3 m_DesiredPosition;              // The position the camera is moving towards.

    public GameObject player1;
    public GameObject Player2;

    public BirdCtr BC;
    public int birdNum = 0;
    private bool BirdAlive = true;
    private void Awake()
    {
        m_Camera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        if(player1==null&& BC.birds[birdNum] != null)
        {
            player1 = BC.birds[birdNum];
            Player2 = BC.birds[birdNum];
            BC.birds[birdNum].GetComponent<Fire>().enabled = true;
        }
        if (BC.birds[birdNum] == null)
        {

            BirdAlive = false;
        }
        if (!BirdAlive)
        {
            birdNum++;
            player1 = BC.birds[birdNum];
            Player2 = BC.birds[birdNum];
            BC.birds[birdNum].GetComponent<Fire>().enabled = true;
            BirdAlive = true;
        }
    }

    private void FixedUpdate()
    {
        //if(pppl.cam_guding)
        //{
        //    Debug.Log("1");


        //}
        //else
        
        {

            Move();

            // Zoom();
            if (Vector3.Distance(player1.transform.position, Player2.transform.position) > 8.5f)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1.5f - 8.5f * 0.5f) - Vector3.forward * Vector3.Distance(player1.transform.position, Player2.transform.position) * 0.5f;
            }
        }

    }


    private void Move()
    {

        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        averagePos = (player1.transform.position - Player2.transform.position) / 2;
        averagePos += Player2.transform.position;


        averagePos = new Vector3(averagePos.x, averagePos.y, -10);

        m_DesiredPosition = averagePos;
    }


    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }


    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

        float size = 0f;

        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / m_Camera.aspect);
        }

        size += m_ScreenEdgeBuffer;

        size = Mathf.Max(size, m_MinSize);

        return size;
    }


    public void SetStartPositionAndSize()
    {
        // Find the desired position.
        FindAveragePosition();

        // Set the camera's position to the desired position without damping.
        transform.position = m_DesiredPosition;

        // Find and set the required size of the camera.
        m_Camera.orthographicSize = FindRequiredSize();
    }
}
