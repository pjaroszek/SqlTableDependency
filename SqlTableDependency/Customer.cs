

using System;

namespace Jaroszek.ProofOfConcept.SqlTableDependency
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }



        public string City { get; set; }
        public DateTime Born { get; set; }
    }
}