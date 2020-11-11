using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TemperamentId { get; set; }

        public string TemperamentName { get; set; }
    }
    public class TemperamentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ResultDTO
    {
        public int Id { get; set; }

        public int SanguinePercent { get; set; }
        public int PhlegmaticPercent { get; set; }
        public int CholericPercent { get; set; }
        public int MelancholicPercent { get; set; }
        public int? UserId { get; set; }
    }

    public interface IDLL
    {
        IEnumerable<UserDTO> AllUsers();
        IEnumerable<QuestionDTO> AllQuestions();

        void AddUser(UserDTO u);
        void AddResult(ResultDTO u);
        UserDTO Login(string log, string pas);
    }

    public class BLLClass : IDLL
    {
        private readonly DALClass p = new DALClass();
        private readonly IMapper mapper = null;

        public BLLClass()
        {
            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<UserDTO, User>();
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<Question, QuestionDTO>().ForMember(src => src.TemperamentName, opt => opt.MapFrom(res => res.Temperament.Name)); ;
                    cfg.CreateMap<Temperament, TemperamentDTO>(); 
                    cfg.CreateMap<Result, ResultDTO>();
                    cfg.CreateMap<ResultDTO, Result>();
                });

            mapper = new Mapper(config);
        }

        public void AddUser(UserDTO u)
        {
            p.AddUser(mapper.Map<User>(u));
        }

        public IEnumerable<UserDTO> AllUsers()
        {
            return mapper.Map<IEnumerable<UserDTO>>(p.AllUsers());
        }

        public IEnumerable<QuestionDTO> AllQuestions()
        {
            return mapper.Map<IEnumerable<QuestionDTO>>(p.AllQuestions());
        }

        public UserDTO Login(string log, string pas)
        {
            return mapper.Map<UserDTO>(p.Login(log, pas));
        }

        public void AddResult(ResultDTO u)
        {
            p.AddResult(mapper.Map<Result>(u));
        }
    }
}
