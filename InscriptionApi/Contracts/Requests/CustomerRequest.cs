using System;

namespace Ni_Soft.InscriptionApi.Contracts.Requests
{
    public class CustomerRequest
    {
        public long? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
