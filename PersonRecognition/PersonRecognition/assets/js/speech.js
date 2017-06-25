window.APP = (function (module, $) {
    "use strict";

    var m = module;

    m.speechModule = {};

    var speechVoice;

    var initialVoiceName = "Google UK English Female";

    function initVoice() {
        window.speechSynthesis.onvoiceschanged = function () {
            console.log(speechSynthesis.getVoices());
            m.speechModule.setVoice(initialVoiceName);
        };
    }

    m.speechModule.speak = function (text, callback) {
        var u = new SpeechSynthesisUtterance();
        u.text = text;
        u.lang = 'en-US';
        u.voice = speechVoice;

        u.onend = function () {
            if (callback) {
                callback();
            }
        };

        u.onerror = function (e) {
            if (callback) {
                callback(e);
            }
        };

        speechSynthesis.speak(u);
    };

    m.speechModule.setVoice = function (voiceName) {
        var voices = speechSynthesis.getVoices();
        speechVoice = voices.filter(function (voice) {
            return voice.name === voiceName;
        })[0];

        console.log("updated speech voice: ", speechVoice);
    };

    m.speechModule.init = function () {
        initVoice();
    };

    return module;

})(window.APP || {}, window.jQuery);