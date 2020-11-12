using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BlowhardJamboree.Moonshot.UI.CourseSelect
{


    public class CourseOption
    {
        public enum EDifficulty
        {
            Easy,
            Medium,
            Hard
        }

        public string CourseName { get; set; }

        public EDifficulty CourseDifficulty { get; set; }

        public string ImagePath { get; set; }
    
    }



}


