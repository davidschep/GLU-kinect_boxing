using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BoxDetox
{
    public class Character : MonoBehaviour
    {
        private float m_Amplifier = 10f;

        private int m_PlayerId;

        private Vector3 m_MyPosition = new Vector3(-20, 0, 0);
        private const float m_BaseXPos = 0f;

        private BodySourceManager m_BodySourceManager;

        private GameObject m_OtherPlayerHips;
        private float m_DistanceToOtherPlayer;
        public float m_MinDistance = 9f;

        void Start()
        {
            m_PlayerId = int.Parse(gameObject.name[6].ToString()) - 1;

            if (m_PlayerId == 1)
                m_OtherPlayerHips = GameObject.Find("Player1").transform.FindChild("DimplesRig:Hips").gameObject;
            else
                m_OtherPlayerHips = GameObject.Find("Player2").transform.FindChild("DimplesRig:Hips").gameObject;
            m_BodySourceManager = GameObject.Find("BodyManager").GetComponent<BodySourceManager>();
            if (m_PlayerId == 0)
                m_MyPosition += new Vector3(25, 0);
            else
                m_MyPosition += new Vector3(-10, 0);
        }

        void Update()
        {
            if (m_PlayerId == 0)
                m_Hips.eulerAngles = new Vector3(0, -180, 0);
            else
                m_Hips.eulerAngles = new Vector3(0, -180, 0);
            try
            {
                Vector3 offsetPosition = m_MyPosition;
                int myId = -1;
                bool first = false;
                for (int i = 0; i < m_BodySourceManager.GetData().Length; i++)
                    if (m_BodySourceManager.GetData()[i].IsTracked)
                        if (m_PlayerId == 1)
                            if (first)
                                myId = i;
                            else
                                first = true;
                        else
                        {
                            myId = i;
                            break;
                        }

                Windows.Kinect.Body body = GameObject.Find("BodyManager").GetComponent<BodySourceManager>().GetData()[myId];
                //Debug.Log(m_PlayerId.ToString() + "-" + distanceToOtherPlayer.ToString());

                if (myId != -1)
                {
                    foreach (KeyValuePair<Windows.Kinect.JointType, Windows.Kinect.Joint> j in body.Joints)
                    {
                        Vector3 valuePosition = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier + offsetPosition;
                        switch (j.Key)
                        {
                            case Windows.Kinect.JointType.SpineBase:
                                m_Hips.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier; // (5, 2, 0)
                                offsetPosition = m_MyPosition - m_Hips.position; // (17, 2, 0)  last position is the distance to the kinect

                                if (m_PlayerId == 1)
                                    m_DistanceToOtherPlayer = m_OtherPlayerHips.transform.parent.GetComponent<Character>().m_DistanceToOtherPlayer;
                                else
                                    m_DistanceToOtherPlayer = Vector3.Distance(m_Hips.position += offsetPosition, m_OtherPlayerHips.transform.position);
                                Debug.Log(m_PlayerId.ToString() + "-pos-" + m_Hips.position);
                                Debug.Log(m_PlayerId.ToString() + "-otherpos-" + m_OtherPlayerHips.transform.position);
                                if (m_PlayerId == 0)
                                {
                                    offsetPosition += new Vector3(-j.Value.Position.Z * m_Amplifier - m_BaseXPos, 0, 0);
                                    if (m_DistanceToOtherPlayer < m_MinDistance)
                                        offsetPosition -= new Vector3((m_MinDistance - m_DistanceToOtherPlayer) / 2, 0);
                                }
                                else
                                {
                                    offsetPosition += new Vector3(-j.Value.Position.Z * -m_Amplifier + m_BaseXPos, 0, 0);
                                    if (m_DistanceToOtherPlayer < m_MinDistance)
                                        offsetPosition += new Vector3((m_MinDistance - m_DistanceToOtherPlayer) / 2, 0);
                                }
                                m_Hips.position += offsetPosition; // (22, 2, 0)
                                break;
                            case Windows.Kinect.JointType.SpineMid:
                                m_Spine.position = valuePosition + new Vector3(0, -2, 0); break;
                            case Windows.Kinect.JointType.Neck:
                                m_Neck.position = valuePosition + new Vector3(0, -1, 0); break;
                            case Windows.Kinect.JointType.Head:
                                m_Head.position = valuePosition + new Vector3(0, -1, 0); break;

                            case Windows.Kinect.JointType.ShoulderLeft:
                                m_RightShoulder.position = valuePosition; break;
                            case Windows.Kinect.JointType.ElbowLeft:
                                m_RightForeArm.position = valuePosition; break;
                            case Windows.Kinect.JointType.WristLeft:
                                m_RightHand.position = valuePosition; break;
                            case Windows.Kinect.JointType.ShoulderRight:
                                m_LeftShoulder.position = valuePosition; break;
                            case Windows.Kinect.JointType.ElbowRight:
                                m_LeftForeArm.position = valuePosition; break;
                            case Windows.Kinect.JointType.WristRight:
                                m_LeftHand.position = valuePosition; break;

                            // Switching left & right around cuz this works
                            case Windows.Kinect.JointType.HipLeft:
                                m_RightUpLeg.position = valuePosition; break;
                            case Windows.Kinect.JointType.KneeLeft:
                                m_RightLeg.position = valuePosition; break;
                            case Windows.Kinect.JointType.AnkleLeft:
                                m_RightFoot.position = valuePosition; break;
                            case Windows.Kinect.JointType.HipRight:
                                m_LeftUpLeg.position = valuePosition; break;
                            case Windows.Kinect.JointType.KneeRight:
                                m_LeftLeg.position = valuePosition; break;
                            case Windows.Kinect.JointType.AnkleRight:
                                m_LeftFoot.position = valuePosition; break;

                            case Windows.Kinect.JointType.HandTipLeft:
                                Vector3 lookPosRight = (valuePosition - m_RightHand.position).normalized;
                                m_RightHand.rotation = Quaternion.LookRotation(lookPosRight);
                                m_RightHand.eulerAngles += new Vector3(90, 0, 0); break;
                            case Windows.Kinect.JointType.HandTipRight:
                                Vector3 lookPosLeft = (valuePosition - m_LeftHand.position).normalized;
                                m_LeftHand.rotation = Quaternion.LookRotation(lookPosLeft);
                                m_LeftHand.eulerAngles += new Vector3(90, 0, 0); break;
                        }
                    }
                    m_RightForeArm.position = (m_RightHand.position + m_RightForeArm.position) / 2;
                    m_LeftForeArm.position = (m_LeftHand.position + m_LeftForeArm.position) / 2;
                }



                m_LeftShoulder.LookAt(m_LeftForeArm);
                m_LeftShoulder.eulerAngles += new Vector3(100, 0);
                m_LeftForeArm.LookAt(m_LeftHand);
                m_LeftForeArm.eulerAngles += new Vector3(70, 0);
                m_RightShoulder.LookAt(m_RightForeArm);
                m_RightShoulder.eulerAngles += new Vector3(100, 0);
                m_RightForeArm.LookAt(m_RightHand);
                m_RightForeArm.eulerAngles += new Vector3(70, 0);
            }
            catch { }
            if (m_PlayerId == 0)
                m_Hips.eulerAngles = new Vector3(0, -270, 0);
            else
                m_Hips.eulerAngles = new Vector3(0, -90, 0);

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
        [SerializeField]
        private Transform m_ThumbLeft;// ThumbLeft

        // HandTipRight
        [SerializeField]
        private Transform m_ThumbRight;// ThumbRight
    }
}

//case Windows.Kinect.JointType.ShoulderLeft:
//                                m_LeftShoulder.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier + offsetPosition; break;
//                            case Windows.Kinect.JointType.ElbowLeft:
//                                m_LeftForeArm.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier + offsetPosition; break;
//                            case Windows.Kinect.JointType.WristLeft:
//                                m_LeftHand.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier + offsetPosition; break;
//                            case Windows.Kinect.JointType.ShoulderRight:
//                                m_RightShoulder.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier + offsetPosition; break;
//                            case Windows.Kinect.JointType.ElbowRight:
//                                m_RightForeArm.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier + offsetPosition; break;
//                            case Windows.Kinect.JointType.WristRight:
//                                m_RightHand.position = new Vector3(j.Value.Position.X, j.Value.Position.Y, j.Value.Position.Z) * m_Amplifier + offsetPosition; break;