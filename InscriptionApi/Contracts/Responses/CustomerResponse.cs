using System;

namespace Ni_Soft.InscriptionApi.Contracts.Responses
{
    public class CustomerResponse
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
