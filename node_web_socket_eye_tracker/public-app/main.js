let worker = new Worker('eyeTrackingWorker.js'); // Create a new Web Worker
window.saveDataAcrossSessions = true;
worker.postMessage('startEyeTracking'); // Send a message to start eye tracking

worker.onmessage = (event) => {
    // Handle messages received from the Web Worker
    console.log('Message from Web Worker:', event.data);
};

worker.onerror = (error) => {
    // Handle errors from the Web Worker
    console.error('Error from Web Worker:', error);
};
