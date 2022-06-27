using System;


namespace Piekarnia.IServices.Requests
{
    public class EditClient
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientMail { get; set; }
        public string ClientCity { get; set; }
    }
}
