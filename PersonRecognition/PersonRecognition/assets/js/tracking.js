window.APP = (function (module, $) {
    "use strict";

    var m = module;

    m.trackingModule = {};

    var video,
        videoCanvas,
        videoContext,
        imageCanvas,
        imageContext,
        tracker,
        processTracker = true,
        overrideAndDisableServerCall = false,
        videoId = 'video',
        showDataUrlLog = false;

    function setupVars() {
        video = document.getElementById(videoId);
        videoCanvas = document.getElementById('canvas');
        videoContext = videoCanvas.getContext('2d');
        imageCanvas = document.getElementById('capturedFaceCanvas');
        imageContext = imageCanvas.getContext('2d');
        tracker = new tracking.ObjectTracker('face');
    }

    function drawTrackingRectangle(event) {
        videoContext.clearRect(0, 0, videoCanvas.width, videoCanvas.height);

        event.data.forEach(function (rect) {
            videoContext.strokeStyle = '#a64ceb';
            videoContext.strokeRect(rect.x, rect.y, rect.width, rect.height);
            videoContext.font = '11px Helvetica';
            videoContext.fillStyle = "#fff";
            videoContext.fillText('x: ' + rect.x + 'px', rect.x + rect.width + 5, rect.y + 11);
            videoContext.fillText('y: ' + rect.y + 'px', rect.x + rect.width + 5, rect.y + 22);
        });
    }

    function sendImageToServer(imageString) {
        if (overrideAndDisableServerCall) {
            return true;
        }

        $.post("umbraco/api/recognition/findperson", { "image": imageString })
            .done(function (data) {
                //alert("Data Loaded: " + data);
                console.info(data);

                if (data.GreetingText) {
                    m.speechModule.speak(data.GreetingText);
                }
            });
    }

    function setupTracker() {
        tracker.setInitialScale(4);
        tracker.setStepSize(2);
        tracker.setEdgesDensity(0.1);

        processTracker = true;

        tracking.track('#' + videoId, tracker, { camera: true });

        tracker.on('track', function (event) {
            if (event.data.length === 0) {
                // No targets were detected in this frame.
            } else {
                event.data.forEach(function (data) {
                    // Plots the detected targets here.
                    if (processTracker) {
                        processTracker = false;
                        imageContext.clearRect(0, 0, imageCanvas.width, imageCanvas.height);
                        imageContext.drawImage(video, data.x + (data.width / 2), data.y - (data.height / 4), data.width * 2, data.height * 2, 0, 0, imageCanvas.width, imageCanvas.height);

                        if (showDataUrlLog) {
                            console.log(imageCanvas.toDataURL());
                        }

                        //send image to api
                        sendImageToServer(imageCanvas.toDataURL());
                    }

                    // imageContext.drawImage(video, data.x, data.y, data.width, data.height);
                });

                drawTrackingRectangle(event);
            }
        });

        setInterval(function () {
            processTracker = !processTracker;
        }, 5000);
    }

    m.trackingModule.toggleDataLog = function () {
        showDataUrlLog = !showDataUrlLog;
    };

    m.trackingModule.toggleServerCall = function (enable) {
        overrideAndDisableServerCall = enable;
    };

    m.trackingModule.init = function () {
        setupVars();
        setupTracker();
    };

    return module;

})(window.APP || {}, window.jQuery);