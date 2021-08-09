using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SOLID_InterfaceSegregationPrincipSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadRepository<Person> readRepository = new RepositoryBase<Person>(); //User hat nur LEserechte
            readRepository.GetAll();
            readRepository.GetById(123);
            readRepository.GetByStatement(n => n == 3);
            
            

            IRepository<Person> repository = new RepositoryBase<Person>();
            repository.Insert(new Person(2, "Harry"));
            repository.Update(2, new Person(2, "Tester"));
            repository.GetAll();
        }
    }

    public record Person (int Id, string Name);

    #region BadCode

    public interface IReadRepository<T>
    {
        IList<T> GetAll();

        IList<T> GetByStatement(Expression<Func<int, bool>> predicate); //Where Klausen

        T GetById(int Id);
    }

    public interface IRepository<T> : IReadRepository<T>
    {
        public void Insert(T item);
        public void Update(int Id, T modifiedItem);

        public void Delete(int Id);
    }

    public class RepositoryBase<T> : IRepository<T>
    {

        //DbContext -> Verbindung zu DB
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetByStatement(Expression<Func<int, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, T modifiedItem)
        {
            throw new NotImplementedException();
        }
    }


 



    public class Report
    {
        public int Id { get; set; }
        public string Memo { get; set; }
    }


    public class ReportRepository : RepositoryBaseVarianteB<Report>
    {
        /// <summary>
        /// DBContext oder SQLConnection ist hier von nöten
        /// </summary>
        /// <param name="Id"></param>
        public override void Delete(int Id)
        {
            //Expliziete Implementiert
        }

        public override IList<Report> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Report GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public override IList<Report> GetByStatement(Expression<Func<int, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Report item)
        {
            throw new NotImplementedException();
        }

        public override void Update(int Id, Report modifiedItem)
        {
            throw new NotImplementedException();
        }
    }



    #endregion
}
