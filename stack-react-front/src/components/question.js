import questService from '../services/question.service';
import React, { useEffect, useState } from 'react';
import { Container, Spinner } from 'react-bootstrap';
import { useParams } from "react-router-dom";
import AnswersForm from './answers-form';

export default function Question() {
  const [question, setQuestion] = useState(null);
  const [answers, setAnswers] = useState([]);
  const { id } = useParams();
  
  // eslint-disable-next-line
  useEffect(getQuestion, []);

  function getQuestion() {
    questService.getQuestionById(id).then(quest => {
      setQuestion(quest);
      setAnswers(quest.answers);
    }).catch(err => {
      console.error(err);
    });
  }

  function DisplayQuestion() {
    let date = new Date(question.date);
    return (
      <>
        <div className="border-bottom pb-3">
          <h2>{question.title}</h2>
          <div className="d-flex justify-content-start w-10">
            <small className="mr-5">Date: {date.toLocaleDateString()}</small>
            <small>Views: {question.views}</small>
          </div>
        </div>

        <div className="mt-3 py-3 px-4  bg-light">
          <pre className="pb-3">
            {question.questionText}
          </pre>
          <div className="d-flex justify-content-end">
            <span>Asked by: <b>{question.author}</b></span>
          </div>
        </div>

        <div className="pt-5">
          <div>
            <h5>{answers ? answers.length : 0} answers</h5>
          </div>
        </div>
      </>
    );
  }

  function DisplayAnswer() {
    return answers.map(answer => {
      let date = new Date(answer.date);
      return (
        <div key={answer.id} className="bg-light p-3 mb-2 border-bottom d-flex flex-column">
          <pre>{answer.answerText}</pre>
          <small className="align-self-end">{date.toLocaleDateString()}</small>
        </div>
      );
    });
  }

  function answerAdd(newAnswer) {
    setAnswers([...answers, newAnswer]);
  }

  return (
    <Container className="mt-3">
      {question ? (
        <>
          <DisplayQuestion/>
          <DisplayAnswer/>
          <AnswersForm questId={question.id} onAnswerAdd={answerAdd}/>
        </>
      ) : (
        <Spinner animation="border" />
      )}
    </Container>
  );
};