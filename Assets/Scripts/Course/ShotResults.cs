using UnityEngine;
using System.Collections;

namespace BlowhardJamboree.Moonshot.Course
{

    public class ShotResults
    {

        ICelestialBody whereShotEndedUp;

        Vector3 normal;

        public ICelestialBody WhereShotEndedUp { get => whereShotEndedUp; set => whereShotEndedUp = value; }

        public Vector3 Normal { get => normal; set => normal = value; }

    }

}