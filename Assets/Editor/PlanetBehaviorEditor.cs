using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BlowhardJamboree.Moonshot
{

    [CustomEditor(typeof(PlanetBehavior))]
    [CanEditMultipleObjects]
    public class PlanetBehaviorEditor : Editor
    {

        void OnSceneGUI()
        {
            PlanetBehavior t = target as PlanetBehavior;

            if (t == null)
            {
                return;
            }

            Handles.color = Color.yellow;

            Vector3[] elipsePoints = new Vector3[256];
            for (int i = 0; i < elipsePoints.Length; i++)
            {
                elipsePoints[i] = PlanetBehavior.Elipse(t.XElipseRadius(), t.YElipseRadius(), Vector3.zero, t.ElipseAngle(), (float)i / elipsePoints.Length); // ((float)(i + 1) / elipsePoints.Length) * 4 * t.XElipseRadius()
            }

            for (int i = 1; i < elipsePoints.Length; i++)
            {
                Handles.DrawLine(elipsePoints[i - 1], elipsePoints[i]);
            }
        }

        public override void OnInspectorGUI()
        {
            PlanetBehavior t = target as PlanetBehavior;

            if (t == null)
            {
                return;
            }

            if (GUILayout.Button("Move To Start of Orbit"))
            {
                t.transform.position = PlanetBehavior.Elipse(t.XElipseRadius(), t.YElipseRadius(), Vector3.zero, t.ElipseAngle(), 0);
            }

            base.OnInspectorGUI();
        }

    }

}