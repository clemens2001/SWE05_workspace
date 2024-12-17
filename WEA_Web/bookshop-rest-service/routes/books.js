var express = require('express');
var router = express.Router();
var testData = require('../model/test-data');

class BooksResponse {
  books;
  accepted;
  reason;
}

/* GET books listing. */
router.get('/', function(req, res, next) {

  const response = new BooksResponse();
  response.books = testData;
  response.accepted = true;
  response.reason = 'done';

  res.send(response);
});

module.exports = router;
