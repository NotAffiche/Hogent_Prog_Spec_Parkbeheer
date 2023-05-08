using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
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
                return HuurderMapper.MapToDomain(ctx.Huurders.Where(h => h.Id == id).AsNoTracking().SingleOrDefault());
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
                return ctx.Huurders.Select(h => HuurderMapper.MapToDomain(h)).AsNoTracking().Where(h=>h.Naam.Equals(naam)).ToList();
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
                return ctx.Huurders.Any(h => h.Naam == naam && (h.Email.Equals(contact.Email) && h.Adres.Equals(contact.Adres) && h.Telefoon.Equals(contact.Tel)));
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
            ctx.Huurders.Add(HuurderMapper.MapToDB(h));
            SaveAndClear();
            Huurder toegevoegd = HuurderMapper.MapToDomain(ctx.Huurders.Where(x => (x.Naam == h.Naam) && 
            (x.Adres.Equals(h.Contactgegevens.Adres) && x.Telefoon.Equals(h.Contactgegevens.Tel) && x.Email.Equals(h.Contactgegevens.Email)))
                .AsNoTracking().SingleOrDefault());
            SaveAndClear();
            return toegevoegd;
        }
    }
}
