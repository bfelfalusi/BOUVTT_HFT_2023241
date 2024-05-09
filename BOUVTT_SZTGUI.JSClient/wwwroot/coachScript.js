let coaches = [];
let connection = null;
let coachIdToUpdate = -1;


getdata();

setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:43388/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CoachCreated", (user, message) => {
        getdata();
    });

    connection.on("CoachDeleted", (user, message) => {
        getdata();
    });

    connection.on("CoachUpdated", (user, message) => {
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
    await fetch('http://localhost:43388/coach')
        .then(x => x.json())
        .then(y => {
            coaches = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    coaches.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.coachId+ "</td><td>"
            + t.position + "</td><td>"
            + `<button type="button" id="deleteButton" onclick="remove(${t.coachId})">Delete`
            + `<button type="button" onclick="showupdate(${t.coachId})">Update` + "</td></tr>"
        console.log(t.position);
    });
}

function create() {
    let position = document.getElementById('coachposition').value;
    fetch('http://localhost:43388/coach', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                position: position,
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
    document.getElementById('coachpositiontoupdate').value = coaches.find(t => t['coachId'] == id)['position']
    document.getElementById('updateformdiv').style.display = 'flex';
    coachIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let updatepos = document.getElementById('coachpositiontoupdate').value;
    fetch('http://localhost:43388/coach/', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                position: updatepos,
                coachId: coachIdToUpdate

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
    fetch('http://localhost:43388/coach/' + id, {
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