using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BlowhardJamboree.Moonshot.Physics;

namespace BlowhardJamboree.Moonshot
{

    [CustomEditor(typeof(NewtonianRigidBody))]
    [CanEditMultipleObjects]
    public class NewtonianRigidBodyEditor : Editor
    {

        void OnSceneGUI()
        {
            NewtonianRigidBody t = target as NewtonianRigidBody;

            if (t == null)
            {
                return;
            }

            Handles.color = Color.green;
            Handles.DrawLine(t.transform.position, t.transform.position + (t.GravitationalForce() * 10));

            // Vector3[] elipsePoints = new Vector3[256];
            // for (int i = 0; i < elipsePoints.Length; i++)
            // {
            //     elipsePoints[i] = PlanetBehavior.Elipse(t.XElipseRadius(), t.YElipseRadius(), Vector3.zero, t.ElipseAngle(), (float)i / elipsePoints.Length); // ((float)(i + 1) / elipsePoints.Length) * 4 * t.XElipseRadius()
            // }

            // for (int i = 1; i < elipsePoints.Length; i++)
            // {
            //     Handles.DrawLine(elipsePoints[i - 1], elipsePoints[i]);
            // }
        }

        public override void OnInspectorGUI()
        {
            NewtonianRigidBody t = target as NewtonianRigidBody;

            if (t == null)
            {
                return;
            }

            // if (GUILayout.Button("Move To Start of Orbit"))
            // {
            //     t.transform.position = PlanetBehavior.Elipse(t.XElipseRadius(), t.YElipseRadius(), Vector3.zero, t.ElipseAngle(), 0);
            // }

            base.OnInspectorGUI();
        }

    }

}