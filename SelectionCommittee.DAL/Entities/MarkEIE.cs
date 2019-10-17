﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelectionCommittee.DAL.Entities
{
    public class MarkEIE
    {
        [Key]
        public int Id { get; set; }

        public SubjectEIE SubjectEIE { get; set; }

        [ForeignKey("SubjectEIE")]
        public int SubjectEIEId { get; set; }

        public int Mark { get; set; }

        public Enrollee Enrollee { set; get; }

        [ForeignKey("Enrollee")]
        public int EnrolleeId { get; set; }
    }
}
