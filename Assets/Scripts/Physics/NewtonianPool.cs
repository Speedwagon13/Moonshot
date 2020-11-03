using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BlowhardJamboree.Moonshot.Physics
{

    /// <summary>
    /// Pool for easily obtaining a collection of newtonian bodies for 
    /// calculating forces to apply to something
    /// </summary>
    public static class NewtonianPool
    {

        private static List<NewtonianRigidBody> bodies = new List<NewtonianRigidBody>();

        public static void Register(NewtonianRigidBody body)
        {
            if (body == null)
            {
                throw new System.ArgumentNullException("You can not register a null body to the pool");
            }
            bodies.Add(body);
        }

        public static bool Decommission(NewtonianRigidBody body)
        {
            if (body == null)
            {
                throw new System.ArgumentNullException("You can not decommision a null body");
            }
            return bodies.Remove(body);
        }

        public static List<NewtonianRigidBody> Bodies()
        {
            return bodies;
        }

    }

}