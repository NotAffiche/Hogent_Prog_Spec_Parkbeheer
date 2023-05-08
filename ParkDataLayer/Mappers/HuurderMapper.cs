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
            return new HuurderEF() { Id=dom.Id, Naam=dom.Naam, Adres=dom.Contactgegevens.Adres, Email=dom.Contactgegevens.Email, Telefoon=dom.Contactgegevens.Tel };
        }
        catch (Exception ex)
        {
            throw new MapperException("HuurderMapper - MapToDB", ex);
        }
    }
}
