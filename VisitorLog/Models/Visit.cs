using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorLog.Models
{
    public class Visit
    {
        [Key] public int Id { get; set; }
        [Required] [DataType(DataType.Date)] [DisplayName("Visit Date")] public DateTime VisitDt { get; set; }
        [Required] [StringLength(20)] public string Location { get; set; }
        [Required] [StringLength(50)] [DisplayName("Attendee Name")] public string AttendeeName { get; set; }
        [Required] [StringLength(50)] [DisplayName("Attendee Group")] public string AttendeeGroup { get; set; }
        [Required] [StringLength(50)] [DisplayName("Helper Name")] public string HelperName { get; set; }
        [Required] [StringLength(50)] [DisplayName("Helper Group")] public string HelperGroup { get; set; }
        [Required] [StringLength(300)] public string Task { get; set; }
        [Required] [StringLength(300)] public string Resolution { get; set; }
        [Required] [StringLength(50)] public string Tags { get; set; }
    }
}
