using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Repositories;
using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.Infrastructure.Database.Repositories
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly AppDbContext _Dbcontext;

        public SubscriberRepository(AppDbContext dbContext)
        {
            _Dbcontext = dbContext;
        }

        public void Add(Subscriber subscriber)
        {
            _Dbcontext.Subscribers.Add(subscriber);
        }

        public void Delete(Subscriber subscriber)
        {
            _Dbcontext.Subscribers.Remove(subscriber);
        }

        public Subscriber? GetByEmail(string email)
        {
            return _Dbcontext.Subscribers.FirstOrDefault(s => s.Email == email);
        }

        public void Save()
        {
            _Dbcontext.SaveChanges();
        }

        public void Update(Subscriber subscriber)
        {
            _Dbcontext.Subscribers.Update(subscriber);
        }
    }
}
