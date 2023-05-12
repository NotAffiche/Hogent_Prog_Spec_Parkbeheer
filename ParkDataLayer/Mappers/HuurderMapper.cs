using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers;

public static class HuurderMapper
{
    public static Huurder MapToDomain(HuurderEF db)
    {
        try
        {
            return new Huurder(db.Id, db.Naam, new Contactgegevens(db.Email, db.Telefoon, db.Adres));
        }
        catch (Exception ex)
        {
            throw new MapperException("HuurderMapper - MapToDomain", ex);
        }
    }

    public static HuurderEF MapToDB(Huurder dom)
    {
        try
        {
            return new HuurderEF(dom.Id, dom.Naam, dom.Contactgegevens.Tel, dom.Contactgegevens.Email, dom.Contactgegevens.Adres);
        }
        catch (Exception ex)
        {
            throw new MapperException("HuurderMapper - MapToDB", ex);
        }
    }
}
