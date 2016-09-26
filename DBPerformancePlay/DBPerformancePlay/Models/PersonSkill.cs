namespace DBPerformancePlay
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonSkill")]
    public partial class PersonSkill
    {
        public long Id { get; set; }

        public string SkillName { get; set; }
    }
}
