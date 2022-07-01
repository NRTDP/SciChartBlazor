const path = require("path");
module.exports = {
    mode: "development",
    entry: {
        sciChartBlazorJson: "./src/Builder.js"
    },
    module: {
        rules: []
    },
    resolve: {
        extensions: [".js"],
        fallback: {
            "util": false,
            "buffer": false,
            "url": false,
            "vm": false,
            "querystring": false,
            "assert": false,
            "constants": false,
            "os": false,
            "fs": false,
            "tls": false,
            "net": false,
            "path": false,
            "zlib": false,
            "http": false,
            "https": false,
            "stream": false,
            "crypto": false
        }
    },
    output: {
        path: path.resolve(__dirname),
        filename: "[name].js",
        library: "[name]"
    }
};