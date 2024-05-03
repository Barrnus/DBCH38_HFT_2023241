let workers = [];
let connection = null;
let worker;
getData();
initSignalR();
async function getData() {
    await fetch('http://localhost:1542/worker')
        .then(x => x.json())
        .then(y => {
            workers = y;
            console.log(y)
            display();
        });
}
function initSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:1542/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("WorkerCreated", (user, message) => {
        console.log(user);
        console.log(message);
        getData();
    });
    connection.on("WorkerDeleted", (user, message) => {
        console.log(user);
        console.log(message);
        getData();
    });
    connection.on("WorkerUpdated", (user, message) => {
        console.log(user);
        console.log(message);
    });
    connection.onclose(async () => {
        await start();
    });
    start();
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
function display() {
    document.getElementById('resultarea').innerHTML = "";
    workers.forEach(x => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + x.name + "</td>" +
            "<td>" + x.position + "</td>" +
            "<td>" + x.age + "</td>" +
            "<td>" + x.taskId + "</td>" +
            "<td>" + '<button type="button" onclick="remove(' + x.id + ')">Delete</button>' +
            '<button type="button" onclick="showUpdate(' + x.id + ')">Update</button>' + "</td>" +
            "</tr>";
        console.log(x.name)
    });
}

function showUpdate(id) {
    worker = workers.find(x => x['id'] == id);
    document.getElementById('updateName').value = worker['name'];
    document.getElementById('updateAge').value = worker['age'];
    document.getElementById('updatePosition').value = worker['position'];
    document.getElementById('updatediv').style.display = 'flex';
}

function create() {
    let name = document.getElementById('workerName').value;
    let age = document.getElementById('workerAge').value;
    let position = document.getElementById('workerPosition').value;
    fetch('http://localhost:1542/worker', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Name: name,
                Age: age,
                Position:position
            }),
    })
        .then(data => {
            console.log('Success:', data);
            getData();
            display();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function update() {
    document.getElementById('updatediv').style.display = 'none';
    let name = document.getElementById('updateName').value;
    let age = document.getElementById('updateAge').value;
    let position = document.getElementById('updatePosition').value;
    fetch('http://localhost:1542/worker', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Id:worker['id'],
                Name: name,
                Age: age,
                Position: position
            }),
    })
        .then(data => {
            console.log('Success:', data);
            getData();
            display();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:1542/worker/'+id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null,
    })
        .then(data => {
            console.log('Success:', data);
            getData();
            display();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function getWorkersWithUrgentTask() {
    fetch('http://localhost:1542/worker/getworkerswithurgenttask')
        .then(x => x.json())
        .then(y => {
            console.log(y);
            document.getElementById('noncrudDiv').innerHTML = '<table id="noncrudResult"></table>';
            y.forEach(x => {
                document.getElementById('noncrudResult').innerHTML +=
                    "<table>" +
                    "<tr><td>" + x + "</td>" +
                    "</tr>" + "</table>"
            });
        })
}
function getWorkersWithnoTask() {
    fetch('http://localhost:1542/worker/getworkerswithnotask')
        .then(x => x.json())
        .then(y => {
            console.log(y);
            document.getElementById('noncrudDiv').innerHTML = '<table id="noncrudResult"></table>';
            y.forEach(x => {
                document.getElementById('noncrudResult').innerHTML +=
                    "<table>" +
                    "<tr><td>" + x + "</td>" +
                    "</tr>" + "</table>"
            });
        })
}