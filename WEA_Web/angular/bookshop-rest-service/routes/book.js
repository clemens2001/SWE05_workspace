var express = require('express');
var router = express.Router();
var testData = require('../model/test-data');

class BookResponse {
  book;
  accepted;
  reason;
}

/* GET books listing. */
router.get('/:id', function(req, res, next) {

  const id = req.params.id;

  const response = new BookResponse();
  response.book = findBook(id);
  if (response.book != null) {
    response.accepted = true;
    response.reason = 'done';
  } else {
    response.accepted = false;
    response.reason = 'Id not valid!';
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
