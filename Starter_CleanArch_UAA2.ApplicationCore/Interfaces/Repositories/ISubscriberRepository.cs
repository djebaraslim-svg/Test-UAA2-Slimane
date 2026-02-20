using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Repositories
{
    public interface ISubscriberRepository
    {
        Subscriber? GetByEmail(string email);
        void Add(Subscriber subscriber);
        void Update(Subscriber subscriber);
        void Delete(Subscriber subscriber);
        void Save();
    }





}
