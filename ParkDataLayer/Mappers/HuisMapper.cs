using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers;

public static class HuisMapper
{
    public static Huis MapToDomain(HuisEF db)
    {
        try
        {
            return new Huis(db.Id, db.Straat, db.Nummer, db.Actief, ParkMapper.MapToDomain(db.Park));
        }
        catch (Exception ex)
        {
            throw new MapperException("HuisMapper - MapToDomain", ex);
        }
    }

    public static HuisEF MapToDB(Huis dom, ParkbeheerContext ctx)
    {
        try
        {
            ParkEF p = ctx.Parken.Find(dom.Park.Id);
            if (p == null) p = ParkMapper.MapToDB(dom.Park);
            return new HuisEF(dom.Id, dom.Straat, dom.Nr, dom.Actief, p);
        }
        catch (Exception ex)
        {
            throw new MapperException("HuisMapper - MapToDB", ex);
        }
    }
}
