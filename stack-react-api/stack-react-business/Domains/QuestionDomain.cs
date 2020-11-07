using AutoMapper;
using stack_react_business.Domains.Interfaces;
using stack_react_business.ViewModels;
using stack_react_data.Entities;
using stack_react_data.Repostiories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stack_react_business.Domains
{
  public class QuestionDomain : IQuestionDomain
  {
		private readonly IMapper _mapper;
		private readonly IQuestionRepository _questionRepository;

		public QuestionDomain(IQuestionRepository bookRepository, IMapper mapper)
		{
			_questionRepository = bookRepository;
			_mapper = mapper;
		}

		public IEnumerable<QuestionViewModel> GetQuestions() => 
			_mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(_questionRepository.GetAllQuestions().Reverse());

		public QuestionViewModel GetQuestion(int id) =>
			_mapper.Map<Question, QuestionViewModel>(_questionRepository.GetQuestion(id));

		public int AddQuestion(QuestionViewModel questionView)
    {
			questionView.Date = DateTime.Now;
			return _questionRepository.AddQuestion(_mapper.Map<QuestionViewModel, Question>(questionView));
    }

		public bool EditQuestion(QuestionViewModel questionView)
    {
			return _questionRepository.EditQuestion(_mapper.Map<QuestionViewModel, Question>(questionView));
    }
	}
}
