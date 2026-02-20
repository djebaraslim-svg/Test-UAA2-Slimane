using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Utils
{
    public interface IMailerService
    {
        void SendSubscriptionEmail(string email);
        void SendUnsubscriptionEmail(string email);

    }
}
