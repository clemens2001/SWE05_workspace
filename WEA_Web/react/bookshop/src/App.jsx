import './App.css';
import BookList from './components/BookList';
import BookDetails from "./components/BookDetails.jsx";
import {useState} from "react";

import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link
} from "react-router-dom";
import Home from "./components/Home.jsx";

function App() {

/*  const [selectedBook, setSelectedBook] = useState(undefined);

  function showDetails(book) {
    setSelectedBook(book);
  }

  function showList() {
    setSelectedBook(undefined);
  }

  let content;
  if (!selectedBook) {
    content = <BookList onBookClick={showDetails}/>;
  } else {
    content = <BookDetails book={selectedBook} onBackClick={showList} />;
  }*/



  return (
      <Router>
        <div className="ui container">
          <div className="ui two item tabs menu">
            <Link to="/" className="item">Home</Link>
            <Link to="/books" className="item">Books</Link>
          </div>
          <Routes>
              <Route path="/books/:bookId" element={<BookDetails />} />
              <Route path="/books" element={<BookList />} />
              <Route path="/" element={<Home />} />
          </Routes>
        </div>
      </Router>
  );
}

/*
class App extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      selectedBook: undefined
    }
  }

  showDetails(book) {
    this.setState({ selectedBook: book });
  }

  showList() {
      this.setState({ selectedBook: undefined });
  }

  render() {
    let content;
    if (!this.state.selectedBook) {
      // content = <BookList onBookClick={this.showDetails.bind(this)}/>;  // .bind because we want to pass the context (otherwise this will be undefined)
      content = <BookList onBookClick={(book) => this.showDetails(book)}/>;
    } else {
      // content = <h1>Details of the book {this.state.selectedBook.title}</h1>
      content = <BookDetails book={this.state.selectedBook} onBackClick={() => this.showList()} />;
    }

    return (
        <div className="ui container">
            {content}
        </div>
    );
  }
}
*/

export default App
