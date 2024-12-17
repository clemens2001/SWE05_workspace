import {Link} from "react-router-dom";


function Home() {
  return (
    <div className="ui container">
        <h1>Home</h1>
        <p>Welcome to our Bookstore</p>

        <Link className="ui red button" to="/books">
            Buchliste ansehen
            <i className="right arrow icon"></i>
        </Link>
    </div>
  );
}

export default Home;