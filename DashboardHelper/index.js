const os = require('os')
const disk = require('diskusage')
const express = require('express')
let app = express()
//https://www.npmjs.com/package/cpu-stat

let cpuName = os.cpus()[0].model.replace('(R)', '').replace('(TM)', '').replace(' CPU', '')
let diskFree, diskTotal, platform

switch(os.platform()) {
    case "darwin":
        platform = "MacOS"
        break;
    case "win32":
        platform = "Windows"
        break;
    case "linux":
        platform = "Linux"
        break;
}

disk.check('/', function(err, info) {
    if (err) {
      console.log(err);
    } else {
        diskFree = info.free
        diskTotal = info.total
    }
  });

let machine = {
    hostname: os.hostname(),
    cpu: os.cpus().length + ' x ' + cpuName,
    platform: platform,
    arch: os.arch(),
    totalMemory: (os.totalmem() / 1000000000).toFixed(2),
    freeMemory: (os.freemem() / 1000000000).toFixed(2),
    diskFree: (diskFree / 1000000000).toFixed(2),
    diskTotal: (diskTotal / 1000000000).toFixed(2)
}

app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*")
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept")
    next();
  });

app.get('/system/info/', function (req, res) {
    res.format({
        'application/json': function () {
            res.send(machine)
        },
    });
});

app.listen(3000, function () {
    console.log('[ServerDashboard] Server is listening on 3000')
});