var express = require('express');
const Book = require('../model/book');
var router = express.Router();
var testData = require('../model/test-data');

class UpdateResponse{
	accepted;
	reason;
}

/* GET books listing. */
router.put('/', function(req, res, next) {

  const bookToSave = req.body;

  const response = new UpdateResponse();
  try {
    const newBook = findBook(bookToSave.id);
    newBook.author = bookToSave.author;
    newBook.title = bookToSave.title;
    newBook.price = bookToSave.price;
    newBook.publisher = bookToSave.publisher;
    newBook.year = bookToSave.year;
    newBook.description = bookToSave.description;
    newBook.picture = bookToSave.picture;

    response.accepted = true;
    response.reason = 'valid data!';
  } catch (e) {
    response.accepted = false;
    response.reason = 'no valid data!';
  }

  res.send(response);
});

function findBook(id) {
  for (var i = 0; i < testData.length; i++) {
    if (testData[i].id === id) {
      return testData[i];
    }
  }
  return null;
}

module.exports = router;
