import { Row, Col, Spinner } from 'react-bootstrap';
import React, { useEffect, useState } from 'react';
import questService from '../services/question.service'
import { Link } from 'react-router-dom';


export default function QuestionsList() {
  const [questions, setQuestions] = useState([]);

  useEffect(() => {
    questService.getQuestions().then(quest => {
      setQuestions(quest);
    }).catch(err => {
      console.log(err);
    });
  }, []);

  function DisplayQuestList(props) {
    props.quest.questionText = props.quest.questionText.slice(0, 100);
    let date = new Date(props.quest.date);
    return (
      <Row className="mb-2 border-top bg-light">
        <Col className="col-md-3 d-flex">
          <Row className="align-self-center">
            <div className="d-flex flex-column align-items-center m-2 p-2 view-item">
              {props.quest.views}
              <span>Views</span>
            </div>
            <div className="d-flex flex-column align-items-center m-2 p-2 view-item">
              {props.quest.answers.length}
              <span>Answers</span>
            </div>
          </Row>
        </Col>
        <Col className="col-md-9">
          <Row className="pt-3">
            <h5><Link to={'question/' + props.quest.id}>{props.quest.title}</Link></h5>
          </Row>
          <Row className="justify-content-between pb-3">
            <Col className="col-md-10 pl-0">
              <p>{props.quest.questionText}</p>
            </Col>
            <Col className="d-flex flex-column col-md-2">
              <small>Date: {date.toLocaleDateString()}</small>
              <small>Author: {props.quest.author}</small>
            </Col>
          </Row>
        </Col>
      </Row>
    );
  }

  return (
    questions.length !== 0 ? ( 
      questions.map(quest => {
        return (
          <DisplayQuestList key={quest.id} quest={quest}/>
        )
      })
    ) : (
      <Spinner animation="border" />
    )
  );
}
