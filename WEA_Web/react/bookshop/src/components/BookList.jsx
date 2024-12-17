import BookListItem from "./BookListItem.jsx";

const books = [
    { id: 1, title: 'The Great Gatsby', author: 'F. Scott Fitzgerald', year: 1925, 
        price: 24.99, description: 'The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan.' },
    { id: 2, title: 'To Kill a Mockingbird', author: 'Harper Lee', year: 1960, 
        price: 19.99, description: 'Description' },
    { id: 3, title: 'The Catcher in the Rye', author: 'J.D. Salinger', year: 1951,
        price: 14.99, description: 'Description' },
    { id: 4, title: 'The Grapes of Wrath', author: 'John Steinbeck', year: 1939,
        price: 9.99, description: 'Description' },
]


function BookList(props) {
    const { onBookClick } = props;  // const onBookClick = props.onBookClick;

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