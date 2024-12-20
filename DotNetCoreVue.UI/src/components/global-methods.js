export default {
    async parse(rb) {
        const reader = rb.getReader();
        var stream = await new ReadableStream({
            start(controller) {
                // The following function handles each data chunk
                function push() {
                    // "done" is a Boolean and value a "Uint8Array"
                    reader.read().then(({ done, value }) => {
                        // If there is no more data to read
                        if (done) {
                            console.log("done", done);
                            controller.close();
                            return;
                        }
                        // Get the data and send it to the browser via the controller
                        controller.enqueue(value);
                        // Check chunks by logging to the console
                        console.log(done, value);
                        push();
                    });
                }

                push();
            },
        })
        var response = await new Response(stream, { headers: { "Content-Type": "text/html" } }).text();
        console.log("response: ", JSON.parse(response))
        return JSON.parse(response)
    }
}