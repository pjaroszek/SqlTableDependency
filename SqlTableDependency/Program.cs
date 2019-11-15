using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;

namespace Jaroszek.ProofOfConcept.SqlTableDependency
{
    class Program
    {
        private static string _con =
            @"Server=PAWEL-PC\SQL2017;Database=Test;User Id=sa;Password=997;MultipleActiveResultSets=True";

        static void Main(string[] args)
        {
            var mapper = new ModelToTableMapper<Customer>();
            // mapper.AddMapping(c => c.Surname, "Second Name");
            //  mapper.AddMapping(c => c.Name, "First Name");


            using (var dep = new SqlTableDependency<Customer>(_con, "Customer"))//, mapper: mapper
            {
                dep.OnChanged += Changed;
                dep.OnError += TableDependency_OnError;
                dep.Start();

                Console.WriteLine("Press a key to exit");
                Console.ReadKey();

                dep.Stop();
            }

        }

        private static void TableDependency_OnError(object sender, ErrorEventArgs e)
        {
            Exception ex = e.Error;
            Console.WriteLine(e.Message);
            
        }

        public static void Changed(object sender, RecordChangedEventArgs<Customer> e)
        {
            var changedEntity = e.Entity;

            Console.WriteLine("DML operation: " + e.ChangeType);
            Console.WriteLine("ID: " + changedEntity.Id);
            Console.WriteLine("Name: " + changedEntity.Name);
            Console.WriteLine("Surname: " + changedEntity.Surname);
        }



    }
}