let players = [];
let connection = null;
let playerIdToUpdate = -1;


getdata();

setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:43388/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PlayerCreated", (user, message) => {
        getdata();
    });

    connection.on("PlayerDeleted", (user, message) => {
        getdata();
    });

    connection.on("PlayerUpdated", (user, message) => {
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
    await fetch('http://localhost:43388/player')
        .then(x => x.json())
        .then(y => {
            players = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    players.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.playerId + "</td><td>"
            + t.playerName + "</td><td>" + t.height + "</td><td>" + t.jerseyNumber + "</td><td>"
            + `<button type="button" id="deleteButton" onclick="remove(${t.playerId})">Delete`
            + `<button type="button" onclick="showupdate(${t.playerId})">Update` + "</td></tr>"
        console.log(t.playerName);
    });
}

function create() {
    let name = document.getElementById('playername').value;
    let height = document.getElementById('playerheight').value;
    let jersey = document.getElementById('jerseynum').value;
    fetch('http://localhost:43388/player', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                playerName: name,
                height: height,
                jerseyNumber: jersey
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
    document.getElementById('playernametoupdate').value = players.find(t => t['playerId'] == id)['playerName']
    document.getElementById('playerheighttoupdate').value = players.find(t => t['playerId'] == id)['height']
    document.getElementById('jerseynumtoupdate').value = players.find(t => t['playerId'] == id)['jerseyNumber']
    document.getElementById('updateformdiv').style.display = 'flex';
    playerIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let updatename = document.getElementById('playernametoupdate').value;
    let updateheight = document.getElementById('playerheighttoupdate').value;
    let updatejersey = document.getElementById('jerseynumtoupdate').value;
    fetch('http://localhost:43388/player/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                playerName: updatename,
                height: updateheight,
                jerseyNumber: updatejersey,
                playerId: playerIdToUpdate

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
    fetch('http://localhost:43388/player/' + id, {
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