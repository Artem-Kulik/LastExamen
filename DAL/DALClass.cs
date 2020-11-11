using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        IQueryable<User> AllUsers();
        IQueryable<Question> AllQuestions();
        void AddUser(User u);
        void AddResult(Result u);
        User Login(string log, string pas);
    }

    public class DALClass : IDAL
    {
        private readonly TestModel c = new TestModel();

        public void AddResult(Result u)
        {
            c.Results.Add(u);
            c.SaveChanges();
        }

        public void AddUser(User u)
        {
            c.Users.Add(u);
            c.SaveChanges();
        }

        public IQueryable<Question> AllQuestions() => c.Questions;

        public IQueryable<User> AllUsers() => c.Users;

        public User Login(string log, string pas)
        {
            return c.Users.Where(y => y.Login == log && y.Password == pas).FirstOrDefault();
        }
    }
}
