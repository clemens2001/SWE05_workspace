import {baseUrl} from "../api/bookApi.js";


function BookListItem(props) {
    const book = props.theBook;

    return (
        <>
            <img className="ui tiny image"
                 src={`${baseUrl}/${props.theBook.picture}`}
                 alt="Book Cover" />

            <div className="content">
                <div className="header">{book.title}</div>
                <div className="description">{book.author}</div>
                <div className="extra">Year {book.year}</div>
            </div>
        </>
    )
}

export default BookListItem;