using UnityEngine;
using System.Collections;

namespace BlowhardJamboree.Moonshot.Course.Turret
{

    public class BuildPlayerAndShootCommand : IShootCommand
    {
        private ICelestialBody planetToShootOffOf;

        private Vector3 normal;

        private ShotResults results;

        GameObject playerToInstantiate;

        public BuildPlayerAndShootCommand(GameObject playerToInstantiate, ICelestialBody planetToShootOffOf, Vector3 normal)
        {
            this.playerToInstantiate = playerToInstantiate;
            this.planetToShootOffOf = planetToShootOffOf;
            this.normal = normal;
        }

        public IEnumerator Run()
        {
            // Instantiate the player to make the shot
            var playerInstance = GameObject.Instantiate(playerToInstantiate);
            var pos = planetToShootOffOf.Body().transform.position;
            pos += (normal.normalized * 2) * planetToShootOffOf.Body().transform.lossyScale.magnitude;
            playerInstance.transform.position = pos;
            playerInstance.transform.SetParent(planetToShootOffOf.Body().transform);

            // Run the shot
            var turretBehavior = playerInstance.GetComponent<TurretBehavior>();
            yield return new WaitUntil(() => turretBehavior.Results() != null);
            results = turretBehavior.Results();

            // Cleanup whatever just happened
            GameObject.Destroy(playerInstance);
        }

        public ShotResults Results()
        {
            return results;
        }

    }

}