let trainings = [];
let connection = null;
let trainingIdToUpdate = -1;


getdata();

setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:43388/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TrainingCreated", (user, message) => {
        getdata();
    });

    connection.on("TrainingDeleted", (user, message) => {
        getdata();
    });

    connection.on("TrainingUpdated", (user, message) => {
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
    await fetch('http://localhost:43388/training')
        .then(x => x.json())
        .then(y => {
            trainings = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    trainings.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.trainingId + "</td><td>"
            + t.trainingType + "</td><td>" + t.time + "</td><td>" + t.playerId + "</td><td>"
            + `<button type="button" id="deleteButton" onclick="remove(${t.trainingId})">Delete`
            + `<button type="button" onclick="showupdate(${t.trainingId})">Update` + "</td></tr>"
        console.log(t.trainingType);
    });
}

function create() {
    let trainingtype = document.getElementById('trainingtype').value;
    let trainingdate = document.getElementById('trainingdate').value;
    let playerid = document.getElementById('playerid').value;
    fetch('http://localhost:43388/training', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                trainingType: trainingtype,
                time: trainingdate,
                playerId: playerid
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
    document.getElementById('trainingtypetoupdate').value = trainings.find(t => t['trainingId'] == id)['trainingType']
    document.getElementById('trainingdatetoupdate').value = trainings.find(t => t['trainingId'] == id)['time']
    document.getElementById('playeridtoupdate').value = trainings.find(t => t['trainingId'] == id)['playerId']
    document.getElementById('updateformdiv').style.display = 'flex';
    trainingIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let updatetype = document.getElementById('trainingtypetoupdate').value;
    let updatetime = document.getElementById('trainingdatetoupdate').value;
    let updateplayerid = document.getElementById('playeridtoupdate').value;
    fetch('http://localhost:43388/training/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                trainingType: updatetype,
                time: updatetime,
                playerId: updateplayerid,
                trainingId: trainingIdToUpdate

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
    fetch('http://localhost:43388/training/' + id, {
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