using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private ParkbeheerContext ctx;

        public HuurderRepositoryEF(string connStr)
        {
            this.ctx = new ParkbeheerContext(connStr);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public Huurder GeefHuurder(int id)
        {
            try
            {
                return HuurderMapper.MapToDomain(ctx.Huurders.Find(id));
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuurderRepo - Geef Id", ex);
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                return ctx.Huurders.Where(x=>x.Naam==naam).Select(x=>HuurderMapper.MapToDomain(x)).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuurderRepo - Geefs Naam", ex);
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try
            {
                return ctx.Huurders.Any(h => h.Naam == naam && h.Email==contact.Email && h.Adres==contact.Adres && h.Telefoon==contact.Tel);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuurderRepo - Heeft Naam/Contact", ex);
            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return ctx.Huurders.Any(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuurderRepo - Heeft Id", ex);
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                ctx.Huurders.Update(HuurderMapper.MapToDB(huurder));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuurderRepo - Update", ex);
            }
        }

        public Huurder VoegHuurderToe(Huurder h)
        {
            HuurderEF hEF = HuurderMapper.MapToDB(h);
            ctx.Huurders.Add(hEF);
            SaveAndClear();
            return HuurderMapper.MapToDomain(ctx.Huurders.Find(hEF.Id));
        }
    }
}
