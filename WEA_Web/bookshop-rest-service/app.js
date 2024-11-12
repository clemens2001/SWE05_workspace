var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');

var indexRouter = require('./routes/index');
var booksRouter = require('./routes/books');
var bookRouter = require('./routes/book');
var saveRouter = require('./routes/save');
var updateRouter = require('./routes/update');
var searchRouter = require('./routes/search');
var cors = require('cors');

var corsOptions = {
  origin: '*',
  methods: ['GET', 'PUT', 'POST', 'DELETE'],
  optionsSuccessStatus: 200
}

var app = express();

app.use(cors(corsOptions));

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'pug');

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/bookshop-rest-service', indexRouter);
app.use('/bookshop-rest-service/api/book', bookRouter);
app.use('/bookshop-rest-service/api/books', booksRouter);
app.use('/bookshop-rest-service/api/save', saveRouter);
app.use('/bookshop-rest-service/api/update', updateRouter);
app.use('/bookshop-rest-service/api/search', searchRouter);

// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

module.exports = app;
