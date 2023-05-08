using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model;

public class HuurderEF
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Naam { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string Telefoon { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string Email { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string Adres { get; set; }
}
