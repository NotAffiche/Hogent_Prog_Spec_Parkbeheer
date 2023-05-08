using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers;

public static class ParkMapper
{
    public static Park MapToDomain(ParkEF dbp)
    {
        try
        {
            return new Park(dbp.Id, dbp.Naam, dbp.Locatie);
        }
        catch (Exception ex)
        {
            throw new MapperException("ParkMapper - MapToDomain", ex);
        }
    }

    public static ParkEF MapToDB(Park dom)
    {
        try
        {
            return new ParkEF() { Id=dom.Id, Naam=dom.Naam, Locatie=dom.Locatie };
        }
        catch (Exception ex)
        {
            throw new MapperException("ParkMapper - MapToDB", ex);
        }
    }
}
