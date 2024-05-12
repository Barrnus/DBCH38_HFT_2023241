let prios = [];
let connection = null;
let prio;
getData();
initSignalR();
async function getData() {
    await fetch('http://localhost:1542/priority')
        .then(x => x.json())
        .then(y => {
            prios = y;
            console.log(y)
            display();
        });
}
function initSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:1542/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PriorityCreated", (user, message) => {
        console.log(user);
        console.log(message);
        getData();
    });
    connection.on("PriorityDeleted", (user, message) => {
        console.log(user);
        console.log(message);
        getData();
    });
    connection.on("PriorityUpdated", (user, message) => {
        console.log(user);
        console.log(message);
        getData();

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
    prios.forEach(x => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + x.value + "</td>" +
            "<td>" + '<button type="button" onclick="remove(' + x.id + ')">Delete</button>' +
            '<button type="button" onclick="showUpdate(' + x.id + ')">Update</button>' + "</td>" +
            "</tr>";
    });
}

function showUpdate(id) {
    prio = prios.find(x => x['id'] == id);
    document.getElementById('updateValue').value = prio['value'];
    document.getElementById('updatediv').style.display = 'flex';
}

function create() {
    let value = document.getElementById('priorityValue').value;
    fetch('http://localhost:1542/priority', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Value:value
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
    let value = document.getElementById('updateValue').value;
    fetch('http://localhost:1542/priority', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Id: prio['id'],
                Value:value
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
    fetch('http://localhost:1542/priority/' + id, {
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

function getPriorityWithMostTasks() {
    fetch('http://localhost:1542/priority/getprioritywithmosttasks')
        .then(x => x.json())
        .then(y => {
            document.getElementById('noncrudDiv').innerHTML = '<table id="noncrudResult"></table>';
            y.forEach(x => {
                document.getElementById('noncrudResult').innerHTML +=
                    "<table>" +
                    "<tr><td>" + x.value + "</td>" +
                    "</tr>" + "</table>"
            });
        })
}