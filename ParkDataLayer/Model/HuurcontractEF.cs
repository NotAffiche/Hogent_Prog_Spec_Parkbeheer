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
    public HuurcontractEF()
    {

    }

    public HuurcontractEF(string id, DateTime startDatum, DateTime? eindDatum, int aantalDagenVerhuur, HuurderEF huurder, HuisEF huis)
    {
        Id= id;
        StartDatum= startDatum;
        EindDatum = eindDatum;
        AantalDagenVerhuur= aantalDagenVerhuur;
        Huurder= huurder;
        Huis= huis;
    }

    [Key]
    [Column(TypeName = "nvarchar(25)")]
    public string Id { get; set; }
    [Required]
    public DateTime StartDatum { get; set; }
    public DateTime? EindDatum { get; set; }
    [Required]
    public int AantalDagenVerhuur { get; set; }
    public HuurderEF Huurder { get; set; }
    public HuisEF Huis { get; set; }
}
