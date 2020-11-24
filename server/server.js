const express = require('express');
const app = express();
const port = process.env.PORT || 3000;
const bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({ extended: true }));
const mysql      = require('mysql');
const connection = mysql.createConnection({
  host     : 'localhost',    // 호스트 주소
  user     : 'root',           // mysql user
  password : 'dkssudgktpdydkssudgktpdy',       // mysql password
  database : 'top_shooting'         // mysql 데이터베이스
});
connection.connect();

app.get('/', (req, res) => {
    res.json({
        success: true,
    });
});

app.get('/hello', (req, res) => {
    res.json({
        msg: "hello world",
    });
});

app.get('/ranking', (req, res) => {
    const rankings = [];
   connection.query(`SELECT * FROM userscores;`, (error, results, fields) =>{
   if(error){
       console.log(error);
   }
   console.log(results);
   
   results.sort((a, b) => b - a);
   res.json(results);
    }); 
});

app.post('/registerScore', (req, res, next) => {
    var name = req.body.name;
    var score = req.body.score;

    connection.query(`INSERT INTO top_shooting.userscores VALUE ('${name}', ${score}) ON DUPLICATE KEY UPDATE score = ${score};`, (error, results, fields) => {
        if(error) {
            console.log(error);
        }
        console.log(results);
    });
    res.json({ success: true });
});

app.listen(port, () => {
    console.log(`server is listening at localhost:${port}`);
});