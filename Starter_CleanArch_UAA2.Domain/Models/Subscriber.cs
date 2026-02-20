using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.Domain.Models
{
    public class Subscriber
    {
        public int Id { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public bool Nouveautes { get; set; }
        public bool RecapitulatifMois { get; set; }
        public bool FaitDuJour { get; set; }


        public Subscriber() { }

        public Subscriber(string email)
        {   
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("L'Email ne pas être vide", nameof(email));
            }

            Email = email;
           
        }

        public void UpdateSubscription(bool nouveautes, bool recapitulatifMois, bool faitDuJour)
        {
            Nouveautes = nouveautes;
            RecapitulatifMois = recapitulatifMois;
            FaitDuJour = faitDuJour;
        }

    }
}
