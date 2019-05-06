const os = require('os')
const express = require('express')
let app = express();

let cpu = os.cpus()
let cpuName = os.cpus()[0].model.replace('(R)', '').replace('(TM)', '').replace(' CPU', '')
let arch = os.arch()
let freeMemGb = (os.freemem() / 1000000000).toFixed(2)
let hostname = os.hostname()

let machine = {
    hostname: os.hostname(),
    cpu: os.cpus().length + ' x ' + cpuName,
    platform: os.platform(),
    arch: os.arch(),
    totalMemory: (os.totalmem() / 1000000000).toFixed(2),
    freeMemory: (os.freemem() / 1000000000).toFixed(2),
}

app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
  });

app.get('/system/info/', function (req, res) {
    res.format({
        'application/json': function () {
            res.send(machine);
        },
    });
});

app.listen(3000, function () {
    console.log('[ServerDashboard] Server is listening on 3000');
});
