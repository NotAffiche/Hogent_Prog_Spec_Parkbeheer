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
    public HuisEF()
    {

    }

    public HuisEF(int id, string straat, int nummer, bool actief, ParkEF park)
    {
        Id= id;
        Straat= straat;
        Nummer= nummer;
        Actief= actief;
        Park= park;
    }

    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(250)")]
    public string Straat { get; set; }
    [Required]
    public int Nummer { get; set; }
    [Required]
    [Column(TypeName = "bit")]
    public bool Actief { get; set; }
    public ParkEF Park { get; set; }
    public ICollection<HuurcontractEF> Huurcontracten { get; set; } =  new List<HuurcontractEF>();
}
