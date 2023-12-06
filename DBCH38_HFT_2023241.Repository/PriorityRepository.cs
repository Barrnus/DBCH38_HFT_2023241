﻿using DBCH38_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Repository
{
    public class PriorityRepository : IPriorityRepository<Priority>
    {
        protected TaskDbContext ctx;
        public PriorityRepository(TaskDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException("the context is null");
        }

        public void Create(Priority item)
        {
            ctx.Set<Priority>().Add(item);
            ctx.SaveChanges();

        }

        public void Delete(int id)
        {
            ctx.Set<Priority>().Remove(Read(id));
            ctx.SaveChanges();

        }

        public Priority Read(int id)
        {
            return ctx.Set<Priority>().FirstOrDefault(item => item.Id.Equals(id));
        }

        public IQueryable<Priority> ReadAll()
        {
            return ctx.Set<Priority>();
        }

        public void Update(Priority item)
        {
            Priority old = Read(item.Id);
            foreach (var property in item.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(item));
            }

            ctx.SaveChanges();

        }
    }
}
