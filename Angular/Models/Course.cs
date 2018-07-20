﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int? CourseID { get; set; }
        public string Title { get; set; }
        public int? Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
