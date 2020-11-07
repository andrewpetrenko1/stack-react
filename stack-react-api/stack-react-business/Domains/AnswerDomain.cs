using AutoMapper;
using stack_react_business.Domains.Interfaces;
using stack_react_business.ViewModels;
using stack_react_data.Entities;
using stack_react_data.Repostiories.Interfaces;
using System;

namespace stack_react_business.Domains
{
  public class AnswerDomain : IAnswerDomain
  {
    private readonly IMapper _mapper;
    private readonly IAnswerRepository _answerRepository;

    public AnswerDomain(IAnswerRepository answerRepository, IMapper mapper)
    {
      _answerRepository = answerRepository;
      _mapper = mapper;
    }

    public int AddAnswer(AnswerViewModel answerView)
    {
      answerView.Date = DateTime.Now;
      return _answerRepository.AddAnswer(_mapper.Map<AnswerViewModel, Answer>(answerView));
    }
  }
}
