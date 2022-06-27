using System;
using System.Text.RegularExpressions;
using Piekarnia.Common.Enums;
using Piekarnia.Domain.DomainExceptions;

namespace Piekarnia.Domain
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; private set; }
        public string ClientSurname { get; private set; }
        public string ClientStreet { get; private set; }
        public string ClientBuildingNumber { get; private set; }
        public string ClientCity { get; private set; }
        public int? ClientPhone { get; private set; }
        public string ClientMail { get; private set; }

        public Client(int clientId, string clientName, string clientSurname, string clientStreet, string clientBuildingNumber, string clientCity, int? clientPhone, string clientMail){
            ClientId = clientId;
            ClientName = clientName;
            ClientSurname = clientSurname;
            ClientStreet = clientStreet;
            ClientBuildingNumber = clientBuildingNumber;
            ClientCity = clientCity;
            ClientPhone = clientPhone;
            ClientMail = clientMail;
        }

        public Client(string clientName, string clientSurname, string clientMail, string clientCity){
            if (!Regex.IsMatch(clientName, @"^[a-zA-Z]+$")){
                throw new InvalidNameSurnameException(clientName);
            }
            if (!Regex.IsMatch(clientSurname, @"^[a-zA-Z]+$"))
            {
                throw new InvalidNameSurnameException(clientSurname);
            }

            ClientName = clientName;
            ClientSurname = clientSurname;
            ClientMail = clientMail;
            ClientCity = clientCity;

            ClientBuildingNumber = "";
            ClientStreet = "";
            ClientPhone = null;
        }

        public void EditClient(string clientName, string clientSurname, string clientMail, string clientCity){
            if (!Regex.IsMatch(clientName, @"^[a-zA-Z]+$"))
            {
                throw new InvalidNameSurnameException(clientName);
            }
            if (!Regex.IsMatch(clientSurname, @"^[a-zA-Z]+$"))
            {
                throw new InvalidNameSurnameException(clientSurname);
            }

            ClientName = clientName;
            ClientSurname = clientSurname;
            ClientMail = clientMail;
            ClientCity = clientCity;
        }

    }
}