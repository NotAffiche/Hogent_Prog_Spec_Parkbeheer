using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model;

public class HuisEF
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string Straat { get; set; }
    [Required]
    public int Nummer { get; set; }
    [Required]
    [Column(TypeName = "bit")]
    public bool Actief { get; set; }
}
