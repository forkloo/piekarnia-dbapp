using System;
using Piekarnia.Common.Enums;

namespace Piekarnia.IServices.Requests
{
    public class CreateClient
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientCity { get; set; }
        public string ClientMail { get; set; }
    }
}
