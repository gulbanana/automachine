let handle = 0;

export function start(component) {
    function callback(timestamp) {
        if (handle == 0) {
            return;
        }

        component.invokeMethod("OnFrame", timestamp);
        handle = requestAnimationFrame(callback);
    }

    handle = requestAnimationFrame(callback);
}

export function stop() {
    cancelAnimationFrame(handle);
    handle = 0;
}