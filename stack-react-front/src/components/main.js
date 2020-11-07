import { Container, Row, Col, Button } from 'react-bootstrap';
import QuestionsList from './quesions-list';
import { useHistory } from "react-router-dom";

function Main() {

  const history = useHistory();

  function addQuestion() {
    history.push('/add');
  }
  
  return (
    <Container className="mt-2">
      <Row className="p-3">
        <Col>
          <h3>Questions</h3>
        </Col>
        <Col className="d-flex justify-content-end">
          <Button onClick={addQuestion}>
            Ask question
          </Button>
        </Col>
      </Row>
      <QuestionsList/>
    </Container>
  );
}

export default Main;