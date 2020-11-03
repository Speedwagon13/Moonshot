using UnityEngine;
using System.Collections;

namespace BlowhardJamboree.Moonshot.Course
{

    public interface IShootCommand
    {
        
        IEnumerator Run();

        ShotResults Results();
 
    }

}