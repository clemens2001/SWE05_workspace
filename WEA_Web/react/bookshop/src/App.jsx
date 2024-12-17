import React from 'react';
import './App.css';
import BookList from './components/BookList';
import BookDetails from "./components/BookDetails.jsx";

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

export default App
