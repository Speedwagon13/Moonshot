using UnityEngine;
using System.Collections;

namespace BlowhardJamboree.Moonshot.Course.Turret
{

    public class TurretShooterMethodBehavior : MonoBehaviour, IShooter
    {
        
        [SerializeField]
        private GameObject playerToInstantiate;

        public IShootCommand Shoot(ICelestialBody planetToShootOffOf, Vector3 normal)
        {
            return new BuildPlayerAndShootCommand(playerToInstantiate, planetToShootOffOf, normal);
        }
 
    }

}