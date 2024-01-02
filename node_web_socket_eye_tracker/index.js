import { express, Server, cors, os } from './dependencies.js';
// No cambiar
// '192.168.80.31'; // Cambiar por la IP del computador
//const IPaddress = os.networkInterfaces().en0[1].address;
//const SERVER_IP = IPaddress;
const SERVER_IP = "localhost";
const PORT = 5050;
const app = express();
app.use(cors({ origin: "*" }));
app.use(express.json());
app.use('/unity-interface', express.static('public-app'));

const httpServer = app.listen(PORT, () => {
    console.log(`Server is running, host http://${SERVER_IP}:${PORT}/`);
    console.table({
        'Unity Interface Endpoint': `http://${SERVER_IP}:${PORT}/unity-interface`,
    });
});
// Run on terminal: ngrok http 5050;

const io = new Server(httpServer, { path: '/real-time' });
let JSON_package = null;
//=========

import http from 'http';
import WebSocket from 'ws';
import { WebSocketServer } from 'ws';

const server = http.createServer(app);
const wss = new WebSocketServer({ server });
let isConnected = false;

io.on('connection', socket => {
    console.log(`WebBrowser connected - ${socket.id}`);
    wss.on('connection', unityWebSocketACB);

    socket.on('eyes-coordinates', eyesData => {
        //console.log(`eyesData: x ${eyesData.x} - y: ${eyesData.y}`);
        let xPos = parseFloat(eyesData.x.toFixed(2));
        let yPos = parseFloat(eyesData.y.toFixed(2));
        JSON_package = JSON.stringify({ x: xPos, y: yPos });


        wss.clients.forEach(client => {
            if (client.readyState === WebSocket.OPEN) {
                client.send(JSON_package);
            }
        });

    });

    socket.on('disconnect', disco => {
        console.log(`WebBrowser disconnected - ${socket.id}`);
        JSON_package = null;
    });
});


function unityWebSocketACB(ws) {
    console.log('A new client connected');
    isConnected = true;

    /*while (!JSON_package) {
        ws.send(JSON_package);
        console.log(`JSON_package - ${JSON_package}`);
    }*/

    ws.on('', (message) => {
        console.log('Received:', message);
        ws.send(`Echo: ${message}`);
    });

    ws.on('close', () => {
        console.log('Client disconnected');
    });
}


function mapEyes(value, browserMin, browserMax, min, max) {
    //let x = parseFloat(data.x.toFixed(2));
    //let y = parseFloat(data.y.toFixed(2));
    const mappedValue = min + (((value - browserMin) * (max - min)) / browserMax - browserMin)
    return parseFloat(mappedValue.toFixed(2));
}

const PORT_WS = process.env.PORT_WS || 8080;
server.listen(PORT_WS, () => {
    console.log(`Server started on port ${PORT_WS}`);
});


//const js = JSON.stringify({ x: mapEyes(eyesData.x, 0, 1000, -6, 6), y: mapEyes(eyesData.y, 0, 800, -4, 4) });
//console.log(js);
//socket.broadcast.emit('mupi-size', deviceSize);