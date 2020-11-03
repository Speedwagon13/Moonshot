using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BlowhardJamboree.Moonshot.Course
{

    public class PlanetBehavior : MonoBehaviour, ICelestialBody
    {

        [SerializeField]
        private float xElipseRadius;

        [SerializeField]
        private float yElipseRadius;

        [SerializeField]
        private float elipseAngle;

        [SerializeField]
        private float secondsPerOrbit;

        [SerializeField]
        private Vector3 orbitCenter;

        // Update is called once per frame
        void Update()
        {
            transform.position = Elipse(xElipseRadius, yElipseRadius, orbitCenter, elipseAngle, Time.time / secondsPerOrbit);
            transform.LookAt(orbitCenter);
        }

        public float XElipseRadius()
        {
            return xElipseRadius;
        }

        public float YElipseRadius()
        {
            return yElipseRadius;
        }

        public float ElipseAngle()
        {
            return elipseAngle;
        }

        public static Vector3 Elipse(float a, float b, Vector3 centerpoint, float theta, float percent)
        {
            Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);
            Vector3 center = new Vector3(centerpoint.x, centerpoint.y, 0.0f);

            float angle = (percent % 100.0f) * 2.0f * Mathf.PI;
            var pos = new Vector3(a * Mathf.Cos(angle), 0, b * Mathf.Sin(angle));
            pos = q * pos + center;

            return pos;
        }

        public GameObject Body()
        {
            return gameObject;
        }
    }

}