/*const NGROK = `${window.location.hostname}`;
console.log('Server IP: ', NGROK);
let socket = io(NGROK, { path: '/real-time' });*/


const URL = `http://${window.location.hostname}:5050`;
let socket = io(URL, { path: '/real-time' });
console.log('Server IP: ', URL);

webgazer.setGazeListener(getEyePositions).begin();

function getEyePositions(data, elapsedTime) {
    if (data == null) {
        return;
    }
    let Xeye = Math.floor(data.x);
    let Yeye = Math.floor(data.y);
    //console.log(elapsedTime);
    console.log({ Xeye, Yeye });

    socket.emit('eyes-coordinates', { Xeye, Yeye });
};

/*

let controllerX, controllerY = 0;
let interactions = 0;
let isTouched = false;

function setup() {
    frameRate(60);
    canvas = createCanvas(windowWidth, windowHeight);
    canvas.style('z-index', '-1');
    canvas.style('position', 'fixed');
    canvas.style('top', '0');
    canvas.style('right', '0');
    controllerX = windowWidth / 2;
    controllerY = windowHeight / 2;
    background(0);
    angleMode(DEGREES);

    const userAgent = window.navigator.userAgent;
    let deviceType;

    if (/iPhone|iPad|iPod/.test(userAgent)) {
        deviceType = 'iOS';
    } else if (/Android/.test(userAgent)) {
        deviceType = 'Android';
    } else {
        deviceType = 'Other';
    }
    socket.emit('device-size', { deviceType, windowWidth, windowHeight });

    let btn = createButton("Permitir movimiento");
    btn.mousePressed(function () {
        DeviceOrientationEvent.requestPermission();
    });

}

function draw() {
    background(0, 5);
    newCursor(pmouseX, pmouseY);
    fill(255);
    ellipse(controllerX, controllerY, 50, 50);
}

function touchMoved() {
    switch (interactions) {
        case 0:
            socket.emit('mobile-instructions', { interactions, pmouseX, pmouseY });
            background(255, 0, 0);
            break;
    }
}

function touchStarted() {
    isTouched = true;
}

function touchEnded() {
    isTouched = false;
}

function deviceMoved() {
    switch (interactions) {
        case 1:
            socket.emit('mobile-instructions', { interactions, pAccelerationX, pAccelerationY, pAccelerationZ });
            background(0, 255, 255);
            break;
        case 2:
            socket.emit('mobile-instructions', { interactions, rotationX, rotationY, rotationZ });
            background(0, 255, 0);
            break;
    }

}

function deviceShaken() {
    //socket.emit('mobile-instructions', 'Moved!');
    //background(0, 255, 255);
}

function windowResized() {
    resizeCanvas(windowWidth, windowHeight);
}

function newCursor(x, y) {
    noStroke();
    fill(255);
    ellipse(x, y, 10, 10);
}
*/