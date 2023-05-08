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
    public static Huurcontract MapToDomain(HuurcontractEF dbhc)
    {
        try
        {
            return new Huurcontract(dbhc.Id, new Huurperiode(dbhc.StartDatum, dbhc.AantalDagenVerhuur), HuurderMapper.MapToDomain(dbhc.Huurder), HuisMapper.MapToDomain(dbhc.Huis));
        }
        catch (Exception ex)
        {
            throw new MapperException("ContractMapper - MapToDomain", ex);
        }
    }

    public static HuurcontractEF MapToDB(Huurcontract dom)
    {
        try
        {
            return new HuurcontractEF() { Id=dom.Id, AantalDagenVerhuur=dom.Huurperiode.Aantaldagen, StartDatum=dom.Huurperiode.StartDatum, EindDatum=dom.Huurperiode.EindDatum, Huis=HuisMapper.MapToDB(dom.Huis), Huurder=HuurderMapper.MapToDB(dom.Huurder) };
        }
        catch (Exception ex)
        {
            throw new MapperException("Contractmapper - MapToDB", ex);
        }
    }
}
