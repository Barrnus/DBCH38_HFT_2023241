let tasks = [];
let connection = null;
let task;
getData();
initSignalR();
async function getData() {
    await fetch('http://localhost:1542/task')
        .then(x => x.json())
        .then(y => {
            tasks = y;
            console.log(y)
            display();
        });
}
function initSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:1542/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TaskCreated", (user, message) => {
        console.log(user);
        console.log(message);
        getData();
    });
    connection.on("TaskDeleted", (user, message) => {
        console.log(user);
        console.log(message);
        getData();
    });
    connection.on("TaskUpdated", (user, message) => {
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
    tasks.forEach(x => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + x.type + "</td>" +
            "<td>"+x.description+"</td>"+
            "<td>" + '<button type="button" onclick="remove(' + x.id + ')">Delete</button>' +
            '<button type="button" onclick="showUpdate(' + x.id + ')">Update</button>' + "</td>" +
            "</tr>";
    });
}

function showUpdate(id) {
    task = tasks.find(x=>x['id']==id)
    document.getElementById('updateType').value = task['type'];
    document.getElementById('updateDesc').value = task['description'];
    document.getElementById('updatediv').style.display = 'flex';
}

function create() {
    let type = document.getElementById('taskType').value;
    let desc = document.getElementById('taskDesc').value;
    fetch('http://localhost:1542/task', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Type: type,
                Description:desc
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
    let type = document.getElementById('updateType').value;
    let desc = document.getElementById('updateDesc').value;
    fetch('http://localhost:1542/task', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Id: task['id'],
                Type: type,
                Description:desc
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
    fetch('http://localhost:1542/task/' + id, {
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

function getTaskWithManyWorkers() {
    fetch('http://localhost:1542/priority/gettaskwithmanyworkers')
        .then(x => x.json())
        .then(y => {
            console.log(y);
            document.getElementById('noncrudDiv').innerHTML = '<table id="noncrudResult"></table>';
            y.forEach(x => {
                document.getElementById('noncrudResult').innerHTML +=
                    "<table>" +
                    "<tr><td>" + x.description + "</td>" +
                    "</tr>" + "</table>"
            });
        })
}
function getTaskWithManyWorkersUrgent() {
    fetch('http://localhost:1542/priority/gettaskwithmanyworkersurgent')
        .then(x => x.json())
        .then(y => {
            console.log(y);
            document.getElementById('noncrudDiv').innerHTML = '<table id="noncrudResult"></table>';
            y.forEach(x => {
                document.getElementById('noncrudResult').innerHTML +=
                    "<table>" +
                    "<tr><td>" + x.description + "</td>" +
                    "</tr>" + "</table>"
            });
        })
}