window.APP = (function (module, $) {
    "use strict";

    var m = module;

    $(function () {
        m.trackingModule && m.trackingModule.init();
        m.speechModule && m.speechModule.init();
    });

    return module;
})(window.APP || {}, window.jQuery);