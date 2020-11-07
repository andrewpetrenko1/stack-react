import env from '../app-settings';

const axios = require('axios');

axios.defaults.baseURL = env.apiUrl;

async function getQuestions() {
  try {
    const response = await axios.get('/question');
    return await JSON.parse(response.request.response);
  } catch (error) {
    console.error(error);
  }
}

async function createQuestion(param) {
  try {
    const response = await axios.post('/question', param);
    return await JSON.parse(response.request.response);
  } catch (error) {
    console.error(error);
  }
}

async function getQuestionById(id) {
  try {
    const response = await axios.get(`/question/${id}`);
    return await JSON.parse(response.request.response);
  } catch (error) {
    console.error(error);
  }
}

export default {
  getQuestions,
  getQuestionById,
  createQuestion
}