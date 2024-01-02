namespace Trip_Expense_Tracker.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("transaction")]
    public partial class transaction
    {
        public int id { get; set; }

        public int amount { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime date { get; set; }

        public int? expeno { get; set; }

        public int? budgno { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public virtual budget budget { get; set; }

        public virtual expense expense { get; set; }
    }
}
