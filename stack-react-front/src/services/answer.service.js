import env from '../app-settings';

const axios = require('axios');

axios.defaults.baseURL = env.apiUrl;

async function createAnswer(newAnswer) {
  try {
    const response = await axios.post('/answer', newAnswer);
    return await JSON.parse(response.request.response);
  } catch (error) {
    console.error(error);
  }
}

export default {
  createAnswer
}