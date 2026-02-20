using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services
{
    public interface ISubscriptionService
    {   
        void Unsubscribe(string email);
        void Subscribe(string email, bool nouveautes, bool recapitulatifMois, bool faitDuJour);
    }
}
