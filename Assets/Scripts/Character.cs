using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    private Camera m_Camera;

    private float m_Amplifier = 10f;

    // Use this for initialization
    void Start()
    {
        m_Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (KeyValuePair<Windows.Kinect.JointType, Windows.Kinect.Joint> j in GameObject.Find("BodyManager").GetComponent<BodySourceManager>().GetData()[0].Joints)
            {
                switch (j.Key)
                {
                    case Windows.Kinect.JointType.SpineBase:
                        m_Hips.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.SpineMid:
                        m_Spine.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.Neck:
                        m_Neck.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.Head:
                        m_Head.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.ShoulderLeft:
                        m_LeftShoulder.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.ElbowLeft:
                        m_LeftForeArm.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.WristLeft:
                        m_LeftHand.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.ShoulderRight:
                        m_RightShoulder.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.ElbowRight:
                        m_RightForeArm.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.WristRight:
                        m_RightHand.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;

                    case Windows.Kinect.JointType.HipLeft:
                        m_LeftUpLeg.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.KneeLeft:
                        m_LeftLeg.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.AnkleLeft:
                        m_LeftFoot.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.HipRight:
                        m_RightUpLeg.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.KneeRight:
                        m_RightLeg.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                    case Windows.Kinect.JointType.AnkleRight:
                        m_RightFoot.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; break;
                }
                Debug.Log(j.Value.Position);
            }
            m_LeftShoulder.LookAt(m_LeftForeArm);
            m_LeftShoulder.eulerAngles += new Vector3(70, 0);
            m_LeftForeArm.LookAt(m_LeftHand);
            m_LeftForeArm.eulerAngles += new Vector3(70, 0);
            m_RightShoulder.LookAt(m_RightForeArm);
            m_RightShoulder.eulerAngles += new Vector3(70, 0);
            m_RightForeArm.LookAt(m_RightHand);
            m_RightForeArm.eulerAngles += new Vector3(70, 0);
        }
    }

    [SerializeField]
    private Transform m_Hips; // SpineBase
    [SerializeField]
    private Transform m_Spine; // SpineMid
    [SerializeField]
    private Transform m_Neck; // Neck
    [SerializeField]
    private Transform m_Head; // Head

    // SpineShoulder

    [SerializeField]
    private Transform m_LeftShoulder; // ShoulderLeft
    [SerializeField]
    private Transform m_LeftForeArm; // ElbowLeft
    [SerializeField]
    private Transform m_LeftHand; // WristLeft

    // HandLeft

    [SerializeField]
    private Transform m_RightShoulder; // ShoulderRight
    [SerializeField]
    private Transform m_RightForeArm; // ElbowRight
    [SerializeField]
    private Transform m_RightHand; // WristRight

    // HandRight

    [SerializeField]
    private Transform m_LeftUpLeg; // HipLeft
    [SerializeField]
    private Transform m_LeftLeg; // KneeLeft
    [SerializeField]
    private Transform m_LeftFoot; // AnkleLeft

    // FootLeft

    [SerializeField]
    private Transform m_RightUpLeg; // HipRight
    [SerializeField]
    private Transform m_RightLeg; // KneeRight
    [SerializeField]
    private Transform m_RightFoot; // AnkleRight

    // FootRight

    // HandTipLeft
    // ThumbLeft

    // HandTipRight
    // ThumbRight
}

/*

    case Windows.Kinect.JointType.SpineBase:
                        m_Hips.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.SpineMid:
                        m_Spine.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.Neck:
                        m_Neck.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.Head:
                        m_Head.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.ShoulderLeft:
                        m_LeftShoulder.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.ElbowLeft:
                        m_LeftForeArm.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.WristLeft:
                        m_LeftHand.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.ShoulderRight:
                        m_RightShoulder.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.ElbowRight:
                        m_RightForeArm.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.WristRight:
                        m_RightHand.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;

                    case Windows.Kinect.JointType.HipLeft:
                        m_LeftUpLeg.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.KneeLeft:
                        m_LeftLeg.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.AnkleLeft:
                        m_LeftFoot.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.HipRight:
                        m_RightUpLeg.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.KneeRight:
                        m_RightLeg.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;
                    case Windows.Kinect.JointType.AnkleRight:
                        m_RightFoot.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z); break;


    */
