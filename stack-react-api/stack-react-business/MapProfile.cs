using AutoMapper;
using stack_react_business.ViewModels;
using stack_react_data.Entities;
using System;

namespace stack_react_business
{
  public class MapProfile : Profile
  {
    public MapProfile()
    {
      CreateMap<Question, QuestionViewModel>().ReverseMap();
      CreateMap<Answer, AnswerViewModel>().ReverseMap();
    }
  }
}
