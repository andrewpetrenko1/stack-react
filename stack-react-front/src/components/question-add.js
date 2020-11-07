import { Container } from 'react-bootstrap';
import React, { useState } from "react";
import { useHistory } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import questService from '../services/question.service';
import '../App.css';

export default function AddQuestion() {
  const history = useHistory();
  const [submitted, setSubmitted] = useState(false);
  const { register, handleSubmit, errors } = useForm();

  const onSubmit = data => {
    questService.createQuestion(data).then(response => {
      setSubmitted(true);
      setTimeout(() => history.push('/'), 1000);
    });
  }

  const addForm = (
    <form className="w-75 bg-light p-4" onSubmit={handleSubmit(onSubmit)}>
      <div className="form-group">
        <label htmlFor="title">Title</label>
        <input
          type="text"
          className={errors.title ? 'form-control is-invalid' : 'form-control'}
          id="title"
          name="title"
          ref={register({ required: "Title required" })}
        />
        {errors.title && <small className="form-text text-danger">{errors.title.message}</small>}
      </div>

      <div className="form-group">
        <label htmlFor="questionText">Question text</label>
        <textarea
          type="text"
          className={errors.questionText ? 'form-control is-invalid' : 'form-control'}
          id="questionText"
          name="questionText"
          ref={register({ required: "Question text required"})}
          rows="5"
          columns="10"
        />
        {errors.questionText && <small className="form-text text-danger">{errors.questionText.message}</small>}
      </div>

      <div className="form-group">
        <label htmlFor="author">Author</label>
        <input
          type="text"
          className={errors.author ? 'form-control is-invalid' : 'form-control'}
          id="author"
          name="author"
          ref={register({ required: "Author required" })}
        />
        {errors.author && <small className="form-text text-danger">{errors.author.message}</small>}
      </div>

      <input type="submit" className="btn btn-success" value="Add question" />
    </form>
  );

  return (
    <Container className="d-flex align-items-center flex-column pt-4">
      {addForm}
      { submitted &&
        <div className="alert alert-success w-100">
          <p>Question added!</p>
        </div>
      }
    </Container>
  );
}