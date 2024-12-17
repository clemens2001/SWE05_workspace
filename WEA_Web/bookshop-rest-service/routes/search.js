var express = require('express');
var router = express.Router();
var testData = require('../model/test-data');

class SearchResponse{
	books;
	accepted;
	reason;
}

/* GET books listing. */
router.get('/:searchTerm', function(req, res, next) {

  const searchTerm = req.params.searchTerm;

  const response = new SearchResponse();
  try {
    response.books = searchBooks(searchTerm);
    response.accepted = true;
    response.reason = 'done';
  } catch (e) {
    console.error(e);
    response.books = [];
    response.accepted = false;
    response.reason = 'no data!';
  }

  res.send(response);
});

function searchBooks(searchTerm) {
  const books = [];
  for (var i = 0; i < testData.length; i++) {
    if (testData[i].title.toLowerCase().includes(searchTerm.toLowerCase())) {
      books.push(testData[i]);
    }
  }
  return books;
}

module.exports = router;
