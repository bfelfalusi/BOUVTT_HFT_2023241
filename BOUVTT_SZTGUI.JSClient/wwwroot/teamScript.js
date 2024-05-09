let teams = [];
let connection = null;
let teamIdToUpdate = -1;


getdata();

setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:43388/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeamCreated", (user, message) => {
        getdata();
    });

    connection.on("TeamDeleted", (user, message) => {
        getdata();
    });

    connection.on("TeamUpdated", (user, message) => {
        getdata();
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
}

async function getdata() {
    await fetch('http://localhost:43388/team')
        .then(x => x.json())
        .then(y => {
            teams = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    teams.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.teamId + "</td><td>"
            + t.teamName + "</td><td>"
            + `<button type="button" id="deleteButton" onclick="remove(${t.teamId})">Delete`
            + `<button type="button" onclick="showupdate(${t.teamId})">Update` + "</td></tr>"
        console.log(t.teamName);
    });
}

function create() {
    let teamname = document.getElementById('teamname').value;
    fetch('http://localhost:43388/team', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                teamName: teamname,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showupdate(id) {
    document.getElementById('teamnametoupdate').value = teams.find(t => t['teamId'] == id)['teamName']
    document.getElementById('updateformdiv').style.display = 'flex';
    teamIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let updatename = document.getElementById('teamnametoupdate').value;
    fetch('http://localhost:43388/team/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                teamName: updatename,
                teamId: teamIdToUpdate

            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:43388/team/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function goBackToMain() {
    window.location = "index.html";
}