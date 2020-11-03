using UnityEngine;

namespace BlowhardJamboree.Moonshot.Course.Turret
{

    /// <summary>
    /// Behavior surrounding having a player make a shot off a planet
    /// </summary>
    public class TurretBehavior : MonoBehaviour
    {

        private ShotResults results;

        [SerializeField]
        private GameObject bullet;

        private Vector3 lastPos;

        void Fire()
        {
            var bulletInstance = Instantiate(bullet, transform.position + transform.forward * 1.4f, transform.rotation);
            bulletInstance
                .GetComponent<Physics.NewtonianRigidBody>()
                .AddVelocity((transform.forward * 10) + (transform.position - lastPos));
        }

        void Update()
        {
            transform.Rotate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Fire();
            }
            lastPos = transform.position;
        }

        public ShotResults Results()
        {
            return results;
        }

    }

}