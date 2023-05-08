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
    public static Huis MapToDomain(HuisEF dbh, ParkEF pef)
    {
        try
        {
            return new Huis(dbh.Id, dbh.Straat, dbh.Nummer, dbh.Actief, new Park(pef.Id, pef.Naam, pef.Locatie));
        }
        catch (Exception ex)
        {
            throw new MapperException("HuisMapper - MapToDomain", ex);
        }
    }

    public static HuisEF MapToDB(Huis dom)
    {
        try
        {
            return new HuisEF() { Id=dom.Id, Straat=dom.Straat, Nummer=dom.Nr, Actief=dom.Actief };
        }
        catch (Exception ex)
        {
            throw new MapperException("HuisMapper - MapToDB", ex);
        }
    }
}
