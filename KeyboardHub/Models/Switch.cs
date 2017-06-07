namespace KeyboardHub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Switch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SwitchID { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public short AccuationForce { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string TouchAudio { get; set; }

        [StringLength(50)]
        public string TouchOringAudio { get; set; }

        [StringLength(50)]
        public string BottomAudio { get; set; }

        [StringLength(50)]
        public string BottomOringAudio { get; set; }

        [StringLength(50)]
        public string GIFPath { get; set; }

        public string HTML1 { get; set; }

        public string HTML2 { get; set; }

        public string HTML3 { get; set; }
    }
}
