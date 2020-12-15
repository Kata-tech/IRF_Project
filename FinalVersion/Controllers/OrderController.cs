using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FinalVersion.Abstractions;
using FinalVersion.Entities;
using FinalVersion.Services;

namespace FinalVersion.Controllers
{
    public class OrderController
    {
        public IOrderManager OrderManager { get; set; }

        public OrderController()
        {
            OrderManager = new OrderManager();
        }

        public Adat Register(string telepules, string hotelnev, string sorszam, int ejszaka, int forint)
        {
            if (!ValidateTelepules(telepules))
                throw new ValidationException(
                    "A megadott település nem megfelelő!");
            if (!ValidateHotelnev(hotelnev))
                throw new ValidationException(
                    "A megadottt hotel név nem megfelelő!");
            if (!ValidateSorszam(sorszam))
                throw new ValidationException(
                    "A megadottt sorszám nem megfelelő!");
            if (!ValidateEjszaka(ejszaka))
                throw new ValidationException(
                    "A megadottt éjszakák száma nem megfelelő!");
            if (!ValidateForint(forint))
                throw new ValidationException(
                    "A megadottt forint mennyiség nem megfelelő!");

            var account = new Adat()
            {
                Telepules = telepules,
                Hotelnev = hotelnev,
                Sorszam =sorszam,
                Ejszaka = ejszaka,
                Forint = forint
            };

            var newAccount = OrderManager.CreateAdat(account);

            return newAccount;
        }

        public bool ValidateTelepules(string telepules)
        {
            return Regex.IsMatch(
                telepules,
                @"^([a-zA-Z\u0080-\u024F]+(?:. |-| |'))*[a-zA-Z\u0080-\u024F]*$");
        }

        public bool ValidateHotelnev(string hotelnev)
        {
            return Regex.IsMatch(
                hotelnev,
                @"^.{1,35}$");
        }

        public bool ValidateSorszam(string sorszam)
        {
            return Regex.IsMatch(
                sorszam,
                @"^[0-9]{1,20}$");
        }

        public bool ValidateEjszaka(int ejszaka)
        {
            return Regex.IsMatch(
                ejszaka.ToString(),
                @"^[1-9][0-9]{0,1}$");
        }

        public bool ValidateForint(int forint)
        {
            return Regex.IsMatch(
                forint.ToString(),
                @"^[1-9][0-9]{1,7}$");
        }
    }
}
