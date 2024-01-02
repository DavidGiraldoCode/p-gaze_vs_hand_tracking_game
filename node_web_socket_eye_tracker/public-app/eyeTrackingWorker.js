const URL = `http://${window.location.hostname}:5050`;
let socket = io(URL, { path: '/real-time' });
console.log('Server IP: ', URL);

webgazer.setGazeListener(getEyePositions).begin();

// Get the canvas element used by webgazer.js
const webgazerCanvas = document.getElementById('webgazerCanvasId'); // Replace 'webgazerCanvasId' with your canvas ID

// Check if the canvas element exists and supports the willReadFrequently attribute
if (webgazerCanvas && webgazerCanvas.getContext) {
  const ctx = webgazerCanvas.getContext('2d');

  // Set the willReadFrequently attribute if supported
  if ('imageSmoothingQuality' in ctx) {
    ctx.imageSmoothingQuality = 'high';
  }

  // Check if willReadFrequently is supported before setting it
  if ('willReadFrequently' in webgazerCanvas) {
    webgazerCanvas.willReadFrequently = true;
  } else {
    console.warn('willReadFrequently attribute is not supported on this browser.');
  }
} else {
  console.warn('Webgazer canvas element not found or getContext not supported.');
}


function getEyePositions(data, elapsedTime) {
    if (data == null) {
        return;
    }
    /*let x = Math.floor(data.x);
    let y = Math.floor(data.y);*/
    //let x = parseFloat(data.x.toFixed(2));
    //let y = parseFloat(data.y.toFixed(2));
    let x = data.x;
    let y = data.y;

    //console.log(elapsedTime);
    //console.log({ x, y });

    socket.emit('eyes-coordinates', { x, y });
};