using UnityEngine;
using System.Collections;

namespace BlowhardJamboree.Moonshot.Physics
{

    /// <summary>
    /// Does Newtons gravity formula on the object, and influences other 
    /// objects that are not marked as static.
    /// </summary>
    public class NewtonianRigidBody : MonoBehaviour
    {

        private static readonly float gravitationalConstant = 1f;

        public enum Mode
        {
            /// <summary>
            /// Velocity is effected by other newtonian bodies, and effects 
            /// others.
            /// </summary>
            Free,

            /// <summary>
            /// Only effects the velocity of other newtonian bodies, but it 
            /// itself is not effected.
            /// </summary>
            Static
        }

        private Vector3 currentVelocity;

        [SerializeField]
        private Mode currentMode;

        [SerializeField]
        private float mass;

        void Awake()
        {
            currentVelocity = Vector3.zero;
            NewtonianPool.Register(this);
        }

        void OnDestroy()
        {
            NewtonianPool.Decommission(this);
        }

        public void AddVelocity(Vector3 velocity)
        {
            this.currentVelocity += velocity;
        }

        void Update()
        {
            this.transform.position += this.currentVelocity * Time.deltaTime;
            if (currentMode != Mode.Free)
            {
                return;
            }
            this.currentVelocity += GravitationalForce() * Time.deltaTime;
        }

        public Vector3 GravitationalForce()
        {
            var accelerationVector = Vector3.zero;
            foreach (var body in NewtonianPool.Bodies())
            {
                var dir = body.transform.position - this.transform.position;
                if (dir == Vector3.zero)
                {
                    continue;
                }
                accelerationVector += ((gravitationalConstant * this.mass * body.mass) / Mathf.Abs(dir.sqrMagnitude)) * dir.normalized;
            }
            return accelerationVector;
        }

    }

}