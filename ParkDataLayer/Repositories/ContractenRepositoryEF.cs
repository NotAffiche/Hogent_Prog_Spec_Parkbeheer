using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        private ParkbeheerContext ctx;

        public ContractenRepositoryEF(string connStr)
        {
            this.ctx = new ParkbeheerContext(connStr);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            try
            {
                ctx.Huurcontracten.Remove(ctx.Huurcontracten.Find(contract.Id));
                SaveAndClear();
            }
            catch(Exception ex)
            {
                throw new RepositoryException("ContractRepo - Anulleer", ex);
            }
        }

        public Huurcontract GeefContract(string id)
        {
            try
            {
                return ContractMapper.MapToDomain(ctx.Huurcontracten.Where(x=>x.Id==id).Include(x=>x.Huurder).Include(x=>x.Huis).Include(x=>x.Huis.Park).AsNoTracking().SingleOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepo - Geef Id", ex);
            }
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            try
            {
                return ctx.Huurcontracten.Where(x=>x.StartDatum==dtBegin&&x.EindDatum==dtEinde).Include(x => x.Huurder).Include(x => x.Huis).Include(x => x.Huis.Park).AsNoTracking().Select(x=>ContractMapper.MapToDomain(x)).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepo - Geefs DTBegin DT, DT?End", ex);
            }
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return ctx.Huurcontracten.Any(c => c.Huurder.Id==huurderid&&c.StartDatum==startDatum&&c.Huis.Id==huisid);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepo - Heeft DTBegin, huurderID, huisID", ex);
            }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return ctx.Huurcontracten.Any(c=>c.Id==id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepo - Heeft Id", ex);
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            try
            {
                ctx.Huurcontracten.Update(ContractMapper.MapToDB(contract, ctx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepo - Update", ex);
            }
        }

        public void VoegContractToe(Huurcontract contract)
        {
            try
            {
                ctx.Huurcontracten.Add(ContractMapper.MapToDB(contract, ctx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepo - Add", ex);
            }
        }
    }
}
