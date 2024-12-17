

function BookListItem(props) {
    const book = props.theBook;

    return (
        <div className="content">
            <div className="header">{book.title}</div>
            <div className="description">{book.author}</div>
            <div className="extra">Year {book.year}</div>
        </div>
    )
}

export default BookListItem;