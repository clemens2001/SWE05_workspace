import './App.css';
import BookList from './components/BookList';
import BookDetails from "./components/BookDetails.jsx";
import {useState} from "react";



function App() {

  const [selectedBook, setSelectedBook] = useState(undefined);

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
  }

  return (
      <div className="ui container">
        {content}
      </div>
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
