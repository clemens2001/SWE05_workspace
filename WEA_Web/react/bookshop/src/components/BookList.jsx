import BookListItem from "./BookListItem.jsx";
import {getBooks} from "../api/bookApi.js";
import {useEffect, useState} from "react";
import {Navigate} from "react-router-dom";



function BookList(props) {
    // const { onBookClick } = props;  // const onBookClick = props.onBookClick;

    // const books = getBooks();
    const [books, setBooks] = useState([]);
    const [detailBookId, setDetailBookId] = useState(undefined);

    useEffect(() => {
        getBooks().then(data => setBooks(data.books));
    }, []); // empty array means that this effect will only run once after the first render


    function onBookClick(book) {
        setDetailBookId(book.id);
    }

    if(detailBookId) {
        return <Navigate to={`/books/${detailBookId}`} />;
    }

/*    const bookItems = [];
    for (const book of books) {
        bookItems.push(
            <div key={book.id} className="item" onClick={() => onBookClick(book)}>
                <div className="content">
                    <div className="header">{book.title}</div>
                    <div className="description">{book.author}</div>
                    <div className="extra">Year {book.year}</div>
                </div>
            </div>
        )
    }*/

    return (
        <div className="ui middle aligned selection divided list">
            {
                books.map(book => (
                    <div key={book.id} className="item" onClick={() => onBookClick(book)}>
                        <BookListItem theBook={book} />
                    </div>
                ))
                // bookItems
            }
        </div>
    )
}


export default BookList;