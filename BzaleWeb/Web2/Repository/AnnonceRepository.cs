﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Web2.Models;
using Web2.Repository.Context;
using Web2.Repository.Interfaces;

namespace Web2.Repository
{
    public class AnnonceRepository: IAnnonceRepository<Annonce>
    {
       private BzaleContext context;

       public AnnonceRepository(BzaleContext context)
       {
           this.context = context;
       }

        #region dispose
       private bool disposed = false;
       protected virtual void Dispose(bool disposing)
       {
           if (!this.disposed)
           {
               if (disposing)
               {
                   context.Dispose();
               }
           }
           this.disposed = true;
       }

       public void Dispose()
       {
           Dispose(true);
           GC.SuppressFinalize(this);
       }
       #endregion


        public Annonce AddItem(Annonce newAnnonce)
        {
            Annonce annonce = null;
            if (newAnnonce.Owner != null && newAnnonce.CreatedBy != null && newAnnonce.CreatedBy.Company == newAnnonce.Owner)
            {
                context.Items.Add(newAnnonce);
                context.SaveChanges();
            }
            else
            {
                newAnnonce = null;
            }
            return newAnnonce;
        }

        public Annonce UpdateItem(Annonce updatedAnnonce)
        {
            context.Entry(updatedAnnonce).State = EntityState.Modified;
            context.SaveChanges();
            return context.Items.FirstOrDefault(e => e.ID == updatedAnnonce.ID);
        }

        public Annonce GetItem(int itemid)
        {
            return context.Items.FirstOrDefault(e => e.ID == itemid && e.Deleted == null && e.ExpirationDate > DateTime.Now);
        }

        public void DeleteItem(Annonce annonce)
        {
            annonce.Deleted = DateTime.Now;
            context.Entry(annonce).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Annonce> GetItemsForCompany(string vatnumber)
        {
            return context.Items.Where(e => e.Owner.VAT == vatnumber && e.Deleted == null).ToList();
        }

        public List<Annonce> GetSoldItemsForCompany(string vatnumber)
        {
            //Needs some check for if the Annonce is sold as well!
            return context.Items.Where(e => e.Owner.VAT == vatnumber ).ToList();
        }

        public List<Annonce> GetDeletedItemsForCompany(string vatnumber)
        {
            return context.Items.Where(e => e.Owner.VAT == vatnumber && e.Deleted != null).ToList();
        }
    }
}
