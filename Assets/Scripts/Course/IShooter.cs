using System.Collections;
using UnityEngine;

namespace BlowhardJamboree.Moonshot.Course
{

    public interface IShooter
    {

        IShootCommand Shoot(ICelestialBody planetToShootOffOf, Vector3 normal);

    }

}