namespace KeyboardHub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Favorite
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FavoriteID { get; set; }

        [Key]
        [Column("_URL", Order = 1)]
        public string C_URL { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AspNetUser { get; set; }

    }
}
