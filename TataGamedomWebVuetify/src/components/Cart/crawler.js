const request = require('request');
const cheerio = require('cheerio');
const async = require('async');

getCities((cities) => {
  async.map(cities, (city, callback) => {
    getStories(city, (stores) => {
      callback(null, stores);
    })
  }, (err, results) => {
    console.log([].concat.apply([], results));
  })
})

function getCities(callback) {
  request('http://www.ibon.com.tw/retail_inquiry.aspx#gsc.tab=0', (err, res, body) => {
    var $ = cheerio.load(body)
    var cities = $('#Class1 option').map((index, obj) => {
      return $(obj).text()
    }).get()
    callback(cities)
  })
}

function getStories(city, callback) {
  var options = {
    url: 'http://www.ibon.com.tw/retail_inquiry_ajax.aspx',
    method: 'POST',
    form: {
      strTargetField: 'COUNTY',
      strKeyWords: city,
    }
  }
  request(options, (err, res, body) => {
    var $ = cheerio.load(body)
    var stores = $('tr').map((index, obj) => {
      return {
        id: $(obj).find('td').eq(0).text().trim(),
        store: $(obj).find('td').eq(1).text().trim(),
        address: $(obj).find('td').eq(2).text().trim(),
      }
    }).get()
    stores.shift()
    callback(stores)
  })
}
