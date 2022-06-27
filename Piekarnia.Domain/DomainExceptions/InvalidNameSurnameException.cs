using System;

namespace Piekarnia.Domain.DomainExceptions
{
    public class InvalidNameSurnameException : Exception
    {
        public InvalidNameSurnameException(string nameSurname) : base(ModifyMessage(nameSurname)){ }
        private static string ModifyMessage(string nameSurname){
            return $"Invalid name or surname: {nameSurname}";
        }
    }
}
