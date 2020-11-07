import { Container, Navbar, Nav, } from 'react-bootstrap';
import Main from './components/main';
import Question from './components/question';
import AddQuestion from './components/question-add';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

function App() {
  const NoMatch = ({ location }) => (
    <Container className="pt-5">
      <h4>No match for <code>{location.pathname}</code></h4>
    </Container>
  )
  
  return (
    <Router>
      <Navbar bg="dark" variant="dark">
        <Container>
          <Nav className="mr-auto">
            <Link className="nav-link" to="/">Home</Link> 
          </Nav>
        </Container>
      </Navbar>
      <Switch>
        <Route exact path="/">
          <Main />
        </Route>
        <Route exact path="/question/:id">
          <Question />
        </Route>
        <Route exact path="/add">
          <AddQuestion />
        </Route>
        <Route component={NoMatch} />
      </Switch>
    </Router>
  );
}

export default App;
