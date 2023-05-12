using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers;

public static class ContractMapper
{
    public static Huurcontract MapToDomain(HuurcontractEF db)
    {
        try
        {
            return new Huurcontract(db.Id, new Huurperiode(db.StartDatum, db.AantalDagenVerhuur), HuurderMapper.MapToDomain(db.Huurder), HuisMapper.MapToDomain(db.Huis));
        }
        catch (Exception ex)
        {
            throw new MapperException("ContractMapper - MapToDomain", ex);
        }
    }

    public static HuurcontractEF MapToDB(Huurcontract dom, ParkbeheerContext ctx)
    {
        try
        {
            HuurderEF huurder = ctx.Huurders.Find(dom.Huurder.Id);
            HuisEF huis = ctx.Huizen.Find(dom.Huis.Id);
            if (huurder == null) huurder = HuurderMapper.MapToDB(dom.Huurder);
            if (huis == null) huis = HuisMapper.MapToDB(dom.Huis, ctx);
            return new HuurcontractEF(dom.Id, dom.Huurperiode.StartDatum, dom.Huurperiode.EindDatum, dom.Huurperiode.Aantaldagen, huurder, huis);
        }
        catch (Exception ex)
        {
            throw new MapperException("Contractmapper - MapToDB", ex);
        }
    }
}
