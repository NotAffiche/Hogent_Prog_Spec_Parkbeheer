using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model;

public class HuurcontractEF
{
    [Required]
    [Column(TypeName = "nvarchar(25)")]
    public string Id { get; set; }
    [Required]
    public DateTime StartDatum { get; set; }
    [Required]
    public DateTime EindDatum { get; set; }
    [Required]
    public int AantalDagenVerhuur { get; set; }
}
