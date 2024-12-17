var express = require('express');
const Book = require('../model/book');
var router = express.Router();
var testData = require('../model/test-data');

class UpdateResponse{
	accepted;
	reason;
}

/* GET books listing. */
router.post('/', function(req, res, next) {

  const bookToSave = req.body;

  const response = new UpdateResponse();
  try {
    const newBook = new Book();
    newBook.id = '' + testData.length + 1;
    newBook.author = bookToSave.author;
    newBook.title = bookToSave.title;
    newBook.price = bookToSave.price;
    newBook.publisher = bookToSave.publisher;
    newBook.year = bookToSave.year;
    newBook.description = bookToSave.description;
    newBook.picture = bookToSave.picture;
    newBook.isbn = bookToSave.isbn;
    testData.push(newBook);

    response.accepted = true;
    response.reason = 'valid data!';
  } catch (e) {
    response.accepted = false;
    response.reason = 'no valid data!';
  }

  res.send(response);
});

module.exports = router;
