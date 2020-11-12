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
        IQueryable<Result> AllResultsById(int id);
        IQueryable<Temperament> AllTemperaments();

        void AddUser(User u);
        void AddQuestion(string q, int t, int ta);
        void AddResult(Result u);
        User Login(string log, string pas);
        void EditUser(string log, string pas, string name, int id);
        void EditQuestion(string text, int id);
        float[] FullPersent();
    }

    public class DALClass : IDAL
    {
        private readonly TestModel c = new TestModel();

        public void AddQuestion(string q, int t, int ta)
        {
            c.Questions.Add(new Question() { TemperamentId = t, TemperamentAntonimID = ta, Text = q });
            c.SaveChanges();
        }

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

        public IQueryable<Result> AllResultsById(int id)
        {
            return c.Results.Where(res => res.UserId == id);
        }

        public IQueryable<Temperament> AllTemperaments()
        {
            return c.Temperaments;
        }

        public IQueryable<User> AllUsers() => c.Users;

        public void EditQuestion(string text, int id)
        {
            Question u = c.Questions.Where(t => t.Id == id).First();
            u.Text = text;
            c.SaveChanges();
        }

        public void EditUser(string log, string pas, string name, int id)
        {
            User u = c.Users.Where(t => t.Id == id).First();
            u.Name = name;
            u.Password = pas;
            u.Login = log;
            c.SaveChanges();
        }

        public float[] FullPersent()
        {
            float s = 0, p = 0, h = 0, m = 0;
            int i = 0;
            foreach (var it in c.Results)
            {
                i++;
                s += it.SanguinePercent;
                p += it.PhlegmaticPercent;
                h += it.CholericPercent;
                m += it.MelancholicPercent;
            }
            return new float[4] { s / i, p / i, h / i, m / i }; ;
        }       

        public User Login(string log, string pas)
        {
            return c.Users.Where(y => y.Login == log && y.Password == pas).FirstOrDefault();
        }
    }
}
