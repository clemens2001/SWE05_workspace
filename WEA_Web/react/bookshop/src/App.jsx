import './App.css';
import BookList from './components/BookList';

function App() {

  return (
    <BookList onBookClick={(book) => alert(book.title)}/>
  );
}

export default App
