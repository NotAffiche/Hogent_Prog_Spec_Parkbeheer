﻿using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private ParkbeheerContext ctx;

        public HuizenRepositoryEF(string connStr)
        {
            this.ctx = new ParkbeheerContext(connStr);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public Huis GeefHuis(int id)
        {
            try
            {
                return HuisMapper.MapToDomain(ctx.Huizen.Where(h => h.Id == id).AsNoTracking().SingleOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuisRepo - Geef Id", ex);
            }
        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                return ctx.Huizen.Any(h=>h.Straat.Equals(straat)&&h.Nummer==nummer&&h.Park==ParkMapper.MapToDB(park));
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuisRepo - Geef Id", ex);
            }
        }

        public bool HeeftHuis(int id)
        {
            try
            {
                return ctx.Huizen.Any(h => h.Id==id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuisRepo - Heeft Id", ex);
            }
        }

        public void UpdateHuis(Huis huis)
        {
            try
            {
                ctx.Huizen.Update(HuisMapper.MapToDB(huis));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuisRepo - Update", ex);
            }
        }

        public Huis VoegHuisToe(Huis h)
        {
            try
            {
                Park p = h.Park;
                ParkEF pEF = ParkMapper.MapToDB(p);
                ctx.Parken.Add(pEF);
                HuisEF hsEF = HuisMapper.MapToDB(h);
                ctx.Huizen.Add(hsEF);
                SaveAndClear();
                //
                return h;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuisRepo - Add", ex);
            }
        }
    }
}
